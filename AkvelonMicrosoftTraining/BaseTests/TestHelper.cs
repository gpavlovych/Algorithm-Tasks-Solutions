namespace BaseTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class TestHelper
    {
        public static void AssertCollectionsEqual<T>(
            IEnumerable<T> expectedCollection,
            IEnumerable<T> actualCollection,
            Action<T, T, int> assertAction = null)
        {
            if (expectedCollection == null)
            {
                throw new ArgumentNullException("expectedCollection");
            }
            if (actualCollection == null)
            {
                throw new ArgumentNullException("actualCollection");
            }
            var expectedCollectionCount = expectedCollection.Count();
            var actualCollectionCount = actualCollection.Count();
            Assert.AreEqual(
                expectedCollectionCount,
                actualCollectionCount,
                "Expected Count to be {0} but was {1}",
                expectedCollectionCount,
                actualCollectionCount);
            int index = 0;
            using (var expectedEnumerator = expectedCollection.GetEnumerator())
            using (var actualEnumerator = actualCollection.GetEnumerator())
            {
                while (expectedEnumerator.MoveNext() && actualEnumerator.MoveNext())
                {
                    var expectedCurrent = expectedEnumerator.Current;
                    var actualCurrent = actualEnumerator.Current;
                    if (assertAction == null)
                    {
                        Assert.AreEqual(
                            expectedCurrent,
                            actualCurrent,
                            "wrong element at {0}: expected {1} but was {2}",
                            index,
                            expectedCurrent,
                            actualCurrent);
                    }
                    else
                    {
                        assertAction(expectedCurrent, actualCurrent, index);
                    }
                    index++;
                }
            }
        }

        public static void AssertCollectionsNotEqual<T>(
            IEnumerable<T> expectedCollection,
            IEnumerable<T> actualCollection)
        {
            if (expectedCollection == null)
            {
                throw new ArgumentNullException("expectedCollection");
            }
            if (actualCollection == null)
            {
                throw new ArgumentNullException("actualCollection");
            }
            var expectedCollectionCount = expectedCollection.Count();
            var actualCollectionCount = actualCollection.Count();
            if (expectedCollectionCount != actualCollectionCount)
            {
                return;
            }
            int index = 0;
            var same = true;
            using (var expectedEnumerator = expectedCollection.GetEnumerator())
            using (var actualEnumerator = actualCollection.GetEnumerator())
            {
                while (expectedEnumerator.MoveNext() && actualEnumerator.MoveNext())
                {
                    var expectedCurrent = expectedEnumerator.Current;
                    var actualCurrent = actualEnumerator.Current;
                    if (!object.Equals(expectedCurrent, actualCurrent))
                    {
                        same = false;
                        break;
                    }
                    index++;
                }
            }
            Assert.IsFalse(same);
        }
    }
}