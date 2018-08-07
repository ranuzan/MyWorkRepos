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

        public static void insertUser(int _id, string _password, string _firstName, string _lastName, string _role, string _department = "")
        {
            //this function adds a user to the user DB table 
            //all details are recived as params
            try
            {
                connection.Open();
                SqlCommand insertUser = new SqlCommand("INSERT INTO [Users] VALUES (@ID,  @Password, @FirstName, @LastName, @Role, @Department)", connection);
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
                    insertStudent.Parameters.AddWithValue("@Semester", false);
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
            }
            finally
            {
                connection.Close();
            }
        }

        public static void addClassroom(string _name, int _capacity)
        {
            //this function adds a classroom to the classroom DB table
            //all details are recived as params
            try
            {
                connection.Open();
                SqlCommand insertClassroom = new SqlCommand("INSERT INTO [Classrooms] VALUES (@Name,  @Capacity)", connection);
                insertClassroom.Parameters.AddWithValue("@Name", _name);
                insertClassroom.Parameters.AddWithValue("@Capacity", _capacity);
                insertClassroom.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool checkLogIn(int _id, string _password)
        {
            //this function checks login details of a user trying to login
            //all details are recived as params

            connection.Open();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Users] WHERE ID='" + _id + "'AND Password='" + _password + "'", connection);

            int result = (int)command.ExecuteScalar();
            connection.Close();

            if (result > 0)
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
                SqlCommand command = new SqlCommand("SELECT Role FROM [Users] WHERE ID=@ID", connection);
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Users] WHERE ID=@ID", connection);
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

        public static void deleteUser(int _id)
        {
            //this function deletes a user from the user DB table via its id
            //id is recived as a param
            try
            {
                connection.Open();
                SqlCommand deleteUser = new SqlCommand("DELETE FROM [Users] Where ID=@ID", connection);
                deleteUser.Parameters.AddWithValue("@ID", _id);
                deleteUser.ExecuteNonQuery();
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

        public static void deleteClassroom(string _name)
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
            }
            finally
            {
                connection.Close();
            }
        }

        public static void updateUserRole(int _id, string _role, string _department = "")
        {
            //this function changes a user permission via its id
            //all details are recived as params
            try
            {
                connection.Open();
                SqlCommand updateRole = new SqlCommand("UPDATE [Users] SET Role=@Role, Department=@Department WHERE ID=@ID", connection);
                updateRole.Parameters.AddWithValue("@Role", _role);
                updateRole.Parameters.AddWithValue("@Department", _department);
                updateRole.Parameters.AddWithValue("@ID", _id);
                updateRole.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                //case exception
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public static void addLecturesToStudent(int _id, List<int> _lecureIDs, float _semesterPoints, int _weeklyHours)
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
                    SqlCommand addLecture = new SqlCommand("INSERT INTO [StudentsTimeTable] VALUES (@StudentID,  @LectureID)", connection);
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
            }
            finally
            {
                connection.Close();
            }
        }

        public static void deleteLectureFromStudent(int _id, int _lectureID)
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
            }
            finally 
            {
                connection.Close();
            }
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

            SqlCommand cmd = new SqlCommand("SELECT * FROM [Lectures] WHERE LectureID=@LectureID", connection);
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

            SqlCommand cmd = new SqlCommand("SELECT * FROM [CoursesA] WHERE ID=@ID", connection);
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

        public static List<int> findAllowedCoursesForStudent(int _id, int _year, bool _semester, string _department)
        {
            //find allowed courses for a specific student  via his year semester and department     
            //all details are recived  as params
            List<int> allowedCoursesWithoutPreReqs = new List<int>();
            List<int> allowedCoursesWithPreReqs = new List<int>();
            float _yearSemester = _year + ((float)(Convert.ToInt32(_semester) + 1) / 10);

            SqlCommand cmd = new SqlCommand("SELECT ID FROM [CoursesA] WHERE PreReqID IS NULL AND YearSemester<=@YearSemester AND Department=@Department", connection);
            cmd.Parameters.AddWithValue("@YearSemester", _yearSemester);
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
                dr.Close();
            }

            cmd = new SqlCommand("SELECT ID FROM [CoursesA],(SELECT CourseID FROM StudentsGrades WHERE ID=@ID AND Grade >= 56) AS PassedCourses WHERE PreReqID = PassedCourses.CourseID AND YearSemester<=@YearSemester AND Department=@Department", connection);
            cmd.Parameters.AddWithValue("@ID", _id);
            cmd.Parameters.AddWithValue("@YearSemester", _yearSemester);
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

            SqlCommand cmd = new SqlCommand("SELECT Name FROM [CoursesA] WHERE ID=@ID", connection);
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

            SqlCommand cmd = new SqlCommand("SELECT LectureID FROM [Lectures] WHERE CourseID=@CourseID", connection);
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
            int courseID=0;

            SqlCommand cmd = new SqlCommand("SELECT ID FROM [CoursesA] WHERE Name=@Name", connection);
            cmd.Parameters.AddWithValue("@Name", _courseName);
            connection.Open();

            courseID =(int)cmd.ExecuteScalar();

            connection.Close();

            return courseID;
        }

        public static void addGradeToStudent(int _studentID,int _courseID,int _grade)
        {
            //this function adds a grade to student for a specific course
            //all params recived at checked and if valid grade is given
            try
            {
                connection.Open();
                SqlCommand addGrade = new SqlCommand("INSERT INTO [StudentsGrades] VALUES (@ID,  @CourseID,@Grade)", connection);
                addGrade.Parameters.AddWithValue("@ID", _studentID);
                addGrade.Parameters.AddWithValue("@CourseID", _courseID);
                addGrade.Parameters.AddWithValue("@Grade", _grade);
                addGrade.ExecuteNonQuery();
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

        public static List<string> findCoursePropertiesByDepartment(string _department)
        {
            //this function returns all course properties of a specifc department 
            List<string> coursesPropertiesList = new List<string>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [CoursesA] WHERE Department=@Department", connection);
            cmd.Parameters.AddWithValue("@Department", _department);
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

        public static List<string> findStudentsToGrade(int _courseID)
        {
            //this function finds student via a course he is signed to and then lets user grade a specific student
            List<string> studentsPropertiesList = new List<string>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [StudentsTimeTable] WHERE CourseID=@CourseID", connection);
            cmd.Parameters.AddWithValue("@CourseID", _courseID);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        studentsPropertiesList.Add(Convert.ToString(dr.GetValue(i)));
                    }
                }

                connection.Close();
                return studentsPropertiesList;
            }

            connection.Close();
            return studentsPropertiesList;
        }

        public static int covertLectureNametoLectureID(string _lectureName)
        {
            //this function recives a lecture name and return the lecture id for that lecture
            int lectureID = 0;

            SqlCommand cmd = new SqlCommand("SELECT LectureID FROM [Lectures] WHERE Name=@Name", connection);
            cmd.Parameters.AddWithValue("@Name", _lectureName);
            connection.Open();

            lectureID = (int)cmd.ExecuteScalar();

            connection.Close();

            return lectureID;
        }

        public static List<int> getStudentDetailsByCourseID(int _courseID)
        {
            //this function return all student details for a student signed to some course
            List<int> LecturesID = new List<int>();
            
            SqlCommand cmd = new SqlCommand("SELECT LectureID FROM [Lectures] WHERE CourseID=@CourseID", connection);
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

            SqlCommand cmd = new SqlCommand("SELECT LastName FROM [Users] WHERE ID=@ID", connection);
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

            SqlCommand cmd = new SqlCommand("SELECT FirstName FROM [Users] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _studentID);
            connection.Open();

            studentName = (string)cmd.ExecuteScalar();

            connection.Close();

            return studentName;
        }

        public static int getStudentYear(int _studentID)
        {
            //this function recives a student id and returns that student year
            int studentYear = 0;

            SqlCommand cmd = new SqlCommand("SELECT Year FROM [StudentsDetails] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _studentID);
            connection.Open();

            studentYear = (int)cmd.ExecuteScalar();

            connection.Close();

            return studentYear;
        }

        public static bool getStudentSemester(int _studentID)
        {
            //this function recives a student id and returns that student semeter
            bool studentSemester = false;

            SqlCommand cmd = new SqlCommand("SELECT Semester FROM [StudentsDetails] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _studentID);
            connection.Open();

            studentSemester = (bool)cmd.ExecuteScalar();

            connection.Close();

            return studentSemester;
        }

        public static string getStudentDepartment(int _studentID)
        {
            //this function recives a student id and returns that student department
            string studentDepartment = "";

            SqlCommand cmd = new SqlCommand("SELECT Department FROM [Users] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _studentID);
            connection.Open();

            studentDepartment = (string)cmd.ExecuteScalar();

            connection.Close();

            return studentDepartment;
        }

        public static float getStudentSemesterPoints(int _studentID)
        {
            //this function recives a student id and returns that student semester points
            float studentSemesterPoints = 0;

            SqlCommand cmd = new SqlCommand("SELECT SemesterPoint FROM [StudentsDetails] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _studentID);
            connection.Open();

            studentSemesterPoints = (float)(double)cmd.ExecuteScalar();

            connection.Close();

            return studentSemesterPoints;
        }

        public static bool getStudentNotificationsState(int _studentID)
        {
            //this function recives a student id and returns that student notification state (0 or 1)

            bool studentNotification = false;

            SqlCommand cmd = new SqlCommand("SELECT Notification FROM [StudentsDetails] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _studentID);
            connection.Open();

            studentNotification = (bool)cmd.ExecuteScalar();

            connection.Close();

            return studentNotification;
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

        public static int getStudentWeeklyHours(int _studentID)
        {
            //this function recives a student id and returns that student weekly hours
            int studentWeeklyHours = 0;

            SqlCommand cmd = new SqlCommand("SELECT WeeklyHours FROM [StudentsDetails] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _studentID);
            connection.Open();

            studentWeeklyHours = (int)cmd.ExecuteScalar();

            connection.Close();

            return studentWeeklyHours;
        }

        public static List<string> getCourseDetailsByYearAndSemester(double _yearAndSemester)
        {
            List<string> courseDetails = new List<string>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [CoursesA] WHERE YearSemester=@YearSemester", connection);
            cmd.Parameters.AddWithValue("@YearSemester", _yearAndSemester);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        courseDetails.Add(Convert.ToString(dr.GetValue(i)));
                    }
                }

                connection.Close();
                return courseDetails;
            }
            connection.Close();
            courseDetails = null;
            return courseDetails;
        }

        public static int covertCourseIDtoCourseLectureHours(int _courseID)
        {
            //this function recives a course id and returns its name
            int courseHours = 0;

            SqlCommand cmd = new SqlCommand("SELECT LectureHour FROM [CoursesA] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _courseID);
            connection.Open();
            courseHours = (int)cmd.ExecuteScalar();
            connection.Close();
            return courseHours;
        }

        public static int covertCourseIDtoCoursePracticeHours(int _courseID)
        {
            //this function recives a course id and returns its name
            int courseHours = 0;

            SqlCommand cmd = new SqlCommand("SELECT PracticeHour FROM [CoursesA] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _courseID);
            connection.Open();
            courseHours = (int)cmd.ExecuteScalar();
            connection.Close();
            return courseHours;
        }
        public static List<string> getStudentsGrades(int _id)
        {
            List<string> studentsGrades = new List<string>();

            SqlCommand cmd = new SqlCommand("SELECT CourseID,Grade FROM [StudentsGrades] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _id);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        studentsGrades.Add(Convert.ToString(dr.GetValue(i)));
                    }
                }

                connection.Close();
                return studentsGrades;
            }
            connection.Close();
            studentsGrades = null;
            return studentsGrades;
        }

        public static bool isStudentGraded(int _studentID,int _courseID)
        {
            int exists;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [StudentsGrades] WHERE ID=@ID AND CourseID=@CourseID", connection);
            cmd.Parameters.AddWithValue("@ID", _studentID);
            cmd.Parameters.AddWithValue("@CourseID", _courseID);
            connection.Open();
            exists = (int)cmd.ExecuteScalar();
            if (exists>0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;            
        }

        public static void updateGradeToStudent(int _studentID, int _courseID, int _grade)
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
            }
            finally
            {
                connection.Close();
            }
        }

        public static void deleteStudentTimeTable(int _id)
        {
            try
            {
                connection.Open();
                SqlCommand deleteTimeTable = new SqlCommand("DELETE FROM [StudentsTimeTable] WHERE StudentID=@StudentID", connection);
                deleteTimeTable.Parameters.AddWithValue("@StudentID", _id);
                SqlCommand resetSemesterPoints = new SqlCommand("UPDATE [StudentsDetails] SET SemesterPoint=0 WHERE ID=@ID", connection);
                resetSemesterPoints.Parameters.AddWithValue("@ID", _id);
                deleteTimeTable.ExecuteNonQuery();
                resetSemesterPoints.ExecuteNonQuery();
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

        public static DataTable getCourseProperties (int _id)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT CoursesA.ID, CoursesA.Name, CoursesA.PreReqID, CoursesA.Credits, CoursesA.LectureHour, CoursesA.PracticeHour, CoursesA.receiptHour, CoursesA.yearSemester, CoursesA.Department, Lectures.LectureID, Lectures.day, Lectures.starts, Lectures.ends, Lectures.Type FROM CoursesA, Lectures WHERE CoursesA.ID = Lectures.CourseID AND CoursesA.ID = @ID", connection);
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

            return dataTable;
        }
        public static void addChange(string _description, int _starts,int _ends,int _day,int _month,int _year,int _LectureID)
        {
            try
            {
                connection.Open();
                SqlCommand insertChanges= new SqlCommand("INSERT INTO [CurriculumChanges] VALUES (@LectureID,@Description,  @Starts, @Ends, @Day, @Month, @Year)", connection);
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
            }
            finally
            {
                connection.Close();
            }
        }
        public static List<string> getChanges()
        {
            List<string> ChangesList = new List<string>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [CurriculumChanges]", connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        ChangesList.Add(Convert.ToString(dr.GetValue(i)));
                    }
                }

                connection.Close();
                return ChangesList;
            }
            connection.Close();
            return null;
        }
        public static string getUsersDepartment(int _userID)
        {
            string department;
            //this function recives a course id and returns its name
            SqlCommand cmd = new SqlCommand("SELECT Department FROM [Users] WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", _userID);
            connection.Open();
            department = (string)cmd.ExecuteScalar();
            connection.Close();
            return department;
        }
        public static string covertLectureIDtoLectureName(int _lectureID)
        {
            //this function recives a course id and returns its name
            string lectureName = "";

            SqlCommand cmd = new SqlCommand("SELECT Name FROM [Lectures] WHERE LectureID=@LectureID", connection);
            cmd.Parameters.AddWithValue("@LectureID", _lectureID);
            connection.Open();

            lectureName = (string)cmd.ExecuteScalar();

            connection.Close();

            return lectureName;
        }

    }
}
