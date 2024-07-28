using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentConsole.Model {
    internal class Teacher {

        public int Id { get; set; } // Teacher Id
        public string Name { get; set; } // Teacher Name
        public string Type { get; set; } // Type of teacher (optional)
        public string Department { get; set; } // Teacher Department
        public List<TeacherSubject> Subjects { get; set; } // List of subjects taught by the teacher

        public Teacher() {
            Subjects = new List<TeacherSubject>();
        }
    }
}
