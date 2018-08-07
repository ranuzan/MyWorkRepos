using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using B_8;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMet()
        {
            /*
            string connetionString = "Data Source=team8db.database.windows.net;Initial Catalog=Team8DB;Persist Security Info=True;User ID=dbadmin;Password=Aa123456";
            SqlConnection cnn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("select " + "*"+ " from " + "Courses", cnn);
            SqlDataReader read = cmd.ExecuteReader();
            Assert.AreEqual(read, DataBase.Select("*", "Courses"));
            */
            DataBase db1 = new DataBase();
            Assert.IsTrue(true== db1.Update("false", "Constraints", "Seen", "4"));

        }
    }
}
