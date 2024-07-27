using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentConsole.Model {
    internal class Teacher {
        public Teacher() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Department { get; set; }
        public string[] Subjects { get; set; }
    }
}
