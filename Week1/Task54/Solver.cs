namespace Task54
{
    using System;

    /// <summary>
    /// Write an efficient algorithm to shuffle a pack of cards this one was a feedback process 
    /// until we came up with one with no extra storage.
    /// </summary>
    public static class Solver
    {
        private static ulong _sNext = 1;

        private const ulong A = 1103515245;

        private const ulong C = 12345;

        private static uint Rand(uint maxRand)
        {
            _sNext = _sNext * A + C;
            return (uint) ( _sNext / 65536 ) % maxRand;
        }

        private static void RandInit(ulong seed)
        {
            _sNext = seed;
        }

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
            RandInit((uint)DateTime.UtcNow.Ticks);
            var feedbackResult = false;
            while (!feedbackResult)
            {
                for (uint i = (uint)cards.Length; i > 0; i--)
                {
                    uint j = Rand(i);
                    Swap(ref cards[ i - 1 ], ref cards[ j ]);
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
