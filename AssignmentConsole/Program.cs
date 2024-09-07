using System;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Linq;

namespace AssignmentConsole {

    internal class Program {


        static void Main(string[] args) {

            char[] whitespace = new char[] { ' ', '\t', '\r', '\n' };

            try {

                string sourceCode =
                    "using System;" +
                    "using System.Collections.Generic;" +
                    "using System.IO;" +

                    "public class Program {" +
                    "    public static void Main() {" +
                    "       Console.WriteLine(Solution.add(5,4));" +
                    "    }" +
                    "}" +

                    "public class Solution {" +
                    "   public static int add(int n1, int n2) {" +
                    "       return n1 + n2;" +
                    "   }" +
                    "}";

                // Trimming whitespaces from the source code.
                string[] trimmedCode = sourceCode.Split(whitespace, StringSplitOptions.RemoveEmptyEntries);

                sourceCode = string.Join(" ", trimmedCode);

                // Setting up the compiler
                using (var provider = new CSharpCodeProvider()) {
                    var parameters = new CompilerParameters {
                        GenerateExecutable = true,
                        GenerateInMemory = true,
                    };

                    parameters.ReferencedAssemblies.Add("System.dll"); // add a reference to the 'System.dll' assembly, necessary for the code to run.

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

                // Console.WriteLine(sourceCode);

            } catch (Win32Exception ex) {
                Console.WriteLine("System error...");
                Console.WriteLine(ex.Message);
            } catch (Exception ex) {
                Console.WriteLine("Unhandled Exception occurred...");
                Console.WriteLine(ex.Message);
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
