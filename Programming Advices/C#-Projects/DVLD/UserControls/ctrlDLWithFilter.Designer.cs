namespace DVLD
{
    partial class ctrlDLWithFilter
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
            this.FilterBox = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.ctrlDriverInfo = new DVLD.ctrlDriverInfo();
            this.FilterBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilterBox
            // 
            this.FilterBox.Controls.Add(this.btnSearch);
            this.FilterBox.Controls.Add(this.txtBox);
            this.FilterBox.Controls.Add(this.label19);
            this.FilterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterBox.Location = new System.Drawing.Point(3, 3);
            this.FilterBox.Name = "FilterBox";
            this.FilterBox.Size = new System.Drawing.Size(624, 100);
            this.FilterBox.TabIndex = 1;
            this.FilterBox.TabStop = false;
            this.FilterBox.Text = "Filtre";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::DVLD.Properties.Resources.License_View_32;
            this.btnSearch.Location = new System.Drawing.Point(508, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 55);
            this.btnSearch.TabIndex = 102;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(118, 42);
            this.txtBox.Multiline = true;
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(348, 31);
            this.txtBox.TabIndex = 101;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(25, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 21);
            this.label19.TabIndex = 100;
            this.label19.Text = "LicenseID:";
            // 
            // ctrlDriverInfo
            // 
            this.ctrlDriverInfo.Location = new System.Drawing.Point(3, 109);
            this.ctrlDriverInfo.Name = "ctrlDriverInfo";
            this.ctrlDriverInfo.Size = new System.Drawing.Size(809, 307);
            this.ctrlDriverInfo.TabIndex = 103;
            // 
            // ctrlDLWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlDriverInfo);
            this.Controls.Add(this.FilterBox);
            this.Name = "ctrlDLWithFilter";
            this.Size = new System.Drawing.Size(815, 394);
            this.FilterBox.ResumeLayout(false);
            this.FilterBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox FilterBox;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Label label19;
        private ctrlDriverInfo ctrlDriverInfo;
    }
}
