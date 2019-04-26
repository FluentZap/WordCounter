using System;
using System.Collections.Generic;
using System.Text;

namespace WordCounter
{
    public class WordCount
    {

        private List<char> _letterList = new List<char>()
        {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

        public int CountWords(string keyWord, string wordsToCheck, bool strict = false)
        {
            int count = 0;
            
            if (!strict)
            {
                wordsToCheck = wordsToCheck.ToLower();
                keyWord = keyWord.ToLower();
                keyWord = _RemoveSpecialCharacters(keyWord);
            }
            

            char[] keyArray = keyWord.ToCharArray();
            char[] wordsArray = wordsToCheck.ToCharArray();

            int k = 0;
            int skips = 0;

            string testString = "";
            int testLetters = 0;

            for (int i = 0; i < wordsArray.Length; i++)
            {
                char letter = wordsArray[i];

                //Check the first keyWord letter to our index in the word array
                if (keyArray[k] == letter || (keyArray[k] == '*' && _letterList.Contains(letter)))
                {
                    //Found the letter now check for the seccond
                    k++;
                    //Found word now check if it is surronded by spaces or at the start or end of the wordsArray
                    if (k == keyArray.Length)
                    {                        
                        k += skips;
                        
                        if ((i - k < 0 || !_letterList.Contains(wordsArray[i - k])) &&
                            (i + 1 >= wordsArray.Length || !_letterList.Contains(wordsArray[i + 1])))
                            count++;
                        //Reset count and start again
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
