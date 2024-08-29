using AssignmentConsole.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AssignmentConsole {

    internal class Program {

        private static readonly object lockObj = new object();

        static void Main(string[] args) {
            /*var student = new Student(1, "Harsh", 18, 3);

            var teacher = new Teacher(
                1, "T1", "Ast", "CSE", Subject.preDefinedSubjects.FindAll(sub => sub.Name == "")
            );*/

            if (args.Length == 0) {
                Console.WriteLine("Please provide the path to the C# script.");
                return;
            }

            string scriptPath = args[0];

            lock (lockObj) {
                ProcessStartInfo startInfo = new ProcessStartInfo("dotnet-script", scriptPath) {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process ps = new Process()) {
                    ps.StartInfo = startInfo;
                    ps.Start();

                    string output = ps.StandardOutput.ReadToEnd();
                    string error = ps.StandardError.ReadToEnd();

                    ps.WaitForExit();

                    if (!string.IsNullOrEmpty(output)) {
                        Console.WriteLine("Output: ");
                        Console.WriteLine(output);
                    }

                    if (!string.IsNullOrEmpty(error)) {
                        Console.WriteLine("Error: ");
                        Console.WriteLine(error);
                    }

                    ps.Dispose();

                    ps.Close();
                }

            }
        }
    }
}
