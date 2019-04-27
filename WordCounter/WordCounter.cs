using System;
using System.Collections.Generic;

namespace WordCounter
{
    public class WordCount
    {
        private List<char> _letterList = new List<char>()

        { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

        private List<char> _nonWordEnders = new List<char>()
        {'_', '-'};
        
        struct KeyWithParameters
        {
            public string keyWord;
            public string options;
        }

        private class _SearchOptions
        {
            public bool strict = false;
            public bool partial = false;
            public bool array = false;
        }

        private KeyWithParameters _GetSearchParameters(string word)
        {
            string _options = "";
            string _keyWord = "";
            word = word.Substring(2);

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != '/')
                    _options += word[i];
                else
                {
                    _keyWord = word.Substring(i + 1);
                    break;
                }                    
            }
            return new KeyWithParameters() { keyWord = _keyWord, options = _options };
        }

        public int CountWords(string keyWord, string wordsToCheck, bool strict = false)
        {
            _SearchOptions so = new _SearchOptions();
            if (keyWord.Length >= 2 && keyWord.Substring(0, 2) == "^/")
            {
                KeyWithParameters keyPar = _GetSearchParameters(keyWord);
                keyWord = keyPar.keyWord;
                string options = keyPar.options;
                for (int i = 0; i < options.Length; i++)
                {
                    switch(options[i])
                    {
                        case 'S':
                            so.strict = true;
                            break;
                        case 'P':
                            so.partial = true;
                            break;
                        case 'A':
                            so.array = true;
                            break;
                    }                    
                }                
            }

            if (strict) // backwards compatibility for earlier version with constructor overload
                so.strict = true;

            int count = 0;
            if (so.array)
            {
                string[] _keyWords = keyWord.Split(null);
                foreach (string key in _keyWords)
                {
                    count += CountSingleWords(key, wordsToCheck, so);
                }                
            }
            else
            {
                count += CountSingleWords(keyWord, wordsToCheck, so);
            }
            return count;
        }

        private int CountSingleWords(string keyWord, string wordsToCheck, _SearchOptions so)
        {
            int count = 0; // the number of words we have matched with
            if (!so.strict)
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
                    // found the letter now check for the second
                    k++;
                    // found word now check if it is surrounded by spaces or at the start or end of the wordsArray
                    if (k == keyArray.Length)
                    {
                        k += skips;

                        bool _goodStartOfWord =
                            i - k < 0 ||   // is the start of the word the start of the phrase
                            !_letterList.Contains(wordsArray[i - k]) || // is the letter before the word not a letter
                            !_letterList.Contains(wordsArray[i - (k - skips)]); // if it is a letter is there a symbol between them


                        bool _goodEndOfWord =
                            i + 1 >= wordsArray.Length || // is the end of the word the end of the phrase
                            (
                                !_letterList.Contains(wordsArray[i + 1]) && // is there a non letter after the end of the word
                                !_nonWordEnders.Contains(wordsArray[i + 1]) // is the non letter a hyphen or an underscore 
                            ) ||
                            (
                                _letterList.Contains(wordsArray[i + 1]) && // is the next letter after the end a letter
                                so.partial //do we accept partials
                            );


                        if (_goodStartOfWord && _goodEndOfWord) // does the word start and end with the correct characters with the correct characters between them
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
