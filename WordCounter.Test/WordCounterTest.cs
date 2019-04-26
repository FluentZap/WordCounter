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
    }
}
