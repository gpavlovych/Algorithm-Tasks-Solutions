using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace Task2
{
    /// <summary>
    /// 2. Given "aabcbcbdcc" you can remove and shuffle character. Find the maximum length of string, which forms palindrome like "ccabdbacc"
    /// </summary>
    public static class Solver
    {
        public static string GetMaxPalindromeByRemoveOrShuffle(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            char minChar = 'a';
            char maxChar = 'z';
            
            var charCount  = new Dictionary<char, int>();
            for(var ch = minChar; ch <= maxChar; ch++)
            {
                charCount.Add(ch, 0);
            }

            // find freq of characters in the input string
            for(var inputChIndex = 0; inputChIndex < input.Length; inputChIndex++)
            {
                var inputCh = input[inputChIndex];
                if (!charCount.ContainsKey(inputCh))
                {
                    throw new ArgumentOutOfRangeException(nameof(input),$"input contains invalid character '{inputCh}'@{inputChIndex}");
                }

                charCount[inputCh]++;
            }

            // Any palindromic string consists of three parts
            // beg + mid + end
            var beg = "";
            var mid = "";
            var end = "";

            // solution assumes only lowercase characters are
            // present in string. We can easily extend this
            // to consider any set of characters
            for (char ch = minChar; ch <= maxChar; ch++)
            {
                // if the current character freq is odd
                if (charCount[ch] % 2 == 1)
                {
                    // mid will contain only 1 character. It
                    // will be overridden with next character
                    // with odd freq
                    mid = "" + ch;

                    // decrement the character freq to make
                    // it even and consider current character
                    // again
                    charCount[ch--]--;
                }

                // if the current character freq is even
                else
                {
                    // If count is n(an even number), push
                    // n/2 characters to beg string and rest
                    // n/2 characters will form part of end
                    // string
                    for (int i = 0; i < charCount[ch] / 2; i++)
                        beg += ch;
                }
            }

            // end will be reverse of beg
            foreach (var ch in beg)
            {
                end = ch + end;
            }

            // return palindrome string
            return beg + mid + end;
        }
    }
}