namespace TalkingClipboard
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._btnSpeak = new System.Windows.Forms.Button();
            this._btnSaveAsWavFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._btnStop = new System.Windows.Forms.Button();
            this._comboVoices = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._knobRate = new System.Windows.Forms.TrackBar();
            this._lblSpeed = new System.Windows.Forms.Label();
            this._btnPauseRestart = new System.Windows.Forms.Button();
            this._checkDontWatchClipboard = new System.Windows.Forms.CheckBox();
            this.richText = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.RadioButton();
            this.checkBox2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._knobRate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnSpeak
            // 
            this._btnSpeak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSpeak.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._btnSpeak.Location = new System.Drawing.Point(12, 211);
            this._btnSpeak.Name = "_btnSpeak";
            this._btnSpeak.Size = new System.Drawing.Size(56, 23);
            this._btnSpeak.TabIndex = 2;
            this._btnSpeak.Text = "朗读";
            this._btnSpeak.UseVisualStyleBackColor = true;
            this._btnSpeak.Click += new System.EventHandler(this._btnSpeak_Click);
            // 
            // _btnSaveAsWavFile
            // 
            this._btnSaveAsWavFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSaveAsWavFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(77)))), ((int)(((byte)(52)))));
            this._btnSaveAsWavFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._btnSaveAsWavFile.Location = new System.Drawing.Point(473, 7);
            this._btnSaveAsWavFile.Name = "_btnSaveAsWavFile";
            this._btnSaveAsWavFile.Size = new System.Drawing.Size(121, 23);
            this._btnSaveAsWavFile.TabIndex = 4;
            this._btnSaveAsWavFile.Text = "保存为MP3文件...";
            this._btnSaveAsWavFile.UseVisualStyleBackColor = false;
            this._btnSaveAsWavFile.Click += new System.EventHandler(this._btnSaveAsWavFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "朗读文字";
            // 
            // _btnStop
            // 
            this._btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._btnStop.Location = new System.Drawing.Point(72, 211);
            this._btnStop.Name = "_btnStop";
            this._btnStop.Size = new System.Drawing.Size(56, 23);
            this._btnStop.TabIndex = 3;
            this._btnStop.Text = "停止";
            this._btnStop.UseVisualStyleBackColor = true;
            this._btnStop.Click += new System.EventHandler(this._btnStop_Click);
            // 
            // _comboVoices
            // 
            this._comboVoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._comboVoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(77)))), ((int)(((byte)(52)))));
            this._comboVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboVoices.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._comboVoices.FormattingEnabled = true;
            this._comboVoices.Location = new System.Drawing.Point(404, 213);
            this._comboVoices.Name = "_comboVoices";
            this._comboVoices.Size = new System.Drawing.Size(190, 21);
            this._comboVoices.TabIndex = 5;
            this._comboVoices.SelectionChangeCommitted += new System.EventHandler(this._comboVoices_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "朗诵者:";
            // 
            // _knobRate
            // 
            this._knobRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._knobRate.Location = new System.Drawing.Point(230, 213);
            this._knobRate.Name = "_knobRate";
            this._knobRate.Size = new System.Drawing.Size(122, 45);
            this._knobRate.TabIndex = 7;
            this._knobRate.Value = 5;
            this._knobRate.ValueChanged += new System.EventHandler(this._knobRate_ValueChanged);
            // 
            // _lblSpeed
            // 
            this._lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblSpeed.AutoSize = true;
            this._lblSpeed.Location = new System.Drawing.Point(194, 216);
            this._lblSpeed.Name = "_lblSpeed";
            this._lblSpeed.Size = new System.Drawing.Size(35, 13);
            this._lblSpeed.TabIndex = 8;
            this._lblSpeed.Text = "语速:";
            // 
            // _btnPauseRestart
            // 
            this._btnPauseRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnPauseRestart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._btnPauseRestart.Location = new System.Drawing.Point(132, 211);
            this._btnPauseRestart.Name = "_btnPauseRestart";
            this._btnPauseRestart.Size = new System.Drawing.Size(56, 23);
            this._btnPauseRestart.TabIndex = 9;
            this._btnPauseRestart.Text = "暂停";
            this._btnPauseRestart.UseVisualStyleBackColor = true;
            this._btnPauseRestart.Click += new System.EventHandler(this._btnPauseRestart_Click);
            // 
            // _checkDontWatchClipboard
            // 
            this._checkDontWatchClipboard.AutoSize = true;
            this._checkDontWatchClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._checkDontWatchClipboard.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._checkDontWatchClipboard.Location = new System.Drawing.Point(99, 7);
            this._checkDontWatchClipboard.Name = "_checkDontWatchClipboard";
            this._checkDontWatchClipboard.Size = new System.Drawing.Size(138, 23);
            this._checkDontWatchClipboard.TabIndex = 10;
            this._checkDontWatchClipboard.Text = "停止检测剪切板";
            this._checkDontWatchClipboard.UseVisualStyleBackColor = true;
            // 
            // richText
            // 
            this.richText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.richText.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richText.Location = new System.Drawing.Point(12, 34);
            this.richText.Multiline = true;
            this.richText.Name = "richText";
            this.richText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.richText.Size = new System.Drawing.Size(582, 171);
            this.richText.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox1.Location = new System.Drawing.Point(2, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(30, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "9";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(253, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 30);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox3.Location = new System.Drawing.Point(67, 12);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(36, 17);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "18";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox2.Location = new System.Drawing.Point(31, 12);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(36, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "12";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(77)))), ((int)(((byte)(52)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(382, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "文件...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(77)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(606, 248);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richText);
            this.Controls.Add(this._checkDontWatchClipboard);
            this.Controls.Add(this._btnPauseRestart);
            this.Controls.Add(this._lblSpeed);
            this.Controls.Add(this._knobRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._comboVoices);
            this.Controls.Add(this._btnStop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._btnSaveAsWavFile);
            this.Controls.Add(this._btnSpeak);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(384, 287);
            this.Name = "MainFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "话匣子";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._knobRate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnSpeak;
        private System.Windows.Forms.Button _btnSaveAsWavFile;
       // private System.Windows.Forms.TextBox _editText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnStop;
        private System.Windows.Forms.ComboBox _comboVoices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar _knobRate;
        private System.Windows.Forms.Label _lblSpeed;
        private System.Windows.Forms.Button _btnPauseRestart;
        private System.Windows.Forms.CheckBox _checkDontWatchClipboard;
        private System.Windows.Forms.TextBox richText;
        private System.Windows.Forms.RadioButton checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton checkBox3;
        private System.Windows.Forms.RadioButton checkBox2;
        private System.Windows.Forms.Button button1;
    }
}

