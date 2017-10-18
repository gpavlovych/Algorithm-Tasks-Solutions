using System;
using System.CodeDom;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Task5
{
    /// <summary>
    /// 5. Given a list L of numbers from 0 to n, and another number k = [0-9], find
    /// how many times k appears in L. If the target number in L is more than one digit, treat each digit separately.
    /// For example, k appears twice in L = [0,10].
    /// </summary>
    public static class Solver
    {
        public static int DigitsCount(int k, int[] numbers)
        {
            if (k < 0 || k > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(k),"k should be in range 0 to 9");
            }

            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            var count = 0;
            for (var numberIndex = 0; numberIndex < numbers.Length; numberIndex++)
            {
                var number = numbers[numberIndex];
                while (number > 9)
                {
                    var digit = number % 10;
                    if (digit == k)
                    {
                        count++;
                    }

                    number /= 10;
                }

                if (number == k)
                {
                    count++;
                }
            }

            return count;
        }
    }
}