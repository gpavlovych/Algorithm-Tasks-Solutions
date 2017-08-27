using System;

namespace Task7
{
    internal class DigitNode
    {
        private int value = 0;
        public int Value
        {
            get { return this.value; }
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "value must be in range 0 to 9");
                }

                this.value = value;
            }
        }

        public DigitNode Next { get; set; }
    }
}
