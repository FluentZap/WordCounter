using System;
using System.Collections.Generic;

namespace WordCounter
{


	public class WordSearch
	{
		public string Keyword { get; set; }
		public string WordsToCheck { get; set; }
		public int Count { get; set; }

		public WordSearch(string keyword, string wordsToCheck)
		{
			Keyword = keyword;
			WordsToCheck = wordsToCheck;
		}
	}



	public static class WordDatabase
	{
		static Dictionary<Guid, WordSearch> _database = new Dictionary<Guid, WordSearch>();

		public static void AddWordSearch(WordSearch search)
		{
			_database.Add(Guid.NewGuid(), search);
		}

		public static Dictionary<Guid, WordSearch> GetWordSearches()
		{
			return _database;
		}

		public static void ClearDatabase()
		{
			_database.Clear();
		}

	}


}