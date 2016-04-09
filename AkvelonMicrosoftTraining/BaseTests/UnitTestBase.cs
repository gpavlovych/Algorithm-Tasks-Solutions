namespace BaseTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class UnitTestBase
    {
        protected void AssertCollectionsEqual<T>(IEnumerable<T> expectedCollection, IEnumerable<T> actualCollection)
        {
            if (expectedCollection == null)
            {
                throw new ArgumentNullException("expectedCollection");
            }
            if (actualCollection == null)
            {
                throw new ArgumentNullException("expectedCollection");
            }
            Assert.AreEqual(expectedCollection.Count(), actualCollection.Count());
            using (var expectedEnumerator = expectedCollection.GetEnumerator())
            using (var actualEnumerator = actualCollection.GetEnumerator())
            {
                while (expectedEnumerator.MoveNext() && actualEnumerator.MoveNext())
                {
                    Assert.AreEqual(expectedEnumerator.Current, actualEnumerator.Current);
                }
            }
        }
    }
}