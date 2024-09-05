using System;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

namespace AssignmentConsole {

    internal class Program {


        static void Main(string[] args) {

            string path = @"C:\Users\HARSH\Desktop\1.C";

            try {

                string code =
                    "using System;" +
                    "using System.Collections.Generic;" +
                    "using System.IO;" +

                    "public class Program {" +
                    "    public static void Main()    {" +
                    "        Console.WriteLine(\"Hello from dynamically compiled code!\");" +
                    "        string v = Console.ReadLine();" +
                    "        Console.WriteLine(v);" +
                    "    }" +
                    "}";

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
                }

            } catch (FileNotFoundException ex) {
                Console.WriteLine("Directory is invalid...");
                Console.WriteLine(ex.Message);
                Console.WriteLine(path);
            } catch (Win32Exception ex) {
                Console.WriteLine("System error...");
                Console.WriteLine(ex.Message);
                Console.WriteLine(path);
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
