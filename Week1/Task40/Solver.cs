namespace Task40
{
    using System;
    using System.Drawing;

    /// <summary>
    /// Write a routine to draw a circle (x ** 2 + y ** 2 = r ** 2) without making use of any floating point computations at all.
    /// </summary>
    /// <remarks>use Bitmap to build the result(so that the routine can be used in WinForms app).</remarks>
    public static class Solver
    {
        public static void BuildCircle(Bitmap bitmap, int x0, int y0, int radius, Color color)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException("bitmap");
            }
            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException("radius", "Radius should be non-negative");
            }
            if (x0 + radius >= bitmap.Width || y0 + radius >= bitmap.Height || x0 - radius <= 0 || y0 - radius <= 0)
            {
                throw new ArgumentOutOfRangeException("radius", "Radius should not go beyond the image boundaries");
            }
            if (radius == 0)
            {
                bitmap.SetPixel(x0, y0, color);
                return;
            }
            int x = radius;
            int y = 0;
            int decisionOver2 = 1 - x;
            while (y <= x)
            {
                bitmap.SetPixel(x + x0, y + y0, color); // Octant 1
                bitmap.SetPixel(y + x0, x + y0, color); // Octant 2
                bitmap.SetPixel(-x + x0, y + y0, color); // Octant 4
                bitmap.SetPixel(-y + x0, x + y0, color); // Octant 3
                bitmap.SetPixel(-x + x0, -y + y0, color); // Octant 5
                bitmap.SetPixel(-y + x0, -x + y0, color); // Octant 6
                bitmap.SetPixel(x + x0, -y + y0, color); // Octant 7
                bitmap.SetPixel(y + x0, -x + y0, color); // Octant 8
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
