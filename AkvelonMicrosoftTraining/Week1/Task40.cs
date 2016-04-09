using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    /// <summary>
    /// Draws circle without using floating point operations at all
    /// </summary>
    public static class Task40
    {
        public struct Point
        {
            public int X;

            public int Y;
        }

        public static IEnumerable<Point> BuildCircle(int radius)
        {
            int x0 = 0;
            int y0 = 0;
            int x = radius;
            int y = 0;
            int decisionOver2 = 1 - x;
            while (y <= x)
            {
                yield return new Point { X = x + x0, Y = y + y0 }; // Octant 1
                yield return new Point { X = y + x0, Y = x + y0 }; // Octant 2
                yield return new Point { X = -x + x0, Y = y + y0 }; // Octant 4
                yield return new Point { X = -y + x0, Y = x + y0 }; // Octant 3
                yield return new Point { X = -x + x0, Y = -y + y0 }; // Octant 5
                yield return new Point { X = -y + x0, Y = -x + y0 }; // Octant 6
                yield return new Point { X = x + x0, Y = -y + y0 }; // Octant 7
                yield return new Point { X = y + x0, Y = -x + y0 }; // Octant 8
                y++;
                if (decisionOver2 <= 0)
                {
                    decisionOver2 += 2 * y + 1; // Change in decision criterion for y -> y+1
                }
                else
                {
                    x--;
                    decisionOver2 += 2 * (y - x) + 1; // Change for y -> y+1, x -> x-1
                }
            }
        }
    }
}
