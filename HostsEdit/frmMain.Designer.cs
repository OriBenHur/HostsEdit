namespace HostsEdit
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.Password = new System.Windows.Forms.TextBox();
            this._Password = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnEncrypt = new System.Windows.Forms.Button();
            this._UserName = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.ShowUser = new System.Windows.Forms.CheckBox();
            this.DomainAdmin = new System.Windows.Forms.CheckBox();
            this._Domain = new System.Windows.Forms.Label();
            this.Domain = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Password.Location = new System.Drawing.Point(72, 53);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(269, 21);
            this.Password.TabIndex = 2;
            this.Password.Click += new System.EventHandler(this.Password_Click);
            this.Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_KeyDown);
            // 
            // _Password
            // 
            this._Password.AutoSize = true;
            this._Password.Location = new System.Drawing.Point(6, 55);
            this._Password.Name = "_Password";
            this._Password.Size = new System.Drawing.Size(56, 13);
            this._Password.TabIndex = 4;
            this._Password.Text = "Password:";
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(266, 88);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "OK";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // _UserName
            // 
            this._UserName.AutoSize = true;
            this._UserName.Location = new System.Drawing.Point(6, 24);
            this._UserName.Name = "_UserName";
            this._UserName.Size = new System.Drawing.Size(63, 13);
            this._UserName.TabIndex = 6;
            this._UserName.Text = "User Name:";
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UserName.Location = new System.Drawing.Point(72, 21);
            this.UserName.Name = "UserName";
            this.UserName.PasswordChar = '*';
            this.UserName.Size = new System.Drawing.Size(269, 21);
            this.UserName.TabIndex = 1;
            this.UserName.Click += new System.EventHandler(this.UserName_Click);
            this.UserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserName_KeyDown);
            // 
            // ShowUser
            // 
            this.ShowUser.AutoSize = true;
            this.ShowUser.Location = new System.Drawing.Point(72, 81);
            this.ShowUser.Name = "ShowUser";
            this.ShowUser.Size = new System.Drawing.Size(109, 17);
            this.ShowUser.TabIndex = 8;
            this.ShowUser.Text = "Show User Name";
            this.ShowUser.UseVisualStyleBackColor = true;
            this.ShowUser.CheckedChanged += new System.EventHandler(this.ShowUser_CheckedChanged);
            // 
            // DomainAdmin
            // 
            this.DomainAdmin.AutoSize = true;
            this.DomainAdmin.Location = new System.Drawing.Point(72, 102);
            this.DomainAdmin.Name = "DomainAdmin";
            this.DomainAdmin.Size = new System.Drawing.Size(94, 17);
            this.DomainAdmin.TabIndex = 9;
            this.DomainAdmin.Text = "Domain Admin";
            this.DomainAdmin.UseVisualStyleBackColor = true;
            this.DomainAdmin.CheckedChanged += new System.EventHandler(this.DomainAdmin_CheckedChanged);
            // 
            // _Domain
            // 
            this._Domain.AutoSize = true;
            this._Domain.Location = new System.Drawing.Point(6, 88);
            this._Domain.Name = "_Domain";
            this._Domain.Size = new System.Drawing.Size(46, 13);
            this._Domain.TabIndex = 11;
            this._Domain.Text = "Domain:";
            this._Domain.Visible = false;
            // 
            // Domain
            // 
            this.Domain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Domain.Location = new System.Drawing.Point(72, 85);
            this.Domain.Name = "Domain";
            this.Domain.PasswordChar = '*';
            this.Domain.Size = new System.Drawing.Size(269, 21);
            this.Domain.TabIndex = 3;
            this.Domain.Visible = false;
            this.Domain.Click += new System.EventHandler(this.Domain_Click);
            this.Domain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Domain_KeyDown);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 129);
            this.Controls.Add(this._Domain);
            this.Controls.Add(this.Domain);
            this.Controls.Add(this.DomainAdmin);
            this.Controls.Add(this.ShowUser);
            this.Controls.Add(this._UserName);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this._Password);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.btnEncrypt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Update Info";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label _Password;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label _UserName;
        private System.Windows.Forms.CheckBox ShowUser;
        private System.Windows.Forms.Label _Domain;
        private System.Windows.Forms.TextBox Domain;
        private System.Windows.Forms.CheckBox DomainAdmin;
    }
}