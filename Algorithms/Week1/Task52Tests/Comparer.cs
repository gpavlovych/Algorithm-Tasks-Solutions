using System.Collections;
using Task52;

namespace Task52Tests
{
    internal class Comparer: IComparer
    {
        public int Compare(object x, object y)
        {
            return this.Compare(x as Token, y as Token);
        }

        private int Compare(Token token1, Token token2)
        {
            if ((token1 != null && token2 != null) && (token1.Position == token2.Position && token1.Type == token2.Type && token1.Value == token2.Value))
            {
                return 0;
            }

            if (token1 == null && token2 == null)
            {
                return 0;
            }

            return -1;
        }
    }
}