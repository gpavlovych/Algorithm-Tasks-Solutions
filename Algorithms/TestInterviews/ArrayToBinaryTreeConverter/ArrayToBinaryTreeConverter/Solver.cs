using System;

namespace ArrayToBinaryTreeConverter
{
    public static class Solver
    {
        public static TreeNode ConvertToTree(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                return null;
            }

            var leftArrayLength = array.Length / 2;
            var rightArrayLength = array.Length - leftArrayLength - 1;
            var leftArray = new int[leftArrayLength];
            var rightArray = new int[rightArrayLength];
            for (var leftIndex = 0; leftIndex < leftArrayLength; leftIndex++)
            {
                leftArray[leftIndex] = array[leftIndex];
            }

            var middleItem = array[leftArrayLength];
            for (var rightIndex = 0; rightIndex < rightArrayLength; rightIndex++)
            {
                rightArray[rightIndex] = array[leftArrayLength + rightIndex + 1];
            }

            var result = new TreeNode(middleItem) { Child1 = ConvertToTree(leftArray), Child2 = ConvertToTree(rightArray) };
            return result;
        }
    }
}
