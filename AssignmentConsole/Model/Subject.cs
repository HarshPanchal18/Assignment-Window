namespace AssignmentConsole.Model {
    internal class Subject {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; } // Subject Code

        public Subject() { }

        public Subject(int id, string name, string code) {
            Id = id;
            Name = name;
            Code = code;
        }

        public override string ToString() {
            return "Subject(" + Id + ", " + Name + ", " + Code + ")";
        }
    }
}