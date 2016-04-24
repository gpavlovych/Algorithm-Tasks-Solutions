using System.Text;

namespace Task55Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task55;

    [TestClass]
    public class SolverTests
    {
        private const string LATIN_LOWERCASE = "abcdefghijklmnopqrstuvwxyz";

        private const string LATIN_UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private const string CYRILLIC_LOWERCASE = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        private const string CYRILLIC_UPPERCASE = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        private void ToUpperTest(string input)
        {
            //arrange
            var expectedResult = input.ToUpper();

            //act
            var result = Solver.ToUpper(input);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ToUpperTestNonEmptyCyrillic()
        {
            this.ToUpperTest(LATIN_LOWERCASE + LATIN_UPPERCASE + CYRILLIC_LOWERCASE + CYRILLIC_UPPERCASE);
        }

        [TestMethod]
        public void ToUpperTestNonEmpty()
        {
            this.ToUpperTest(LATIN_LOWERCASE + LATIN_UPPERCASE);
        }

        [TestMethod]
        public void ToUpperTestEmpty()
        {
            this.ToUpperTest("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToUpperTestNull()
        {
            Solver.ToUpper(null);
        }
    }
}
