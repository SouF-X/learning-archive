using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Project
{
    public partial class frmAdminMain : Form
    {
        public frmAdminMain()
        {
            InitializeComponent();
        }

        private void frmAdminMain_Load(object sender, EventArgs e)
        {

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {

        }

/*        private void btnUsers_Click(object sender, EventArgs e)
        {
            // 1. Hide any other content panels you might have
            // e.g., pnlReservations.Hide(); 

            // 2. Clear the main content area (optional, but good practice)
            mainContentPanel.Controls.Clear();

            // 3. Add the User Management panel
            pnlUserManagement.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(pnlUserManagement);
            pnlUserManagement.BringToFront();
            pnlUserManagement.Show();

            // 4. (Recommended) Call a method to load user data into the DataGridView
            // LoadUserData(); 
        }*/

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            // This is where you would call your Add New User form/panel logic
            MessageBox.Show("Open Add New User Form/Panel Logic Here.");
            // Example: ShowAddUserPanel();
        }

        private void txtSearchUsers_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
