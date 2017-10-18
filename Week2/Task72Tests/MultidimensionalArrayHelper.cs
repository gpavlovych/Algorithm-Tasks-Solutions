using System;
using System.Collections.Generic;

namespace Task72.Tests
{
    public static class MultidimensionalArrayHelper
    {
        public static IEnumerable<T> ToEnumerable<T>(this Array target)
        {
            foreach (var item in target)
                yield return (T)item;
        }
    }
}