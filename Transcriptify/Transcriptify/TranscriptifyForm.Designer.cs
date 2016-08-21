namespace Transcriptify
{
    partial class TranscriptifyForm
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
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.txtYoutubeURI = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnTranscript = new System.Windows.Forms.Button();
            this.lblURI = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.trackBarScript = new System.Windows.Forms.TrackBar();
            this.txtTranscriptOut = new System.Windows.Forms.TextBox();
            this.lblTimeCode = new System.Windows.Forms.Label();
            this.btnCopyLine = new System.Windows.Forms.Button();
            this.btnGotoLine = new System.Windows.Forms.Button();
            this.btnSeach = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lsbSearchResults = new System.Windows.Forms.ListBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.lblOccurences = new System.Windows.Forms.Label();
            this.lblOccurenceLocationList = new System.Windows.Forms.Label();
            this.ckbLoadXML = new System.Windows.Forms.CheckBox();
            this.bntNextLine = new System.Windows.Forms.Button();
            this.btnPrevLine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScript)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(453, 74);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(482, 381);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "";
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(12, 74);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(435, 464);
            this.webBrowser.TabIndex = 1;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // txtYoutubeURI
            // 
            this.txtYoutubeURI.Location = new System.Drawing.Point(88, 24);
            this.txtYoutubeURI.Name = "txtYoutubeURI";
            this.txtYoutubeURI.Size = new System.Drawing.Size(272, 20);
            this.txtYoutubeURI.TabIndex = 2;
            this.txtYoutubeURI.Text = "https://www.youtube.com/watch?v=U_m9zPKle-0";
            this.txtYoutubeURI.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtYoutubeURI_KeyUp);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(372, 22);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnTranscript
            // 
            this.btnTranscript.Location = new System.Drawing.Point(453, 22);
            this.btnTranscript.Name = "btnTranscript";
            this.btnTranscript.Size = new System.Drawing.Size(75, 23);
            this.btnTranscript.TabIndex = 4;
            this.btnTranscript.Text = "Transcriptify";
            this.btnTranscript.UseVisualStyleBackColor = true;
            this.btnTranscript.Visible = false;
            this.btnTranscript.Click += new System.EventHandler(this.btnTranscript_Click);
            // 
            // lblURI
            // 
            this.lblURI.AutoSize = true;
            this.lblURI.Location = new System.Drawing.Point(12, 27);
            this.lblURI.Name = "lblURI";
            this.lblURI.Size = new System.Drawing.Size(73, 13);
            this.lblURI.TabIndex = 5;
            this.lblURI.Text = "Youtube Link:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(861, 461);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // trackBarScript
            // 
            this.trackBarScript.LargeChange = 1;
            this.trackBarScript.Location = new System.Drawing.Point(476, 518);
            this.trackBarScript.Maximum = 0;
            this.trackBarScript.Name = "trackBarScript";
            this.trackBarScript.Size = new System.Drawing.Size(534, 45);
            this.trackBarScript.TabIndex = 8;
            this.trackBarScript.Scroll += new System.EventHandler(this.trackBarScript_Scroll);
            // 
            // txtTranscriptOut
            // 
            this.txtTranscriptOut.Location = new System.Drawing.Point(511, 494);
            this.txtTranscriptOut.Name = "txtTranscriptOut";
            this.txtTranscriptOut.Size = new System.Drawing.Size(471, 20);
            this.txtTranscriptOut.TabIndex = 9;
            // 
            // lblTimeCode
            // 
            this.lblTimeCode.AutoSize = true;
            this.lblTimeCode.Location = new System.Drawing.Point(456, 497);
            this.lblTimeCode.Name = "lblTimeCode";
            this.lblTimeCode.Size = new System.Drawing.Size(49, 13);
            this.lblTimeCode.TabIndex = 10;
            this.lblTimeCode.Text = "00:00:00";
            // 
            // btnCopyLine
            // 
            this.btnCopyLine.Location = new System.Drawing.Point(988, 491);
            this.btnCopyLine.Name = "btnCopyLine";
            this.btnCopyLine.Size = new System.Drawing.Size(75, 23);
            this.btnCopyLine.TabIndex = 11;
            this.btnCopyLine.Text = "Copy Line";
            this.btnCopyLine.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopyLine.UseVisualStyleBackColor = true;
            this.btnCopyLine.Click += new System.EventHandler(this.btnCopyLine_Click);
            // 
            // btnGotoLine
            // 
            this.btnGotoLine.Location = new System.Drawing.Point(453, 461);
            this.btnGotoLine.Name = "btnGotoLine";
            this.btnGotoLine.Size = new System.Drawing.Size(105, 23);
            this.btnGotoLine.TabIndex = 12;
            this.btnGotoLine.Text = "Go to line in video";
            this.btnGotoLine.UseVisualStyleBackColor = true;
            this.btnGotoLine.Click += new System.EventHandler(this.btnGotoLine_Click);
            // 
            // btnSeach
            // 
            this.btnSeach.Location = new System.Drawing.Point(762, 22);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(75, 23);
            this.btnSeach.TabIndex = 13;
            this.btnSeach.Text = "Search";
            this.btnSeach.UseVisualStyleBackColor = true;
            this.btnSeach.Visible = false;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(608, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(148, 20);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.Visible = false;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(560, 27);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 15;
            this.lblSearch.Text = "Search:";
            this.lblSearch.Visible = false;
            // 
            // lsbSearchResults
            // 
            this.lsbSearchResults.FormattingEnabled = true;
            this.lsbSearchResults.Location = new System.Drawing.Point(942, 113);
            this.lsbSearchResults.Name = "lsbSearchResults";
            this.lsbSearchResults.Size = new System.Drawing.Size(120, 342);
            this.lsbSearchResults.TabIndex = 16;
            this.lsbSearchResults.SelectedIndexChanged += new System.EventHandler(this.lsbSearchResults_SelectedIndexChanged);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(942, 74);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(68, 13);
            this.lblResults.TabIndex = 17;
            this.lblResults.Text = "Occurences:";
            // 
            // lblOccurences
            // 
            this.lblOccurences.AutoSize = true;
            this.lblOccurences.Location = new System.Drawing.Point(1006, 74);
            this.lblOccurences.Name = "lblOccurences";
            this.lblOccurences.Size = new System.Drawing.Size(0, 13);
            this.lblOccurences.TabIndex = 18;
            // 
            // lblOccurenceLocationList
            // 
            this.lblOccurenceLocationList.AutoSize = true;
            this.lblOccurenceLocationList.Location = new System.Drawing.Point(942, 97);
            this.lblOccurenceLocationList.Name = "lblOccurenceLocationList";
            this.lblOccurenceLocationList.Size = new System.Drawing.Size(51, 13);
            this.lblOccurenceLocationList.TabIndex = 19;
            this.lblOccurenceLocationList.Text = "Location:";
            // 
            // ckbLoadXML
            // 
            this.ckbLoadXML.AutoSize = true;
            this.ckbLoadXML.Location = new System.Drawing.Point(15, 51);
            this.ckbLoadXML.Name = "ckbLoadXML";
            this.ckbLoadXML.Size = new System.Drawing.Size(175, 17);
            this.ckbLoadXML.TabIndex = 20;
            this.ckbLoadXML.Text = "Display XML when Transcribing";
            this.ckbLoadXML.UseVisualStyleBackColor = true;
            // 
            // bntNextLine
            // 
            this.bntNextLine.Location = new System.Drawing.Point(1009, 520);
            this.bntNextLine.Name = "bntNextLine";
            this.bntNextLine.Size = new System.Drawing.Size(22, 22);
            this.bntNextLine.TabIndex = 21;
            this.bntNextLine.Text = ">";
            this.bntNextLine.UseVisualStyleBackColor = true;
            this.bntNextLine.Click += new System.EventHandler(this.bntNextLine_Click);
            // 
            // btnPrevLine
            // 
            this.btnPrevLine.Location = new System.Drawing.Point(459, 518);
            this.btnPrevLine.Name = "btnPrevLine";
            this.btnPrevLine.Size = new System.Drawing.Size(22, 22);
            this.btnPrevLine.TabIndex = 22;
            this.btnPrevLine.Text = "<";
            this.btnPrevLine.UseVisualStyleBackColor = true;
            this.btnPrevLine.Click += new System.EventHandler(this.btnPrevLine_Click);
            // 
            // TranscriptifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 550);
            this.Controls.Add(this.btnPrevLine);
            this.Controls.Add(this.bntNextLine);
            this.Controls.Add(this.ckbLoadXML);
            this.Controls.Add(this.lblOccurenceLocationList);
            this.Controls.Add(this.lblOccurences);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lsbSearchResults);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSeach);
            this.Controls.Add(this.btnGotoLine);
            this.Controls.Add(this.btnCopyLine);
            this.Controls.Add(this.lblTimeCode);
            this.Controls.Add(this.txtTranscriptOut);
            this.Controls.Add(this.trackBarScript);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblURI);
            this.Controls.Add(this.btnTranscript);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtYoutubeURI);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.txtOutput);
            this.Name = "TranscriptifyForm";
            this.Text = "Transcriptify";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScript)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TextBox txtYoutubeURI;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnTranscript;
        private System.Windows.Forms.Label lblURI;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TrackBar trackBarScript;
        private System.Windows.Forms.TextBox txtTranscriptOut;
        private System.Windows.Forms.Label lblTimeCode;
        private System.Windows.Forms.Button btnCopyLine;
        private System.Windows.Forms.Button btnGotoLine;
        private System.Windows.Forms.Button btnSeach;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ListBox lsbSearchResults;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblOccurences;
        private System.Windows.Forms.Label lblOccurenceLocationList;
        private System.Windows.Forms.CheckBox ckbLoadXML;
        private System.Windows.Forms.Button bntNextLine;
        private System.Windows.Forms.Button btnPrevLine;
    }
}

