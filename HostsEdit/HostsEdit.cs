using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using CustomMsgbox;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Text;

namespace HostsEdit
{
    class HostsEdit
    {

        public static string[] read(string str, bool swich)
        {
            XmlTextReader reader = new XmlTextReader(str);
            XmlNodeType Type;
            string[] ans = new string[3];
            if (!File.Exists(str))
            {
                DialogResult dr = MessageBox.Show("Config File is Missing\nContact Your System Administrator", "Config File is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            try
            {
                while (reader.Read())
                {
                    Type = reader.NodeType;
                    if (Type == XmlNodeType.Element)
                    {
                        if (reader.Name == "SyncToken")
                        {
                            reader.Read();
                            string tmp = CryptorEngine.Decrypt(reader.Value, true, "pMg5R#zU0z");
                            ans[0] = CryptorEngine.Decrypt(tmp, true, "Tu@%n9DshW");

                        }
                        if (reader.Name == "TokenKey")
                        {
                            reader.Read();
                            string tmp = CryptorEngine.Decrypt(reader.Value, true, "mXb2IOfs%8");
                            ans[1] = CryptorEngine.Decrypt(tmp, true, "g%EMajStp0");
                        }
                        if (reader.Name == "Control")
                        {
                            reader.Read();
                            string tmp = CryptorEngine.Decrypt(reader.Value, true, "5$302@%F1d");
                            ans[2] = CryptorEngine.Decrypt(tmp, true, "$X!OotQ36M");
                        }
                    }
                }
                reader.Close();
            }
            catch
            {
                if (swich)
                {
                    reader.Close();
                    File.Delete(str);
                }
                else
                {
                    MessageBox.Show("Config File is Corrupted!\nContact Your System Administrator", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }
            return ans;
        }
        

        static void RunAdmin()
        {
            
            // Launch itself as administrator
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.Arguments = "-Admin";
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Application.ExecutablePath;
            proc.Verb = "runas";

            try
            {
                Process.Start(proc);
            }
            catch
            {
                //MsgBox.Show("Opps", "Why?", "OK");
                // The user refused to allow privileges elevation.
                // Do nothing and return directly ...
                Environment.Exit(0);
            }
            // Quit itself
            Environment.Exit(0);
        }
        public static void Admin()
        {
            try
            {
                if (!(File.Exists(Application.StartupPath + "\\library\\Test.txt")))
                {
                    using (FileStream fs = File.Create(Application.StartupPath + "\\library\\Test.txt"))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("Text...");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                }
                if (File.Exists(Application.StartupPath + "\\library\\Test.txt"))
                {
                    File.Delete(Application.StartupPath + "\\library\\Test.txt");
                }
                frmMain fr = new frmMain();
                fr.ShowDialog();
                fr.Close();
                Environment.Exit(0);
            }
            catch
            {
                MessageBox.Show("You Don't Have Admin Rights!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
        public static bool iSrunning()
        {
            Process[] pname = Process.GetProcessesByName("TextEditor");
            if (pname.Length == 0) return false;
            return true;
        }
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr WindowHandle);
        public const int SW_RESTORE = 9;
        public const int SW_SHOW = 5;
        private static void FocusProcess(string procName)
        {

            Process[] objProcesses = Process.GetProcessesByName(procName);
            if (objProcesses.Length > 0)
            {
                IntPtr hWnd = IntPtr.Zero;
                hWnd = objProcesses[0].MainWindowHandle;
                ShowWindowAsync(new HandleRef(null, hWnd), SW_SHOW);
                ShowWindowAsync(new HandleRef(null, hWnd), SW_RESTORE);
                SetForegroundWindow(objProcesses[0].MainWindowHandle);
            }
        }

        static int RunAs(string apppath, string arguments, string domain, string username, string password)
        {
            Process userProcess;
            if (iSrunning())
            {
                MsgBox.Show("Program Already Running", "Already Running", "OK");
                FocusProcess("TextEditor");
                return 0;
            }
            else
            {
                try
                {
                    userProcess = Process.Start(apppath, arguments, username, GetSecure(password), domain);
                    userProcess.Dispose();
                }
                catch
                {
                    DialogResult dr = MessageBox.Show("Password is incorrect!\nContact Your System Administrator", "Password is incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                return 0;
            }
        }

        static SecureString GetSecure(string str)
        {
            SecureString SecureStr = new SecureString();
            foreach (char c in str)
            {
                SecureStr.AppendChar(c);
            }

            return SecureStr;
        }
        static int Main(string[] args)
        {
            
            if (args.Length > 0)
            {
                if(args[0] == "Admin" || args[0] == "admin")
                {
                    RunAdmin();
                }
                else if (args[0] == "-Admin")
                {
                    Admin();
                }
            }
            string[] ans = read(Application.StartupPath + "\\library\\config.xml", false);
            string username = ans[0];
            string password = ans[1];
            string domain = ans[2];
            //MsgBox.Show(ans[2],"Domain","OK");
            string apppath = Application.StartupPath + "\\library\\TextEditor.exe", arguments = "";
            Console.WriteLine(arguments);
            return RunAs(apppath, arguments, domain, username, password);
        }
    }
}