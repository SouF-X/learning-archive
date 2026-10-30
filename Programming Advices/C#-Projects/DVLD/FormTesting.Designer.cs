namespace DVLD
{
    partial class FormTesting
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
            this.ctrlDLWithFilter1 = new DVLD.ctrlDLWithFilter();
            this.SuspendLayout();
            // 
            // ctrlDLWithFilter1
            // 
            this.ctrlDLWithFilter1.Location = new System.Drawing.Point(23, 12);
            this.ctrlDLWithFilter1.Name = "ctrlDLWithFilter1";
            this.ctrlDLWithFilter1.Size = new System.Drawing.Size(815, 539);
            this.ctrlDLWithFilter1.TabIndex = 0;
            // 
            // FormTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 594);
            this.Controls.Add(this.ctrlDLWithFilter1);
            this.Name = "FormTesting";
            this.Text = "FormTesting";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDLWithFilter ctrlDLWithFilter1;
    }
}