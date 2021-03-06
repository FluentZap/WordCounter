using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter;

namespace WordCounterTest
{
	[TestClass]
	public class WordCounterTests
	{
		[TestMethod]
		public void Model_Test_MatchSingleLetter()
		{
			Assert.AreEqual(1, WordCount.CountWords("f", "f"));
		}

		[TestMethod]
		public void Model_Test_MatchSingleLetterIgnoreCase()
		{
			Assert.AreEqual(1, WordCount.CountWords("f", "F"));
		}

		[TestMethod]
		public void Model_Test_MatchSingleLetterIgnoreCaseStrict()
		{
			Assert.AreEqual(0, WordCount.CountWords("f", "F", true));
		}

		[TestMethod]
		public void Model_Test_MatchMultipleLetters()
		{
			Assert.AreEqual(1, WordCount.CountWords("apple", "apple"));
		}

		[TestMethod]
		public void Model_Test_DoesNotMatchPartialWords()
		{
			Assert.AreEqual(0, WordCount.CountWords("app", "apple"));
		}

		[TestMethod]
		public void Model_Test_TreatWordsAsSeparateSpace()
		{
			Assert.AreEqual(2, WordCount.CountWords("apple", "apple juice apple pie"));
		}

		[TestMethod]
		public void Model_Test_IgnoreKeyWordSpecialCharacters()
		{
			Assert.AreEqual(2, WordCount.CountWords("!apple!", "apple juice apple pie"));
		}

		[TestMethod]
		public void Model_Test_StarWildCard()
		{
			Assert.AreEqual(2, WordCount.CountWords("**ple", "apple people ple maple"));
		}

		[TestMethod]
		public void Model_Test_StrictSpecialCharacters()
		{
			Assert.AreEqual(2, WordCount.CountWords("ap*le!", "apple! apple apile!", true));
		}

		[TestMethod]
		public void Model_Test_IgnoreWordsToCheckSpecialCharacters()
		{
			Assert.AreEqual(2, WordCount.CountWords("apples", "apple's, juice! apples' pie!"));
		}

		[TestMethod]
		public void Model_Test_SpecialCharactersMatchStrict()
		{
			Assert.AreEqual(1, WordCount.CountWords("apple's", "apple's, juice! apples' pie!", true));
		}

		[TestMethod]
		public void Model_Test_TreatSpecialCharactersAsWordDeviders()
		{
			Assert.AreEqual(2, WordCount.CountWords("apple", "apple,juice.apple!pie!"));
		}

		[TestMethod]
		public void Model_Test_DoNotIncludeHyphenOrUnderscores()
		{
			Assert.AreEqual(0, WordCount.CountWords("apple", "apple-juice apple_pie"));
		}

		[TestMethod]
		public void Model_Test_SearchParametersStrict()
		{
			Assert.AreEqual(1, WordCount.CountWords("^/S/Apple", "Apple bob and his apple"));
		}

		[TestMethod]
		public void Model_Test_SearchParametersPartial()
		{
			Assert.AreEqual(2, WordCount.CountWords("^/P/app", "apple app"));
		}

		[TestMethod]
		public void Model_Test_SearchParametersArray()
		{
			Assert.AreEqual(4, WordCount.CountWords("^/A/apple juice", "apple juice from the juice of the apple"));
		}

	}
}
