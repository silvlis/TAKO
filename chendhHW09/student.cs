using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace chendhHW09
{
    class student
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }

        public override string ToString()
        {
            return $"{StudentID} {StudentName}";
        }
    }
}
