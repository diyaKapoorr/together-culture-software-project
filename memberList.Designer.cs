namespace member_space
{
    partial class memberList
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
            this.dataGridMember = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMember)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridMember
            // 
            this.dataGridMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMember.Location = new System.Drawing.Point(39, 38);
            this.dataGridMember.Name = "dataGridMember";
            this.dataGridMember.RowHeadersWidth = 51;
            this.dataGridMember.RowTemplate.Height = 24;
            this.dataGridMember.Size = new System.Drawing.Size(712, 373);
            this.dataGridMember.TabIndex = 0;
         //   this.dataGridMember.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMember);
            // 
            // memberList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridMember);
            this.Name = "memberList";
            this.Text = "MemberList";
            this.Load += new System.EventHandler(this.MemberList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMember)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridMember;
    }
}