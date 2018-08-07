using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace A_8
{
    static class SQLFunctions
    {
        private static SqlConnection connection = new SqlConnection("Data Source=team8db.database.windows.net;Initial Catalog=Team8DB;Persist Security Info=True;User ID=dbadmin;Password=Aa123456");

        public static void addUser(int _id, string _password, string _firstName, string _lastName, string _role)
        {
            try
            {
                connection.Open();
                SqlCommand insertUser = new SqlCommand("INSERT INTO [Users] VALUES (@ID,  @Password, @FirstName, @LastName, @Role)", connection);
                insertUser.Parameters.AddWithValue("@ID", _id);
                insertUser.Parameters.AddWithValue("@Password", _password);
                insertUser.Parameters.AddWithValue("@FirstName", _firstName);
                insertUser.Parameters.AddWithValue("@LastName", _lastName);
                insertUser.Parameters.AddWithValue("@Role", _role);
                insertUser.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool checkLogIn(int _id, string _password)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT COUNT(*) FROM [Users] WHERE ID='" + _id + "'AND Password='" + _password + "'", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows[0][0].ToString() == "1")
                return true;

            return false;
        }
    }
}
