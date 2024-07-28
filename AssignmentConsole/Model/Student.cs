namespace AssignmentConsole.Model {
    internal class Student {
        public int Id { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }

        public Student() { }

        public Student(int Id, string Name) {
            this.Id = Id;
            this.Name = Name;
        }

    }
}
