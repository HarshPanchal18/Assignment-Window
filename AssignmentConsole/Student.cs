using System;

namespace AssingmentConsole.Model {
    
    public class Student {

        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Student(int Id, string Name) {
            this.Id = Id;
            this.Name = Name;
        }

        public Student() { }
    }
}
