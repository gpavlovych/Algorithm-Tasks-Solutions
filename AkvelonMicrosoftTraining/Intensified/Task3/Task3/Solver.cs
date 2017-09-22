using System;
using System.CodeDom;
using System.Runtime.ExceptionServices;

namespace Task3
{
    /// <summary>
    /// 3. Write a program to display numbers having sum of left side numbers equal to right side numbers. Eg. {1,0,-11,1,12}=>0 {Left side number 1+0=1, Right side number -11+1+12=1}.
    /// </summary>
    public static class Solver
    {
        /// <summary>
        /// Returns index of the item where sum (a[0..index]) = sum(a[index+1..N-1])
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static int FindMedian(int [] inputs)
        {
            if (inputs == null)
            {
                throw new ArgumentNullException(nameof(inputs));
            }

            if (inputs.Length < 2)
            {
                return -1;
            }

            var leftSum = 0;
            for (var inputIndex = 0; inputIndex < inputs.Length; inputIndex++)
            {
                leftSum += inputs[inputIndex];
            }
            
            var rightSum = 0;
            int rightIndex;
            for (rightIndex = inputs.Length - 1; rightIndex >= 0; rightIndex--)
            {
                var currentItem = inputs[rightIndex];
                rightSum += currentItem;
                leftSum -= currentItem;
                if (rightSum == leftSum)
                {
                    return rightIndex - 1;
                }
            }

            return -1;
        }
    }
}