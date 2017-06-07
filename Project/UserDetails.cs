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
    
    public partial class UserDetails : Form
    {
        int thisint=0;
        public UserDetails()
        {
            thisint = UserInformation.myInt;
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void UserDetails_Load(object sender, EventArgs e)
        {
            if (thisint == 1)
            {
                btnSendEmail.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            UserInformation frm = new UserInformation();
            frm.Show();
        }
    }
}
