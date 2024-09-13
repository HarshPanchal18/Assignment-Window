namespace AssignmentConsole.Model {
    internal class Solution {
        public static int Add(int n, int m) {
            return n + m;
        }

        public static int Minimum(int x, int y, int z) {
            return x < y && x < z ? x : (y < z) ? y : z;
        }
    }
}
