using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    /// <summary>
    /// 12.Implement function which takes parameters (string, char, char, int) and returns True or False.
    /// Example: doCompare("Tadas s sf ksffdf g ts", 't', 's', 2).
    /// </summary>
    /// <remarks>What the function is intended for? how its input parameters can be related to the return value?</remarks>
    public static class Solver
    {
        public static bool doCompare(string str, char chr1, char chr2, int num)
        {
            if (num % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
