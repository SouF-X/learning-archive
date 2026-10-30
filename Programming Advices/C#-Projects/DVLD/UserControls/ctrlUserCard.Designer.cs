namespace DVLD
{
    partial class ctrlUserCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginInfoBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblisActive = new System.Windows.Forms.Label();
            this.ctrlCardPerson1 = new DVLD.ctrlCardPerson();
            this.LoginInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginInfoBox
            // 
            this.LoginInfoBox.Controls.Add(this.lblisActive);
            this.LoginInfoBox.Controls.Add(this.lblUserName);
            this.LoginInfoBox.Controls.Add(this.lblUserID);
            this.LoginInfoBox.Controls.Add(this.label3);
            this.LoginInfoBox.Controls.Add(this.label1);
            this.LoginInfoBox.Controls.Add(this.label2);
            this.LoginInfoBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginInfoBox.Location = new System.Drawing.Point(3, 267);
            this.LoginInfoBox.Name = "LoginInfoBox";
            this.LoginInfoBox.Size = new System.Drawing.Size(777, 74);
            this.LoginInfoBox.TabIndex = 1;
            this.LoginInfoBox.TabStop = false;
            this.LoginInfoBox.Text = "Login Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "User ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "UserName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(579, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Is Active:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(162, 36);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(42, 17);
            this.lblUserID.TabIndex = 7;
            this.lblUserID.Text = "[????]";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(398, 35);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(42, 17);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "[????]";
            // 
            // lblisActive
            // 
            this.lblisActive.AutoSize = true;
            this.lblisActive.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblisActive.Location = new System.Drawing.Point(663, 36);
            this.lblisActive.Name = "lblisActive";
            this.lblisActive.Size = new System.Drawing.Size(42, 17);
            this.lblisActive.TabIndex = 9;
            this.lblisActive.Text = "[????]";
            // 
            // ctrlCardPerson1
            // 
            this.ctrlCardPerson1.Location = new System.Drawing.Point(3, 3);
            this.ctrlCardPerson1.Name = "ctrlCardPerson1";
            this.ctrlCardPerson1.Size = new System.Drawing.Size(780, 258);
            this.ctrlCardPerson1.TabIndex = 0;
            // 
            // ctrlUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoginInfoBox);
            this.Controls.Add(this.ctrlCardPerson1);
            this.Name = "ctrlUserCard";
            this.Size = new System.Drawing.Size(785, 344);
            this.LoginInfoBox.ResumeLayout(false);
            this.LoginInfoBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlCardPerson ctrlCardPerson1;
        private System.Windows.Forms.GroupBox LoginInfoBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblisActive;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserID;
    }
}
