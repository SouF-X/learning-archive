namespace Login_Form
{
    partial class RegisterForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.FullName_txtBox = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.Email_txtBox = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.Password_txtBox = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.ConfirmPassword_txtBox = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.lblCheckAccount = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(299, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create a new Account";
            // 
            // FullName_txtBox
            // 
            this.FullName_txtBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FullName_txtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FullName_txtBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullName_txtBox.ForeColor = System.Drawing.Color.DimGray;
            this.FullName_txtBox.Location = new System.Drawing.Point(36, 100);
            this.FullName_txtBox.Multiline = true;
            this.FullName_txtBox.Name = "FullName_txtBox";
            this.FullName_txtBox.Size = new System.Drawing.Size(300, 25);
            this.FullName_txtBox.TabIndex = 1;
            this.FullName_txtBox.Validating += new System.ComponentModel.CancelEventHandler(this.FullName_Validating);
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblFullName.Location = new System.Drawing.Point(33, 70);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(78, 18);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Full Name";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblEmail.Location = new System.Drawing.Point(33, 150);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 18);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email";
            // 
            // Email_txtBox
            // 
            this.Email_txtBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Email_txtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Email_txtBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_txtBox.ForeColor = System.Drawing.Color.DimGray;
            this.Email_txtBox.Location = new System.Drawing.Point(36, 180);
            this.Email_txtBox.Multiline = true;
            this.Email_txtBox.Name = "Email_txtBox";
            this.Email_txtBox.Size = new System.Drawing.Size(300, 25);
            this.Email_txtBox.TabIndex = 2;
            this.Email_txtBox.Validating += new System.ComponentModel.CancelEventHandler(this.Email_Validating);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblPassword.Location = new System.Drawing.Point(33, 230);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 18);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            // 
            // Password_txtBox
            // 
            this.Password_txtBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Password_txtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password_txtBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_txtBox.ForeColor = System.Drawing.Color.DimGray;
            this.Password_txtBox.Location = new System.Drawing.Point(36, 260);
            this.Password_txtBox.Multiline = true;
            this.Password_txtBox.Name = "Password_txtBox";
            this.Password_txtBox.PasswordChar = '*';
            this.Password_txtBox.Size = new System.Drawing.Size(300, 25);
            this.Password_txtBox.TabIndex = 3;
            this.Password_txtBox.Validating += new System.ComponentModel.CancelEventHandler(this.Password_Validating);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(33, 310);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(137, 18);
            this.lblConfirmPassword.TabIndex = 7;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // ConfirmPassword_txtBox
            // 
            this.ConfirmPassword_txtBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ConfirmPassword_txtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfirmPassword_txtBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPassword_txtBox.ForeColor = System.Drawing.Color.DimGray;
            this.ConfirmPassword_txtBox.Location = new System.Drawing.Point(36, 340);
            this.ConfirmPassword_txtBox.Multiline = true;
            this.ConfirmPassword_txtBox.Name = "ConfirmPassword_txtBox";
            this.ConfirmPassword_txtBox.PasswordChar = '*';
            this.ConfirmPassword_txtBox.Size = new System.Drawing.Size(300, 25);
            this.ConfirmPassword_txtBox.TabIndex = 4;
            this.ConfirmPassword_txtBox.Validating += new System.ComponentModel.CancelEventHandler(this.ConfirmPassword_Validating);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(36, 430);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(120, 50);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Continue";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox.Location = new System.Drawing.Point(36, 390);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(231, 20);
            this.checkBox.TabIndex = 5;
            this.checkBox.Text = "I agree to the Terms and Conditions";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // lblCheckAccount
            // 
            this.lblCheckAccount.AutoSize = true;
            this.lblCheckAccount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckAccount.Location = new System.Drawing.Point(36, 500);
            this.lblCheckAccount.Name = "lblCheckAccount";
            this.lblCheckAccount.Size = new System.Drawing.Size(186, 18);
            this.lblCheckAccount.TabIndex = 11;
            this.lblCheckAccount.Text = "Already have an account?";
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel.Location = new System.Drawing.Point(218, 500);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(85, 18);
            this.linkLabel.TabIndex = 7;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Login Here";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(434, 551);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.lblCheckAccount);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.ConfirmPassword_txtBox);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.Password_txtBox);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.Email_txtBox);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.FullName_txtBox);
            this.Controls.Add(this.lblTitle);
            this.Name = "RegisterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Join Us";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox FullName_txtBox;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox Email_txtBox;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox Password_txtBox;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox ConfirmPassword_txtBox;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label lblCheckAccount;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}