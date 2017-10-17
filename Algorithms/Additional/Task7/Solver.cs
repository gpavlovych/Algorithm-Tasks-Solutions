using System;

namespace Task7
{
    /// <summary>
    /// 7. Calculate the count of 1's in a number 11^N (the range of N is 0 to 1000) without using pow function.
    /// For example: if n is 5, it should return 3, if n is 10, it should return 1.
    /// </summary>
    /// <remarks>Ask questions: what should be the time/space complexity? can we use List or string?</remarks>
    public static class Solver
    {
        public static int Calculate1sOf11PowerN(int n)
        {
            if (n < 0 || n > 1000)
            {
                throw new ArgumentOutOfRangeException("n", "n should be in range 0 to 1000");
            }

            var result = new DigitNode() { Value = 1 };
            for (var pow = 0; pow < n; pow++)
            {
                MultiplyBy(result, 11);
            }

            var ones = 0;
            while (result != null)
            {
                if (result.Value == 1)
                {
                    ones++;
                }

                result = result.Next;
            }

            return ones;
        }

        private static void MultiplyBy(DigitNode digits, int number)
        {
            if (digits == null)
            {
                throw new ArgumentNullException(nameof(digits));
            }

            int carry = 0;
            while(digits != null)
            {
                var currentDigit = digits.Value;
                currentDigit *= number;
                currentDigit += carry;
                carry = currentDigit / 10;
                currentDigit = currentDigit % 10;
                digits.Value = currentDigit;
                if (digits.Next == null && carry != 0)
                {
                    digits.Next = new DigitNode();
                }

                digits = digits.Next;
            }
        }
    }
}
