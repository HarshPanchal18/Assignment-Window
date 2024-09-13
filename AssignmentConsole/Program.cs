using System;
using System.Diagnostics;
using System.ComponentModel;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Linq;
using AssignmentConsole.Model;
using System.Collections.Generic;
using AssignmentConsole.Utils;

namespace AssignmentConsole {

    internal class Program {

        static void Main(string[] args) {

            RunCsCode(
                        Const.USING_IMPORTS +

                        Const.MainMethod(
                            "{" +
                                "Console.WriteLine(Solution.add(7,8));" +
                            "}") +

                        Const.Solution("{" +
                                "public static int add(int n1, int n2) {" +
                                    "return n1 + n2;" +
                                "}" +
                            "}")

            );
        }

        private static Action<string> RunCsCode = (sourceCode) => {
            char[] whitespace = new char[] { ' ', '\t', '\r', '\n' };

            try {

                // Trimming whitespaces from the source code.
                string[] trimmedCode = sourceCode.Split(whitespace, StringSplitOptions.RemoveEmptyEntries);

                sourceCode = string.Join(" ", trimmedCode);

                // Setting up the compiler
                using (var provider = new CSharpCodeProvider()) {
                    var parameters = new CompilerParameters {
                        GenerateExecutable = true,
                        GenerateInMemory = true,
                    };

                    // add a reference to the 'System.dll' assembly, necessary for the code to run.
                    parameters.ReferencedAssemblies.Add("System.dll");

                    // Compiling the source-code into an assembly
                    CompilerResults results = provider.CompileAssemblyFromSource(parameters, sourceCode);

                    if (results.Errors.Count > 0) { // Compilation error
                        foreach (CompilerError error in results.Errors) {
                            Console.WriteLine($"Error ({error.ErrorNumber}): {error.ErrorText}");
                        }
                    } else {
                        Assembly assembly = results.CompiledAssembly;
                        Type programType = assembly.GetType("Program"); // ClassName of the source-code which contains Main()
                        MethodInfo mainMethod = programType.GetMethod("Main"); // Provide entry point method name to start from

                        mainMethod.Invoke(null, null); // Invoke the Main method
                    }
                }

            } catch (Win32Exception ex) {
                Console.WriteLine("System error...");
                Console.WriteLine(ex.Message);
            } catch (Exception ex) {
                Console.WriteLine("Unhandled Exception occurred...");
                Console.WriteLine(ex.Message);
            }
        };

        public static void AdditionTestcase() {
            List<Testcase<int>> testCases = new List<Testcase<int>> {
                new Testcase<int>(5, (DataType.INT, "2"), (DataType.INT, "3")),
                new Testcase<int>(5, (DataType.INT, "7"), (DataType.INT, "12")),
                new Testcase<int>(-1, (DataType.INT, "-1"), (DataType.INT, "-2")),
                new Testcase<int>(0, (DataType.INT, "0"), (DataType.INT, "0"))
            };

            foreach (var testcase in testCases) {
                int result = Solution.Add(
                        int.Parse(testcase.Inputs[0].Item2),
                        int.Parse(testcase.Inputs[1].Item2)
                    );

                if (result == testcase.Output) {
                    Console.WriteLine($"Test passed for inputs ({string.Join(", ", testcase.Inputs.Select(i => i.Item2))}). " +
                        $"Got {result}.");
                } else {
                    Console.WriteLine($"Test failed for inputs ({string.Join(", ", testcase.Inputs.Select(i => i.Item2))}). " +
                        $"Expected {testcase.Output}, but got {result}");
                }
            }
        }

        public static void MinimumTestcase() {
            List<Testcase<int>> testCases = new List<Testcase<int>> {
                new Testcase<int>(5, (DataType.INT, "2"), (DataType.INT, "3"), (DataType.INT, "2")),
                new Testcase<int>(5, (DataType.INT, "7"), (DataType.INT, "12"), (DataType.INT, "-1")),
                new Testcase<int>(-2, (DataType.INT, "-1"), (DataType.INT, "-2"), (DataType.INT, "6")),
                new Testcase<int>(0, (DataType.INT, "0"), (DataType.INT, "0"), (DataType.INT, "-8"))
            };

            foreach (var testcase in testCases) {
                int result = Solution.Minimum(
                        int.Parse(testcase.Inputs[0].Item2),
                        int.Parse(testcase.Inputs[1].Item2),
                        int.Parse(testcase.Inputs[2].Item2)
                    );

                if (result == testcase.Output) {
                    Console.WriteLine($"Test passed for inputs ({string.Join(", ", testcase.Inputs.Select(i => i.Item2))}). " +
                        $"Got {result}.");
                } else {
                    Console.WriteLine($"Test failed for inputs ({string.Join(", ", testcase.Inputs.Select(i => i.Item2))}). " +
                        $"Expected {testcase.Output}, but got {result}");
                }
            }
        }


        static void runCprogram() {

            ProcessStartInfo startInfo = new ProcessStartInfo() {
                UseShellExecute = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true
            };

            Process ps = Process.Start(startInfo);

            string output = ps.StandardOutput.ReadToEnd();
            Console.WriteLine(output);

            string error = ps.StandardError.ReadToEnd();
            Console.WriteLine(error);

            ps.WaitForExit();

        }
    }
}
