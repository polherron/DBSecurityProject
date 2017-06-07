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
    public partial class UserInformation : Form
    {
        Connection objConnect = new Connection();
        DataSet ds;
        public static int myInt = 0;

        public UserInformation()
        {            
            InitializeComponent();
            fillData();
        }

        private void fillData()
        {
            try
            {
                cboRestricted.Items.Clear();
                cboRestricted.Items.Add("True");
                cboRestricted.Items.Add("False");
                cboAccessLevel.Items.Clear();
                cboAccessLevel.Items.Add("Admin");
                cboAccessLevel.Items.Add("Sales Rep");
                cboAccessLevel.Items.Add("Clerical");

                objConnect.sql_string = "SELECT * FROM UserLogin";
                ds = objConnect.GetConnection;

                dgvUsers.DataSource = ds;
                dgvUsers.VirtualMode = false;
                dgvUsers.Columns.Clear();
                dgvUsers.AutoGenerateColumns = true;
                dgvUsers.DataMember = ds.Tables[0].ToString();
                this.dgvUsers.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvUsers_CellFormatting);
                dgvUsers.AutoResizeColumns();
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Fill Data");
            }
        }

        void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 2 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 && e.RowIndex != this.dgvUsers.NewRowIndex)
                {
                    if (e != null && !String.IsNullOrEmpty(e.Value as string))
                    {
                        if (IsEncrypted(e.Value.ToString()))
                        {
                          // MessageBox.Show(e.Value.ToString(), "encrypting");
                            e.Value = EncypherDecypher.Decypher(e.Value.ToString());
                        }
                    }
                }

            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, e.Value.ToString());
            }
        }

        //Fix for issue where decrypted value being passed to decryption method.
        public static bool IsEncrypted(string input)
        {
            string i = "hello world";
              return (input.Contains("=="));
        }
       
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Close();
            myInt = 1;
            UserDetails frm = new UserDetails();
            frm.Show();
            
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            this.Close();
            UserDetails frm = new UserDetails();
            frm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin frm = new Admin();
            frm.Show();
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = string.Format("UserName LIKE '%{0}%'", tbUserName.Text);
            dgvUsers.DataSource = dv;
        }

        private void cboRestricted_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataView dv = ds.Tables[0].DefaultView;
                if (cboRestricted.SelectedItem.ToString() == "True")
                {
                    dv.RowFilter = "IsRestricted = 1";
                }
                else
                {
                    dv.RowFilter = "IsRestricted = 0";
                }
                dgvUsers.DataSource = dv;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }           
        }

        private void cboAccessLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataView dv = ds.Tables[0].DefaultView;
                if (cboAccessLevel.SelectedItem.ToString() == "Admin")
                {
                    dv.RowFilter = "AccessLevel = 1";
                }
                else if (cboAccessLevel.SelectedItem.ToString() == "Sales Rep")
                {
                    dv.RowFilter = "AccessLevel = 2";
                }
                else
                {
                    dv.RowFilter = "AccessLevel = 3";
                }
                dgvUsers.DataSource = dv;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //cboRestricted.SelectedIndex = -1;
            //cboAccessLevel.SelectedIndex = -1;
            //ds.Clear();
            fillData();
        }

    }
}
