using System;
using System.Collections.Generic;

using BaseTests.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Week1.Tests
{
    [TestClass]
    public class Task45Tests : UnitTestBase
    {
        [TestMethod]
        public void AddSortedListTest()
        {
            //arrange
            var item = 5;
            var initialList = new List<int>() { 1, 2, 3, 4, 6, 7, 8 };
            var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            //act
            Task45.AddSortedList(initialList, item);

            //assert
            AssertCollectionsEqual(expected, initialList);
        }

        [TestMethod]
        public void AddSortedListTestToEmpty()
        {
            //arrange
            var item = 5;
            var initialList = new List<int>() { };
            var expected = new[] { 5 };

            //act
            Task45.AddSortedList(initialList, item);

            //assert
            AssertCollectionsEqual(expected, initialList);
        }

        [TestMethod]
        public void AddSortedListTestEnd()
        {
            //arrange
            var item = 9;
            var initialList = new List<int>() { 1, 2, 3, 4, 6, 7, 8 };
            var expected = new[] { 1, 2, 3, 4, 6, 7, 8, 9 };

            //act
            Task45.AddSortedList(initialList, item);

            //assert
            AssertCollectionsEqual(expected, initialList);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddSortedListTestNull()
        {
            Task45.AddSortedList(null, 3);
        }
    }
}