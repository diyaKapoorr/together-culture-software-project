namespace member_space
{
    partial class Login
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
            this.LcreateAccount = new System.Windows.Forms.Label();
            this.LdontHaveAccount = new System.Windows.Forms.Label();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.CHbxLogShowPass = new System.Windows.Forms.CheckBox();
            this.txtbLogPassword = new System.Windows.Forms.TextBox();
            this.Llogpassword = new System.Windows.Forms.Label();
            this.Llogusername = new System.Windows.Forms.Label();
            this.Llogin = new System.Windows.Forms.Label();
            this.txtbLogUsername = new System.Windows.Forms.TextBox();
            this.ButtonForgetPass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LcreateAccount
            // 
            this.LcreateAccount.AutoSize = true;
            this.LcreateAccount.BackColor = System.Drawing.Color.White;
            this.LcreateAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LcreateAccount.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LcreateAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LcreateAccount.Location = new System.Drawing.Point(527, 315);
            this.LcreateAccount.Name = "LcreateAccount";
            this.LcreateAccount.Size = new System.Drawing.Size(182, 25);
            this.LcreateAccount.TabIndex = 24;
            this.LcreateAccount.Text = "Create Account";
            this.LcreateAccount.Click += new System.EventHandler(this.LcreateAccount_Click);
            // 
            // LdontHaveAccount
            // 
            this.LdontHaveAccount.AutoSize = true;
            this.LdontHaveAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LdontHaveAccount.Location = new System.Drawing.Point(313, 319);
            this.LdontHaveAccount.Name = "LdontHaveAccount";
            this.LdontHaveAccount.Size = new System.Drawing.Size(193, 20);
            this.LdontHaveAccount.TabIndex = 23;
            this.LdontHaveAccount.Text = "Don\'t Have An Account?";
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonLogin.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLogin.ForeColor = System.Drawing.Color.White;
            this.ButtonLogin.Location = new System.Drawing.Point(358, 250);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(130, 40);
            this.ButtonLogin.TabIndex = 22;
            this.ButtonLogin.Text = "LOGIN";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // CHbxLogShowPass
            // 
            this.CHbxLogShowPass.AutoSize = true;
            this.CHbxLogShowPass.Location = new System.Drawing.Point(502, 210);
            this.CHbxLogShowPass.Name = "CHbxLogShowPass";
            this.CHbxLogShowPass.Size = new System.Drawing.Size(125, 20);
            this.CHbxLogShowPass.TabIndex = 21;
            this.CHbxLogShowPass.Text = "Show Password";
            this.CHbxLogShowPass.UseVisualStyleBackColor = true;
            this.CHbxLogShowPass.CheckedChanged += new System.EventHandler(this.CHbxLogShowPass_CheckedChanged);
            // 
            // txtbLogPassword
            // 
            this.txtbLogPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtbLogPassword.Location = new System.Drawing.Point(389, 158);
            this.txtbLogPassword.Multiline = true;
            this.txtbLogPassword.Name = "txtbLogPassword";
            this.txtbLogPassword.PasswordChar = '*';
            this.txtbLogPassword.Size = new System.Drawing.Size(160, 22);
            this.txtbLogPassword.TabIndex = 18;
            // 
            // Llogpassword
            // 
            this.Llogpassword.AutoSize = true;
            this.Llogpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Llogpassword.Location = new System.Drawing.Point(214, 155);
            this.Llogpassword.Name = "Llogpassword";
            this.Llogpassword.Size = new System.Drawing.Size(98, 25);
            this.Llogpassword.TabIndex = 17;
            this.Llogpassword.Text = "Password";
            // 
            // Llogusername
            // 
            this.Llogusername.AutoSize = true;
            this.Llogusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Llogusername.Location = new System.Drawing.Point(214, 97);
            this.Llogusername.Name = "Llogusername";
            this.Llogusername.Size = new System.Drawing.Size(102, 25);
            this.Llogusername.TabIndex = 16;
            this.Llogusername.Text = "Email";
            // 
            // Llogin
            // 
            this.Llogin.AutoSize = true;
            this.Llogin.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Llogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Llogin.Location = new System.Drawing.Point(338, 37);
            this.Llogin.Name = "Llogin";
            this.Llogin.Size = new System.Drawing.Size(79, 28);
            this.Llogin.TabIndex = 15;
            this.Llogin.Text = "Login";
            // 
            // txtbLogUsername
            // 
            this.txtbLogUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtbLogUsername.Location = new System.Drawing.Point(389, 100);
            this.txtbLogUsername.Multiline = true;
            this.txtbLogUsername.Name = "txtbLogUsername";
            this.txtbLogUsername.Size = new System.Drawing.Size(160, 22);
            this.txtbLogUsername.TabIndex = 14;
            this.txtbLogUsername.TextChanged += new System.EventHandler(this.txtbLogUsername_TextChanged);
            // 
            // ButtonForgetPass
            // 
            this.ButtonForgetPass.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonForgetPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonForgetPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonForgetPass.Location = new System.Drawing.Point(307, 366);
            this.ButtonForgetPass.Name = "ButtonForgetPass";
            this.ButtonForgetPass.Size = new System.Drawing.Size(262, 42);
            this.ButtonForgetPass.TabIndex = 25;
            this.ButtonForgetPass.Text = "Forget Password";
            this.ButtonForgetPass.UseVisualStyleBackColor = false;
            this.ButtonForgetPass.Click += new System.EventHandler(this.ButtonForgetPass_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonForgetPass);
            this.Controls.Add(this.LcreateAccount);
            this.Controls.Add(this.LdontHaveAccount);
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.CHbxLogShowPass);
            this.Controls.Add(this.txtbLogPassword);
            this.Controls.Add(this.Llogpassword);
            this.Controls.Add(this.Llogusername);
            this.Controls.Add(this.Llogin);
            this.Controls.Add(this.txtbLogUsername);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LcreateAccount;
        private System.Windows.Forms.Label LdontHaveAccount;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.CheckBox CHbxLogShowPass;
        private System.Windows.Forms.TextBox txtbLogPassword;
        private System.Windows.Forms.Label Llogpassword;
        private System.Windows.Forms.Label Llogusername;
        private System.Windows.Forms.Label Llogin;
        private System.Windows.Forms.TextBox txtbLogUsername;
        private System.Windows.Forms.Button ButtonForgetPass;
    }
}