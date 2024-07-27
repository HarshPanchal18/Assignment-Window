using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentConsole.Model {
    internal class Assignment {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Semester { get; set; }
        
        public Assignment() { }
        public Assignment(int id, string name, string content) {
            Id = id;
            Name = name;
            Content = content;
        }
    }
}
