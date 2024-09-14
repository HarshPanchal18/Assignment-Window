namespace AssignmentConsole.Model {
    internal class Solution {
        public static int Add(int n, int m) {
            return n + m;
        }

        public static int Minimum(int x, int y, int z) {
            return x < y && x < z ? x : (y < z) ? y : z;
        }

        public static string GetFirstTwoChars(string s) {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            else if (s.Length == 1) return s.Substring(0, 1);
            return s.Substring(0, 2);
        }
    }
}
