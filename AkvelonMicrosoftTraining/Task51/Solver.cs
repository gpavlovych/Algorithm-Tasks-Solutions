namespace Task51
{
    using System.Collections.Generic;
    using System.Text;

    public static class Solver
    {
        public static string DeleteAndClean(string s1, string s2)
        {
            s1 = s1 ?? "";
            s2 = s2 ?? "";
            var dict = new Dictionary<char, bool>();

            foreach (var cs1 in s1)
            {
                dict[cs1] = true;
            }
            var result = new StringBuilder();
            foreach (var cs2 in s2)
                if (!dict.ContainsKey(cs2))
                {
                    result.Append(cs2);
                }
            return result.ToString();
        }
    }
}
