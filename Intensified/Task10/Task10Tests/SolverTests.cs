using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task10;

namespace Task10Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestInitialize]
        public void Init()
        {
            Solver.InitSeed();
        }

        [TestMethod]
        public void Verify25And75()
        {
            // arrange
            var total = 10000;
            var total0 = 0;
            var total1 = 0;

            // act
            for (var i = 0; i < total; i++)
            {
                var nextRand = Solver.Rand75();
                if (nextRand == 0)
                {
                    total0++;
                }

                if (nextRand == 1)
                {
                    total1++;
                }
            }
            
            // assert
            var probability0 = (double) total0 / total;
            var probability1 = (double) total1 / total;
            Assert.AreEqual(0.25, probability0, 0.01);
            Assert.AreEqual(0.75, probability1, 0.01);
        }
    }
}