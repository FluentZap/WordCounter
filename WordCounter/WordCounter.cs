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

            char[] keyArray = keyWord.ToCharArray();
            char[] wordsArray = wordsToCheck.ToCharArray();
            
            int k = 0;            

            for (int i = 0; i < wordsArray.Length; i++)
            {
                //Check the first keyWord letter to our index in the word array
                if (keyArray[k] == wordsArray[i])
                {
                    //Found the letter now check for the seccond
                    k++;
                    //Found word now check if it is surronded by spaces or at the start or end of the wordsArray
                    if (k == keyArray.Length)
                    {
                        if ((i - k < 0 || wordsArray[i - k] == ' ') && 
                            (i + 1 >= wordsArray.Length || wordsArray[i + 1] == ' '))
                            count++;                        
                        //Reset count and start again
                        k = 0;
                    }
                }
                else
                    k = 0; //If we don't find a matching letter reset test char to start of word
            }            

            return count;
        }

    }
}
