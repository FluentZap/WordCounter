using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordCounter;

namespace MVCTemplate.Controllers
{
	public class WordCounterController: Controller
	{
		[HttpGet("/wordcounter")]
		public IActionResult Index()
		{
			return View(WordDatabase.GetWordSearches());
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

			return RedirectToAction("Index");
		}
	}
}
