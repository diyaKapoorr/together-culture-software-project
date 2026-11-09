namespace member_space
{
    partial class ChangePassword
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
            this.LcpNewPass = new System.Windows.Forms.Label();
            this.LcpConfirmPass = new System.Windows.Forms.Label();
            this.textBcpNewPass = new System.Windows.Forms.TextBox();
            this.textBcpConfirmPass = new System.Windows.Forms.TextBox();
            this.BcpBacktoLogin = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.chbxCPShowPass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LcpNewPass
            // 
            this.LcpNewPass.AutoSize = true;
            this.LcpNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LcpNewPass.Location = new System.Drawing.Point(127, 96);
            this.LcpNewPass.Name = "LcpNewPass";
            this.LcpNewPass.Size = new System.Drawing.Size(176, 29);
            this.LcpNewPass.TabIndex = 0;
            this.LcpNewPass.Text = "New Password";
            // 
            // LcpConfirmPass
            // 
            this.LcpConfirmPass.AutoSize = true;
            this.LcpConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LcpConfirmPass.Location = new System.Drawing.Point(93, 193);
            this.LcpConfirmPass.Name = "LcpConfirmPass";
            this.LcpConfirmPass.Size = new System.Drawing.Size(210, 29);
            this.LcpConfirmPass.TabIndex = 1;
            this.LcpConfirmPass.Text = "Confirm Password";
            // 
            // textBcpNewPass
            // 
            this.textBcpNewPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.textBcpNewPass.Location = new System.Drawing.Point(388, 103);
            this.textBcpNewPass.Name = "textBcpNewPass";
            this.textBcpNewPass.Size = new System.Drawing.Size(181, 22);
            this.textBcpNewPass.TabIndex = 2;
            this.textBcpNewPass.TextChanged += new System.EventHandler(this.textBcpNewPass_TextChanged);
            // 
            // textBcpConfirmPass
            // 
            this.textBcpConfirmPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.textBcpConfirmPass.Location = new System.Drawing.Point(388, 200);
            this.textBcpConfirmPass.Name = "textBcpConfirmPass";
            this.textBcpConfirmPass.Size = new System.Drawing.Size(181, 22);
            this.textBcpConfirmPass.TabIndex = 3;
            this.textBcpConfirmPass.TextChanged += new System.EventHandler(this.textBcpConfirmPass_TextChanged);
            // 
            // BcpBacktoLogin
            // 
            this.BcpBacktoLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BcpBacktoLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BcpBacktoLogin.ForeColor = System.Drawing.Color.White;
            this.BcpBacktoLogin.Location = new System.Drawing.Point(364, 364);
            this.BcpBacktoLogin.Name = "BcpBacktoLogin";
            this.BcpBacktoLogin.Size = new System.Drawing.Size(188, 46);
            this.BcpBacktoLogin.TabIndex = 4;
            this.BcpBacktoLogin.Text = "Back To Login";
            this.BcpBacktoLogin.UseVisualStyleBackColor = false;
            this.BcpBacktoLogin.Click += new System.EventHandler(this.BcpBacktoLogin_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.ForeColor = System.Drawing.Color.White;
            this.confirmButton.Location = new System.Drawing.Point(388, 284);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(164, 54);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "confirm";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // chbxCPShowPass
            // 
            this.chbxCPShowPass.AutoSize = true;
            this.chbxCPShowPass.Location = new System.Drawing.Point(594, 253);
            this.chbxCPShowPass.Name = "chbxCPShowPass";
            this.chbxCPShowPass.Size = new System.Drawing.Size(125, 20);
            this.chbxCPShowPass.TabIndex = 12;
            this.chbxCPShowPass.Text = "Show Password";
            this.chbxCPShowPass.UseVisualStyleBackColor = true;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chbxCPShowPass);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.BcpBacktoLogin);
            this.Controls.Add(this.textBcpConfirmPass);
            this.Controls.Add(this.textBcpNewPass);
            this.Controls.Add(this.LcpConfirmPass);
            this.Controls.Add(this.LcpNewPass);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LcpNewPass;
        private System.Windows.Forms.Label LcpConfirmPass;
        private System.Windows.Forms.TextBox textBcpNewPass;
        private System.Windows.Forms.TextBox textBcpConfirmPass;
        private System.Windows.Forms.Button BcpBacktoLogin;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.CheckBox chbxCPShowPass;
    }
}