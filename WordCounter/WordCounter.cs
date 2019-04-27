using System;
using System.Collections.Generic;

namespace WordCounter
{
    public class WordCount
    {

        private List<char> _letterList = new List<char>()
        {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

        private List<char> _nonWordEnders = new List<char>()
        {'_', '-'};

        public int CountWords(string keyWord, string wordsToCheck, bool strict = false)
        {
            int count = 0; // the number of words we have matched with
            if (!strict)
            {
                wordsToCheck = wordsToCheck.ToLower();
                keyWord = keyWord.ToLower();
                keyWord = _RemoveSpecialCharacters(keyWord);
            }
            
            char[] keyArray = keyWord.ToCharArray();
            char[] wordsArray = wordsToCheck.ToCharArray();

            int k = 0; //current letter in the keyword we are checking to
            int skips = 0; // keeps track of the amount of special characters we skipped

            for (int i = 0; i < wordsArray.Length; i++)
            {
                char letter = wordsArray[i];

                // check the first keyWord letter to our index in the word array
                if (keyArray[k] == letter || (keyArray[k] == '*' && _letterList.Contains(letter)))
                {
                    // found the letter now check for the seccond
                    k++;
                    // found word now check if it is surronded by spaces or at the start or end of the wordsArray
                    if (k == keyArray.Length)
                    {                        
                        k += skips;
                        
                        if ((i - k < 0 || // is the start of the word the start of the phrase
                            !_letterList.Contains(wordsArray[i - k]) || // is the letter before the word not a letter
                            !_letterList.Contains(wordsArray[i - (k - skips)])) // if it is a letter is there a symbol between them
                            && 
                            (i + 1 >= wordsArray.Length || // is the end of the word the end of the phrase
                                (!_letterList.Contains(wordsArray[i + 1]) // is there a non letter that ends the word
                                && 
                                !_nonWordEnders.Contains(wordsArray[i + 1])))) // is the non letter a hyphen or a underscore
                            count++; // if so we got one!
                        // reset count and start again
                        k = 0;
                        skips = 0;
                    }
                }
                else
                {
                    if (letter == ' ' || _letterList.Contains(letter))
                    {
                        k = 0;
                        skips = 0;
                    }
                    else
                        skips++;
                }
            }
            return count;
        }

       private string _RemoveSpecialCharacters(string phrase)
       {
            string output = "";
            for (int i = 0; i < phrase.Length; i++)
            {
                if (_letterList.Contains(phrase[i]) || phrase[i] == '*')
                    output += phrase[i];
            }
            return output;
       }
    }
}
