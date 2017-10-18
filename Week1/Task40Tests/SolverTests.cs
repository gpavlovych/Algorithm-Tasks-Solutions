namespace Task40Tests
{
    using System;
    using System.Drawing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task40;

    [TestClass]
    public class Task40Tests
    {
        private void BuildCircleTest(int r)
        {
            //arrange
            var color = Color.Red;
            var expectedBitmap = new Bitmap(r * 2 + 2, r * 2 + 2);
            var actualBitmap = new Bitmap(r * 2 + 2, r * 2 + 2);
            var graphics = Graphics.FromImage(expectedBitmap);
            if (r > 1)
            {
                graphics.DrawEllipse(
                    new Pen(color),
                    expectedBitmap.Width / 2 - r,
                    expectedBitmap.Height / 2 - r,
                    r * 2,
                    r * 2);
            }
            else
            {
                graphics.DrawRectangle(
                    new Pen(color),
                    expectedBitmap.Width / 2 - r,
                    expectedBitmap.Height / 2 - r,
                    r > 0 ? r * 2 : 1,
                    r > 0 ? r * 2 : 1);
            }

            //act
            Solver.BuildCircle(actualBitmap, actualBitmap.Width / 2, actualBitmap.Height / 2, r, color);

            //assert
            var count = 0;
            for (var x = 0; x < expectedBitmap.Width; x++)
                for (var y = 0; y < expectedBitmap.Height; y++)
                {
                    if (expectedBitmap.GetPixel(x, y) != actualBitmap.GetPixel(x, y))
                    {
                        count++;
                    }
                }
            Assert.IsTrue(count <= r * Math.PI * 0.9);
        }

        [TestMethod]
        public void BuildCircleTest1000()
        {
            this.BuildCircleTest(1000);
        }

        [TestMethod]
        public void BuildCircleTest100()
        {
            this.BuildCircleTest(100);
        }

        [TestMethod]
        public void BuildCircleTest10()
        {
            this.BuildCircleTest(10);
        }

        [TestMethod]
        public void BuildCircleTest1()
        {
            this.BuildCircleTest(1);
        }

        [TestMethod]
        public void BuildCircleTest0()
        {
            this.BuildCircleTest(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuildCircleTestRadiusNegative()
        {
            //arrange
            var R = -10;
            var bitmap = new Bitmap(100, 100);
            //act
            Solver.BuildCircle(bitmap, 50, 50, R, Color.Black);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuildCircleTestBeyondWidth()
        {
            //arrange
            var R = 10;
            var bitmap = new Bitmap(100, 100);
            //act
            Solver.BuildCircle(bitmap, 95, 50, R, Color.Black);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuildCircleTestBeyondHeight()
        {
            //arrange
            var R = 10;
            var bitmap = new Bitmap(100, 100);
            //act
            Solver.BuildCircle(bitmap, 50, 95, R, Color.Black);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuildCircleTestBelow0X()
        {
            //arrange
            var R = 10;
            var bitmap = new Bitmap(100, 100);
            //act
            Solver.BuildCircle(bitmap, 5, 50, R, Color.Black);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuildCircleTestBelow0Y()
        {
            //arrange
            var R = 10;
            var bitmap = new Bitmap(100, 100);
            //act
            Solver.BuildCircle(bitmap, 50, 5, R, Color.Black);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuildCircleTestBitmapNull()
        {
            //arrange
            var R = 10;
            //act
            Solver.BuildCircle(null, 50, 50, R, Color.Black);
        }
    }
}
