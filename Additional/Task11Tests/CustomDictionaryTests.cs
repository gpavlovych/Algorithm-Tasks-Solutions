using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task11;

namespace Task11Tests
{
    [TestClass]
    public class CustomDictionaryTests
    {
        private CustomDictionary<string, string> target;

        [TestInitialize]
        public void Init()
        {
            target = new CustomDictionary<string, string>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetNoKey()
        {
            var result = target["somestr"];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInsertDifferentKey()
        {
            // arrange
            target.Insert("somestr1", "someval");

            // act
            var result = target["somestr"];
        }

        [TestMethod]
        public void TestInsertSameKey()
        {
            // arrange
            target.Insert("somestr1", "someval");

            // act
            var result = target["somestr1"];

            // assert
            Assert.AreEqual("someval", result);
        }

        [TestMethod]
        public void TestInsertSameAndDifferentKeys()
        {
            // arrange
            target.Insert("somestr1", "someval");
            target.Insert("somestr2", "someval2");

            // act
            var result = target["somestr1"];

            // assert
            Assert.AreEqual("someval", result);
        }

        [TestMethod]
        public void TestInsertSameKeyMultipleTimes()
        {
            // arrange
            target.Insert("somestr1", "someval");
            target.Insert("somestr1", "someval2");

            // act
            var result = target["somestr1"];

            // assert
            Assert.AreEqual("someval2", result);
        }
    }
}
