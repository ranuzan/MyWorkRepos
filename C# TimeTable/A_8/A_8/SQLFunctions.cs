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
    public static class SQLFunctions
    {
        private static SqlConnection connection = new SqlConnection("Data Source=team8db.database.windows.net;Initial Catalog=Team8DB;Persist Security Info=True;User ID=dbadmin;Password=Aa123456");

        public static bool insertUser(string _email, int _id, string _password, string _firstName, string _lastName, string _role, string _department = "")
        {
            //this function adds a user to the user DB table 
            //all details are recived as params
            try
            {
                connection.Open();
                SqlCommand insertUser = new SqlCommand("INSERT INTO [NewUsers] (Email, ID, Password, FirstName, LastName, Role, Department) VALUES (@Email, @ID,  @Password, @FirstName, @LastName, @Role, @Department)", connection);
                insertUser.Parameters.AddWithValue("@Email", _email);
                insertUser.Parameters.AddWithValue("@ID", _id);
                insertUser.Parameters.AddWithValue("@Password", _password);
                insertUser.Parameters.AddWithValue("@FirstName", _firstName);
                insertUser.Parameters.AddWithValue("@LastName", _lastName);
                insertUser.Parameters.AddWithValue("@Role", _role);
                insertUser.Parameters.AddWithValue("@Department", _department);
                insertUser.ExecuteNonQuery();
                if (_role == "Student")
                {
                    SqlCommand insertStudent = new SqlCommand("INSERT INTO [StudentsDetails] VALUES (@ID, @Year, @Semester, @WeeklyHours, @SemesterPoint, @Notification)", connection);
                    insertStudent.Parameters.AddWithValue("@ID", _id);
                    insertStudent.Parameters.AddWithValue("@Year", 1);
                    insertStudent.Parameters.AddWithValue("@Semester", "A");
                    insertStudent.Parameters.AddWithValue("@WeeklyHours", 0);
                    insertStudent.Parameters.AddWithValue("@SemesterPoint", 0);
                    insertStudent.Parameters.AddWithValue("@Notification", false);
                    insertStudent.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static bool addClassroom(string _name, int _capacity, string _type)
        {
            //this function adds a classroom to the classroom DB table
            //all details are recived as params
            try
            {
                connection.Open();
                SqlCommand insertClassroom = new SqlCommand("INSERT INTO [Classrooms] VALUES (@Name,  @Capacity, @Type)", connection);
                insertClassroom.Parameters.AddWithValue("@Name", _name);
                insertClassroom.Parameters.AddWithValue("@Capacity", _capacity);
                insertClassroom.Parameters.AddWithValue("@Type", _type);
                insertClassroom.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static bool checkLogIn(int _id, string _password)
        {
            //this function checks login details of a user trying to login
            //all details are recived as params
            int result = 0;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [NewUsers] WHERE ID='" + _id + "'AND Password='" + _password + "'", connection);

                result = (int)command.ExecuteScalar();
            }
            catch
            {
                MessageBox.Show("Login Failure: could not connect to the database");
                return false;
            }
            connection.Close();
            if(result>0)
                return true;
            return false;
          
        }

        public static string checkRole(int _id)
        {
            //this function checks the rule of a user via his id
            //user details are recived as params
            string role = "ERROR";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Role FROM [NewUsers] WHERE ID=@ID", connection);
                command.Parameters.AddWithValue("@ID", _id);
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                role = dataReader[0].ToString();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                //case exception
                connection.Close();
            }
            return role;
        }

        public static bool checkExistsUsers(int _id)
        {
            //this function checks if a user exits in the user DB table
            SqlCommand cmd = new SqlCommand("SELECT * FROM [NewUsers] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _id);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                if (dr.HasRows == true)
                {
                    connection.Close();
                    return true;
                }

            connection.Close();
            return false;
        }


        public static bool checkExistsClassroom(string _name)
        {
            //this function checks if a classroom exits in the user DB table via its name
            //name is accepted as param
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Classrooms] WHERE Name=@Name", connection);
            cmd.Parameters.AddWithValue("@Name", _name);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                if (dr.HasRows == true)
                {
                    connection.Close();
                    return true;
                }

            connection.Close();
            return false;
        }

        public static bool deleteUser(int _id)
        {
            //this function deletes a user from the user DB table via its id
            //id is recived as a param

            try
            {
                connection.Open();
                SqlCommand deleteUser = new SqlCommand("DELETE FROM [StudentsGrades] WHERE [ID] = @ID ; DELETE FROM [StudentsTimeTable] WHERE [StudentID] = @ID ; DELETE FROM [NewUsers] WHERE [ID]=@ID; DELETE FROM [StudentsDetails] WHERE [ID] = @ID", connection);
                deleteUser.Parameters.AddWithValue("@ID", _id);
                deleteUser.ExecuteNonQuery();

            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;

        }

        public static bool deleteClassroom(string _name)
        {
            //this function deletes a classroom from the classroom DB table via its name
            //name is recived as a param
            try
            {
                connection.Open();
                SqlCommand deleteClassroom = new SqlCommand("DELETE FROM [Classrooms] Where Name=@Name", connection);
                deleteClassroom.Parameters.AddWithValue("@Name", _name);
                deleteClassroom.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static bool updateUserRole(int _id, string _role, string _department = "")
        {
            //this function changes a user permission via its id
            //all details are recived as params
            try
            {
                connection.Open();
                SqlCommand updateRole = new SqlCommand("UPDATE [NewUsers] SET Role=@Role, Department=@Department WHERE ID=@ID", connection);
                updateRole.Parameters.AddWithValue("@Role", _role);
                updateRole.Parameters.AddWithValue("@Department", _department);
                updateRole.Parameters.AddWithValue("@ID", _id);
                updateRole.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public static bool updateStudentYearAndSemester(int _id, int _year, char _semester)
        {
            //this function changes a user permission via its id
            //all details are recived as params
            try
            {
                connection.Open();
                SqlCommand updateRole = new SqlCommand("UPDATE [StudentsDetails] SET Year=@Year, Semester=@Semester WHERE ID=@ID", connection);
                updateRole.Parameters.AddWithValue("@Year", _year);
                updateRole.Parameters.AddWithValue("@Semester", _semester);
                updateRole.Parameters.AddWithValue("@ID", _id);
                updateRole.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static bool addLecturesToStudent(int _id, List<int> _lecureIDs, float _semesterPoints, int _weeklyHours)
        {
            //adds a lecture to a student timetable DB via his id and the lecture id
            //all details are recived as params
            try
            {
                connection.Open();
                SqlCommand clearLectures = new SqlCommand("DELETE FROM [StudentsTimeTable] WHERE StudentID=@StudentID", connection);
                clearLectures.Parameters.AddWithValue("@StudentID", _id);
                clearLectures.ExecuteNonQuery();

                for (int i = 0; i < _lecureIDs.Count; i++)
                {
                    SqlCommand addLecture = new SqlCommand("INSERT INTO [StudentsTimeTable] (StudentID, LectureID) VALUES (@StudentID,  @LectureID)", connection);
                    addLecture.Parameters.AddWithValue("@StudentID", _id);
                    addLecture.Parameters.AddWithValue("@LectureID", _lecureIDs[i]);
                    addLecture.ExecuteNonQuery();
                }

                SqlCommand editPoints = new SqlCommand("UPDATE [StudentsDetails] SET SemesterPoint=@SemesterPoint WHERE ID=@ID", connection);
                editPoints.Parameters.AddWithValue("@ID", _id);
                editPoints.Parameters.AddWithValue("@SemesterPoint", _semesterPoints);
                editPoints.ExecuteNonQuery();

                SqlCommand editWeeklyHours = new SqlCommand("UPDATE [StudentsDetails] SET WeeklyHours=@WeeklyHours WHERE ID=@ID", connection);
                editWeeklyHours.Parameters.AddWithValue("@ID", _id);
                editWeeklyHours.Parameters.AddWithValue("@WeeklyHours", _weeklyHours);
                editWeeklyHours.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static bool deleteLectureFromStudent(int _id, int _lectureID)
        {
            //this function deltes a lecture from a students timetable via his id and lecture id
            //all details are recived as params
            try
            {
                connection.Open();
                SqlCommand deleteLecture = new SqlCommand("DELETE FROM [StudentsTimeTable] Where StudentID=@StudentID AND LectureID=@LectureID", connection);
                deleteLecture.Parameters.AddWithValue("@StudentID", _id);
                deleteLecture.Parameters.AddWithValue("@LectureID", _lectureID);
                deleteLecture.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static List<int> findStudentLecturesIDs(int _id)
        {
            //this function find a student lectures id  via his id
            //all details are recived as params
            List<int> lecturesIDsList = new List<int>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [StudentsTimeTable] WHERE StudentID=@StudentID", connection);
            cmd.Parameters.AddWithValue("@StudentID", _id);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lecturesIDsList.Add(dr.GetInt32(1));
                }
                connection.Close();
                return lecturesIDsList;

            }

            connection.Close();
            return lecturesIDsList;

        }

        public static List<string> findLectureProperties(int _lectureID)
        {
            //this function returns all lecture properties as an array
            //lecture id is recived as a param
            List<string> lecturesPropertiesList = new List<string>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [NewSchedule] WHERE LectureID=@LectureID", connection);
            cmd.Parameters.AddWithValue("@LectureID", _lectureID);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        lecturesPropertiesList.Add(Convert.ToString(dr.GetValue(i)));
                    }
                }

                connection.Close();
                return lecturesPropertiesList;
            }

            connection.Close();
            return lecturesPropertiesList;
        }

        public static List<string> findCourseProperties(int _courseID)
        {
            //this function returns all course properties as an array
            //course id is recived as a param
            List<string> coursesPropertiesList = new List<string>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [NewCourses] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _courseID);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        coursesPropertiesList.Add(Convert.ToString(dr.GetValue(i)));
                    }
                }

                connection.Close();
                return coursesPropertiesList;
            }

            connection.Close();
            return coursesPropertiesList;
        }

        public static List<int> findAllowedCoursesForStudent(int _id, int _year, string _semester, string _department)
        {
            //find allowed courses for a specific student  via his year semester and department     
            //all details are recived  as params
            List<int> allowedCoursesWithoutPreReqs = new List<int>();
            List<int> allowedCoursesWithPreReqs = new List<int>();

            SqlCommand cmd = new SqlCommand("SELECT ID FROM [NewCourses] WHERE PreReqID IS NULL AND Year<=@Year AND Department=@Department", connection);
            cmd.Parameters.AddWithValue("@Year", _year);
            cmd.Parameters.AddWithValue("@Department", _department);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        allowedCoursesWithoutPreReqs.Add(Convert.ToInt32(dr.GetValue(i)));
                    }
                }
            }
            dr.Close();

            if (_semester == "A")
            {
                cmd = new SqlCommand("SELECT ID FROM [NewCourses] WHERE PreReqID IS NULL AND Year=@Year AND Semester='B' AND Department=@Department", connection);
                cmd.Parameters.AddWithValue("@Year", _year);
                cmd.Parameters.AddWithValue("@Department", _department);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    List<int> temp = new List<int>();
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            temp.Add(Convert.ToInt32(dr.GetValue(i)));
                        }
                    }
                    foreach (int id in temp)
                        allowedCoursesWithoutPreReqs.Remove(id);
                }
                dr.Close();
            }

            cmd = new SqlCommand("SELECT ID FROM [NewCourses],(SELECT CourseID FROM StudentsGrades WHERE ID=@ID AND Grade >= 56) AS PassedCourses WHERE PreReqID = PassedCourses.CourseID AND Year<=@Year AND Department=@Department", connection);
            cmd.Parameters.AddWithValue("@ID", _id);
            cmd.Parameters.AddWithValue("@Year", _year);
            cmd.Parameters.AddWithValue("@Department", _department);
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        allowedCoursesWithPreReqs.Add(Convert.ToInt32(dr.GetValue(i)));
                    }
                }
            }
            dr.Close();

            if (_semester == "A")
            {
                cmd = new SqlCommand("SELECT ID FROM [NewCourses],(SELECT CourseID FROM StudentsGrades WHERE ID=@ID AND Grade >= 56) AS PassedCourses WHERE PreReqID = PassedCourses.CourseID AND Year=@Year AND Semester='B' AND Department=@Department", connection);
                cmd.Parameters.AddWithValue("@Year", _year);
                cmd.Parameters.AddWithValue("@ID", _id);
                cmd.Parameters.AddWithValue("@Department", _department);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    List<int> temp = new List<int>();
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            temp.Add(Convert.ToInt32(dr.GetValue(i)));
                        }
                    }
                    foreach (int id in temp)
                        allowedCoursesWithPreReqs.Remove(id);

                }
                dr.Close();
            }

            connection.Close();
            return allowedCoursesWithoutPreReqs.Union(allowedCoursesWithPreReqs).ToList();
        }

        public static List<int> getStudentFailedCoursesIDs(int _id)
        {
            //this function returns a list of coursed a student failed in via his id
            //id is recived as param
            List<int> passedCourses = new List<int>();

            SqlCommand cmd = new SqlCommand("SELECT CourseID FROM [StudentsGrades] WHERE ID=@ID AND Grade<56", connection);
            cmd.Parameters.AddWithValue("@ID", _id);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        passedCourses.Add(Convert.ToInt32(dr.GetValue(i)));
                    }
                }

                connection.Close();
                return passedCourses;
            }

            connection.Close();
            return passedCourses;
        }

        public static string covertCourseIDtoCourseName(int _courseID)
        {
            //this function recives a course id and returns its name
            string courseName = "";

            SqlCommand cmd = new SqlCommand("SELECT Name FROM [NewCourses] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _courseID);
            connection.Open();

            courseName = (string)cmd.ExecuteScalar();

            connection.Close();

            return courseName;
        }

        public static List<int> findLecturesIDsForCourse(int _courseID)
        {
            //this fucntion finds lecture id via the course id
            List<int> lecturesIDsList = new List<int>();

            SqlCommand cmd = new SqlCommand("SELECT LectureID FROM [NewSchedule] WHERE CourseID=@CourseID", connection);
            cmd.Parameters.AddWithValue("@CourseID", _courseID);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        lecturesIDsList.Add(Convert.ToInt32(dr.GetValue(i)));
                    }
                }

                connection.Close();
                return lecturesIDsList;
            }

            connection.Close();
            return lecturesIDsList;
        }

        public static int covertCourseNametoCourseID(string _courseName)
        {
            //this function recives a course name and returns the course id of that name
            int courseID = 0;

            SqlCommand cmd = new SqlCommand("SELECT ID FROM [NewCourses] WHERE Name=@Name", connection);
            cmd.Parameters.AddWithValue("@Name", _courseName);
            connection.Open();

            courseID = (int)cmd.ExecuteScalar();

            connection.Close();

            return courseID;
        }

        public static bool addGradeToStudent(int _studentID, int _courseID, int _grade)
        {
            //this function adds a grade to student for a specific course
            //all params recived at checked and if valid grade is given
            try
            {
                connection.Open();
                SqlCommand addGrade = new SqlCommand("INSERT INTO [StudentsGrades] (ID, CourseID, Grade) VALUES (@ID,  @CourseID, @Grade)", connection);
                addGrade.Parameters.AddWithValue("@ID", _studentID);
                addGrade.Parameters.AddWithValue("@CourseID", _courseID);
                addGrade.Parameters.AddWithValue("@Grade", _grade);
                addGrade.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static DataTable findCoursePropertiesByDepartment(string _department)
        {
            //this function returns all course properties of a specifc department 

            DataTable courseProperties = new DataTable();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [NewCourses] WHERE Department=@Department", connection);
            cmd.Parameters.AddWithValue("@Department", _department);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            try
            {
                connection.Open();
                dataAdapter.Fill(courseProperties);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (courseProperties.Rows.Count <= 0)
                return null;

            return courseProperties;
        }


        public static int covertLectureNametoLectureID(string _lectureName)
        {
            //this function recives a lecture name and return the lecture id for that lecture
            int lectureID = 0;

            SqlCommand cmd = new SqlCommand("SELECT LectureID FROM [NewSchedule] WHERE Name=@Name", connection);
            cmd.Parameters.AddWithValue("@Name", _lectureName);
            connection.Open();

            lectureID = (int)cmd.ExecuteScalar();

            connection.Close();

            return lectureID;
        }

        public static List<int> getLectureIDByCourseID(int _courseID)
        {
            //this function return all student details for a student signed to some course
            List<int> LecturesID = new List<int>();

            SqlCommand cmd = new SqlCommand("SELECT LectureID FROM [NewSchedule] WHERE CourseID=@CourseID", connection);
            cmd.Parameters.AddWithValue("@CourseID", _courseID);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        LecturesID.Add(Convert.ToInt32(dr.GetValue(i)));
                    }
                }

                connection.Close();
                return LecturesID;
            }
            connection.Close();
            LecturesID = null;
            return LecturesID;
        }

        public static string covertStudentIDtoStudentLastName(int _studentID)
        {
            //this function recives a student id and returns that student last name
            string studentName = "";

            SqlCommand cmd = new SqlCommand("SELECT LastName FROM [NewUsers] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _studentID);
            connection.Open();

            studentName = (string)cmd.ExecuteScalar();

            connection.Close();

            return studentName;
        }

        public static string covertStudentIDtoStudentFirstName(int _studentID)
        {
            //this function recives a student id and returns that student first name
            string studentName = "";

            SqlCommand cmd = new SqlCommand("SELECT FirstName FROM [NewUsers] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _studentID);
            connection.Open();

            studentName = (string)cmd.ExecuteScalar();

            connection.Close();

            return studentName;
        }


        public static List<int> getStudentsIDfromLectureID(int _lectureID)
        {
            //this function recives a lecture id and returns all student ids
            List<int> studentsID = new List<int>();

            SqlCommand cmd = new SqlCommand("SELECT StudentID FROM [StudentsTimeTable] WHERE LectureID=@LectureID", connection);
            cmd.Parameters.AddWithValue("@LectureID", _lectureID);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        studentsID.Add(Convert.ToInt32(dr.GetValue(i)));
                    }
                }

                connection.Close();
                return studentsID;
            }
            connection.Close();
            studentsID = null;
            return studentsID;
        }


        public static DataTable getCourseDetailsByYearAndSemester(int _Year,char _Semester)
        {
            DataTable courseDetails = new DataTable();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [NewCourses] WHERE Year=@Year And Semester=@Semester", connection);
            cmd.Parameters.AddWithValue("@Year", _Year);
            cmd.Parameters.AddWithValue("@Semester", _Semester);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            try
            {
                connection.Open();
                dataAdapter.Fill(courseDetails);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }
            if (courseDetails != null)
                return courseDetails;
            return null;   
        }


        public static DataTable getStudentsGrades(int _id)
        {
            DataTable studentsGrades = new DataTable();

            SqlCommand cmd = new SqlCommand("SELECT CourseID,Grade FROM [StudentsGrades] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            try
            {
                connection.Open();
                dataAdapter.Fill(studentsGrades);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (studentsGrades.Rows.Count <= 0)
                return null;
            return studentsGrades;
        }

        public static bool isStudentGraded(int _studentID, int _courseID)
        {
            int exists;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [StudentsGrades] WHERE ID=@ID AND CourseID=@CourseID", connection);
            cmd.Parameters.AddWithValue("@ID", _studentID);
            cmd.Parameters.AddWithValue("@CourseID", _courseID);
            connection.Open();
            exists = (int)cmd.ExecuteScalar();
            if (exists > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public static bool updateGradeToStudent(int _studentID, int _courseID, int _grade)
        {

            try
            {
                connection.Open();
                SqlCommand updateGrade = new SqlCommand("UPDATE [StudentsGrades] SET Grade = @Grade WHERE  ID=@ID AND CourseID=@CourseID", connection);
                updateGrade.Parameters.AddWithValue("@ID", _studentID);
                updateGrade.Parameters.AddWithValue("@CourseID", _courseID);
                updateGrade.Parameters.AddWithValue("@Grade", _grade);
                updateGrade.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }


        public static DataTable getCourseProperties(int _id)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT NewCourses.ID, NewCourses.Name, NewCourses.PreReqID, NewCourses.Credits, NewCourses.LectureHour, NewCourses.PracticeHour, NewCourses.ReceptionHour, NewCourses.Year, NewCourses.Semester, NewCourses.Department, NewSchedule.LectureID, NewSchedule.Day, NewSchedule.StartHour, NewSchedule.EndHour, NewSchedule.Type FROM NewCourses, NewSchedule WHERE NewCourses.ID = NewSchedule.CourseID AND NewCourses.ID = @ID AND (NewSchedule.Type='Lecture' OR NewSchedule.Type='Lab' OR NewSchedule.Type='Practice')", connection);
            command.Parameters.AddWithValue("@ID", _id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable;
        }
        public static bool addChange(string _title, string _description, int _starts, int _ends, int _day, int _month, int _year, int _LectureID)
        {
            try
            {
                connection.Open();
                SqlCommand insertChanges = new SqlCommand("INSERT INTO [CurriculumChanges] (LectureID, Title, Description, Starts, Ends, Day, Month, Year) VALUES (@LectureID, @Title, @Description,  @Starts, @Ends, @Day, @Month, @Year)", connection);
                insertChanges.Parameters.AddWithValue("@Title", _title);
                insertChanges.Parameters.AddWithValue("@LectureID", _LectureID);
                insertChanges.Parameters.AddWithValue("@Description", _description);
                insertChanges.Parameters.AddWithValue("@Starts", _starts);
                insertChanges.Parameters.AddWithValue("@Ends", _ends);
                insertChanges.Parameters.AddWithValue("@Day", _day);
                insertChanges.Parameters.AddWithValue("@Month", _month);
                insertChanges.Parameters.AddWithValue("@Year", _year);
                insertChanges.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static bool delChange(int _LectureID)
        {
            try
            {
                connection.Open();
                SqlCommand insertChanges = new SqlCommand("DELETE FROM [CurriculumChanges] WHERE LectureID=@LectureID", connection);
                insertChanges.Parameters.AddWithValue("@LectureID", _LectureID);
                insertChanges.ExecuteNonQuery();

            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static DataTable getChanges()
        {
            DataTable changes = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [CurriculumChanges]", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            try
            {
                connection.Open();
                dataAdapter.Fill(changes);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (changes.Rows.Count <= 0)
                return null;

            return changes;
        }

        public static string getUsersDepartment(int _userID)
        {
            string department;
            //this function recives a course id and returns its name
            SqlCommand cmd = new SqlCommand("SELECT Department FROM [NewUsers] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _userID);
            connection.Open();
            department = (string)cmd.ExecuteScalar();
            connection.Close();
            return department;
        }

        public static string covertLectureIDtoLectureName(int _lectureID)
        {
          
            string lectureName = "";

            SqlCommand cmd = new SqlCommand("SELECT Name FROM [NewSchedule] WHERE LectureID=@LectureID", connection);
            cmd.Parameters.AddWithValue("@LectureID", _lectureID);
            connection.Open();

            lectureName = (string)cmd.ExecuteScalar();

            connection.Close();

            return lectureName;
        }

        public static DataRow getUserProperties(int _id)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM NewUsers WHERE ID=@ID", connection);
            command.Parameters.AddWithValue("@ID", _id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable.Rows[0];
        }

        public static DataRow getStudentProperties(int _id)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM [StudentsDetails] WHERE ID=@ID", connection);
            command.Parameters.AddWithValue("@ID", _id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable.Rows[0];
        }

        public static DataRow getClassroomProperties(string _name)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM [Classrooms] WHERE Name=@Name", connection);
            command.Parameters.AddWithValue("@Name", _name);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable.Rows[0];

        }

        public static int getNumberOfRegisteredStudentsAtLesson(int _lectureID)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM [StudentsTimeTable] WHERE LectureID=@LectureID", connection);
            command.Parameters.AddWithValue("@LectureID", _lectureID);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            return dataTable.Rows.Count;
        }

        public static DataRow getLessonProperties(int _lectureID)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM [NewSchedule] WHERE LectureID=@LectureID", connection);
            command.Parameters.AddWithValue("@LectureID", _lectureID);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable.Rows[0];
        }

        public static bool addError(int _userID, string _title, string _description)
        {
            try
            {
                connection.Open();
                SqlCommand addError = new SqlCommand("INSERT INTO [Errors] (UserID, Title, Description, Viewed) VALUES (@UserID, @Title, @Description, 'False')", connection);
                addError.Parameters.AddWithValue("@UserID", _userID);
                addError.Parameters.AddWithValue("@Title", _title);
                addError.Parameters.AddWithValue("@Description", _description);
                addError.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public static bool deleteError(int _UserID)
        {
            try
            {
                connection.Open();
                SqlCommand delError = new SqlCommand("DELETE FROM [Errors] WHERE UserID = @UserID", connection);
                delError.Parameters.AddWithValue("@UserID", _UserID);
                delError.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static DataTable getErrors()
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM [Errors], [NewUsers] WHERE NewUsers.ID=Errors.UserID", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable;
        }

        public static bool updateErrorsStatus(List<int> _errorsIds)
        {
            try
            {
                connection.Open();

                for (int i = 0; i < _errorsIds.Count; i++)
                {
                    SqlCommand updateStatus = new SqlCommand("UPDATE [Errors] SET Viewed='True' WHERE ErrorID=@ErrorID", connection);
                    updateStatus.Parameters.AddWithValue("@ErrorID", _errorsIds[i]);
                    updateStatus.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static bool ChangeStudentNotificationState(List<int> _userIDs, string _state)
        {
            try
            {
                connection.Open();
                for (int i = 0; _userIDs != null && i < _userIDs.Count; i++)
                {
                    SqlCommand updateState = new SqlCommand("UPDATE [StudentsDetails] SET Notification=@Notification WHERE ID=@ID", connection);
                    updateState.Parameters.AddWithValue("@ID", _userIDs[i]);
                    updateState.Parameters.AddWithValue("@Notification", _state);
                    updateState.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static DataTable getTimeTableChanges()
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM [CurriculumChanges]", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable;
        }
        public static DataTable getLectureDataTable(int _lectureID)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM [NewSchedule] WHERE LectureID=@LectureID", connection);
            command.Parameters.AddWithValue("@LectureID", _lectureID);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable;
        }
        public static DataTable getStudentsTimetable(int _id)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM [StudentsTimeTable] WHERE StudentID=@ID", connection);
            command.Parameters.AddWithValue("@ID ",_id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable;
        }

        public static int getIDbyEmail(string _email)
        {
            int id;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID FROM [NewUsers] WHERE Email=@Email", connection);
                cmd.Parameters.AddWithValue("@Email", _email);

                id = (int)cmd.ExecuteScalar();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return 0;
            }
            finally
            {
                connection.Close();
            }
            return id;
        }
        public static bool checkExistsEmail(string _email)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM [NewUsers] WHERE Email=@Email", connection);
            cmd.Parameters.AddWithValue("@Email", _email);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                if (dr.HasRows == true)
                {
                    connection.Close();
                    return true;
                }

            connection.Close();
            return false;
        }

        public static DataRow checkFbLogIn(string _mail)
        {

            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT ID, Password FROM [NewUsers] WHERE FBMail=@FBMail", connection);
            command.Parameters.AddWithValue("@FBMail", _mail);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable.Rows[0];
        }
        public static string convertFbMailToMail(string _fbMail)
        {
            string role = "ERROR";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Email FROM [NewUsers] WHERE FBMail=@FBMail", connection);
                command.Parameters.AddWithValue("@FBMail", _fbMail);
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                role = dataReader[0].ToString();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                //case exception
                connection.Close();
            }
            return role;
        }

        public static bool linkFbAccount(string _mail, string _fbMail)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [NewUsers] SET FBMail=@FBMail WHERE Email=@Email", connection);
                command.Parameters.AddWithValue("@Email", _mail);
                command.Parameters.AddWithValue("@FBMail", _fbMail);
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                //case exception
                connection.Close();
            }
            return true;
        }
        public static DataTable getUsers()
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM [NewUsers]", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable;
        }
        public static bool checkExistsStudents(int _id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM [StudentsDetails] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _id);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                if (dr.HasRows == true)
                {
                    connection.Close();
                    return true;
                }

            connection.Close();
            return false;
        }
        public static bool addStudent(int _id, int _year, char _semester)
        {
   
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [StudentsDetails] VALUES (@ID,  @Year, @Semester,@WeeklyHours,@SemesterPoint,@Notification)", connection);
                cmd.Parameters.AddWithValue("@ID",_id);
                cmd.Parameters.AddWithValue("@Year", _year);
                cmd.Parameters.AddWithValue("@Semester", _semester);
                cmd.Parameters.AddWithValue("@WeeklyHours", 0);
                cmd.Parameters.AddWithValue("@SemesterPoint", 0);
                cmd.Parameters.AddWithValue("@Notification", false);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public static bool deleteStudent(int _id)
        {

            try
            {
                connection.Open();
                SqlCommand deleteUser = new SqlCommand("DELETE FROM [StudentsDetails] WHERE ID = @ID", connection);
                deleteUser.Parameters.AddWithValue("@ID", _id);
                deleteUser.ExecuteNonQuery();
                deleteUser = new SqlCommand("DELETE FROM [StudentsGrades] WHERE ID = @ID", connection);
                deleteUser.Parameters.AddWithValue("@ID", _id);
                deleteUser.ExecuteNonQuery();

            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;

        }
        public static bool addConstraint(string lecturerID,string day, string startHour, string endHour,string description,string fullName,string date,string semester,string courseName)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Constraints] (User_ID,Days,StartHours,EndHours,Notes,FullName,Seen,Date,Semester,Approved,Course) VALUES (@User_ID,@Day,  @StartHour, @EndHour,@Notes,@FullName,@Seen,@Date,@Semester,@Approved,@Course)", connection);
                cmd.Parameters.AddWithValue("@User_ID", lecturerID);
                cmd.Parameters.AddWithValue("@Day", day);
                cmd.Parameters.AddWithValue("@StartHour", startHour);
                cmd.Parameters.AddWithValue("@EndHour", endHour);
                cmd.Parameters.AddWithValue("@Notes", description);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Semester", semester);
                cmd.Parameters.AddWithValue("@Seen", "true");
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Approved", "true");
                cmd.Parameters.AddWithValue("@Course", courseName);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public static bool ClearErrors()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Errors]", connection);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public static DataTable getClassrooms()
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM [Classrooms]", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable;
        }
        public static DataTable getStudents()
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT FirstName,LastName,NewUsers.ID,Department,StudentsDetails.Year,StudentsDetails.Semester FROM NewUsers,StudentsDetails WHERE NewUsers.ID=StudentsDetails.ID", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable;
        }
        public static string findLectureSemester(int _lectureID)
        {
            string semester = "";
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Semester FROM [NewCourses] WHERE ID = (SELECT CourseID FROM NewSchedule WHERE LectureID=@LectureID)", connection);
                cmd.Parameters.AddWithValue("@LectureID", _lectureID);
                connection.Open();
                semester = (string)cmd.ExecuteScalar();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
            }

            return semester;
        }
       public static string findLecturerNameByLectureID(int _lectureID)
        {
            string fullName = "";
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT LecturerName FROM [NewSchedule] WHERE LectureID=@LectureID", connection);
                cmd.Parameters.AddWithValue("@LectureID", _lectureID);
                connection.Open();
                fullName = (string)cmd.ExecuteScalar();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
            }
            return fullName;
        }
        public static string getLecturerIDByLecturerName(string _lecturerName)
        {
            string id="0";
            string firstName = "";
            string lastName = "";
            int index = _lecturerName.IndexOf(' ');
            if (index > 0)
            {
                firstName = _lecturerName.Substring(0, index);
            }
            lastName = "@"+_lecturerName;
            lastName=lastName.Substring(lastName.IndexOf(@" ") +1);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT ID FROM [NewUsers] WHERE FirstName=@FirstName AND LastName=@LastName", connection);
                cmd.Parameters.AddWithValue("@LecturerName", _lecturerName);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                connection.Open();
                id = (cmd.ExecuteScalar()).ToString();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                
            }

            return id;
        }
        public static DataTable getLecturesByDepartment(string _department)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT LectureID,Name From [NewSchedule] WHERE Department=@Department", connection);
            command.Parameters.AddWithValue("@Department", _department);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
                dataAdapter.Dispose();
            }

            if (dataTable.Rows.Count <= 0)
                return null;

            return dataTable;
        }


    }
}

