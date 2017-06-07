using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Connection
    {
        //The get and set methods for the sql_string
        public string sql_string { get; set; }
        //Sets the connection string to connect to the database
        public string strCon = "Server=COBTUTORPC\\SQLEXPRESS_NLN;Database=PremierInsurance;Trusted_Connection=Yes;";
        //Creates an SQL data adapter
        SqlDataAdapter da_1 = new SqlDataAdapter();
        public DataSet GetConnection
        {
            get { return MyDataSet(); }
        }

        public DataSet MyDataSet()
        {
            //Creates a connection using the connection string
            SqlConnection con = new SqlConnection(strCon);
            //Opens the connection
            con.Open();
            //creates a new SQL data adapter
            da_1 = new SqlDataAdapter(sql_string, con);
            //Creates a data set
            DataSet dat_set = new DataSet();
            //Fills the dataset
            da_1.Fill(dat_set);
            //Closes the connection
            con.Close();
            //Returns the dataset
            return dat_set;
        }
        public void AddToPolicy()
        {
            
        }
        public void AddToCar()
        {

        }
        public void AddToCustomer()
        {

        }
        public void UpdateLoginDB(string userIDIn, string usernameIn, string passwordIn, string accessLevelIn, string isRestrictedIn, string userFirstNameIn, string userSurnameIn, string userEmailIn, string LoginAttemptsIn)
        {
            //Creates the SQL query string
            sql_string = "UPDATE UserLogin SET Username = '" + usernameIn + "', password = '" + passwordIn + "', accessLevel = '" + accessLevelIn + "', isRestricted = '" + isRestrictedIn + "', userFirstName = '" + userFirstNameIn + "', userSurname = '" + userSurnameIn + "', userEmail = '" + userEmailIn + "', LoginAttempts = '" + LoginAttemptsIn + "' WHERE userID = '" + userIDIn + "';";
            //Calls the Run_Query method passing in the sql_string
            Run_Query(sql_string);
        }
        public void AddToLoginDB(string userNameIn, string passwordIn, string accessLevelIn, string userFirstNameIn, string userSurnameIn, string userEmailIn)
        {
            //Creates the SQL query string
            sql_string = "INSERT INTO UserLogin (UserName, Password, AccessLevel, IsRestricted, UserFirstName, UserSurname, UserEmail, LoginAttempts) VALUES ('" + userNameIn + "', '" + passwordIn + "', '" + accessLevelIn + "', True , '" + userFirstNameIn + "', '" + userSurnameIn + "', '" + userEmailIn + "', 1)";
            //Calls the Run_Query method passing in the sql_string
            Run_Query(sql_string);
        }

        public void UpdateDB(string originalHolidayNumber, string newHolidayNumberIn, string destinationIn, string costIn, string departureDateIn, string noOfDaysIn, string availableIn)
        {
            //Splits the date string into day, month and year to pass into the SQL suery
            string[] dates = departureDateIn.Split('/');
            string dayIn = dates[0];
            string monthIn = dates[1];
            string yearIn = dates[2];
            //Creates the SQL query string
            sql_string = "UPDATE tblHoliday SET HolidayNo = '" + newHolidayNumberIn + "', Destination = '" + destinationIn + "', Cost = '" + costIn + "', DepartureDate = CAST('" + yearIn + "-" + monthIn + "-" + dayIn + "' AS DATE), NoOfDays = '" + noOfDaysIn + "', Available = '" + availableIn + "' WHERE HolidayNo = '" + originalHolidayNumber + "';";
            //Calls the Run_Query method passing in the sql_string
            Run_Query(sql_string);
        }

        public void DeleteFromDB(string holidayNoIn)
        {
            //Creates the SQL query string
            sql_string = "DELETE FROM tblHoliday WHERE HolidayNo = '" + holidayNoIn + "';";
            //Calls the Run_Query method passing in the sql_string
            Run_Query(sql_string);
        }

        void Run_Query(string sQuery)
        {
            //Sets the sql_string
            sql_string = sQuery;
            //Creates an SQL command passing in the sql_string
            SqlCommand cmd = new SqlCommand(sql_string);
            //Creates an sql connection
            SqlConnection con = new SqlConnection(strCon);
            //opens the connection, runs the query and closes the connection again.
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}