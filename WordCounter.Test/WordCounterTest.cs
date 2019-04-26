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
            Assert.AreEqual(0, wordCount.CountWords("apple", "apple"));
        }
    }
}
