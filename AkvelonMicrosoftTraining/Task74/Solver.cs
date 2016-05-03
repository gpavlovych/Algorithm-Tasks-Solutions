using System;

namespace Task74
{
    /// <summary>
    /// 74.In given array find the element that occurred more the half times.
    /// </summary>
    public static class Solver
    {
        public static int? FindItemMoreN2(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            // Initially, we have no guess and our count is zero.  However, to avoid
            // edge cases with the empty range, we initialize the candidate to null.
            int? candidate = null;
            int confidence = 0;

            // Scan over the input using the Boyer-Moore update rules. */
            foreach (var inputItem in input)
            {
                // If we have no confidence in our previous guess, update it to this new element.
                if (confidence == 0)
                {
                    candidate = inputItem;
                    ++confidence;
                }
                // Otherwise, increment or decrement the confidence based on whether the next element matches.
                else if (candidate==inputItem)
                    ++confidence;
                else
                    --confidence;
            }

            // Finally, do one more pass to confirm that we have a majority element.
            int numMatches = 0, totalElements = 0;
            foreach (var inputItem in input)
            {
                // Check whether this is a match and update appropriately.
                if (candidate == inputItem)
                    ++numMatches;

                // Either way, increment the total number of elements.
                ++totalElements;
            }

            // This is a majority element if it accounts for at least half the number of elements.
            return totalElements / 2 < numMatches ? candidate : null;
        }
    }
}
