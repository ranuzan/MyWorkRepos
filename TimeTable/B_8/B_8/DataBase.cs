using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_8
{
    public class DataBase
    {
        public  SqlConnection cnn;
        public bool isconnected = false;
        public string help;
        public static int numofcourses = 0;
        public bool IsUnitTest = false;

        public  DataBase()
        {
            string connetionString = "Data Source=team8db.database.windows.net;Initial Catalog=Team8DB;Persist Security Info=True;User ID=dbadmin;Password=Aa123456";
            cnn = new SqlConnection(connetionString);
            isconnected = false;
            help = null;
            IsUnitTest = true;
        }

        public bool Connect()
        {
            if (!isconnected)
            {
                try
                {
                    cnn.Open();
                    isconnected = true;
                    help = null;
                }
                catch (Exception )
                {
                    help = "Could not connect!";
                }
            }
            else
            {
                try
                {
                    cnn.Close();
                    isconnected = false;
                    help = null;
                }
                catch (Exception )
                {
                    help = "Could not disconnect!";
                }
            }
            return true;
        }

        public bool DeleteBySN(string table,string where,string param)
        {
            try
            {
                if (isconnected == false)
                {
                    Connect();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.NewSchedule WHERE LectureID=@sn", cnn);
                cmd.Parameters.AddWithValue("@sn", Int32.Parse(param));


                cmd.ExecuteNonQuery();
                help = null;

            }
            catch (Exception ex)
            {
                help = "Error";

            }
            return true;
        }

        public SqlDataReader Select(string msg, string table)
        {
            SqlDataReader read=null;
            try
            {
                if (isconnected == false)
                {
                    Connect();
                }
                SqlCommand cmd = new SqlCommand("select " + msg + " from " + table, cnn);
                read = cmd.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("Internet connection failure: could not connect to database");
            }
            return read;
        }

        public SqlDataReader Select(string msg, string table, string where, string what)
        {
            if (!isconnected)
            {
                Connect();
            }
            try
            {
                
                SqlCommand cmd = new SqlCommand("select " + msg + " from " + table + " where " + where + " = @what", cnn);
                cmd.Parameters.AddWithValue("@what", what.ToString());
                SqlDataReader read = cmd.ExecuteReader();
                cmd.Dispose();
                return read;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return null;
            }
        
        }

        public void CloseConnection()
        {
            try
            {
                cnn.Close();
                isconnected = false;
            }
            catch (Exception)
            {

                isconnected = false;
            }
        }
        public void OpenConnection()
        {
            try
            {
                cnn.Open();
                isconnected = true;
            }
            catch (Exception)
            {

                isconnected = true;
            }
        }

        public bool Update(string param, string table, string columname, string SerialNumber)
        {
            if (!isconnected)
            {
                Connect();
            }
            SqlCommand cmd = new SqlCommand("update " + table + " SET " + columname + " =@param where SerialNumber=@SerialNumber",cnn);
            cmd.Parameters.AddWithValue("@param", param);
            cmd.Parameters.Add("@SerialNumber", SqlDbType.Int);
            cmd.Parameters["@SerialNumber"].Value = Int32.Parse(SerialNumber);
            cmd.ExecuteNonQuery();

            return true;
        }

        public bool InsertUser(string first, string last, string id,string email, string pass, string role,string department,string unit)
        {
            if (!isconnected)
            {
                Connect();
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO NewUsers(FirstName,LastName,ID,Email,Password,Role,Department,Unit) VALUES(@first,@last,@id,@email,@pass,@role,@department,@unit)", cnn);
            cmd.Parameters.AddWithValue("@first", first);
            cmd.Parameters.AddWithValue("@last", last);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@department", department);
            cmd.Parameters.AddWithValue("@unit", unit);

            try
            {
                cmd.ExecuteNonQuery();
                help = null;
            }
            catch (Exception)
            {
                help = "Could not debug SQL COMMAND! -> InsertUser";
            }
            return true;
        }

        public bool InsertCourse(string name, string credits, string lectureH, string practiceH, string receiptH, string semester, string year, string department,string Unit,string PreReqID)
        {
            SqlCommand cmd;
            if (!isconnected)
            {
                Connect();
            }
            int n;
            if (int.TryParse(PreReqID,out n))
            {
                cmd = new SqlCommand("INSERT INTO NewCourses(Name,Credits,LectureHour,PracticeHour,ReceptionHour,Semester,Year,Department,Unit,PreReqID) VALUES(@name,@credits,@lectureH,@practiceH,@receiptH,@semester,@year,@department,@unit,@PreReqID)", cnn);
            }
          
            else
                cmd = new SqlCommand("INSERT INTO NewCourses(Name,Credits,LectureHour,PracticeHour,ReceptionHour,Semester,Year,Department,Unit) VALUES(@name,@credits,@lectureH,@practiceH,@receiptH,@semester,@year,@department,@unit)", cnn);
            
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@credits", credits);
            cmd.Parameters.AddWithValue("@lectureH", lectureH);
            cmd.Parameters.AddWithValue("@practiceH", practiceH);
            cmd.Parameters.AddWithValue("@receiptH", receiptH);
            cmd.Parameters.AddWithValue("@Semester", semester);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@department", department);
            cmd.Parameters.AddWithValue("@unit", Unit);
            if (int.TryParse(PreReqID, out n))
            {
                cmd.Parameters.AddWithValue("@PreReqID", PreReqID);
            }


                try
            {
                cmd.ExecuteNonQuery();
                help = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                help = "Could not debug SQL COMMAND! -> InsertCourse";
                return false;
            }
            return true;
        }

        
        public bool InsertSce(string Name,int CourseID ,string Department,string Unit,string Role,string Day,int StartHour,int EndHour,string Type,string Classroom,string Date,string LecturerName,string Semester,string Canceled,string NumOfExam,string Responsible, string Description)
        {
            
            if (!isconnected)
            {
                Connect();
            }
           

            SqlCommand cmd2 = new SqlCommand("INSERT INTO NewSchedule (Name,CourseID,Department,Unit,Role,Day,StartHour,EndHour,Type,Classroom,Date,LecturerName,Semester,Canceled,NumOfExam,Responsible,Description) VALUES(@Name,@CourseID,@Department,@Unit,@Role,@Day,@StartHour,@EndHour,@Type,@Classroom,@Date,@LecturerName,@Semester,@Canceled,@NumOfExam,@Responsible,@Description)", cnn);
            
            cmd2.Parameters.AddWithValue("@Name", Name);
            cmd2.Parameters.AddWithValue("@CourseID", CourseID);
            cmd2.Parameters.AddWithValue("@Department", Department);
            cmd2.Parameters.AddWithValue("@Unit", Unit);
            cmd2.Parameters.AddWithValue("@Role", Role);
            cmd2.Parameters.AddWithValue("@Day", Day);            
            cmd2.Parameters.AddWithValue("@StartHour", StartHour);
            cmd2.Parameters.AddWithValue("@EndHour", EndHour);
            cmd2.Parameters.AddWithValue("@Type", Type);
            cmd2.Parameters.AddWithValue("@Classroom", Classroom);
            cmd2.Parameters.AddWithValue("@Date", Date);
            cmd2.Parameters.AddWithValue("@LecturerName", LecturerName);
            cmd2.Parameters.AddWithValue("@Semester", Semester);
            cmd2.Parameters.AddWithValue("@Canceled", Canceled);
            cmd2.Parameters.AddWithValue("@NumOfExam", NumOfExam);
            cmd2.Parameters.AddWithValue("@Responsible", Responsible);
            cmd2.Parameters.AddWithValue("@Description", Description);
            
            try
            {
                cmd2.ExecuteNonQuery();
                help = null;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                help = "Could not debug SQL COMMAND! -> InsertSce";
                return false;
            }
            return true;
        }

        public bool InsertChanges(string LectureID,string Title,string Description,string Starts,string Ends,string day,string month,string year)
        {
            if (!isconnected)
            {
                Connect();
            }
            //MessageBox.Show(cnn.State.ToString());
            if (cnn.State.ToString().Equals("Closed")){
                cnn.Open();
            }
            
            SqlCommand cmd = new SqlCommand("INSERT INTO CurriculumChanges(LectureID,Title,Description,Starts,Ends,day,month,year) VALUES(@LectureID,@Title,@Description,@Starts,@Ends,@day,@month,@year)",cnn);
            cmd.Parameters.AddWithValue("@LectureID", Int32.Parse(LectureID));
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Starts", Int32.Parse(Starts));
            cmd.Parameters.AddWithValue("@Ends", Int32.Parse(Ends));
            cmd.Parameters.AddWithValue("@day", Int32.Parse(day));
            cmd.Parameters.AddWithValue("@month", Int32.Parse(month));
            cmd.Parameters.AddWithValue("@year", Int32.Parse(year));
            try
            {
                cmd.ExecuteNonQuery();
                help = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                help = "Could not debug SQL COMMAND! -> InsertCourseToSchedule";
            }

            return true;
        }
    
        public bool InsertContstraints(string User_ID, string Days, string StartHours, string EndHours, string Notes, string Date, string Semester, string Course)
        {
            if (!isconnected)
            {
                Connect();
            }
            string FullName = GlobalVariables.Full_Name;
            string Seen = "false";
            string Approved = "false";
            SqlCommand cmd = new SqlCommand("INSERT INTO Constraints(User_ID, Days,  StartHours,  EndHours,  Notes,FullName,Seen,Date,Semester,Approved,Course) VALUES(@User_ID,  @Days,  @StartHours,  @EndHours,  @Notes,@FullName,@Seen,@Date,@Semester,@Approved,@Course)", cnn);
            cmd.Parameters.AddWithValue("@User_ID", User_ID);
            cmd.Parameters.AddWithValue("@Days", Days);
            cmd.Parameters.AddWithValue("@StartHours", StartHours);
            cmd.Parameters.AddWithValue("@EndHours", EndHours);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@FullName", FullName);
            cmd.Parameters.AddWithValue("@Seen", Seen);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Semester", Semester);
            cmd.Parameters.AddWithValue("@Approved", Approved);
            cmd.Parameters.AddWithValue("@Course", Course);
            try
            {
                cmd.ExecuteNonQuery();
                help = null;
            }
            catch (Exception)
            {
                help = "Could not debug SQL COMMAND! -> InsertCourseToSchedule";
            }

            return true;
        } 
    }
}

