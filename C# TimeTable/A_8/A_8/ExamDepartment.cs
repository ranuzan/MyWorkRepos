using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_8
{
    class ExamDepartment: Users
    {
        public ExamDepartment(int id):base(id){}
        public static void Grade_student()
        {
            FormExamDepartment_GradeStudent gradeStudent = new FormExamDepartment_GradeStudent();
            gradeStudent.Show();
        }
        public static void SearchCourse()
        {
            FormExamDepartment_SearchCourse searchCourse = new FormExamDepartment_SearchCourse();
            searchCourse.Show();
        }
        public static void FilterCourseByDepartment()
        {
            FormExamDepartment_FilterCourses filterCourse = new FormExamDepartment_FilterCourses();
            filterCourse.Show();
        }


    }
}
