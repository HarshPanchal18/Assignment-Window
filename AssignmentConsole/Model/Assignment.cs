namespace AssignmentConsole.Model {
    internal class Assignment {

        public int Id { get; set; }
        public int Number { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string Content { get; set; }
        public int Semester { get; set; }

        public Assignment() { }
    }
}
