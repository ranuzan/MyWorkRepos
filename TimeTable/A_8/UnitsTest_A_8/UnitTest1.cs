using Microsoft.VisualStudio.TestTools.UnitTesting;
using A_8;
using B_8;
using System.Collections.Generic;
using System.Data;
using System;
using System.Windows.Forms;

namespace UnitsTest_A_8
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SQLTests()
        {
            //Assert.IsTrue(SQLFunctions.);

            //sql unit test

            Assert.AreEqual("Student", SQLFunctions.checkRole(308038405));
            Assert.AreEqual("Hedva1", SQLFunctions.covertCourseIDtoCourseName(2));
            Assert.AreEqual(2, SQLFunctions.covertCourseNametoCourseID("Hedva1"));
            Assert.AreEqual(12, SQLFunctions.covertLectureNametoLectureID("Hedva2"));
            Assert.AreEqual("Computer Architecture 1 ", SQLFunctions.covertLectureIDtoLectureName(40));


        }

        [TestMethod]
        public void LoginUnitTest()
        {

            Assert.IsTrue(SQLFunctions.checkLogIn(222222222, "2"));
            Assert.IsTrue(SQLFunctions.checkExistsUsers(308038405));
            Assert.AreEqual("",SQLFunctions.getUsersDepartment(222222222));
            Assert.IsTrue(SQLFunctions.linkFbAccount("liors1992@gmail.com", "liors1992@gmail.com"));
            Assert.AreEqual(SQLFunctions.convertFbMailToMail("liors1992@gmail.com"), "liors1992@gmail.com");
            Assert.IsTrue(SQLFunctions.checkExistsEmail("liors1992@gmail.com"));
            Assert.AreEqual(SQLFunctions.getIDbyEmail("liors1992@gmail.com"), 308038405);

            DataRow dataRow = SQLFunctions.checkFbLogIn("liors1992@gmail.com");
            Assert.AreEqual(Convert.ToInt32(dataRow[0]), 308038405);
            Assert.AreEqual((dataRow[1]), "654321");

        }

        [TestMethod]
        public void StudentUnitTest()
        {
            Assert.AreEqual("Shusterman", SQLFunctions.covertStudentIDtoStudentLastName(308038405));
            Assert.AreEqual("Lior", SQLFunctions.covertStudentIDtoStudentFirstName(308038405));
            Assert.IsTrue(SQLFunctions.addLecturesToStudent(308038405, new List<int> { 12, 19, 18 }, 30, 23));
            Assert.IsTrue(SQLFunctions.deleteLectureFromStudent(308038405, 12));
            Assert.IsTrue(SQLFunctions.deleteLectureFromStudent(308038405, 19));
            Assert.IsTrue(SQLFunctions.deleteLectureFromStudent(308038405, 18));
            Assert.IsTrue(SQLFunctions.ChangeStudentNotificationState(new List<int> { 308038405 }, "False"));
        }

        [TestMethod]
        public void SecretaryUnitTest()
        {
            Assert.IsTrue(SQLFunctions.addChange("title test", "test for unit Tests", 11, 12, 5, 8, 2016,999));
            Assert.IsTrue(SQLFunctions.delChange(999));
            Assert.IsTrue(SQLFunctions.addError(308038405, "Unit test", "test test test"));
            Assert.IsTrue(SQLFunctions.deleteError(308038405));
        }

        [TestMethod]
        public void ExamDepartmentUnitTest()
        {
            Assert.IsTrue(SQLFunctions.addGradeToStudent(308038405, 2, 90));
            Assert.IsTrue(SQLFunctions.isStudentGraded(308038405, 2));
            Assert.IsTrue(SQLFunctions.updateGradeToStudent(308038405, 2, 95));
            Assert.IsTrue(SQLFunctions.checkExistsClassroom("F104"));
            // adds lectures to student for unit test
            Assert.IsTrue(SQLFunctions.addLecturesToStudent(308038405, new List<int> {12,19,18}, 30, 23));
            //returns the student lectures test the findStudentLecturesIDs method
            CollectionAssert.AreEqual(SQLFunctions.findStudentLecturesIDs(308038405), new List<int> { 12, 19, 18 });
            //deletes the lectures for the test
            Assert.IsTrue(SQLFunctions.deleteLectureFromStudent(308038405, 12));
            Assert.IsTrue(SQLFunctions.deleteLectureFromStudent(308038405, 19));
            Assert.IsTrue(SQLFunctions.deleteLectureFromStudent(308038405, 18));
            CollectionAssert.AreEqual(SQLFunctions.getLectureIDByCourseID(6),new List<int> {17,22,39,44});
   
        }

        [TestMethod]
        public void AdmintUnitTest()
        {
            Assert.IsTrue(SQLFunctions.addClassroom("test", 20, "class"));
            Assert.IsTrue(SQLFunctions.deleteClassroom("test"));
            Assert.IsTrue(SQLFunctions.insertUser("unittest@gmail.com", 333333333, "3", "3", "3", "3", "3"));
            Assert.IsTrue(SQLFunctions.updateStudentYearAndSemester(333333333, 2, 'B'));
            Assert.IsTrue(SQLFunctions.updateUserRole(333333333, "3", "4"));
            Assert.IsTrue(SQLFunctions.deleteUser(333333333));
            Assert.IsTrue(SQLFunctions.checkExistsStudents(308038405));
            Assert.IsTrue(SQLFunctions.deleteStudent(308038405));
            Assert.IsTrue(SQLFunctions.addStudent(308038405, 2, 'A'));
            Assert.IsTrue(SQLFunctions.updateErrorsStatus(new List<int> { 45 }));
        }
    }
}
