namespace DVLD
{
    partial class ctrlCardPersonWithFilter
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
            this.filterGroupBox = new System.Windows.Forms.GroupBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.FilterCmbTextBox = new System.Windows.Forms.TextBox();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlCardPerson1 = new DVLD.ctrlCardPerson();
            this.filterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterGroupBox
            // 
            this.filterGroupBox.Controls.Add(this.btnAddPerson);
            this.filterGroupBox.Controls.Add(this.btnSearch);
            this.filterGroupBox.Controls.Add(this.FilterCmbTextBox);
            this.filterGroupBox.Controls.Add(this.FilterComboBox);
            this.filterGroupBox.Controls.Add(this.label1);
            this.filterGroupBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterGroupBox.Location = new System.Drawing.Point(3, 0);
            this.filterGroupBox.Name = "filterGroupBox";
            this.filterGroupBox.Size = new System.Drawing.Size(776, 73);
            this.filterGroupBox.TabIndex = 4;
            this.filterGroupBox.TabStop = false;
            this.filterGroupBox.Text = "Filter";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = global::DVLD.Properties.Resources.AddPerson_321;
            this.btnAddPerson.Location = new System.Drawing.Point(439, 21);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(41, 37);
            this.btnAddPerson.TabIndex = 27;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::DVLD.Properties.Resources.SearchPerson;
            this.btnSearch.Location = new System.Drawing.Point(392, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(41, 37);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FilterCmbTextBox
            // 
            this.FilterCmbTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterCmbTextBox.Location = new System.Drawing.Point(246, 27);
            this.FilterCmbTextBox.Name = "FilterCmbTextBox";
            this.FilterCmbTextBox.Size = new System.Drawing.Size(140, 25);
            this.FilterCmbTextBox.TabIndex = 25;
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.BackColor = System.Drawing.SystemColors.Control;
            this.FilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterComboBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Items.AddRange(new object[] {
            "PersonID",
            "NationalNo"});
            this.FilterComboBox.Location = new System.Drawing.Point(100, 27);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(140, 25);
            this.FilterComboBox.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Find By:";
            // 
            // ctrlCardPerson1
            // 
            this.ctrlCardPerson1.Location = new System.Drawing.Point(3, 79);
            this.ctrlCardPerson1.Name = "ctrlCardPerson1";
            this.ctrlCardPerson1.Size = new System.Drawing.Size(791, 267);
            this.ctrlCardPerson1.TabIndex = 28;
            // 
            // ctrlCardPersonWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlCardPerson1);
            this.Controls.Add(this.filterGroupBox);
            this.Name = "ctrlCardPersonWithFilter";
            this.Size = new System.Drawing.Size(785, 340);
            this.filterGroupBox.ResumeLayout(false);
            this.filterGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox filterGroupBox;
        private System.Windows.Forms.TextBox FilterCmbTextBox;
        private System.Windows.Forms.ComboBox FilterComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddPerson;
        private ctrlCardPerson ctrlCardPerson1;
    }
}
