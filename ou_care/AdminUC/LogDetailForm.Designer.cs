namespace ou_care.AdminUC
{
    partial class LogDetailForm
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
            this.lblTime = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblEntityID = new System.Windows.Forms.Label();
            this.lblEntityType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(162, 54);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 13);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "label1";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(383, 219);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(35, 13);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "label1";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(209, 247);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(35, 13);
            this.lblAction.TabIndex = 2;
            this.lblAction.Text = "label2";
            // 
            // lblEntityID
            // 
            this.lblEntityID.AutoSize = true;
            this.lblEntityID.Location = new System.Drawing.Point(441, 311);
            this.lblEntityID.Name = "lblEntityID";
            this.lblEntityID.Size = new System.Drawing.Size(35, 13);
            this.lblEntityID.TabIndex = 3;
            this.lblEntityID.Text = "label3";
            // 
            // lblEntityType
            // 
            this.lblEntityType.AutoSize = true;
            this.lblEntityType.Location = new System.Drawing.Point(209, 296);
            this.lblEntityType.Name = "lblEntityType";
            this.lblEntityType.Size = new System.Drawing.Size(35, 13);
            this.lblEntityType.TabIndex = 4;
            this.lblEntityType.Text = "label4";
            // 
            // LogDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEntityType);
            this.Controls.Add(this.lblEntityID);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblTime);
            this.Name = "LogDetailForm";
            this.Text = "LogDetailForm";
            this.Load += new System.EventHandler(this.LogDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblEntityID;
        private System.Windows.Forms.Label lblEntityType;
    }
}