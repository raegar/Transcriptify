/*
 MIT License

Copyright (c) 2016 Jamie Myland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Xml.Linq;
using System.IO;

using System.Runtime.InteropServices;



namespace Transcriptify
{
    public partial class TranscriptifyForm : Form
    {
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, uint wMsg,
                                       UIntPtr wParam, IntPtr lParam);

        XmlDocument xmlDoc = new XmlDocument();
        bool convert = false;
        string output = "";
        string transcriptText = "";
        List<ScriptLine> transcriptList = new List<ScriptLine>();
        List<int> searchResultIndices = new List<int>();
        Font defaultFont;
        private bool searchUpdated = false;

        public TranscriptifyForm()
        {
            InitializeComponent();
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser.Url.AbsolutePath.Contains("xml"))
            {
                if (!ckbLoadXML.Checked)
                    webBrowser.Visible = false;
            }



            if (convert)
            {
                bool loaded = true;
                try
                {
                    xmlDoc.LoadXml(webBrowser.DocumentText.ToString().Replace("&nbsp;", " "));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to load transcript. Please wait a moment and then try again\n");
                    Console.WriteLine(ex.Message);
                    loaded = false;
                }
                if (loaded)
                {
                    string text = "";
                    foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                    {
                        text += node.InnerText;
                    }

                    output = text.Substring(text.IndexOf("<transcript>"));


                    XDocument xdoc = XDocument.Parse(output);


                    txtOutput.Text = "";
                    int charCount = 0;
                    foreach (var scriptLine in xdoc.Descendants("text"))
                    {
                        int index = charCount;

                        string textLine = TextHelper.RemoveLineEndings(scriptLine.Value) + " ";

                        double start = Convert.ToDouble(scriptLine.Attribute("start").Value);

                        string duration = scriptLine.Attribute("dur").Value;

                        transcriptList.Add(new ScriptLine(index, textLine, start, duration));

                        charCount += TextHelper.RemoveLineEndings(textLine).Length;
                    }

                    trackBarScript.Maximum = transcriptList.Count;

                    transcriptText = "";

                    foreach (ScriptLine scritpLine in transcriptList)
                    {
                        transcriptText += scritpLine.Text;
                    }

                    transcriptText = TextHelper.RemoveLineEndings(transcriptText);

                    if (transcriptText != "" || transcriptText != null)
                    {
                        btnSave.Visible = true;
                    }

                    txtOutput.Text = transcriptText;

                    convert = false;
                    btnTranscript.Visible = false;
                    if (txtOutput.Text != "")
                    {
                        lblSearch.Visible = true;
                        txtSearch.Visible = true;
                        btnSeach.Visible = true;
                        SelectLineInTranscript();
                    }
                    if (!ckbLoadXML.Checked)
                        NavigateToURL();
                }
            }
            else
            {
                btnTranscript.Visible = true;
            }
        }

        private void ReloadTranscript()
        {
            txtOutput.Font = defaultFont;
            txtOutput.Text = transcriptText;
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            ClearCachedSWFFiles();
            if (txtYoutubeURI.Text.Contains("https://www.youtube.com/watch?v=") || txtYoutubeURI.Text.Contains("https://youtu.be/") || txtYoutubeURI.Text.Contains("https://www.youtube.com/embed/"))
            {
                NavigateToURL();
            }
            else
            {
                MessageBox.Show("Not a supported YouTube URL!\n");
            }
        }

        private void NavigateToURL()
        {
            convert = false;
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Navigate(txtYoutubeURI.Text);
        }

        private void btnTranscript_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("javascript:function loadTranscript(){if(yt.config_.TTS_URL.length) window.location.href=yt.config_.TTS_URL+\"&kind=asr&fmt=srv1&lang=en\"}loadTranscript();");
            convert = true;    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearCachedSWFFiles();
            defaultFont = txtOutput.Font;
        }

        private void trackBarScript_Scroll(object sender, EventArgs e)
        {
            SelectLineInTranscript();    
        }

        private void SelectLineInTranscript()
        {
            if (transcriptList.Count > 0 && trackBarScript.Value < transcriptList.Count)
            {
                txtTranscriptOut.Text = TextHelper.RemoveLineEndings(transcriptList[trackBarScript.Value].Text);

                TimeSpan t = TimeSpan.FromSeconds(transcriptList[trackBarScript.Value].Start);
                string timeCode = string.Format("{0:D2}:{1:D2}:{2:D2}",
                t.Hours,
                t.Minutes,
                t.Seconds,
                t.Milliseconds);

                lblTimeCode.Text = timeCode;


                txtOutput.Suspend();
                string txtOutputContents = txtOutput.Text;

                int phraseLength = transcriptList[trackBarScript.Value].Text.Length + 1;

                string txtTempStart = txtOutputContents.Substring(0, transcriptList[trackBarScript.Value].Index);

                int phraseEnd = transcriptList[trackBarScript.Value].Index + phraseLength;

                string txtTempEnd = "";
                if (txtOutputContents.Length - phraseEnd > 0)
                {
                    txtTempEnd = txtOutputContents.Substring(phraseEnd - 1, (txtOutputContents.Length - phraseEnd));
                }


                txtOutput.Text = "";

                RichTextBoxExtensions.AppendText(txtOutput, TextHelper.RemoveLineEndings(txtTempStart), Color.Black);
                RichTextBoxExtensions.AppendText(txtOutput, TextHelper.RemoveLineEndings(transcriptList[trackBarScript.Value].Text), Color.Red);
                RichTextBoxExtensions.AppendText(txtOutput, TextHelper.RemoveLineEndings(txtTempEnd), Color.Black);

                if (txtSearch.Text != "")
                {
                    int index = 0;
                    do
                    {
                        index = transcriptText.ToLower().IndexOf(txtSearch.Text.ToLower(), index);
                        if (index != -1)
                        {
                            txtOutput.SelectionStart = index;
                            txtOutput.SelectionLength = txtSearch.Text.Length;
                            txtOutput.SelectionFont = new Font(txtOutput.Font, FontStyle.Bold);
                            index++;
                        }
                    } while (index != -1);
                }

                txtOutput.SelectionStart = phraseEnd;
                txtOutput.ScrollToCaret();
                SendMessage(txtOutput.Handle, (uint)0x00B6, (UIntPtr)0, (IntPtr)(-10));// Scroll down 10 lines
                txtOutput.Resume();
            }

        }

        private void btnCopyLine_Click(object sender, EventArgs e)
        {
            if (txtTranscriptOut.Text != null && txtTranscriptOut.Text != "")
            {
                Clipboard.SetText(txtTranscriptOut.Text);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Transcript.txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                writer.WriteLine(txtOutput.Text);
                writer.Dispose();
                writer.Close();
            }
        }

        private void btnGotoLine_Click(object sender, EventArgs e)
        {
            string youtubeVideoID = null;
            if(txtYoutubeURI.Text.Contains("https://www.youtube.com/watch?v="))
            {
                youtubeVideoID = txtYoutubeURI.Text.Substring(txtYoutubeURI.Text.IndexOf("v=") + 2);
            }
            else if(txtYoutubeURI.Text.Contains("https://youtu.be/"))
            {
                youtubeVideoID = txtYoutubeURI.Text.Substring(txtYoutubeURI.Text.IndexOf(".be/") + 4);
            }
            else if (txtYoutubeURI.Text.Contains("https://youtube.com/embed/"))
            {
                youtubeVideoID = txtYoutubeURI.Text.Substring(txtYoutubeURI.Text.IndexOf("embed/") + 6);
            }
            else
            {
                MessageBox.Show("Invalid link");
            }

            if (youtubeVideoID != null)
            {
                int timecode = 0;
                if (transcriptList.Count > 0)
                {
                    timecode = (int)transcriptList[trackBarScript.Value].Start;
                }

                if (youtubeVideoID.Contains("?"))
                {
                    youtubeVideoID = youtubeVideoID.Substring(0, youtubeVideoID.IndexOf("?"));
                }
                txtYoutubeURI.Text = "https://youtu.be/" + youtubeVideoID + "?t=" + timecode;
                NavigateToURL();
            }
            
           
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            SearchTranscript();
        }

        private void SearchTranscript()
        {
            searchResultIndices.Clear();
            ReloadTranscript();
            lsbSearchResults.DataSource = null;
            lsbSearchResults.Items.Clear();
            int index = 0;
            int occurences = 0;

            do
            {
                index = transcriptText.ToLower().IndexOf(txtSearch.Text.ToLower(), index);
                if (index != -1)
                {
                    occurences++;
                    searchResultIndices.Add(index);
                    txtOutput.SelectionStart = index;
                    txtOutput.SelectionLength = txtSearch.Text.Length;
                    txtOutput.SelectionFont = new Font(txtOutput.Font, FontStyle.Bold);
                    index++;
                }
            } while (index != -1);

            lblOccurences.Text = "" + occurences;
            if (occurences > 0)
            {
                lsbSearchResults.DataSource = searchResultIndices;
                searchUpdated = true;
            }
        }

        private void lsbSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOutput.Suspend();
            if (!searchUpdated)
            {
                if (lsbSearchResults.DataSource != null)
                {
                    txtOutput.SelectionStart = (int)lsbSearchResults.SelectedItem;
                    txtOutput.SelectionLength = txtSearch.Text.Length;
                    txtOutput.SelectionFont = new Font(txtOutput.Font, FontStyle.Bold);
                    txtOutput.ScrollToCaret();

                    ScriptLine foundLine = transcriptList[transcriptList.Count - 1];
                    int foundLineID = transcriptList.Count - 1;

                    for (int index = 0; index < transcriptList.Count - 1; index++)
                    {
                        if (transcriptList[index].Index >= (int)lsbSearchResults.SelectedItem && (int) lsbSearchResults.SelectedItem < transcriptList[index + 1].Index)
                        {
                            foundLine = transcriptList[index];
                            foundLineID = index-1;
                            break;
                        }
                    }
                    if (foundLineID < trackBarScript.Maximum)
                    {
                        trackBarScript.Value = foundLineID;
                        SelectLineInTranscript();
                    }
                }
            }
            else
            {
                searchUpdated = false;
            }
            txtOutput.Resume();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                SearchTranscript();
            }
        }

        private void txtYoutubeURI_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                NavigateToURL();
            }
        }

        private void ClearCachedSWFFiles()
        {
            //try
            //{
            //    var cachefolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
            //                  "\\Microsoft\\Windows\\INetCache\\IE";
            //    var dirinfo = new DirectoryInfo(cachefolder);
            //    foreach (var directoryInfo in dirinfo.GetDirectories())
            //    {
            //        foreach (var fileInfo in directoryInfo.GetFiles("*.swf"))
            //        {
            //            fileInfo.Delete();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private void btnPrevLine_Click(object sender, EventArgs e)
        {
            if (trackBarScript.Value > trackBarScript.Minimum)
            {
                trackBarScript.Value--;
                SelectLineInTranscript();
            }
        }

        private void bntNextLine_Click(object sender, EventArgs e)
        {
            if (trackBarScript.Value < trackBarScript.Maximum)
            {
                trackBarScript.Value++;
                SelectLineInTranscript();
            }
        }
    }

    public class ScriptLine
    {
        public int Index { get; set; }
        public string Text { get; set; }
        public double Start { get; set; }
        public string Duration { get; set; }

        public ScriptLine(int index, string text, double start, string duration)
        {
            Index = index;
            Text = text;
            Start = start;
            Duration = duration;
        }
    }

    public static class TextHelper
    {
        public static string RemoveLineEndings(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            string lineSeparator = ((char)0x2028).ToString();
            string paragraphSeparator = ((char)0x2029).ToString();
            string period = ((char)0x2E).ToString();
            string space = ((char)0xA0).ToString();

            return value.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ").Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty).Replace(period, "\n");
        }

    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }

    public static class ControlExtensions
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        public static void Suspend(this Control control)
        {
            LockWindowUpdate(control.Handle);
        }

        public static void Resume(this Control control)
        {
            LockWindowUpdate(IntPtr.Zero);
        }

    }


}
