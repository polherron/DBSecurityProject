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
    public partial class PolicyInformation : Form
    {
        Connection connect = new Connection();
        DataSet ds;
        DataSet Cust_ds;
        DataSet Car_ds;
        DataSet Driver_ds;
        DataRow dRow;
        DataRow dRowCar;
        DataRow dRowCustomer;
        DataRow dRowDriver;
        int inc = 0;
        int AccessReceiver = 0;
        int MaxRows;
        public PolicyInformation()
        {
            AccessReceiver = Login.AccessCounter;
            InitializeComponent();
            
        }
        public void NavigateRecords()
        {

        }
        private void btnAppend_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        public void Navigate()
        {
            
            Policy();
            Car();
            Customer();
            NewDriver();
            MaxRows = ds.Tables[0].Rows.Count;
            tbRecords.Text = (inc + 1).ToString() + " of " + MaxRows.ToString();
        }
        public void Policy()
        {
            connect.sql_string = "SELECT * FROM Policy";
            ds = connect.GetConnection;
            dRow = ds.Tables[0].Rows[inc];
            tbPolicyId.Text = dRow.ItemArray.GetValue(0).ToString();
            dpPolicyStart.Text = dRow.ItemArray.GetValue(1).ToString();
            dpPolicyEnd.Text =  dRow.ItemArray.GetValue(2).ToString();
            tbLevelOfCover.Text = dRow.ItemArray.GetValue(6).ToString();
            tbAverageMilage.Text = dRow.ItemArray.GetValue(7).ToString();
        }
        public void Car()
        {
            string CarPol = dRow.ItemArray.GetValue(5).ToString();
            connect.sql_string = "SELECT * FROM Car WHERE CarID = " + CarPol;
            Car_ds = connect.GetConnection;
            dRowCar = Car_ds.Tables[0].Rows[0];
            String carReg = EncypherDecypher.Decypher(dRowCar.ItemArray.GetValue(1).ToString());
            tbCarRegistration.Text = carReg;
            String chasisNo = EncypherDecypher.Decypher(dRowCar.ItemArray.GetValue(2).ToString());
            tbChasisNumber.Text = chasisNo;
            String carMake = EncypherDecypher.Decypher(dRowCar.ItemArray.GetValue(3).ToString());
            tbCarMake.Text = carMake;
            String carModel = EncypherDecypher.Decypher(dRowCar.ItemArray.GetValue(4).ToString());
            tbCarModel.Text = carModel;
            String carEngineSize = EncypherDecypher.Decypher(dRowCar.ItemArray.GetValue(5).ToString());
            tbCarEngineSize.Text = carEngineSize;
            String estimatedWorth = EncypherDecypher.Decypher(dRowCar.ItemArray.GetValue(6).ToString());
            cbEstimatedWorth.Text = estimatedWorth;

            
        }
        public void Customer()
        {
            string CustPol = dRow.ItemArray.GetValue(3).ToString();
            connect.sql_string = "SELECT * FROM Customer WHERE CustomerID = " + CustPol;
            Cust_ds = connect.GetConnection;
            dRowCustomer = Cust_ds.Tables[0].Rows[0];
            String firstName = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(1).ToString());
            tbFirstName.Text = firstName;
            String Surname = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(2).ToString());
            tbSurname.Text = Surname;
            String Title = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(3).ToString());
            cbTitle.Text = Title;
            String Street = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(4).ToString());
            tbStreet.Text = Street;
            String Town = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(5).ToString());
            tbTown.Text = Town;
            String County = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(6).ToString());
            cbCounty.Text = County;
            String Eircode = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(7).ToString());
            tbEircode.Text = Eircode;
            String dateOfBirth = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(8).ToString());
            dpDateOfBirth.Text = dateOfBirth;
            String contactNumber = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(9).ToString());
            tbContactNumber.Text = contactNumber;
            String licenceType = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(10).ToString());
            cbLicenceType.Text = licenceType;
            String licenceNo = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(11).ToString());
            tbLicenceNo.Text = licenceNo;
            String licenceIssued = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(12).ToString());
            dpLicenceIssued.Text = licenceIssued;
            String penaltyPoints = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(13).ToString());
            tbPenaltyPoints.Text = penaltyPoints;
            String noClaims = EncypherDecypher.Decypher(dRowCustomer.ItemArray.GetValue(14).ToString());
            if (noClaims.Equals("TRUE"))
            {
                cbNoClaims.Checked = true;
            }
            else
            {
                cbNoClaims.Checked = false;
            }
            
        }
        public void NewDriver()
        {
            
                string DrivePol = dRow.ItemArray.GetValue(4).ToString();
                connect.sql_string = "SELECT * FROM Customer WHERE CustomerID = " + DrivePol;
                Driver_ds = connect.GetConnection;
                var temp = dRow.ItemArray.GetValue(4);
                if (!dRow.ItemArray.GetValue(4).Equals((object)0))
                {
                    dRowDriver = Driver_ds.Tables[0].Rows[0];
                
                    
                    String firstName = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(1).ToString());
                    tbnFirstName.Text = firstName;
                    String Surname = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(2).ToString());
                    tbnSurname.Text = Surname;
                    String Title = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(3).ToString());
                    cbnTitle.Text = Title;
                    String Street = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(4).ToString());
                    tbnStreet.Text = Street;
                    String Town = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(5).ToString());
                    tbnTown.Text = Town;
                    String County = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(6).ToString());
                    cbnCounty.Text = County;
                    String Eircode = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(7).ToString());
                    tbnEircode.Text = Eircode;
                    dpnDateOfBirth.Format = DateTimePickerFormat.Custom;
                    dpnDateOfBirth.CustomFormat = "dd MMMM yyyy";
                    String dateOfBirth = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(8).ToString());
                    dpnDateOfBirth.Text = dateOfBirth;
                    String contactNumber = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(9).ToString());
                    tbnContactNumber.Text = contactNumber;
                    String licenceType = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(10).ToString());
                    cbnLicenceType.Text = licenceType;
                    String licenceNo = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(11).ToString());
                    tbnLicenceNumber.Text = licenceNo;
                    dpnLicenceIssued.Format = DateTimePickerFormat.Custom;
                    dpnLicenceIssued.CustomFormat = "dd MMMM yyyy";
                    String licenceIssued = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(12).ToString());
                    dpnLicenceIssued.Text = licenceIssued;
                    String penaltyPoints = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(13).ToString());
                    tbnPenaltyPoints.Text = penaltyPoints;
                    String noClaims = EncypherDecypher.Decypher(dRowDriver.ItemArray.GetValue(14).ToString());
                    if (noClaims.Equals("TRUE"))
                    {
                        cbnNoClaims.Checked = true;
                    }
                    else
                    {
                        cbnNoClaims.Checked = false;
                    }
                }
                else
                {
                    tbnFirstName.Clear();
                    tbnSurname.Clear();
                    cbnTitle.Text = (" "); 
                    tbnStreet.Clear();
                    tbnTown.Clear();
                    cbnCounty.Text = (" "); 
                    tbnEircode.Clear();
                    dpnDateOfBirth.Format = DateTimePickerFormat.Custom;
                    dpnDateOfBirth.CustomFormat = " ";
                    tbnContactNumber.Clear();
                    cbnLicenceType.Text=(" ");
                    tbnLicenceNumber.Clear();
                    dpnLicenceIssued.Format = DateTimePickerFormat.Custom;
                    dpnLicenceIssued.CustomFormat = " ";
                    tbnPenaltyPoints.Clear();
                    cbnNoClaims.Checked = false;
                }
                
        }
        private void PolicyInformation_Load(object sender, EventArgs e)
        {
            connect = new Connection();
            Navigate();
            if (AccessReceiver == 1)
            {
                btnLogOffBack.Text = "Back";
            }
            else if (AccessReceiver == 2 || AccessReceiver == 3)
            {
                btnLogOffBack.Text = "LogOff";
            }
            //ds = connect.GetConnection;

            
            //NavigateRecords();

            cbNamedDriver.Checked = true;
            if(AccessReceiver == 3)
            {
                tbPolicyId.ReadOnly = true;
                tbLevelOfCover.ReadOnly = true;
                tbAverageMilage.ReadOnly = true;
                tbCarRegistration.ReadOnly = true;
                tbChasisNumber.ReadOnly = true;
                tbCarMake.ReadOnly = true;
                tbCarModel.ReadOnly = true;
                tbCarEngineSize.ReadOnly = true;
                tbFirstName.ReadOnly = true;
                tbSurname.ReadOnly = true;
                tbStreet.ReadOnly = true;
                tbTown.ReadOnly = true;
                tbEircode.ReadOnly = true;
                tbContactNumber.ReadOnly = true;
                tbLicenceNo.ReadOnly = true;
                tbPenaltyPoints.ReadOnly = true;
                dpPolicyEnd.Enabled = false;
                dpPolicyStart.Enabled = false;
                cbEstimatedWorth.Enabled = false;
                cbTitle.Enabled = false;
                cbCounty.Enabled = false;
                dpDateOfBirth.Enabled = false;
                cbLicenceType.Enabled = false;
                dpLicenceIssued.Enabled = false;
                cbNamedDriver.Enabled = false;
                cbNoClaims.Enabled = false;

            }
        }



        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbNamedDriver_CheckedChanged(object sender, EventArgs e)
        {
            if(cbNamedDriver.Checked==true)
            {
                tbnFirstName.ReadOnly = true;
                tbnSurname.ReadOnly = true;
                cbnTitle.Enabled = false;
                tbnStreet.ReadOnly = true;
                tbnTown.ReadOnly = true;
                tbnEircode.ReadOnly = true;
                tbnContactNumber.ReadOnly = true;
                tbnLicenceNumber.ReadOnly = true;
                tbnPenaltyPoints.ReadOnly = true;
                cbnCounty.Enabled = false;
                cbnLicenceType.Enabled = false;
                cbnNoClaims.Enabled = false;
                dpnDateOfBirth.Enabled = false;
                dpnLicenceIssued.Enabled = false;
            }
            if (cbNamedDriver.Checked == false)
            {
                tbnFirstName.ReadOnly = false;
                tbnSurname.ReadOnly = false;
                cbnTitle.Enabled = true;
                tbnStreet.ReadOnly = false;
                tbnTown.ReadOnly = false;
                tbnEircode.ReadOnly = false;
                tbnContactNumber.ReadOnly = false;
                tbnLicenceNumber.ReadOnly = false;
                tbnPenaltyPoints.ReadOnly = false;
                cbnCounty.Enabled = true;
                cbnLicenceType.Enabled = true;
                cbnNoClaims.Enabled = true;
                dpnDateOfBirth.Enabled = true;
                dpnLicenceIssued.Enabled = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Close();
            Search_Policy frm = new Search_Policy();
            frm.Show();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (inc != 0)
            {
                inc = 0;
                Navigate();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (inc > 0)
            {
                inc--;
                Navigate();
            }
            else
            {
                MessageBox.Show("First Record");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (inc != MaxRows - 1)
            {
                inc++;
                Navigate();
            }
            else
            {
                MessageBox.Show("No More Records");
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (inc != MaxRows - 1)
            {
                inc = MaxRows - 1;
                Navigate();
            }
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOffBack_Click(object sender, EventArgs e)
        {
            if (AccessReceiver == 1)
            {
                this.Close();
                Admin frm = new Admin();
                frm.Show();
            }
            else if (AccessReceiver == 2 || AccessReceiver == 3)
            {
                this.Close();
                Login frm = new Login();
                frm.Show();
            }
        }
    }
}
