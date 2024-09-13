using System;

namespace AssignmentConsole.Utils {
    public class Const {
        public static string USING_IMPORTS =
            "using System;" +
            "using System.Collections.Generic;" +
            "using System.Text;" +
            "using System.Threading.Tasks;";

        public static Func<string, string> MainMethod = (body) => {
            return "public class Program {" +
            "    public static void Main() " +
            body +
            "    " +
            "}";
        };

        public static Func<string, string> Solution = (body) => {
            return "public class Solution " + body;
        };
    }
}
