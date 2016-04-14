namespace Task54
{
    using System;

    public static class Solver
    {
        private static void Swap<T>(ref T value1, ref T value2)
        {
            T temp = value1;
            value1 = value2;
            value2 = temp;
        }

        public static void Shuffle<T>(T[] cards, Func<T, int, bool> feedBack)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("cards");
            }

            if (feedBack == null)
            {
                feedBack = (item, index) => true;
            }

            var feedbackResult = false;
            while (!feedbackResult)
            {
                var random = new Random();
                for (var i = cards.Length - 1; i >= 0; i--)
                {
                    int j = random.Next(0, i + 1);
                    Swap(ref cards[i], ref cards[j]);
                }
                feedbackResult = true;
                for (var i = 0; i < cards.Length; i++)
                {
                    if (!feedBack(cards[i], i))
                    {
                        feedbackResult = false;
                        break;
                    }
                }
            }
        }
    }
}
