using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace TalkingClipboard
{
    /// <summary>
    /// Source code for the TalkingClipboard article.
    /// Author: Ravi Bhavnani, ravib@ravib.com
    /// License: CodeProject Open License
    /// </summary>
    public partial class MainFrm : Form
    {
        #region Win32 integration

        const int WM_DRAWCLIPBOARD = 0x0308;

        const int WM_CHANGECBCHAIN = 0x030D;

        [DllImport("user32.dll")]
        static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("user32.dll")]
        static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainFrm()
        {
           
            InitializeComponent();
            this.Disposed += MainFrm_Disposed;
            // Load list of available voices
            _voices = _synth.GetInstalledVoices();

            foreach (InstalledVoice voice in _voices)
                _comboVoices.Items.Add(voice.VoiceInfo.Name);

            var voiceSelect = _voices.FirstOrDefault(p => p.VoiceInfo.Name == Properties.Settings.Default.Voice);

            if (voiceSelect != null)
            {
                _comboVoices.SelectedItem = voiceSelect.VoiceInfo.Name;
            }
            else if (_comboVoices.Items.Count > 0)
                _comboVoices.SelectedIndex = 0;

            // Keep window topmost
            this.TopMost = true;

            
        }

        void MainFrm_Disposed(object sender, EventArgs e)
        {
            this.Stop();
            Properties.Settings.Default.Save();
        }

        #endregion

        #region Overrides
        [Flags]
        enum StateEnum
        {
            None=0,
            Dot=1,
            Is0D=2,
            Is0A=4,
            CR=6,
            Enter=7,
        }
        /// <summary>
        /// Main window procedure.
        /// </summary>
        protected override void WndProc
          (ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    // The contents of the clipboard have changed, so load the
                    // text box and speak its contents.
                    Trace.WriteLine("WM_DRAWCLIPBOARD handled");
                    if (_loaded && !_checkDontWatchClipboard.Checked)
                    {
                        IDataObject dataObj = Clipboard.GetDataObject();
                        if (dataObj.GetDataPresent(DataFormats.Text))
                        {
                            string clipboardText = dataObj.GetData(DataFormats.Text) as string;
                           // _editText.Text = clipboardText;
                            SpeakText(clipboardText);
                        }
                    }
                    break;

                case WM_CHANGECBCHAIN:
                    // The chain of clipboard listeners has changed.
                    Trace.WriteLine("WM_CHANGECBCHAIN handled");
                    if (m.WParam == _chainedWnd)
                        _chainedWnd = m.LParam;
                    else
                        SendMessage(_chainedWnd, m.Msg, m.WParam, m.LParam);
                    break;
            }
        }

        private void SpeakText(string clipboardText)
        {
            bool isChinese = false;

            foreach (char c in clipboardText)
            {
                if (c >= 0x4e00)
                {
                    isChinese = true;
                    break;
                }

            }

            VoiceSelect(isChinese);

            if (_synth.Voice.Culture.ToString() == "en-US")
            {
                string text = Regex.Replace(clipboardText, @"\b\r\n", " ");
                richText.Text = Regex.Replace(text, "\r\n", "\r\n    ");
            }
            else
                richText.Text = clipboardText;



            if (_synth.State == SynthesizerState.Speaking)
                _synth.SpeakAsyncCancelAll();
            _btnSpeak.PerformClick();

            _checkDontWatchClipboard.Checked = true;
        }

        private void VoiceSelect(bool isChinese)
        {
            string culture = isChinese ? "zh-CN" : "en-US";
            var voiceSelect = _voices.Where(p => p.VoiceInfo.Culture.ToString() == culture).LastOrDefault();//.FirstOrDefault(p => p.VoiceInfo.Name == Properties.Settings.Default.Voice);

            if (voiceSelect != null)
            {
                _comboVoices.Invoke(new Action(()=>
                    {
                        _comboVoices.SelectedItem = voiceSelect.VoiceInfo.Name;
                        SetVoice(voiceSelect.VoiceInfo.Name);
                    }));

            }
        }

        #endregion

        #region Form events

        /// <summary>
        /// The form has loaded.
        /// </summary>
        private void MainFrm_Load
          (object sender,
           EventArgs e)
        {
            // Start listening for clipboard changes
            _chainedWnd = SetClipboardViewer(this.Handle);
            _loaded = true;
        }

        /// <summary>
        /// The form is closing.
        /// </summary>
        private void MainFrm_FormClosing
          (object sender,
           FormClosingEventArgs e)
        {
            // Stop listening to clipboard changes
            ChangeClipboardChain(this.Handle, _chainedWnd);
            _chainedWnd = IntPtr.Zero;
        }

        #endregion

        #region Control events

        /// <summary>
        /// A new voice has been selected.
        /// </summary>
        private void _comboVoices_SelectionChangeCommitted
          (object sender,
           EventArgs e)
        {
            string voiceName = _comboVoices.SelectedItem as string;
            SetVoice(voiceName);
        }

        private void SetVoice(string voiceName)
        {
            _synth.SelectVoice(voiceName);

            Properties.Settings.Default.Voice = voiceName;
        }

        /// <summary>
        /// A new voice speed has been selected.
        /// </summary>
        private void _knobRate_ValueChanged
          (object sender,
           EventArgs e)
        {
            int rate = 2 * (_knobRate.Value - 5);
            _synth.Rate = rate;
            _lblSpeed.Text = string.Format("Speed ({0}):", rate.ToString());
        }

        /// <summary>
        /// Start speaking.
        /// </summary>
        private void _btnSpeak_Click
          (object sender,
           EventArgs e)
        {
            _btnStop.PerformClick();
           
            _synth.BookmarkReached += _synth_BookmarkReached;
            _synth.PhonemeReached += _synth_PhonemeReached;
            _synth.SpeakProgress += _synth_SpeakProgress;
            _synth.SpeakStarted += _synth_SpeakStarted;
            _synth.VisemeReached += _synth_VisemeReached;
            _synth.SpeakCompleted += _synth_SpeakCompleted;
            _synth.SpeakAsync(richText.Text);// _editText.Text);
          
        }

        void _synth_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            _checkDontWatchClipboard.Checked = false;
           
        }

        void _synth_VisemeReached(object sender, VisemeReachedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ToString());
        }

        void _synth_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ToString());
        }

        void _synth_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            richText.Select(e.CharacterPosition,e.CharacterCount);
            this.richText.ScrollToCaret();
            richText.Focus();
            System.Diagnostics.Debug.WriteLine(e.ToString());
        }

        void _synth_PhonemeReached(object sender, PhonemeReachedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ToString());
        }

        void _synth_BookmarkReached(object sender, BookmarkReachedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ToString());
        }

        /// <summary>
        /// Start speaking.
        /// </summary>
        private void _btnStop_Click
          (object sender,
           EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            if (_synth.State == SynthesizerState.Paused)
                _synth.Resume();
            _synth.SpeakAsyncCancelAll();
            _btnPauseRestart.Text = "暂停";
        }

        /// <summary>
        /// Pause/Restart speech.
        /// </summary>
        private void _btnPauseRestart_Click
          (object sender,
           EventArgs e)
        {
            if (_synth.State == SynthesizerState.Speaking)
            {
                _synth.Pause();
                _btnPauseRestart.Text = "恢复";
            }
            else
            {
                if (_synth.State == SynthesizerState.Paused)
                {
                    _synth.Resume();
                    _btnPauseRestart.Text = "暂停";
                }
            }
        }

        /// <summary>
        /// Save speech to .WAV file.
        /// </summary>
        private void _btnSaveAsWavFile_Click
          (object sender,
           EventArgs e)
        {
            // Get name of .WAV file - return if user cancels
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;
            
            _checkDontWatchClipboard.Checked = true;

           

            // Save speech as .WAV file
           
            _synth.SetOutputToWaveFile("talkingClipboard.wav");
            _isOutoutFile = true;
            _synth.SpeakAsync(richText.Text);// _editText.Text);
            
            _synth.SpeakCompleted += (obj, se) =>
                {
                    Convert2MP3(sfd.FileName);
                };

           
           

        }

        private void Convert2MP3(string filename)
        {
            if (_isOutoutFile)
            {
                _synth.SetOutputToDefaultAudioDevice();

                ConvertToMp3(filename);

                _checkDontWatchClipboard.Invoke(new Action(()=>
                    {
                         _checkDontWatchClipboard.Checked = false;
                    }));
               

                _isOutoutFile = true;
            }
        }

        public void ConvertToMp3(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                return;
           
            //System.Diagnostics.Process p = new System.Diagnostics.Process();
            //p.StartInfo.UseShellExecute = true;
            //p.StartInfo.CreateNoWindow = false;
            //p.StartInfo.FileName = System.IO.Directory.GetCurrentDirectory() + @"\LAME\lame.exe";
            //p.StartInfo.Arguments = "-b 64 \"" + "talkingClipboard.wav\" \"" + "filename\"";
            //p.Start();
            //p.WaitForExit();

            Process p = Process.Start(System.IO.Directory.GetCurrentDirectory()+@"\LAME\lame.exe", "-V2 \"" + "talkingClipboard.wav" + "\" \"" + filename + "\"");
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.CreateNoWindow = false;
            p.WaitForExit();

            System.IO.File.Delete("talkingClipboard.wav");
            MessageBox.Show(this, filename+"文件已存储!", "保存为MP3", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filename = string.Empty;
          
        }

        

        #endregion

        #region Fields

        /// <summary>
        /// Flag: the form has loaded.
        /// </summary>
        bool _loaded;

        /// <summary>
        /// Next window in clipboard viewer chain to receive clipboard notifications.
        /// </summary>
        IntPtr _chainedWnd;

        /// <summary>
        /// The TTS engine.
        /// </summary>
        SpeechSynthesizer _synth = new SpeechSynthesizer();
        private ReadOnlyCollection<InstalledVoice> _voices;
        private bool _isOutoutFile =false;
       

        #endregion


        #region 字体



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as RadioButton;
            if (checkBox != null)
            {
                float size = float.Parse(checkBox.Text);
                this.richText.Font = new System.Drawing.Font("Microsoft YaHei", size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            // Get name of .WAV file - return if user cancels
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;

            //_checkDontWatchClipboard.Checked = true;
         //   FileInfo fileinfo = new FileInfo(sfd.FileName);
            
            ReadCharacters(sfd.FileName);
        }


        async void ReadCharacters(string fileName)
        {
            String result="aa";
            Encoding encode = GetType(fileName);
            Encoding ansi = Encoding.GetEncoding("GB2312");

            using (StreamReader reader = new StreamReader(fileName, ansi))
            {
                result = await reader.ReadToEndAsync();//.ReadLineAsync();
                if (!string.IsNullOrWhiteSpace(result))
                {
                    this.richText.Text = result;// Encoding.UTF8.GetString(Encoding.Default.GetBytes(result));// result;
                    SpeakText(this.richText.Text);
                }
            }
        }

        public static Encoding GetType(string filename)
        {
            Encoding r = Encoding.Default;

            using (var fs= new FileStream(filename,FileMode.Open,FileAccess.Read))
            {
                r = GetType(fs);
            }

            return r;
        }

        private static Encoding GetType(FileStream fs)
        {
             BinaryReader r = new BinaryReader(fs);
             byte[] ss = r.ReadBytes(3);
             r.Close();
             if (ss == null || ss.Length <= 0)
             {
                 return null;
             }
             if (ss.Length >= 3 && ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF)
             {
                 return Encoding.UTF8;
             }
             else if (ss.Length >= 2 && ss[0] == 0xFF && ss[1] == 0xFE)
             {
                 return Encoding.BigEndianUnicode;
             }
             else if (ss.Length >= 2 && ss[0] == 0xFF && ss[1] == 0xFE)
             {
                 return Encoding.UTF32;
             }
             else
                 return Encoding.GetEncoding("GB2312");
        }
    }
}
