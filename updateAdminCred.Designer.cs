namespace member_space
{
    partial class updateAdminCred
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
            this.updateButton = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelAConfPass = new System.Windows.Forms.Label();
            this.textBoxAConfPass = new System.Windows.Forms.TextBox();
            this.chbxAShowPass = new System.Windows.Forms.CheckBox();
            this.labelAback = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.updateButton.ForeColor = System.Drawing.Color.White;
            this.updateButton.Location = new System.Drawing.Point(417, 316);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(103, 55);
            this.updateButton.TabIndex = 0;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.textBoxEmail.Location = new System.Drawing.Point(439, 69);
            this.textBoxEmail.Multiline = true;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(158, 29);
            this.textBoxEmail.TabIndex = 1;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // textBoxPass
            // 
            this.textBoxPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.textBoxPass.Location = new System.Drawing.Point(439, 148);
            this.textBoxPass.Multiline = true;
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(158, 32);
            this.textBoxPass.TabIndex = 2;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelEmail.Location = new System.Drawing.Point(246, 69);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(124, 29);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "Username";
            this.labelEmail.Click += new System.EventHandler(this.labelEmail_Click);
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelPass.Location = new System.Drawing.Point(217, 141);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(120, 29);
            this.labelPass.TabIndex = 4;
            this.labelPass.Text = "Password";
            // 
            // labelAConfPass
            // 
            this.labelAConfPass.AutoSize = true;
            this.labelAConfPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelAConfPass.Location = new System.Drawing.Point(127, 226);
            this.labelAConfPass.Name = "labelAConfPass";
            this.labelAConfPass.Size = new System.Drawing.Size(210, 29);
            this.labelAConfPass.TabIndex = 5;
            this.labelAConfPass.Text = "Confirm Password";
            // 
            // textBoxAConfPass
            // 
            this.textBoxAConfPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.textBoxAConfPass.Location = new System.Drawing.Point(439, 226);
            this.textBoxAConfPass.Multiline = true;
            this.textBoxAConfPass.Name = "textBoxAConfPass";
            this.textBoxAConfPass.Size = new System.Drawing.Size(158, 32);
            this.textBoxAConfPass.TabIndex = 6;
            // 
            // chbxAShowPass
            // 
            this.chbxAShowPass.AutoSize = true;
            this.chbxAShowPass.Location = new System.Drawing.Point(602, 292);
            this.chbxAShowPass.Name = "chbxAShowPass";
            this.chbxAShowPass.Size = new System.Drawing.Size(125, 20);
            this.chbxAShowPass.TabIndex = 11;
            this.chbxAShowPass.Text = "Show Password";
            this.chbxAShowPass.UseVisualStyleBackColor = true;
            this.chbxAShowPass.CheckedChanged += new System.EventHandler(this.chbxAShowPass_CheckedChanged);
            // 
            // labelAback
            // 
            this.labelAback.AutoSize = true;
            this.labelAback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.labelAback.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelAback.Location = new System.Drawing.Point(413, 391);
            this.labelAback.Name = "labelAback";
            this.labelAback.Size = new System.Drawing.Size(112, 20);
            this.labelAback.TabIndex = 12;
            this.labelAback.Text = "Back to Login";
            // 
            // updateAdminCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 444);
            this.Controls.Add(this.labelAback);
            this.Controls.Add(this.chbxAShowPass);
            this.Controls.Add(this.textBoxAConfPass);
            this.Controls.Add(this.labelAConfPass);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.updateButton);
            this.Name = "updateAdminCred";
            this.Text = "updateAdminCred";
            this.Load += new System.EventHandler(this.updateAdminCred_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelAConfPass;
        private System.Windows.Forms.TextBox textBoxAConfPass;
        private System.Windows.Forms.CheckBox chbxAShowPass;
        private System.Windows.Forms.Label labelAback;
    }
}