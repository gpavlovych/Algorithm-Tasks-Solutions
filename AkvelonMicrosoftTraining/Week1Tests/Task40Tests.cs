namespace Week1Tests
{
    using System;
    using System.Linq;

    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Week1;

    [TestClass]
    public class Task40Tests : UnitTestBase
    {
        private void BuildCircleTest(int R)
        {
            //act
            var actual = Task40.BuildCircle(R);

            //assert
            var actualPolar =
                actual.Select(
                    point =>
                    new
                        {
                            r = Math.Sqrt(Math.Abs(point.X * point.X + point.Y * point.Y)),
                            teta = Math.Atan2(point.Y, point.X),
                            point
                        }).OrderBy(it => it.teta).ToArray();
            //Determine that all points have the same distance R from the point (0,0)
            Assert.AreEqual(R, actualPolar[0].r, 1);
            var totalTeta = 0.0;
            for (var i = 1; i < actualPolar.Length; i++)
            {
                var delta = actualPolar[i].teta - actualPolar[i - 1].teta;
                totalTeta += delta;
                Assert.AreEqual(R, actualPolar[i].r, 1);
            }
            //Determine that points form full circle
            Assert.AreEqual(2 * Math.PI, totalTeta, 1.0 / R);
        }

        [TestMethod]
        public void BuildCircleTest1000()
        {
            BuildCircleTest(1000);
        }

        [TestMethod]
        public void BuildCircleTest100()
        {
            BuildCircleTest(100);
        }

        [TestMethod]
        public void BuildCircleTest10()
        {
            BuildCircleTest(10);
        }

        [TestMethod]
        public void BuildCircleTest1()
        {
            BuildCircleTest(1);
        }

        [TestMethod]
        public void BuildCircleTest0()
        {
            //arrange
            var R = 0;

            //act
            var actual = Task40.BuildCircle(R).ToArray();

            //assert
            var actualSingle = actual.Single();
            Assert.AreEqual(0, actualSingle.X);
            Assert.AreEqual(0, actualSingle.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuildCircleTestNegative()
        {
            //arrange
            var R = -100;

            //act
            Task40.BuildCircle(R).ToArray();
        }
    }
}
