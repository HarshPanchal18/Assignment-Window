﻿using System;
using System.Linq;
using AssignmentConsole.Model;
using System.Collections.Generic;
using AssignmentConsole.Utils;

namespace AssignmentConsole {

    internal class Program {

        static void Main(string[] args) {

            Runner runner = new Runner();

            runner.RunCsCode(
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

            StringTestcase();

            Console.WriteLine();

            EvenListTestcase();

            Console.WriteLine();

            EvenArrayTestcase();

            Console.WriteLine();

            MinStringTestcase();

            Console.WriteLine();

            runner.RunCprogram("" +
                "#include<stdio.h>\n" +
                "int main(){\n" +
                "   printf(\"Hello World\");\n" +
                "   return 0;\n" +
                "}\n");

            runner.RunCppProgram("" +
                "#include<stdio.h>\n" +
                "int main(){\n" +
                "   printf(\"Hello World\");\n" +
                "   return 0;\n" +
                "}\n");

            runner.RunJavaProgram("" +
                "import java.util.*;\n" +
                "public class Program {\n" +
                "   public static void main(String[] a) {\n" +
                "      System.out.print(\"Hello World\");\n" +
                "   }\n" +
                "}\n");

            runner.RunPythonProgram("print(\"Hello World!\")");

        }

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

        public static void StringTestcase() {
            List<Testcase<string>> testCases = new List<Testcase<string>> {
                new Testcase<string>("gh", (DataType.STR, "qwsa")),
                new Testcase<string>("", (DataType.STR, "")),
                new Testcase<string>("ok", (DataType.STR, "okli")),
                new Testcase<string>("q", (DataType.STR, "q"))
            };

            foreach (var testcase in testCases) {
                var result = Solution.GetFirstTwoChars(testcase.Inputs[0].Item2);

                if (result == testcase.Output) {
                    Console.WriteLine($"Test passed for inputs ({string.Join(", ", testcase.Inputs.Select(i => i.Item2))}). " +
                        $"Got {result}.");
                } else {
                    Console.WriteLine($"Test failed for inputs ({string.Join(", ", testcase.Inputs.Select(i => i.Item2))}). " +
                        $"Expected {testcase.Output}, but got {result}.");
                }
            }
        }

        public static void EvenListTestcase() {
            List<Testcase<List<int>>> testCases = new List<Testcase<List<int>>> {
                new Testcase<List<int>>(new List<int> {8,0,2}, (DataType.INT_LIST, "8,0,7,2")),
                new Testcase<List<int>>(new List<int> {8,6,0}, (DataType.INT_LIST, "8,6,7,0")),
                new Testcase<List<int>>(new List<int> {}, (DataType.INT_LIST, "9,7,1")),
            };

            foreach (var testcase in testCases) {
                var list = testcase.Inputs[0].Item2.Split(',').Select(int.Parse).ToList();

                var result = Solution.GetEvens(list);

                // Use SequenceEqual to compare lists
                if (result.SequenceEqual(testcase.Output)) {
                    Console.WriteLine(
                        $"Test passed for inputs ({testcase.Inputs[0].Item2}). " +
                        $"Got [{string.Join(", ", result)}]."
                    );
                } else {
                    Console.WriteLine(
                        $"Test failed for inputs ({testcase.Inputs[0].Item2}). " +
                        $"Expected {testcase.Output}, but got [{string.Join(", ", result)}]."
                    );
                }
            }
        }

        public static void EvenArrayTestcase() {
            List<Testcase<int[]>> testCases = new List<Testcase<int[]>> {
                new Testcase<int[]>(new int[] {8,0,2}, (DataType.INT_ARR, "8,0,7,2")),
                new Testcase<int[]>(new int[] {8,6,0}, (DataType.INT_ARR, "8,6,7,0")),
                new Testcase<int[]>(new int[] {}, (DataType.INT_ARR, "9,7,1")),
            };

            foreach (var testcase in testCases) {
                var list = testcase.Inputs[0].Item2.Split(',').Select(int.Parse).ToArray();

                var result = Solution.GetEvens(list);

                // Use SequenceEqual to compare lists
                if (result.SequenceEqual(testcase.Output)) {
                    Console.WriteLine(
                        $"Test passed for inputs ({testcase.Inputs[0].Item2}). " +
                        $"Got [{string.Join(", ", result)}]."
                    );
                } else {
                    Console.WriteLine(
                        $"Test failed for inputs ({testcase.Inputs[0].Item2}). " +
                        $"Expected {testcase.Output}, but got [{string.Join(", ", result)}]."
                    );
                }
            }
        }

        public static void MinStringTestcase() {
            List<Testcase<string>> testcases = new List<Testcase<string>> {
                new Testcase<string>("har", (DataType.STR_ARR, "harsh,har,shar,panchal")),
                new Testcase<string>("", (DataType.STR_ARR, "")),
                new Testcase<string>("sh", (DataType.STR_ARR, "sh")),
                new Testcase<string>("shara", (DataType.STR_ARR, "harsh,harasdf,shara,panchal")),
            };

            foreach (var testcase in testcases) {
                var list = testcase.Inputs[0].Item2.Split(',');
                var result = Solution.Minimum(list);

                if (result == testcase.Output) {
                    Console.WriteLine(
                        $"Test passed for inputs ({testcase.Inputs[0].Item2}). " +
                        $"Got [{string.Join(", ", result)}]."
                    );
                } else {
                    Console.WriteLine(
                        $"Test failed for inputs ({testcase.Inputs[0].Item2}). " +
                        $"Expected {testcase.Output}, but got [{string.Join(", ", result)}]."
                    );
                }
            }
        }
    }
}
