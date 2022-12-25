using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chendhHW09
{
    internal class teacher
    {
        public string TeacherName { get; set; }

        public ObservableCollection<course> teachingcourses { get; set; }

        public teacher()
        {
            this.teachingcourses = new ObservableCollection<course>();
        }
    }
}
