using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordCounter;

namespace WordCounter
{
	public class WordCounterController: Controller
	{
		[HttpGet("/wordcounter")]
		public IActionResult Index(int message)
		{
			Dictionary<string, object> data = new Dictionary<string, object>();
			data.Add("wordSearch", WordDatabase.GetWordSearches());
			data.Add("message", message);
			return View(data);
		}		

		[HttpGet("/wordcounter/new")]
		public IActionResult New()
		{
			return View();
		}

		[HttpPost("/wordcounter")]
		public IActionResult Create(string keyword, string wordsToCount)
		{
			if (keyword != null && wordsToCount != null)
			{
				WordSearch wordSearch = new WordSearch(keyword, wordsToCount);
				wordSearch.Count = WordCount.CountWords(wordSearch.Keyword, wordSearch.WordsToCheck);
				WordDatabase.AddWordSearch(wordSearch);
			}
			else
			{
				if (keyword == null && wordsToCount == null)
				{
					return RedirectToAction("Index", new { message = 3 });
				}
				if (wordsToCount == null)
				{
					return RedirectToAction("Index", new { message = 2 });
				}
				if (keyword == null)
				{
					return RedirectToAction("Index", new { message = 1 });
				}				
			}

			return RedirectToAction("Index");
		}

		[HttpGet("/wordcounter/{guid}")]
		public IActionResult Show(string guid)
		{
			Guid id;
			try
			{
				id = new Guid(guid);				
			}
			catch (Exception)
			{
				return RedirectToAction("Index", new { message = 4 });
			}

			return View(WordDatabase.GetWordSearches()[id]);
		}

		[HttpPost("/wordcounter/delete")]
		public IActionResult Destroy()
		{			
			WordDatabase.ClearDatabase();
			return RedirectToAction("Index", new { message = 5 });
		}

	}
}
