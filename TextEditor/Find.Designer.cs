namespace TextEditor
{
    partial class Find
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Find_Next = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.MatchCase = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(47, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Find_Next
            // 
            this.Find_Next.Location = new System.Drawing.Point(253, 22);
            this.Find_Next.Name = "Find_Next";
            this.Find_Next.Size = new System.Drawing.Size(75, 20);
            this.Find_Next.TabIndex = 1;
            this.Find_Next.Text = "Find Next";
            this.Find_Next.UseVisualStyleBackColor = true;
            this.Find_Next.Click += new System.EventHandler(this.Find_Next_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(253, 62);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 20);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // MatchCase
            // 
            this.MatchCase.AutoSize = true;
            this.MatchCase.Location = new System.Drawing.Point(47, 65);
            this.MatchCase.Name = "MatchCase";
            this.MatchCase.Size = new System.Drawing.Size(80, 17);
            this.MatchCase.TabIndex = 3;
            this.MatchCase.Text = "MatchCase";
            this.MatchCase.UseVisualStyleBackColor = true;
            this.MatchCase.CheckedChanged += new System.EventHandler(this.MatchCase_CheckedChanged);
            // 
            // Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 94);
            this.Controls.Add(this.MatchCase);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.Find_Next);
            this.Controls.Add(this.textBox1);
            this.Name = "Find";
            this.Text = "Find";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Find_Next;
        //private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.CheckBox MatchCase;
    }
}