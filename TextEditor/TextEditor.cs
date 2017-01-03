using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace TextEditor
{
    public partial class TextEditor : Form
    {
        private string Restore = @"# Copyright (c) 1993-2009 Microsoft Corp.
#
# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.
#
# This file contains the mappings of IP addresses to host names. Each
# entry should be kept on an individual line. The IP address should
# be placed in the first column followed by the corresponding host name.
# The IP address and the host name should be separated by at least one
# space.
#
# Additionally, comments (such as these) may be inserted on individual
# lines or following the machine name denoted by a '#' symbol.
#
# For example:
#
#      102.54.94.97     rhino.acme.com          # source server
#       38.25.63.10     x.acme.com              # x client host

# localhost name resolution is handled within DNS itself.
#	127.0.0.1       localhost
#	::1             localhost
";
        private bool _textChange;
        private readonly string hosts = "C:\\Windows\\System32\\drivers\\etc\\hosts";

        public static ScrollBars ScrollBars { get; private set; }
        public TextEditor()
        {
            InitializeComponent();
            ReadHosts();
            _textChange = false;
        }
        private void ReadHosts()
        {
            try
            {
                StreamReader sr = new StreamReader(hosts);
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    //s = s.Replace("\n", Environment.NewLine);
                    textBox1.AppendText(s + "\r\n");
                }
                sr.Close();
            }
            catch
            {
                MessageBox.Show("Hosts File is Missing!", "Error Opening", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
        public bool _hasChange()
        {
            _textChange = false;
            string s = File.ReadAllText(hosts);
            if (!(textBox1.Text.Equals(s))) return _textChange = true;
            return _textChange;
        }
        public int _Save()
        {
            DialogResult dr = MessageBox.Show("Do You Want to Save The Changes You Made?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Cancel)
            {
                return 1;
            }
            else if (dr == DialogResult.Yes)
            {
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(hosts);
                    //sw = new StreamWriter("C:\\Users\\Ori\\Desktop\\a.txt");
                    sw.Write(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("You Don't Have Permission To Save The File!", "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                finally
                {
                    if (sw != null)
                    {
                        _textChange = false;
                        sw.Close();
                    }
                }
            }
            return 0;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(hosts);
                //sw = new StreamWriter("C:\\Users\\Ori\\Desktop\\a.txt");
                sw.Write(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("You Don't Have Permission To Save The File!", "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (sw != null)
                {
                    _textChange = false;
                    sw.Close();
                }
            }
        }

        private void restoreDefaultToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = Restore;
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Update();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_textChange)
            {
                int Error = _Save();
                if (Error == -1)
                {
                    //MessageBox.Show("You Don't Have Permission To Save The File!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                else if (Error == 0)
                {
                    Dispose(true);
                }
            }
            else
            {
                Dispose(true);
            }
        }

        //private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{

        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _hasChange();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("  Created By: Ori Ben Hur", "                                About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //}
        private void TextEditor_FormClosed(object sender, FormClosingEventArgs e)
        {
            if (_textChange)
            {
                int Error = _Save();
                if (Error == -1)
                {
                    //MessageBox.Show("You Don't Have Permission To Save The File!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else if (Error == 1)
                {
                    e.Cancel = true;
                }
            }
        }

        //private void TextEditor_Load(object sender, EventArgs e)
        //{
        //    TextEditor.ScrollBars = ScrollBars.Both;
        //}
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            var keyCode = (Keys)(msg.WParam.ToInt32() &
                                  Convert.ToInt32(Keys.KeyCode));
            if ((msg.Msg == WM_KEYDOWN && keyCode == Keys.A)
                && (ModifierKeys == Keys.Control)
                && textBox1.Focused)
            {
                textBox1.SelectAll();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool FindAndSelect(string TextToFind, bool MatchCase)
        {
            var mode = MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

            int position = textBox1.Text.IndexOf(TextToFind, mode);

            if (position == -1)
                return false;

            textBox1.SelectionStart = position;
            textBox1.SelectionLength = TextToFind.Length;
            return true;
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Find f = new Find();
            ////f.MdiParent = this;
            //f.Show();
        }
    }
}
