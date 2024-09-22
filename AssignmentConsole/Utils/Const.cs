using System;

namespace AssignmentConsole.Utils {
    public class Const {
        public static string USING_IMPORTS =
            "using System;\n" +
            "using System.Collections.Generic;\n" +
            "using System.Text;\n" +
            "using System.Linq;\n";

        public static Func<string, string> MainMethod = (body) => {
            return "public class Program {\n" +
            "    public static void Main()\n " +
            body +
            "    \n" +
            "}\n";
        };

        public static Func<string, string> Solution = (body) => {
            return "public class Solution " + body;
        };

        public static string JAVA_IMPORTS =
            "import java.io.*;\n" +
            "import java.util.*;\n" +
            "import java.text.*;\n" +
            "import java.math.*;\n" +
            "import java.util.regex.*;\n\n";

        public static string C_IMPORS =
            "#include<stdio.h>\n" +
            "#include<stdlib.h>\n" +
            "#include<conio.h>\n";

        public static string CPP_IMPORTS =
            "#include <iostream>\n" +
            "#include <vector>\n" +
            "#include <cmath>\n" +
            "#include <cstdio>\n" +
            "#include <algorithm>\n" +
            "#include <deque>\n" +
            "#include <map>\n" +
            "#include <set>\n" +
            "#include <string>\n\n" +

            "using namespace std;\n";

    }
}
