namespace DVLD
{
    partial class frmAddUpdatePerson
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
            this.components = new System.ComponentModel.Container();
            this.llOpenFileDialog = new System.Windows.Forms.LinkLabel();
            this.AddressTxtBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.EmailTxtBox = new System.Windows.Forms.TextBox();
            this.DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PhoneTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rdBtnFemale = new System.Windows.Forms.RadioButton();
            this.rdBtnMale = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.NationalNoTxtBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SecondNameTxtBox = new System.Windows.Forms.TextBox();
            this.ThirdNameTxtBox = new System.Windows.Forms.TextBox();
            this.LastNameTxtBox = new System.Windows.Forms.TextBox();
            this.FirstNameTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.PersonIDLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Icon8 = new System.Windows.Forms.PictureBox();
            this.llRemoveImage = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.Icon10 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Icon9 = new System.Windows.Forms.PictureBox();
            this.Icon7 = new System.Windows.Forms.PictureBox();
            this.Icon6 = new System.Windows.Forms.PictureBox();
            this.Icon4 = new System.Windows.Forms.PictureBox();
            this.Icon3 = new System.Windows.Forms.PictureBox();
            this.Icon5 = new System.Windows.Forms.PictureBox();
            this.Icon2 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Icon1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon1)).BeginInit();
            this.SuspendLayout();
            // 
            // llOpenFileDialog
            // 
            this.llOpenFileDialog.AutoSize = true;
            this.llOpenFileDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llOpenFileDialog.Location = new System.Drawing.Point(702, 227);
            this.llOpenFileDialog.Name = "llOpenFileDialog";
            this.llOpenFileDialog.Size = new System.Drawing.Size(68, 16);
            this.llOpenFileDialog.TabIndex = 13;
            this.llOpenFileDialog.TabStop = true;
            this.llOpenFileDialog.Text = "Set Image";
            this.llOpenFileDialog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOpenFileDialog_LinkClicked);
            // 
            // AddressTxtBox
            // 
            this.AddressTxtBox.Location = new System.Drawing.Point(168, 180);
            this.AddressTxtBox.Multiline = true;
            this.AddressTxtBox.Name = "AddressTxtBox";
            this.AddressTxtBox.Size = new System.Drawing.Size(463, 83);
            this.AddressTxtBox.TabIndex = 12;
            this.AddressTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.Address_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 21);
            this.label13.TabIndex = 40;
            this.label13.Text = "Address:";
            // 
            // EmailTxtBox
            // 
            this.EmailTxtBox.Location = new System.Drawing.Point(167, 149);
            this.EmailTxtBox.Name = "EmailTxtBox";
            this.EmailTxtBox.Size = new System.Drawing.Size(128, 20);
            this.EmailTxtBox.TabIndex = 10;
            this.EmailTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.Email_Validating);
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateOfBirth.Location = new System.Drawing.Point(503, 82);
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Size = new System.Drawing.Size(125, 20);
            this.DateOfBirth.TabIndex = 6;
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(503, 147);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(128, 21);
            this.cbCountry.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(387, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 21);
            this.label8.TabIndex = 34;
            this.label8.Text = "Country:";
            // 
            // PhoneTxtBox
            // 
            this.PhoneTxtBox.Location = new System.Drawing.Point(503, 114);
            this.PhoneTxtBox.Name = "PhoneTxtBox";
            this.PhoneTxtBox.Size = new System.Drawing.Size(128, 20);
            this.PhoneTxtBox.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(400, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 21);
            this.label7.TabIndex = 31;
            this.label7.Text = "Phone:";
            // 
            // rdBtnFemale
            // 
            this.rdBtnFemale.AutoSize = true;
            this.rdBtnFemale.Location = new System.Drawing.Point(248, 121);
            this.rdBtnFemale.Name = "rdBtnFemale";
            this.rdBtnFemale.Size = new System.Drawing.Size(59, 17);
            this.rdBtnFemale.TabIndex = 8;
            this.rdBtnFemale.TabStop = true;
            this.rdBtnFemale.Text = "Female";
            this.rdBtnFemale.UseVisualStyleBackColor = true;
            this.rdBtnFemale.CheckedChanged += new System.EventHandler(this.rdBtnFemale_CheckedChanged);
            // 
            // rdBtnMale
            // 
            this.rdBtnMale.AutoSize = true;
            this.rdBtnMale.Location = new System.Drawing.Point(168, 121);
            this.rdBtnMale.Name = "rdBtnMale";
            this.rdBtnMale.Size = new System.Drawing.Size(48, 17);
            this.rdBtnMale.TabIndex = 7;
            this.rdBtnMale.TabStop = true;
            this.rdBtnMale.Text = "Male";
            this.rdBtnMale.UseVisualStyleBackColor = true;
            this.rdBtnMale.CheckedChanged += new System.EventHandler(this.rdBtnMale_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(351, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 21);
            this.label6.TabIndex = 23;
            this.label6.Text = "Date Of Birth:";
            // 
            // NationalNoTxtBox
            // 
            this.NationalNoTxtBox.Location = new System.Drawing.Point(167, 82);
            this.NationalNoTxtBox.Name = "NationalNoTxtBox";
            this.NationalNoTxtBox.Size = new System.Drawing.Size(128, 20);
            this.NationalNoTxtBox.TabIndex = 5;
            this.NationalNoTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.NationalNo_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(371, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "Second";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(540, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Third";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(715, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Last";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(205, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "First";
            // 
            // SecondNameTxtBox
            // 
            this.SecondNameTxtBox.Location = new System.Drawing.Point(335, 50);
            this.SecondNameTxtBox.Name = "SecondNameTxtBox";
            this.SecondNameTxtBox.Size = new System.Drawing.Size(128, 20);
            this.SecondNameTxtBox.TabIndex = 2;
            this.SecondNameTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.SecondName_Validating);
            // 
            // ThirdNameTxtBox
            // 
            this.ThirdNameTxtBox.Location = new System.Drawing.Point(503, 50);
            this.ThirdNameTxtBox.Name = "ThirdNameTxtBox";
            this.ThirdNameTxtBox.Size = new System.Drawing.Size(128, 20);
            this.ThirdNameTxtBox.TabIndex = 3;
            this.ThirdNameTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.ThirdName_Validating);
            // 
            // LastNameTxtBox
            // 
            this.LastNameTxtBox.Location = new System.Drawing.Point(672, 50);
            this.LastNameTxtBox.Name = "LastNameTxtBox";
            this.LastNameTxtBox.Size = new System.Drawing.Size(128, 20);
            this.LastNameTxtBox.TabIndex = 4;
            this.LastNameTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.LastName_Validating);
            // 
            // FirstNameTxtBox
            // 
            this.FirstNameTxtBox.Location = new System.Drawing.Point(167, 50);
            this.FirstNameTxtBox.Name = "FirstNameTxtBox";
            this.FirstNameTxtBox.Size = new System.Drawing.Size(128, 20);
            this.FirstNameTxtBox.TabIndex = 1;
            this.FirstNameTxtBox.Validating += new System.ComponentModel.CancelEventHandler(this.FirstName_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Gender:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Natioanl No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.Red;
            this.TitleLbl.Location = new System.Drawing.Point(303, 9);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(231, 31);
            this.TitleLbl.TabIndex = 66;
            this.TitleLbl.Text = "Add New Person";
            // 
            // PersonIDLbl
            // 
            this.PersonIDLbl.AutoSize = true;
            this.PersonIDLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonIDLbl.Location = new System.Drawing.Point(186, 41);
            this.PersonIDLbl.Name = "PersonIDLbl";
            this.PersonIDLbl.Size = new System.Drawing.Size(40, 21);
            this.PersonIDLbl.TabIndex = 65;
            this.PersonIDLbl.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 63;
            this.label1.Text = "Person ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Icon8);
            this.groupBox1.Controls.Add(this.llRemoveImage);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.llOpenFileDialog);
            this.groupBox1.Controls.Add(this.Icon10);
            this.groupBox1.Controls.Add(this.AddressTxtBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.EmailTxtBox);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.Icon9);
            this.groupBox1.Controls.Add(this.DateOfBirth);
            this.groupBox1.Controls.Add(this.cbCountry);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Icon7);
            this.groupBox1.Controls.Add(this.PhoneTxtBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.rdBtnFemale);
            this.groupBox1.Controls.Add(this.Icon6);
            this.groupBox1.Controls.Add(this.rdBtnMale);
            this.groupBox1.Controls.Add(this.Icon4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NationalNoTxtBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Icon3);
            this.groupBox1.Controls.Add(this.Icon5);
            this.groupBox1.Controls.Add(this.Icon2);
            this.groupBox1.Controls.Add(this.SecondNameTxtBox);
            this.groupBox1.Controls.Add(this.ThirdNameTxtBox);
            this.groupBox1.Controls.Add(this.LastNameTxtBox);
            this.groupBox1.Controls.Add(this.FirstNameTxtBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(838, 331);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Icon8
            // 
            this.Icon8.Image = global::DVLD.Properties.Resources.Email_32;
            this.Icon8.Location = new System.Drawing.Point(131, 147);
            this.Icon8.Name = "Icon8";
            this.Icon8.Size = new System.Drawing.Size(31, 23);
            this.Icon8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon8.TabIndex = 44;
            this.Icon8.TabStop = false;
            // 
            // llRemoveImage
            // 
            this.llRemoveImage.AutoSize = true;
            this.llRemoveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llRemoveImage.Location = new System.Drawing.Point(711, 247);
            this.llRemoveImage.Name = "llRemoveImage";
            this.llRemoveImage.Size = new System.Drawing.Size(59, 16);
            this.llRemoveImage.TabIndex = 43;
            this.llRemoveImage.TabStop = true;
            this.llRemoveImage.Text = "Remove";
            this.llRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveImage_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_321;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(375, 278);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 36);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(509, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 36);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Icon10
            // 
            this.Icon10.Image = global::DVLD.Properties.Resources.Address_32;
            this.Icon10.Location = new System.Drawing.Point(130, 180);
            this.Icon10.Name = "Icon10";
            this.Icon10.Size = new System.Drawing.Size(31, 23);
            this.Icon10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon10.TabIndex = 42;
            this.Icon10.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Male_512;
            this.pictureBox1.Location = new System.Drawing.Point(672, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // Icon9
            // 
            this.Icon9.Image = global::DVLD.Properties.Resources.Country_32;
            this.Icon9.Location = new System.Drawing.Point(466, 147);
            this.Icon9.Name = "Icon9";
            this.Icon9.Size = new System.Drawing.Size(31, 23);
            this.Icon9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon9.TabIndex = 37;
            this.Icon9.TabStop = false;
            // 
            // Icon7
            // 
            this.Icon7.Image = global::DVLD.Properties.Resources.Phone_32;
            this.Icon7.Location = new System.Drawing.Point(466, 117);
            this.Icon7.Name = "Icon7";
            this.Icon7.Size = new System.Drawing.Size(31, 23);
            this.Icon7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon7.TabIndex = 33;
            this.Icon7.TabStop = false;
            // 
            // Icon6
            // 
            this.Icon6.Image = global::DVLD.Properties.Resources.Woman_32;
            this.Icon6.Location = new System.Drawing.Point(211, 117);
            this.Icon6.Name = "Icon6";
            this.Icon6.Size = new System.Drawing.Size(31, 23);
            this.Icon6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon6.TabIndex = 29;
            this.Icon6.TabStop = false;
            // 
            // Icon4
            // 
            this.Icon4.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.Icon4.Location = new System.Drawing.Point(466, 83);
            this.Icon4.Name = "Icon4";
            this.Icon4.Size = new System.Drawing.Size(31, 23);
            this.Icon4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon4.TabIndex = 25;
            this.Icon4.TabStop = false;
            // 
            // Icon3
            // 
            this.Icon3.Image = global::DVLD.Properties.Resources.Number_32;
            this.Icon3.Location = new System.Drawing.Point(130, 85);
            this.Icon3.Name = "Icon3";
            this.Icon3.Size = new System.Drawing.Size(31, 23);
            this.Icon3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon3.TabIndex = 13;
            this.Icon3.TabStop = false;
            // 
            // Icon5
            // 
            this.Icon5.Image = global::DVLD.Properties.Resources.Man_32;
            this.Icon5.Location = new System.Drawing.Point(131, 117);
            this.Icon5.Name = "Icon5";
            this.Icon5.Size = new System.Drawing.Size(31, 23);
            this.Icon5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon5.TabIndex = 12;
            this.Icon5.TabStop = false;
            // 
            // Icon2
            // 
            this.Icon2.Image = global::DVLD.Properties.Resources.Person_32;
            this.Icon2.Location = new System.Drawing.Point(130, 47);
            this.Icon2.Name = "Icon2";
            this.Icon2.Size = new System.Drawing.Size(31, 23);
            this.Icon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon2.TabIndex = 11;
            this.Icon2.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Icon1
            // 
            this.Icon1.Image = global::DVLD.Properties.Resources.Number_32;
            this.Icon1.Location = new System.Drawing.Point(140, 41);
            this.Icon1.Name = "Icon1";
            this.Icon1.Size = new System.Drawing.Size(31, 23);
            this.Icon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon1.TabIndex = 64;
            this.Icon1.TabStop = false;
            // 
            // frmAddUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 404);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.PersonIDLbl);
            this.Controls.Add(this.Icon1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAddUpdatePerson";
            this.ShowIcon = false;
            this.Text = "Add/Edit Person Info";
            this.Load += new System.EventHandler(this.frmAddUpdatePerson_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel llOpenFileDialog;
        private System.Windows.Forms.PictureBox Icon10;
        private System.Windows.Forms.TextBox AddressTxtBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox EmailTxtBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Icon9;
        private System.Windows.Forms.DateTimePicker DateOfBirth;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox Icon7;
        private System.Windows.Forms.TextBox PhoneTxtBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdBtnFemale;
        private System.Windows.Forms.PictureBox Icon6;
        private System.Windows.Forms.RadioButton rdBtnMale;
        private System.Windows.Forms.PictureBox Icon4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NationalNoTxtBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox Icon3;
        private System.Windows.Forms.PictureBox Icon5;
        private System.Windows.Forms.PictureBox Icon2;
        private System.Windows.Forms.TextBox SecondNameTxtBox;
        private System.Windows.Forms.TextBox ThirdNameTxtBox;
        private System.Windows.Forms.TextBox LastNameTxtBox;
        private System.Windows.Forms.TextBox FirstNameTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label PersonIDLbl;
        private System.Windows.Forms.PictureBox Icon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel llRemoveImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox Icon8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}