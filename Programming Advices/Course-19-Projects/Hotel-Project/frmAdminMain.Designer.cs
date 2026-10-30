/*namespace Hotel_Project
{
    partial class frmAdminMain
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
            this.managementMenuPanel = new System.Windows.Forms.Panel();
            this.lblManagementTitle = new System.Windows.Forms.Label();
            this.btnBilling = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnReservations = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.lblSystemTitle = new System.Windows.Forms.Label();
            this.btnAccount = new System.Windows.Forms.Button();
            this.lblMainMenuTitle = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.settingsMenuPanel = new System.Windows.Forms.Panel();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.mainMenuPanel = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblHotelName = new System.Windows.Forms.Label();
            this.userInfoPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.managementMenuPanel.SuspendLayout();
            this.settingsMenuPanel.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.mainMenuPanel.SuspendLayout();
            this.userInfoPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // managementMenuPanel
            // 
            this.managementMenuPanel.Controls.Add(this.lblManagementTitle);
            this.managementMenuPanel.Controls.Add(this.btnBilling);
            this.managementMenuPanel.Controls.Add(this.btnUsers);
            this.managementMenuPanel.Controls.Add(this.btnEmployees);
            this.managementMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.managementMenuPanel.Location = new System.Drawing.Point(0, 173);
            this.managementMenuPanel.Name = "managementMenuPanel";
            this.managementMenuPanel.Size = new System.Drawing.Size(260, 175);
            this.managementMenuPanel.TabIndex = 1;
            // 
            // lblManagementTitle
            // 
            this.lblManagementTitle.AutoSize = true;
            this.lblManagementTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblManagementTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(60)))));
            this.lblManagementTitle.Location = new System.Drawing.Point(25, 10);
            this.lblManagementTitle.Name = "lblManagementTitle";
            this.lblManagementTitle.Size = new System.Drawing.Size(109, 19);
            this.lblManagementTitle.TabIndex = 0;
            this.lblManagementTitle.Text = "MANAGEMENT";
            // 
            // btnBilling
            // 
            this.btnBilling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBilling.FlatAppearance.BorderSize = 0;
            this.btnBilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilling.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBilling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnBilling.Location = new System.Drawing.Point(0, 125);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnBilling.Size = new System.Drawing.Size(260, 45);
            this.btnBilling.TabIndex = 3;
            this.btnBilling.Text = "💰  Billing";
            this.btnBilling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilling.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnUsers.Location = new System.Drawing.Point(0, 80);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(260, 45);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "👤  Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEmployees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnEmployees.Location = new System.Drawing.Point(0, 35);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnEmployees.Size = new System.Drawing.Size(260, 45);
            this.btnEmployees.TabIndex = 1;
            this.btnEmployees.Text = "👨‍💼  Employees";
            this.btnEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.UseVisualStyleBackColor = true;
            // 
            // btnCustomers
            // 
            this.btnCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnCustomers.Location = new System.Drawing.Point(3, 32);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnCustomers.Size = new System.Drawing.Size(260, 45);
            this.btnCustomers.TabIndex = 4;
            this.btnCustomers.Text = "👥  Customers";
            this.btnCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.UseVisualStyleBackColor = true;
            // 
            // btnReservations
            // 
            this.btnReservations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReservations.FlatAppearance.BorderSize = 0;
            this.btnReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnReservations.Location = new System.Drawing.Point(0, 125);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnReservations.Size = new System.Drawing.Size(260, 45);
            this.btnReservations.TabIndex = 3;
            this.btnReservations.Text = "📅  Reservations";
            this.btnReservations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservations.UseVisualStyleBackColor = true;
            // 
            // btnRooms
            // 
            this.btnRooms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRooms.FlatAppearance.BorderSize = 0;
            this.btnRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRooms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRooms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnRooms.Location = new System.Drawing.Point(0, 80);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnRooms.Size = new System.Drawing.Size(260, 45);
            this.btnRooms.TabIndex = 2;
            this.btnRooms.Text = "🛏️  Rooms";
            this.btnRooms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRooms.UseVisualStyleBackColor = true;
            // 
            // lblSystemTitle
            // 
            this.lblSystemTitle.AutoSize = true;
            this.lblSystemTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSystemTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(60)))));
            this.lblSystemTitle.Location = new System.Drawing.Point(25, 10);
            this.lblSystemTitle.Name = "lblSystemTitle";
            this.lblSystemTitle.Size = new System.Drawing.Size(62, 19);
            this.lblSystemTitle.TabIndex = 0;
            this.lblSystemTitle.Text = "SYSTEM";
            // 
            // btnAccount
            // 
            this.btnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnAccount.Location = new System.Drawing.Point(0, 80);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnAccount.Size = new System.Drawing.Size(260, 45);
            this.btnAccount.TabIndex = 2;
            this.btnAccount.Text = "👤  Account";
            this.btnAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.UseVisualStyleBackColor = true;
            // 
            // lblMainMenuTitle
            // 
            this.lblMainMenuTitle.AutoSize = true;
            this.lblMainMenuTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblMainMenuTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(60)))));
            this.lblMainMenuTitle.Location = new System.Drawing.Point(25, 10);
            this.lblMainMenuTitle.Name = "lblMainMenuTitle";
            this.lblMainMenuTitle.Size = new System.Drawing.Size(92, 19);
            this.lblMainMenuTitle.TabIndex = 0;
            this.lblMainMenuTitle.Text = "MAIN MENU";
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnSettings.Location = new System.Drawing.Point(0, 35);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(260, 45);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "⚙️  Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // settingsMenuPanel
            // 
            this.settingsMenuPanel.Controls.Add(this.lblSystemTitle);
            this.settingsMenuPanel.Controls.Add(this.btnAccount);
            this.settingsMenuPanel.Controls.Add(this.btnSettings);
            this.settingsMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsMenuPanel.Location = new System.Drawing.Point(0, 348);
            this.settingsMenuPanel.Name = "settingsMenuPanel";
            this.settingsMenuPanel.Size = new System.Drawing.Size(260, 130);
            this.settingsMenuPanel.TabIndex = 2;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(211)))));
            this.sidebarPanel.Controls.Add(this.settingsMenuPanel);
            this.sidebarPanel.Controls.Add(this.managementMenuPanel);
            this.sidebarPanel.Controls.Add(this.mainMenuPanel);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 70);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(260, 583);
            this.sidebarPanel.TabIndex = 9;
            // 
            // mainMenuPanel
            // 
            this.mainMenuPanel.Controls.Add(this.lblMainMenuTitle);
            this.mainMenuPanel.Controls.Add(this.btnCustomers);
            this.mainMenuPanel.Controls.Add(this.btnReservations);
            this.mainMenuPanel.Controls.Add(this.btnRooms);
            this.mainMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.mainMenuPanel.Name = "mainMenuPanel";
            this.mainMenuPanel.Size = new System.Drawing.Size(260, 173);
            this.mainMenuPanel.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(211)))));
            this.lblUserName.Location = new System.Drawing.Point(55, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 23);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Admin";
            // 
            // lblAvatar
            // 
            this.lblAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(211)))));
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.lblAvatar.Location = new System.Drawing.Point(10, 5);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(35, 30);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "AD";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHotelName
            // 
            this.lblHotelName.AutoSize = true;
            this.lblHotelName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHotelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(211)))));
            this.lblHotelName.Location = new System.Drawing.Point(22, 14);
            this.lblHotelName.Name = "lblHotelName";
            this.lblHotelName.Size = new System.Drawing.Size(284, 41);
            this.lblHotelName.TabIndex = 0;
            this.lblHotelName.Text = "🏨 HOTEL VELORA";
            // 
            // userInfoPanel
            // 
            this.userInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userInfoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(60)))));
            this.userInfoPanel.Controls.Add(this.lblUserName);
            this.userInfoPanel.Controls.Add(this.lblAvatar);
            this.userInfoPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userInfoPanel.Location = new System.Drawing.Point(1002, 15);
            this.userInfoPanel.Name = "userInfoPanel";
            this.userInfoPanel.Size = new System.Drawing.Size(150, 40);
            this.userInfoPanel.TabIndex = 1;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.headerPanel.Controls.Add(this.panel1);
            this.headerPanel.Controls.Add(this.lblHotelName);
            this.headerPanel.Controls.Add(this.userInfoPanel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1182, 70);
            this.headerPanel.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(260, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 583);
            this.panel1.TabIndex = 10;
            // 
            // frmAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "frmAdminMain";
            this.Text = "frmAdminMain";
            this.Load += new System.EventHandler(this.frmAdminMain_Load);
            this.managementMenuPanel.ResumeLayout(false);
            this.managementMenuPanel.PerformLayout();
            this.settingsMenuPanel.ResumeLayout(false);
            this.settingsMenuPanel.PerformLayout();
            this.sidebarPanel.ResumeLayout(false);
            this.mainMenuPanel.ResumeLayout(false);
            this.mainMenuPanel.PerformLayout();
            this.userInfoPanel.ResumeLayout(false);
            this.userInfoPanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel managementMenuPanel;
        private System.Windows.Forms.Label lblManagementTitle;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Label lblSystemTitle;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Label lblMainMenuTitle;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel settingsMenuPanel;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel mainMenuPanel;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblHotelName;
        private System.Windows.Forms.Panel userInfoPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel panel1;
    }
}*/

namespace Hotel_Project
{
    partial class frmAdminMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // --- NEW CONTROLS DECLARATIONS ---
        private System.Windows.Forms.Panel pnlUserManagement;
        private System.Windows.Forms.DataGridView dgvUsersList;
        private System.Windows.Forms.Panel pnlUserControls;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.TextBox txtSearchUsers;
        private System.Windows.Forms.Label lblUsersTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        // --- END NEW DECLARATIONS ---

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.managementMenuPanel = new System.Windows.Forms.Panel();
            this.lblManagementTitle = new System.Windows.Forms.Label();
            this.btnBilling = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnReservations = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.lblSystemTitle = new System.Windows.Forms.Label();
            this.btnAccount = new System.Windows.Forms.Button();
            this.lblMainMenuTitle = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.settingsMenuPanel = new System.Windows.Forms.Panel();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.mainMenuPanel = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblHotelName = new System.Windows.Forms.Label();
            this.userInfoPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.pnlUserManagement = new System.Windows.Forms.Panel();
            this.dgvUsersList = new System.Windows.Forms.DataGridView();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlUserControls = new System.Windows.Forms.Panel();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.txtSearchUsers = new System.Windows.Forms.TextBox();
            this.lblUsersTitle = new System.Windows.Forms.Label();
            this.managementMenuPanel.SuspendLayout();
            this.settingsMenuPanel.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.mainMenuPanel.SuspendLayout();
            this.userInfoPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.mainContentPanel.SuspendLayout();
            this.pnlUserManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).BeginInit();
            this.pnlUserControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // managementMenuPanel
            // 
            this.managementMenuPanel.Controls.Add(this.lblManagementTitle);
            this.managementMenuPanel.Controls.Add(this.btnBilling);
            this.managementMenuPanel.Controls.Add(this.btnUsers);
            this.managementMenuPanel.Controls.Add(this.btnEmployees);
            this.managementMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.managementMenuPanel.Location = new System.Drawing.Point(0, 173);
            this.managementMenuPanel.Name = "managementMenuPanel";
            this.managementMenuPanel.Size = new System.Drawing.Size(260, 175);
            this.managementMenuPanel.TabIndex = 1;
            // 
            // lblManagementTitle
            // 
            this.lblManagementTitle.AutoSize = true;
            this.lblManagementTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblManagementTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(60)))));
            this.lblManagementTitle.Location = new System.Drawing.Point(25, 10);
            this.lblManagementTitle.Name = "lblManagementTitle";
            this.lblManagementTitle.Size = new System.Drawing.Size(109, 19);
            this.lblManagementTitle.TabIndex = 0;
            this.lblManagementTitle.Text = "MANAGEMENT";
            // 
            // btnBilling
            // 
            this.btnBilling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBilling.FlatAppearance.BorderSize = 0;
            this.btnBilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilling.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBilling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnBilling.Location = new System.Drawing.Point(0, 125);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnBilling.Size = new System.Drawing.Size(260, 45);
            this.btnBilling.TabIndex = 3;
            this.btnBilling.Text = "💰  Billing";
            this.btnBilling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilling.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnUsers.Location = new System.Drawing.Point(0, 80);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(260, 45);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "👤  Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = true;
            // 
            // btnEmployees
            // 
            this.btnEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEmployees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnEmployees.Location = new System.Drawing.Point(0, 35);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnEmployees.Size = new System.Drawing.Size(260, 45);
            this.btnEmployees.TabIndex = 1;
            this.btnEmployees.Text = "👨‍💼  Employees";
            this.btnEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.UseVisualStyleBackColor = true;
            // 
            // btnCustomers
            // 
            this.btnCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnCustomers.Location = new System.Drawing.Point(3, 32);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnCustomers.Size = new System.Drawing.Size(260, 45);
            this.btnCustomers.TabIndex = 4;
            this.btnCustomers.Text = "👥  Customers";
            this.btnCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.UseVisualStyleBackColor = true;
            // 
            // btnReservations
            // 
            this.btnReservations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReservations.FlatAppearance.BorderSize = 0;
            this.btnReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnReservations.Location = new System.Drawing.Point(0, 125);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnReservations.Size = new System.Drawing.Size(260, 45);
            this.btnReservations.TabIndex = 3;
            this.btnReservations.Text = "📅  Reservations";
            this.btnReservations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservations.UseVisualStyleBackColor = true;
            // 
            // btnRooms
            // 
            this.btnRooms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRooms.FlatAppearance.BorderSize = 0;
            this.btnRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRooms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRooms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnRooms.Location = new System.Drawing.Point(0, 80);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnRooms.Size = new System.Drawing.Size(260, 45);
            this.btnRooms.TabIndex = 2;
            this.btnRooms.Text = "🛏️  Rooms";
            this.btnRooms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRooms.UseVisualStyleBackColor = true;
            // 
            // lblSystemTitle
            // 
            this.lblSystemTitle.AutoSize = true;
            this.lblSystemTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSystemTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(60)))));
            this.lblSystemTitle.Location = new System.Drawing.Point(25, 10);
            this.lblSystemTitle.Name = "lblSystemTitle";
            this.lblSystemTitle.Size = new System.Drawing.Size(62, 19);
            this.lblSystemTitle.TabIndex = 0;
            this.lblSystemTitle.Text = "SYSTEM";
            // 
            // btnAccount
            // 
            this.btnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnAccount.Location = new System.Drawing.Point(0, 80);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnAccount.Size = new System.Drawing.Size(260, 45);
            this.btnAccount.TabIndex = 2;
            this.btnAccount.Text = "👤  Account";
            this.btnAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.UseVisualStyleBackColor = true;
            // 
            // lblMainMenuTitle
            // 
            this.lblMainMenuTitle.AutoSize = true;
            this.lblMainMenuTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblMainMenuTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(60)))));
            this.lblMainMenuTitle.Location = new System.Drawing.Point(25, 10);
            this.lblMainMenuTitle.Name = "lblMainMenuTitle";
            this.lblMainMenuTitle.Size = new System.Drawing.Size(92, 19);
            this.lblMainMenuTitle.TabIndex = 0;
            this.lblMainMenuTitle.Text = "MAIN MENU";
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnSettings.Location = new System.Drawing.Point(0, 35);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(260, 45);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "⚙️  Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // settingsMenuPanel
            // 
            this.settingsMenuPanel.Controls.Add(this.lblSystemTitle);
            this.settingsMenuPanel.Controls.Add(this.btnAccount);
            this.settingsMenuPanel.Controls.Add(this.btnSettings);
            this.settingsMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsMenuPanel.Location = new System.Drawing.Point(0, 348);
            this.settingsMenuPanel.Name = "settingsMenuPanel";
            this.settingsMenuPanel.Size = new System.Drawing.Size(260, 130);
            this.settingsMenuPanel.TabIndex = 2;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(211)))));
            this.sidebarPanel.Controls.Add(this.settingsMenuPanel);
            this.sidebarPanel.Controls.Add(this.managementMenuPanel);
            this.sidebarPanel.Controls.Add(this.mainMenuPanel);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 70);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(260, 583);
            this.sidebarPanel.TabIndex = 9;
            // 
            // mainMenuPanel
            // 
            this.mainMenuPanel.Controls.Add(this.lblMainMenuTitle);
            this.mainMenuPanel.Controls.Add(this.btnCustomers);
            this.mainMenuPanel.Controls.Add(this.btnReservations);
            this.mainMenuPanel.Controls.Add(this.btnRooms);
            this.mainMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.mainMenuPanel.Name = "mainMenuPanel";
            this.mainMenuPanel.Size = new System.Drawing.Size(260, 173);
            this.mainMenuPanel.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(211)))));
            this.lblUserName.Location = new System.Drawing.Point(55, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 23);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Admin";
            // 
            // lblAvatar
            // 
            this.lblAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(211)))));
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.lblAvatar.Location = new System.Drawing.Point(10, 5);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(35, 30);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "AD";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHotelName
            // 
            this.lblHotelName.AutoSize = true;
            this.lblHotelName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHotelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(211)))));
            this.lblHotelName.Location = new System.Drawing.Point(22, 14);
            this.lblHotelName.Name = "lblHotelName";
            this.lblHotelName.Size = new System.Drawing.Size(284, 41);
            this.lblHotelName.TabIndex = 0;
            this.lblHotelName.Text = "🏨 HOTEL VELORA";
            // 
            // userInfoPanel
            // 
            this.userInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userInfoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(60)))));
            this.userInfoPanel.Controls.Add(this.lblUserName);
            this.userInfoPanel.Controls.Add(this.lblAvatar);
            this.userInfoPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userInfoPanel.Location = new System.Drawing.Point(1002, 15);
            this.userInfoPanel.Name = "userInfoPanel";
            this.userInfoPanel.Size = new System.Drawing.Size(150, 40);
            this.userInfoPanel.TabIndex = 1;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.headerPanel.Controls.Add(this.lblHotelName);
            this.headerPanel.Controls.Add(this.userInfoPanel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1182, 70);
            this.headerPanel.TabIndex = 8;
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.Controls.Add(this.pnlUserManagement);
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(260, 70);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainContentPanel.Size = new System.Drawing.Size(922, 583);
            this.mainContentPanel.TabIndex = 10;
            // 
            // pnlUserManagement
            // 
            this.pnlUserManagement.Controls.Add(this.dgvUsersList);
            this.pnlUserManagement.Controls.Add(this.pnlUserControls);
            this.pnlUserManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserManagement.Location = new System.Drawing.Point(20, 20);
            this.pnlUserManagement.Name = "pnlUserManagement";
            this.pnlUserManagement.Size = new System.Drawing.Size(882, 543);
            this.pnlUserManagement.TabIndex = 0;
            // 
            // dgvUsersList
            // 
            this.dgvUsersList.AllowUserToAddRows = false;
            this.dgvUsersList.AllowUserToDeleteRows = false;
            this.dgvUsersList.AllowUserToResizeRows = false;
            this.dgvUsersList.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsersList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsersList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsersList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUsername,
            this.colName,
            this.colRole,
            this.colEdit,
            this.colDelete});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsersList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsersList.EnableHeadersVisualStyles = false;
            this.dgvUsersList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvUsersList.Location = new System.Drawing.Point(0, 70);
            this.dgvUsersList.Name = "dgvUsersList";
            this.dgvUsersList.ReadOnly = true;
            this.dgvUsersList.RowHeadersVisible = false;
            this.dgvUsersList.RowHeadersWidth = 51;
            this.dgvUsersList.RowTemplate.Height = 35;
            this.dgvUsersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsersList.Size = new System.Drawing.Size(882, 473);
            this.dgvUsersList.TabIndex = 1;
            // 
            // colUsername
            // 
            this.colUsername.DataPropertyName = "Username";
            this.colUsername.HeaderText = "USERNAME";
            this.colUsername.MinimumWidth = 6;
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;
            this.colUsername.Width = 150;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "FullName";
            this.colName.HeaderText = "FULL NAME";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colRole
            // 
            this.colRole.DataPropertyName = "Role";
            this.colRole.HeaderText = "ROLE";
            this.colRole.MinimumWidth = 6;
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            this.colRole.Width = 125;
            // 
            // colEdit
            // 
            this.colEdit.DataPropertyName = "Edit";
            this.colEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEdit.HeaderText = "EDIT";
            this.colEdit.MinimumWidth = 6;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "✏️ Edit";
            this.colEdit.UseColumnTextForButtonValue = true;
            this.colEdit.Width = 80;
            // 
            // colDelete
            // 
            this.colDelete.DataPropertyName = "Delete";
            this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.HeaderText = "DELETE";
            this.colDelete.MinimumWidth = 6;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "❌ Delete";
            this.colDelete.UseColumnTextForButtonValue = true;
            this.colDelete.Width = 90;
            // 
            // pnlUserControls
            // 
            this.pnlUserControls.BackColor = System.Drawing.Color.White;
            this.pnlUserControls.Controls.Add(this.btnAddNewUser);
            this.pnlUserControls.Controls.Add(this.txtSearchUsers);
            this.pnlUserControls.Controls.Add(this.lblUsersTitle);
            this.pnlUserControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserControls.Location = new System.Drawing.Point(0, 0);
            this.pnlUserControls.Name = "pnlUserControls";
            this.pnlUserControls.Size = new System.Drawing.Size(882, 70);
            this.pnlUserControls.TabIndex = 0;
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.btnAddNewUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewUser.FlatAppearance.BorderSize = 0;
            this.btnAddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewUser.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewUser.ForeColor = System.Drawing.Color.White;
            this.btnAddNewUser.Location = new System.Drawing.Point(707, 18);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(160, 35);
            this.btnAddNewUser.TabIndex = 2;
            this.btnAddNewUser.Text = "+ Add New User";
            this.btnAddNewUser.UseVisualStyleBackColor = false;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // txtSearchUsers
            // 
            this.txtSearchUsers.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchUsers.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearchUsers.Location = new System.Drawing.Point(314, 21);
            this.txtSearchUsers.Name = "txtSearchUsers";
            this.txtSearchUsers.Size = new System.Drawing.Size(300, 30);
            this.txtSearchUsers.TabIndex = 1;
            this.txtSearchUsers.Text = "🔍 Search by name or username...";
            this.txtSearchUsers.TextChanged += new System.EventHandler(this.txtSearchUsers_TextChanged);
            // 
            // lblUsersTitle
            // 
            this.lblUsersTitle.AutoSize = true;
            this.lblUsersTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(68)))), ((int)(((byte)(35)))));
            this.lblUsersTitle.Location = new System.Drawing.Point(10, 15);
            this.lblUsersTitle.Name = "lblUsersTitle";
            this.lblUsersTitle.Size = new System.Drawing.Size(258, 38);
            this.lblUsersTitle.TabIndex = 0;
            this.lblUsersTitle.Text = "User Management";
            // 
            // frmAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "frmAdminMain";
            this.Text = "frmAdminMain";
            this.Load += new System.EventHandler(this.frmAdminMain_Load);
            this.managementMenuPanel.ResumeLayout(false);
            this.managementMenuPanel.PerformLayout();
            this.settingsMenuPanel.ResumeLayout(false);
            this.settingsMenuPanel.PerformLayout();
            this.sidebarPanel.ResumeLayout(false);
            this.mainMenuPanel.ResumeLayout(false);
            this.mainMenuPanel.PerformLayout();
            this.userInfoPanel.ResumeLayout(false);
            this.userInfoPanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.mainContentPanel.ResumeLayout(false);
            this.pnlUserManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).EndInit();
            this.pnlUserControls.ResumeLayout(false);
            this.pnlUserControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel managementMenuPanel;
        private System.Windows.Forms.Label lblManagementTitle;
        private System.Windows.Forms.Button btnBilling;
        public System.Windows.Forms.Button btnUsers; // Changed to public for easy access in your .cs file
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Label lblSystemTitle;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Label lblMainMenuTitle;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel settingsMenuPanel;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel mainMenuPanel;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblHotelName;
        private System.Windows.Forms.Panel userInfoPanel;
        private System.Windows.Forms.Panel headerPanel;
        public System.Windows.Forms.Panel mainContentPanel; // Changed to public for easy access in your .cs file

    }
}