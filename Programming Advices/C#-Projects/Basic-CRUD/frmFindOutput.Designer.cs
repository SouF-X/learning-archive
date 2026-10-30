namespace MyOwnContactsWinForms
{
    partial class frmFindOutput
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
            this.lblFindMessage = new System.Windows.Forms.Label();
            this.EditFindBTN = new System.Windows.Forms.Button();
            this.DeleteFindBTN = new System.Windows.Forms.Button();
            this.CancelFindBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFindMessage
            // 
            this.lblFindMessage.AutoSize = true;
            this.lblFindMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindMessage.Location = new System.Drawing.Point(12, 19);
            this.lblFindMessage.Name = "lblFindMessage";
            this.lblFindMessage.Size = new System.Drawing.Size(239, 21);
            this.lblFindMessage.TabIndex = 0;
            this.lblFindMessage.Text = "Contact ID Found Successfully";
            this.lblFindMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EditFindBTN
            // 
            this.EditFindBTN.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditFindBTN.Location = new System.Drawing.Point(6, 59);
            this.EditFindBTN.Name = "EditFindBTN";
            this.EditFindBTN.Size = new System.Drawing.Size(87, 31);
            this.EditFindBTN.TabIndex = 1;
            this.EditFindBTN.Text = "Edit";
            this.EditFindBTN.UseVisualStyleBackColor = true;
            this.EditFindBTN.Click += new System.EventHandler(this.EditFindBTN_Click);
            // 
            // DeleteFindBTN
            // 
            this.DeleteFindBTN.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteFindBTN.Location = new System.Drawing.Point(99, 59);
            this.DeleteFindBTN.Name = "DeleteFindBTN";
            this.DeleteFindBTN.Size = new System.Drawing.Size(87, 31);
            this.DeleteFindBTN.TabIndex = 2;
            this.DeleteFindBTN.Text = "Delete";
            this.DeleteFindBTN.UseVisualStyleBackColor = true;
            this.DeleteFindBTN.Click += new System.EventHandler(this.DeleteFindBTN_Click);
            // 
            // CancelFindBTN
            // 
            this.CancelFindBTN.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelFindBTN.Location = new System.Drawing.Point(192, 59);
            this.CancelFindBTN.Name = "CancelFindBTN";
            this.CancelFindBTN.Size = new System.Drawing.Size(87, 31);
            this.CancelFindBTN.TabIndex = 3;
            this.CancelFindBTN.Text = "Cancel";
            this.CancelFindBTN.UseVisualStyleBackColor = true;
            this.CancelFindBTN.Click += new System.EventHandler(this.CancelFindBTN_Click);
            // 
            // frmFindOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.CancelFindBTN);
            this.Controls.Add(this.DeleteFindBTN);
            this.Controls.Add(this.EditFindBTN);
            this.Controls.Add(this.lblFindMessage);
            this.Name = "frmFindOutput";
            this.Text = "CONTACT FOUND";
            this.Load += new System.EventHandler(this.frmFindOutput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFindMessage;
        private System.Windows.Forms.Button EditFindBTN;
        private System.Windows.Forms.Button DeleteFindBTN;
        private System.Windows.Forms.Button CancelFindBTN;
    }
}