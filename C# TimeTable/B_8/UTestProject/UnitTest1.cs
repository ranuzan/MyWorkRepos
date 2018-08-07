using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using B_8;
using System.Data.SqlClient;

namespace UTestProject
{
    [TestClass]
    public class UnitTest1 /*  DataBase  */
    {
        [TestMethod]
        public void Test_Connect_Method()
        {
            DataBase db = new DataBase();
            Assert.IsTrue(db.Connect());
        }

        [TestMethod]
        public void Test_Select_Method()
        {
            DataBase db = new DataBase();
            SqlDataReader read = db.Select("*", "Courses");
            Assert.IsInstanceOfType(read, typeof(SqlDataReader));
        }

        [TestMethod]
        public void Test_Select_2_Method()
        {
            DataBase db = new DataBase();
            SqlDataReader read = db.Select("ID", "Courses", "100001", "100001");
            Assert.IsInstanceOfType(read, typeof(SqlDataReader));
        }

        [TestMethod]
        public void Test_isconnected_Method()
        {
            DataBase db = new DataBase();
            Assert.IsFalse(db.isconnected);
        }

        [TestMethod]
        public void Test_DataBase_Method()
        {
            DataBase db = new DataBase();
            Assert.IsTrue(db.IsUnitTest);
        }

        [TestMethod]
        public void Test_DeleteCourse_Method()
        {
            DeleteCourse dc = new DeleteCourse();
            Assert.IsTrue(dc.IsUnitTest); 
        }

        [TestMethod]
        public void Test_AddCourse_Method()
        {
            AddCourse ad = new AddCourse();
            Assert.IsTrue(ad.IsUnitTest);
        }
        [TestMethod]
        public void Test_AddCourseToSchedule_Method()
        {
            AddCourseToSchedule acts = new AddCourseToSchedule();
            Assert.IsTrue(acts.IsUnitTest);
        }

        [TestMethod]
        public void Test_ClassDepartment_Method()
        {
            ClassDepartment cd = new ClassDepartment();
            Assert.IsTrue(cd.IsUnitTest);
        }

        [TestMethod]
        public void Test_Constraints_Method()
        {
            Constraints C = new Constraints();
            Assert.IsTrue(C.IsUnitTest);
        }

        [TestMethod]
        public void Test_Contact_Us_Method()
        {
            Contact_Us cu = new Contact_Us();
            Assert.IsTrue(cu.IsUnitTest);
        }

        [TestMethod]
        public void Test_Course_Filtering_Suitability_Method()
        {
            Course_Filtering_Suitability cfs = new Course_Filtering_Suitability();
            Assert.IsTrue(cfs.IsUnitTest);
        }

        [TestMethod]
        public void Test_DeleteWeeklySchedule_Method()
        {
            DeleteWeeklySchedule dws = new DeleteWeeklySchedule();
            Assert.IsTrue(dws.IsUnitTest);
        }

        [TestMethod]
        public void Test_EnterKey_Method()
        {
            EnterKey ek = new EnterKey();
            Assert.IsTrue(ek.IsUnitTest);
        }

        [TestMethod]
        public void Test_Exam_Deatails_Method()
        {
            Exam_Deatails ed = new Exam_Deatails();
            Assert.IsTrue(ed.IsUnitTest);
        }

        [TestMethod]
        public void Test_ForgotMyPassword_Method()
        {
            ForgotMyPassword ed = new ForgotMyPassword();
            Assert.IsTrue(ed.IsUnitTest);
        }

        [TestMethod]
        public void Test_GlobalVariables_Method()
        {
            Assert.IsInstanceOfType(GlobalVariables.minDate, typeof(DateTime));
        }

        [TestMethod]
        public void Test_GlobalVariables_2_Method()
        {
            Assert.IsInstanceOfType(GlobalVariables.maxDate, typeof(DateTime));
        }

        [TestMethod]
        public void Test_GlobalVariables_3_Method()
        {
            Assert.IsNotInstanceOfType(GlobalVariables.Full_Name, typeof(int));
        }

        [TestMethod]
        public void Test_ListCourses_Method()
        {
            ListCourses lc = new ListCourses();
            Assert.IsTrue(lc.IsUnitTest);
        }

        [TestMethod]
        public void Test_main_Method()
        {
            main M = new main();
            Assert.IsTrue(M.IsUnitTest);
        }

        [TestMethod]
        public void Test_login_Method()
        {
            login L = new login();
            Assert.IsTrue(L.IsUnitTest);
        }



    }
}
