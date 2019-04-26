using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter;

namespace WordCounterTest
{
    [TestClass]
    public class WordCounterTest
    {
        [TestMethod]
        public void Test_MatchSingleLetter()
        {
            WordCount wordCount = new WordCount();
            Assert.AreEqual(1, wordCount.CountWords("f", "f"));
        }

        [TestMethod]
        public void Test_MatchSingleLetterIgnoreCase()
        {
            WordCount wordCount = new WordCount();
            Assert.AreEqual(1, wordCount.CountWords("f", "F"));
        }

        [TestMethod]
        public void Test_MatchSingleLetterIgnoreCaseStrict()
        {
            WordCount wordCount = new WordCount();
            Assert.AreEqual(0, wordCount.CountWords("f", "F", true));
        }

        [TestMethod]
        public void Test_MatchMultipleLetters()
        {
            WordCount wordCount = new WordCount();
            Assert.AreEqual(1, wordCount.CountWords("apple", "apple"));
        }

        [TestMethod]
        public void Test_DoesNotMatchPartialWords()
        {
            WordCount wordCount = new WordCount();
            Assert.AreEqual(0, wordCount.CountWords("app", "apple"));
        }

        [TestMethod]
        public void Test_TreatWordsAsSeparateSpace()
        {
            WordCount wordCount = new WordCount();
            Assert.AreEqual(2, wordCount.CountWords("apple", "apple juice apple pie"));
        }

        [TestMethod]
        public void Test_IgnoreKeyWordSpecialCharacters()
        {
            WordCount wordCount = new WordCount();
            Assert.AreEqual(2, wordCount.CountWords("!apple!", "apple juice apple pie"));
        }

        [TestMethod]
        public void Test_StarWildCard()
        {
            WordCount wordCount = new WordCount();
            Assert.AreEqual(2, wordCount.CountWords("**ple", "apple people ple maple"));
        }

        [TestMethod]
        public void Test_StrictSpecialCharacters()
        {
            WordCount wordCount = new WordCount();
            Assert.AreEqual(2, wordCount.CountWords("ap*le!", "apple! apple apile!", true));
        }

        [TestMethod]
        public void Test_IgnoreWordsToCheckSpecialCharacters()
        {
            WordCount wordCount = new WordCount();
            Assert.AreEqual(2, wordCount.CountWords("apples", "apple's, juice! apples' pie!"));
        }

        [TestMethod]
        public void Test_SpecialCharactersMatchStrict()
        {
            WordCount wordCount = new WordCount();
            Assert.AreEqual(1, wordCount.CountWords("apple's", "apple's, juice! apples' pie!", true));
        }



        [TestMethod]
        public void Test_TreatSpecialCharactersAsWordDeviders()
        {
            WordCount wordCount = new WordCount();
            Assert.AreEqual(2, wordCount.CountWords("apple", "apple,juice.apple!pie!"));
        }

    }
}
