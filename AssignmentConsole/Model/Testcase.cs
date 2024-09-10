using System;

namespace AssignmentConsole.Model {
    internal class Testcase<T1, T2, T3> {

        // public Testcase(params  input) { }

        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string InputValues { get; set; } = null;

        public string InputValueDatatype { get; set; } = null;

        public bool IsHidden { get; set; } = false;

        public string OutputValue { get; set; } = null;

        public string OutputValueDatatype { get; set; } = null;

        public bool Status { get; set; } = false;

        public bool Deleted { get; set; } = false;

        public DateTime? CreationTimestamp { get; set; }

        public DateTime? UpdationTimestamp { get; set; }

        public DateTime? DeletionTimestamp { get; set; }

        public virtual Question Question { get; set; } = null;

        /*public void Demo() {
            List<Testcase> testCases = new List<Testcase> {
                new Testcase(1, 2, 3),
                new Testcase(5, 7, 12),
                new Testcase(-1, -1, -2),
                new Testcase(0, 0, 0)
            };

            foreach (var testcase in testcases) {
                int result = Solution.Add(testcase.Input1, testcase.Input2);

                if (result == testcase.ExpectedOutput) {
                    Console.WriteLine($"Test passed for inputs ({testcase.Input1}, {testcase.Input2})");
                } else {
                    Console.WriteLine($"Test failed for inputs ({testcase.Input1}, {testcase.Input2}). Expected {testcase.ExpectedOutput}, but got {result}");
                }
            }
        }*/

    }

}
