using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chendhHW09
{
    internal class course
    {
        public string CourseName { get; set; }
        public string Type { get; set; }
        public int Point { get; set; }
        public string OpeningClass { get; set; }
        public teacher Tutor { get; set; }
        public course(teacher tutor)
        {
            this.Tutor = tutor;
        }
    }
}
