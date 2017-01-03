using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomMsgbox
{
    public partial class MsgBox : Form
    {
        public MsgBox()
        {
            InitializeComponent();
        }
        static MsgBox msgBox; static DialogResult Result = DialogResult.No;
        public static DialogResult Show(string Text, string Caption, string btnOK)
        {
            msgBox = new MsgBox();
            msgBox.label1.Text = Text;
            msgBox.button1.Text = btnOK;
            msgBox.Text = Caption;
            Result = DialogResult.No;
            msgBox.ShowDialog();
            return Result;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Yes; msgBox.Close();
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
