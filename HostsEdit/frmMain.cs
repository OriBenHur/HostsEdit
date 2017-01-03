using System;
using System.Drawing;
using System.IO;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using System.Xml;


namespace HostsEdit
{
    
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            if (File.Exists(Application.StartupPath + "\\library\\config.xml"))
            {
                string[] ans = HostsEdit.read(Application.StartupPath + "\\library\\config.xml", true);
                UserName.Text = ans[0];
                Password.Text = ans[1];
            }
        }

        private void generateXML(string elam1, string val1, string elam2, string val2, string elam3, string val3)
        {
            try
            {
                string xmlString = "<config><" + val1 + ">" + elam1 + "</" + val1 + "><" + val2 + ">" + elam2 + "</" + val2 + "><" + val3 + ">" + elam3 + "</" + val3 + "></config>";
                XmlDocument doc = new XmlDocument();
                doc.Load(new StringReader(xmlString));

                // Save the document to a file and auto-indent the output.
                using (TextWriter writer = new StreamWriter(Application.StartupPath + "\\library\\config.xml", false, Encoding.UTF8))
                {
                    //writer.Formatting = Formatting.Indented;
                    doc.Save(writer);
                    writer.Close();
                }
            }

            catch
            {
                MessageBox.Show("You Don't Have Permission To Save The File!", "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }



        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            error.Clear();
            if (Password.Text == "" && UserName.Text == "")
            {
                error.SetError(UserName, "Enter Username");
                error.SetError(Password, "Enter Password");
            }

            else if (Password.Text == "" || UserName.Text == "")
            {
                if (Password.Text == "")
                {
                    error.SetError(Password, "Enter Password");
                }

                else
                {
                    error.SetError(UserName, "Enter Username");

                }

            }

            else
            {
                error.Clear();
                string UserClearText = UserName.Text.Trim();
                string tmpUsercipherText = CryptorEngine.Encrypt(UserClearText, true, "Tu@%n9DshW");
                string cipherUserText = CryptorEngine.Encrypt(tmpUsercipherText, true, "pMg5R#zU0z");
                string PassClearText = Password.Text.Trim();
                string tmpPassCipherText = CryptorEngine.Encrypt(PassClearText, true, "g%EMajStp0");
                string cipherPassText = CryptorEngine.Encrypt(tmpPassCipherText, true, "mXb2IOfs%8");
                string DomainClearText = Domain.Text.Trim();
                string tmpDomaincipherText = CryptorEngine.Encrypt(DomainClearText, true, "$X!OotQ36M");
                string cipherDomainText = CryptorEngine.Encrypt(tmpDomaincipherText, true, "5$302@%F1d");
                generateXML(cipherUserText, "SyncToken", cipherPassText, "TokenKey", cipherDomainText, "Control");
                Close();
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose(true);
        }

        private void UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEncrypt.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEncrypt.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void UserName_Click(object sender, EventArgs e)
        {
            UserName.SelectAll();
        }

        private void Password_Click(object sender, EventArgs e)
        {
            Password.SelectAll();
        }

        private void ShowUser_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowUser.Checked)
            {
                UserName.PasswordChar = '\0';
            }
            else
            {
                UserName.PasswordChar = '*';
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void DomainAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (DomainAdmin.Checked)
            {
                if (File.Exists(Application.StartupPath + "\\library\\config.xml"))
                {
                    string[] ans = HostsEdit.read(Application.StartupPath + "\\library\\config.xml",false);
                    Domain.Text = ans[2];
                }
                Size = new Size(380, 212);
                btnEncrypt.Location = new Point(266, 128);
                ShowUser.Location = new Point(72, 121);
                DomainAdmin.Location = new Point(72, 142);
                Domain.Visible = true;
                _Domain.Visible = true;
            }
            else
            {
                Domain.Text = "";
                Size = new Size(380, 172);
                btnEncrypt.Location = new Point(266, 88);
                ShowUser.Location = new Point(72, 81);
                DomainAdmin.Location = new Point(72, 102);
                Domain.Visible = false;
                _Domain.Visible = false;
            }
        }

        private void Domain_Click(object sender, EventArgs e)
        {
            Domain.SelectAll();
        }

        private void Domain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEncrypt.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
