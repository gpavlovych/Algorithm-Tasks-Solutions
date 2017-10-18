using System;
using System.Collections.Generic;

namespace Converter
{
    /// <summary>
    /// Convert a number to English representation.
    /// Ex: Input : 100 
    /// Output : One Hundred.
    /// </summary>
    /// <remarks>Input number should be non-negative and is of type int</remarks>
    public static class ConvertNumberToWords
    {
        public static string Convert(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "number should be non-negative");
            }
            // or alternatively, if negative numbers are allowed, remove the above argument check, prefix the answer with "Minus " and call Convert(-number, ...) 
            // so that Convert takes positive number;

            var numberWords = new Dictionary<int, string>()
            {
                {0, "Zero"},
                {1, "One"},
                {2, "Two"},
                {3, "Three"},
                {4, "Four"},
                {5, "Five"},
                {6, "Six"},
                {7, "Seven"},
                {8, "Eight"},
                {9, "Nine"},
                {10, "Ten"},
                {11, "Eleven"},
                {12, "Twelve"},
                {13, "Thirteen"},
                {14, "Fourteen"},
                {15, "Fifteen"},
                {16, "Sixteen"},
                {17, "Seventeen"},
                {18, "Eighteen"},
                {19, "Nineteen"},
                {20, "Twenty"},
                {30, "Thirty"},
                {40, "Fourty"},
                {50, "Fifty"},
                {60, "Sixty"},
                {70, "Seventy"},
                {80, "Eighty"},
                {90, "Ninety"},
                {100, "Hundred"},
                {1000, "Thousand"},
                {1000000, "Million"},
                {1000000000, "Billion"},
            };

            return Convert(number, numberWords, 1000000000);
        }

        private static string Convert(int number, Dictionary<int, string> numberWords, int multiplier)
        {
            if (multiplier == 10)
            {
                return ConvertTens(number, numberWords);
            }

            var major = number / multiplier;
            var majorStr = "";
            if (major > 0)
            {
                majorStr = Convert(major, numberWords, 100) + " " + numberWords[multiplier];
            }

            var hundreds = number % multiplier;
            var hundredsStr = "";
            if (major == 0 || hundreds > 0)
            {
                if (multiplier > 1000)
                {
                    multiplier /= 1000;
                }
                else
                {
                    multiplier /= 10;
                }

                hundredsStr = Convert(hundreds, numberWords, multiplier);
            }

            return (majorStr + " " + hundredsStr).Trim();
        }

        private static string ConvertTens(int number, Dictionary<int, string> numberWords)
        {
            var tens = (number / 10) * 10;
            var units = number;

            var tensStr = "";
            if (tens >= 20)
            {
                tensStr = numberWords[tens];
                units = units % 10;
            }

            var unitsStr = "";
            if (tens == 0 || units > 0)
            {
                unitsStr = numberWords[units];
            }

            return (tensStr +" "+ unitsStr).Trim();
        }
    }
}