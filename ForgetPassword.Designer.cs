namespace member_space
{
    partial class ForgetPassword
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
            this.lFPusername = new System.Windows.Forms.Label();
            this.comboBfpSequrityQues = new System.Windows.Forms.ComboBox();
            this.LselectSecurityQues = new System.Windows.Forms.Label();
            this.Lanswer = new System.Windows.Forms.Label();
            this.textBfpAnswer = new System.Windows.Forms.TextBox();
            this.textBfpUsername = new System.Windows.Forms.TextBox();
            this.BfpSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lFPusername
            // 
            this.lFPusername.AutoSize = true;
            this.lFPusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFPusername.Location = new System.Drawing.Point(244, 100);
            this.lFPusername.Name = "lFPusername";
            this.lFPusername.Size = new System.Drawing.Size(102, 25);
            this.lFPusername.TabIndex = 0;
            this.lFPusername.Text = "Email";
            // 
            // comboBfpSequrityQues
            // 
            this.comboBfpSequrityQues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBfpSequrityQues.ForeColor = System.Drawing.Color.White;
            this.comboBfpSequrityQues.FormattingEnabled = true;
            this.comboBfpSequrityQues.Items.AddRange(new object[] {
            "Nmae of the city you were born in?",
            "Name of the first school you went to?",
            "Nmae of your first pet?"});
            this.comboBfpSequrityQues.Location = new System.Drawing.Point(420, 169);
            this.comboBfpSequrityQues.Name = "comboBfpSequrityQues";
            this.comboBfpSequrityQues.Size = new System.Drawing.Size(216, 24);
            this.comboBfpSequrityQues.TabIndex = 1;
            this.comboBfpSequrityQues.SelectedIndexChanged += new System.EventHandler(this.comboBfpSequrityQues_SelectedIndexChanged);
            // 
            // LselectSecurityQues
            // 
            this.LselectSecurityQues.AutoSize = true;
            this.LselectSecurityQues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LselectSecurityQues.Location = new System.Drawing.Point(73, 168);
            this.LselectSecurityQues.Name = "LselectSecurityQues";
            this.LselectSecurityQues.Size = new System.Drawing.Size(273, 25);
            this.LselectSecurityQues.TabIndex = 2;
            this.LselectSecurityQues.Text = "Select Your Security Question";
            // 
            // Lanswer
            // 
            this.Lanswer.AutoSize = true;
            this.Lanswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lanswer.Location = new System.Drawing.Point(268, 233);
            this.Lanswer.Name = "Lanswer";
            this.Lanswer.Size = new System.Drawing.Size(78, 25);
            this.Lanswer.TabIndex = 3;
            this.Lanswer.Text = "Answer";
            // 
            // textBfpAnswer
            // 
            this.textBfpAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.textBfpAnswer.Location = new System.Drawing.Point(420, 233);
            this.textBfpAnswer.Multiline = true;
            this.textBfpAnswer.Name = "textBfpAnswer";
            this.textBfpAnswer.Size = new System.Drawing.Size(216, 22);
            this.textBfpAnswer.TabIndex = 4;
            this.textBfpAnswer.TextChanged += new System.EventHandler(this.textBfpAnswer_TextChanged);
            // 
            // textBfpUsername
            // 
            this.textBfpUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.textBfpUsername.Location = new System.Drawing.Point(420, 102);
            this.textBfpUsername.Multiline = true;
            this.textBfpUsername.Name = "textBfpUsername";
            this.textBfpUsername.Size = new System.Drawing.Size(216, 23);
            this.textBfpUsername.TabIndex = 5;
            this.textBfpUsername.TextChanged += new System.EventHandler(this.textBfpUsername_TextChanged);
            // 
            // BfpSubmit
            // 
            this.BfpSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BfpSubmit.Location = new System.Drawing.Point(633, 313);
            this.BfpSubmit.Name = "BfpSubmit";
            this.BfpSubmit.Size = new System.Drawing.Size(108, 35);
            this.BfpSubmit.TabIndex = 6;
            this.BfpSubmit.Text = "Submit";
            this.BfpSubmit.UseVisualStyleBackColor = false;
            this.BfpSubmit.Click += new System.EventHandler(this.BfpSubmit_Click);
            // 
            // ForgetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BfpSubmit);
            this.Controls.Add(this.textBfpUsername);
            this.Controls.Add(this.textBfpAnswer);
            this.Controls.Add(this.Lanswer);
            this.Controls.Add(this.LselectSecurityQues);
            this.Controls.Add(this.comboBfpSequrityQues);
            this.Controls.Add(this.lFPusername);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ForgetPassword";
            this.Text = "ForgetPassword";
            this.Load += new System.EventHandler(this.ForgetPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lFPusername;
        private System.Windows.Forms.ComboBox comboBfpSequrityQues;
        private System.Windows.Forms.Label LselectSecurityQues;
        private System.Windows.Forms.Label Lanswer;
        private System.Windows.Forms.TextBox textBfpAnswer;
        private System.Windows.Forms.TextBox textBfpUsername;
        private System.Windows.Forms.Button BfpSubmit;
    }
}