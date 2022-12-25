using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace chendhHW09
{
    internal class Rcord
    {
        public student SelectedStudent { get; set; }
        public course SelectedCourse { get; set; }
        public string TeacherName { get; set; }

        public bool Equals (Rcord r)
        {
            if (this.SelectedStudent.StudentID == r.SelectedStudent.StudentID && this.SelectedCourse.CourseName == r.SelectedCourse.CourseName) return true;
            else return false;
        }
    }
}
