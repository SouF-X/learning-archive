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
    public partial class ctrlUserCard : UserControl
    {
        clsPeople Person;
        clsUsers User;
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            Person = clsPeople.Find(PersonID);
            if (Person != null)
            {
                ctrlCardPerson1.LoadPersonInfo(PersonID);
            }
        }

        public void LoadUserInfo(int UserID)
        {
            User = clsUsers.Find(UserID);
            if (User != null)
            {
                lblUserID.Text = UserID.ToString();
                lblUserName.Text = User._UserName;
                
                if (User._isActive == false)
                {
                    lblisActive.Text = "No";
                }
                else
                {
                    lblisActive.Text = "Yes";
                }
            }
        }
    }
}
