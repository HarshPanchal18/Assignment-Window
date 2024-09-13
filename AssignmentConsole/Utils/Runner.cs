using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace AssignmentConsole.Utils {
    public class Runner {

        public Runner() { }

        public Action<string> RunCsCode = (sourceCode) => {
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

        public void runCprogram() {

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
