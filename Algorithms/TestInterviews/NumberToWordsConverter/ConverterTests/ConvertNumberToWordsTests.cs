using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Converter;

namespace ConverterTests
{
    [TestClass]
    public class ConvertNumberToWordsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConvertNegative()
        {
            this.Convert("Zero", -10);
        }

        [TestMethod]
        public void ConvertZero()
        {
            this.Convert("Zero", 0);
        }

        [TestMethod]
        public void Convert13()
        {
            this.Convert("Thirteen", 13);
        }

        [TestMethod]
        public void Convert20()
        {
            this.Convert("Twenty", 20);
        }

        [TestMethod]
        public void Convert25()
        {
            this.Convert("Twenty Five", 25);
        }

        [TestMethod]
        public void Convert125()
        {
            this.Convert("One Hundred Twenty Five", 125);
        }

        [TestMethod]
        public void Convert100()
        {
            this.Convert("One Hundred", 100);
        }

        [TestMethod]
        public void Convert1125()
        {
            this.Convert("One Thousand One Hundred Twenty Five", 1125);
        }

        [TestMethod]
        public void Convert1000()
        {
            this.Convert("One Thousand", 1000);
        }

        [TestMethod]
        public void Convert1000000()
        {
            this.Convert("One Million", 1000000);
        }

        [TestMethod]
        public void Convert1000000000()
        {
            this.Convert("One Billion", 1000000000);
        }

        [TestMethod]
        public void Convert1017()
        {
            this.Convert("One Thousand One Hundred Seventeen", 1117);
        }

        [TestMethod]
        public void Convert11125()
        {
            this.Convert("Eleven Thousand One Hundred Twenty Five", 11125);
        }

        [TestMethod]
        public void Convert110125()
        {
            this.Convert("One Hundred Ten Thousand One Hundred Twenty Five", 110125);
        }

        [TestMethod]
        public void Convert1110125()
        {
            this.Convert("One Million One Hundred Ten Thousand One Hundred Twenty Five", 1110125);
        }

        [TestMethod]
        public void Convert1000110125()
        {
            this.Convert("One Billion One Hundred Ten Thousand One Hundred Twenty Five", 1000110125);
        }

        [TestMethod]
        public void ConvertMaxInt()
        {
            this.Convert("Two Billion One Hundred Fourty Seven Million Four Hundred Eighty Three Thousand Six Hundred Fourty Seven", int.MaxValue);
        }

        private void Convert(string expectedOutput, int input)
        {
            // act
            var result = ConvertNumberToWords.Convert(input);

            // assert
            Assert.AreEqual(expectedOutput, result);
        }
    }
}
