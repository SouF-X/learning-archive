using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial  class ctrlCardPersonWithFilter : UserControl
    {
        public static clsPeople _Person;

        public ctrlCardPersonWithFilter()
        {
            InitializeComponent();
            FilterComboBox.SelectedIndex = FilterComboBox.Items.IndexOf("NationalNo");
        }

        public int GetPersonID()
        {
            return ctrlCardPerson1.GetPersonID();
        }

        public void LoadPersonInfoOnEditMode(int PersonID)
        {
            ctrlCardPerson1.LoadPersonInfo(PersonID);
            FilterComboBox.SelectedItem = "PersonID";
            FilterCmbTextBox.Text = PersonID.ToString();
            filterGroupBox.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (FilterComboBox.SelectedItem != null && FilterComboBox.SelectedItem.ToString() == "PersonID")
            {
                if (int.TryParse(FilterCmbTextBox.Text, out int result) || FilterCmbTextBox.Text != "")
                {
                    ctrlCardPerson1.LoadPersonInfo(result);
                }
            }
            else if (FilterComboBox.SelectedItem != null && FilterComboBox.SelectedItem.ToString() == "NationalNo")
            {
                if (FilterCmbTextBox.Text != "")
                {
                    ctrlCardPerson1.LoadPersonInfo(FilterCmbTextBox.Text);
                }
            }
            else
            {
                MessageBox.Show("Error in Something", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);

            // Subscribe to the PersonSaved event
            frm.PersonSaved += new frmAddUpdatePerson.PersonSavedEventHandler(this.OnPersonSaved);

            frm.ShowDialog();
        }

        public  void OnPersonSaved(object sender, int personId)
        {
            if (_Person != null)
            {
                FilterComboBox.SelectedItem = "PersonID";
                FilterCmbTextBox.Text = _Person.ID.ToString();

                ctrlCardPerson1.LoadPersonInfo(personId);
            }
        }

        public bool isUserExist()
        {
            bool isExist = false;

            if (clsUsers.isUserExist(ctrlCardPerson1.GetPersonID()))
            {
                isExist = true;
            }
            else
            {
                isExist = false;
            }

            return isExist;
        }
    }
}