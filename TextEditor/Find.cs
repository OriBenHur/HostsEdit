using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Find : Form
    {
        bool Bstat = false;
        public Find()
        {
            InitializeComponent();
        }
        
        public bool Case()
        {
            if (MatchCase.Checked) Bstat = true;
            return Bstat;
            
        }
        private void Find_Next_Click(object sender, EventArgs e)
        {
            TextEditor PF = new TextEditor();
            //f.MdiParent = MDIParent1.ActiveForm;
            PF.FindAndSelect(textBox1.Text, Case()); 
            //PF.
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Dispose(true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MatchCase_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
