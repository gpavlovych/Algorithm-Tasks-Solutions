using System;
using System.Collections.Generic;

namespace Week1
{
    /// <summary>
    /// Add to the sorted list
    /// </summary>
    public static class Task45
    {
        public static void AddSortedList<T>(IList<T> list, T item) where T : IComparable<T>
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            list.Add(item);
            for (var index = list.Count - 1; index > 0; index--)
            {
                if (list[index - 1].CompareTo(item) > 0)
                {
                    list[index] = list[index - 1];
                }
                else
                {
                    list[index] = item;
                    break;
                }
            }
        }
    }
}
