using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    /// <summary>
    /// 9. Given an unsorted array of integers (size of array is really large) write an efficient function to
    ///  retrieve top N integers.Result array may or may not be sorted.For example, if given arrays is {33, 2, 110, 21, 17 }
    /// and N is 3 the answer should be { 33, 110, 21 }. Original array can’t be modified or sorted.
    /// </summary>
    public static class Solver
    {
        private static void FindMinItemAndIndex(int[] array, out int min, out int minIndex)
        {
            min = array[0];
            minIndex = 0;
            for (var index = 1; index < array.Length; index++)
            {
                if (min > array[index])
                {
                    min = array[index];
                    minIndex = index;
                }
            }
        }

        public static int[] RetrieveTopNumbers(int[] array, int top)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (top < 0 || top > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(top), "top must be in range 0 to array.Length");
            }

            var result = new int[top];
            if (top == 0)
            {
                return result;
            }

            for (var topIndex = 0; topIndex < top; topIndex++)
            {
                result[topIndex] = array[topIndex];
            }
            int min, minIndex;
            FindMinItemAndIndex(result, out min, out minIndex);

            for (var arrayIndex = top; arrayIndex < array.Length; arrayIndex++)
            {
                var currentItem = array[arrayIndex];
                if (min < currentItem)
                {
                    result[minIndex] = currentItem;
                    FindMinItemAndIndex(result, out min, out minIndex);

                }
            }

            return result;
        }
    }
}
