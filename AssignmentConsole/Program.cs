using AssignmentConsole.Model;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Linq;

namespace AssignmentConsole {

    internal class Program {

        //private static readonly object lockObj = new object();

        static void Main(string[] args) {
            /*var student = new Student(1, "Harsh", 18, 3);

            var teacher = new Teacher(
                1, "T1", "Ast", "CSE", Subject.preDefinedSubjects.FindAll(sub => sub.Name == "")
            );*/

            /*if (args.Length == 0) {
                Console.WriteLine("Please provide the path to the C# script.");
                return;
            }*/

            // string path = @"C:\Users\HARSH\Desktop\hello.txt"; // args[0];

            try {
                // string path = @"/Users/HARSH/Oracle/hello.txt"; // args[0];

                string code =
                    "using System;" +
                    "using System.Collections.Generic;" +
                    "using System.IO;" +
                    // "using System.Linq;" +

                    "public class Program {" +

                    "    public static void Main()    {" +
                    "        Console.WriteLine(\"Hello from dynamically compiled code!\");" +
                    "        string v = Console.ReadLine();" +
                    "        Console.WriteLine(v);" +

                    "       var names = new List<string>() { \"name\", \"age\", \"address\" };" +
                    /*"       var namess = from n in names where n.Length == 4 select n;" +
                    "       foreach (var name in namess) {" +
                    "            Console.WriteLine(name);" +
                    "       }" +*/

                    "    }" +
                    "}";

                var names = new List<string>() { "name", "age", "address" };

                var namess = from n in names where n.Length == 4 select n;
                foreach (var name in namess) {
                    Console.WriteLine(name);
                }

                using (var provider = new CSharpCodeProvider()) {
                    var parameters = new CompilerParameters {
                        GenerateExecutable = true,
                        GenerateInMemory = true,
                    };
                    parameters.ReferencedAssemblies.Add("System.dll");

                    CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);

                    if (results.Errors.Count > 0) {
                        foreach (CompilerError error in results.Errors) {
                            Console.WriteLine($"Error ({error.ErrorNumber}): {error.ErrorText}");
                        }
                    } else {
                        Assembly assembly = results.CompiledAssembly;
                        Type programType = assembly.GetType("Program");
                        MethodInfo mainMethod = programType.GetMethod("Main");

                        mainMethod.Invoke(null, null);
                    }

                    // lock (lockObj) {
                    /*ProcessStartInfo startInfo = new ProcessStartInfo {
                        FileName = scriptPath,
                        RedirectStandardOutput = true, // Use the operating system shell to start the process
                        RedirectStandardError = true, // Set to true if you want to capture output
                        UseShellExecute = false, // Set to true if you want to capture errors
                        CreateNoWindow = true // Set to true if you don't want a window to be created
                    };

                    try {
                        using (Process ps = Process.Start(startInfo)) {

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

                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                    }
                    */
                }
            } catch (FileNotFoundException ex) {
                Console.WriteLine("Directory is invalid...");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
