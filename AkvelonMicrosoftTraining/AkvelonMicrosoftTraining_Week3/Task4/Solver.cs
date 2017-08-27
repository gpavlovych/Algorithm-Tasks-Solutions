using System;
using System.Collections.Generic;

namespace Task4
{
    /// <summary>
    /// Write an efficient function to find this missing number in array with integers from 1 till 100.
    /// </summary>
    /// <remarks>Ask question: can be there only one missing item or multiple? can be there no missing items? are array items unique? if there are more than one missing item, what's the order to be in answer, desc or asc?
    /// </remarks>
    public static class Solver
    {
        public static int[] FindMissingNumber(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            //below refers to the case when there are 1 missing number and all numbers are unique (how can this case be validated...?)
            var minNumber = 1;
            var maxNumber = 100;
#if Unique
            if (numbers.Length != 99)
            {
                throw new ArgumentOutOfRangeException(nameof(numbers), "numbers should contain 99 items");
            }

            var hashSet = new HashSet<int>();
            var sum = 0;
            for (var numberIndex = 0; numberIndex < numbers.Length; numberIndex++)
            {
                var currentNumber = numbers[numberIndex];
                if (currentNumber < 1 || currentNumber > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(numbers), "numbers should contain items in range 1 to 100");
                }

                if (hashSet.Contains(currentNumber))
                {
                    throw new ArgumentException("numbers should contain unique items", nameof(numbers)); 
                }

                sum += numbers[numberIndex];
            }

            var expectedSum = 100 * (100 + 1) / 2;
            var missingNumber = expectedSum - sum;

            return new int[]{missingNumber};
#else
            var occurences = new int[maxNumber - minNumber + 1];
            for (var occurenceIndex = 0; occurenceIndex < occurences.Length; occurenceIndex++)
            {
                occurences[occurenceIndex] = 0;
            }

            var zeroNumbers = occurences.Length;
            for (var numberIndex = 0; numberIndex < numbers.Length; numberIndex++)
            {
                var currentNumber = numbers[numberIndex];
                if (currentNumber < minNumber || currentNumber > maxNumber)
                {
                    throw new ArgumentOutOfRangeException(nameof(numbers), $"numbers should contain items in range {minNumber} to {maxNumber}");
                }

                if ((occurences[currentNumber - 1]++) == 0)
                {
                    zeroNumbers--;
                }
            }

            var result = new int[zeroNumbers];
            var zeroIndex = 0;
            for (var occurenceIndex = 0; occurenceIndex < occurences.Length; occurenceIndex++)
            {
                if (occurences[occurenceIndex] == 0)
                {
                    result[zeroIndex++] = occurenceIndex + minNumber;
                }
            }

            return result;
#endif

        }
    }
}
