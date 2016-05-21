using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using $saferootprojectname$;

namespace $safeprojectname$
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void DoSomething()
        {
            //arrange
            var input = new object();

            //act
            var actualOutput = Solver.DoSomething(input);

            //assert
            Assert.IsNotNull(actualOutput);
        }
    
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DoSomethingNullInput()
        {
            //act
            Solver.DoSomething(null);
        }
    }
}