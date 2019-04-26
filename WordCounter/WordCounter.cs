using System;
using System.Collections.Generic;
using System.Text;

namespace WordCounter
{
    public class WordCount
    {
        public int CountWords(string keyWord, string wordsToCheck, bool strict = false)
        {
            int count = 0;

            if (!strict)
            {
                wordsToCheck = wordsToCheck.ToLower();
                keyWord = keyWord.ToLower();
            }

            if (keyWord == wordsToCheck)
                count++;

            return count;
        }

    }
}
