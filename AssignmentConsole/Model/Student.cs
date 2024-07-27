using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentConsole.Model {
    internal class Student {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Student() { }

        public Student(int id, string name, string firstName, string lastName, int age, string email, string phone, string address, string city, string state) {
            Id = id;
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            State = state;
        }

        public Student(int Id, string Name) {
            this.Id = Id;
            this.Name = Name;
        }

    }
}
