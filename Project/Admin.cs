using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnPolicyInformation_Click(object sender, EventArgs e)
        {
            this.Close();
            PolicyInformation frm = new PolicyInformation();
            frm.Show();
        }

        private void btnUserInformation_Click(object sender, EventArgs e)
        {
            Admin.ActiveForm.Close();
            UserInformation frm = new UserInformation();
            frm.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Admin.ActiveForm.Close();
            Login frm = new Login();
            frm.Show();
        }
    }
}
