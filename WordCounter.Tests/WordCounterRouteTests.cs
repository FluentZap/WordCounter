using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter;
using System.Collections.Generic;
using WordCounter;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WordCounterRouteTests
{
	[TestClass]
	public class WordCounterTests
	{
		[TestMethod]
		public void Controller_Test_HomeControllerGet()
		{
			HomeController homeController = new HomeController();
			IActionResult indexView = homeController.Index();
			Assert.IsInstanceOfType(indexView, typeof(ViewResult));			
		}

		[TestMethod]
		public void Controller_Test_WordCounterControllerGetIndex()
		{
			WordCounterController wordCounterController = new WordCounterController();
			IActionResult indexView = wordCounterController.Index(0);
			Assert.IsInstanceOfType(indexView, typeof(ViewResult));
		}

		[TestMethod]
		public void Controller_Test_WordCounterControllerIndexHasCorrectModelType()
		{
			WordCounterController wordCounterController = new WordCounterController();
			ViewResult indexView = wordCounterController.Index(0) as ViewResult;

			var result = indexView.ViewData.Model;

			Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
		}

		[TestMethod]
		public void Controller_Test_WordCounterControllerGetNew()
		{
			WordCounterController wordCounterController = new WordCounterController();
			IActionResult indexView = wordCounterController.New();
			Assert.IsInstanceOfType(indexView, typeof(ViewResult));
		}
		

		[TestMethod]
		public void Controller_Test_WordCounterControllerGetShow()
		{
			WordCounterController wordCounterController = new WordCounterController();
			WordDatabase.AddWordSearch(new WordSearch("apple", "Apple juice is good!"));
			IActionResult showView = wordCounterController.Show(WordDatabase.GetWordSearches().First().Key.ToString());
			Assert.IsInstanceOfType(showView, typeof(ViewResult));
		}

		[TestMethod]
		public void Controller_Test_WordCounterControllerGetShowError()
		{
			WordCounterController wordCounterController = new WordCounterController();
			IActionResult showView = wordCounterController.Show("");
			Assert.IsInstanceOfType(showView, typeof(RedirectToActionResult));
		}


		[TestMethod]
		public void Controller_Test_WordCounterControllerShowHasCorrectModelType()
		{
			WordCounterController wordCounterController = new WordCounterController();
			WordDatabase.AddWordSearch(new WordSearch("apple", "Apple juice is good!"));
			ViewResult showView = wordCounterController.Show(WordDatabase.GetWordSearches().First().Key.ToString()) as ViewResult;				
			var result = showView.ViewData.Model;

			Assert.IsInstanceOfType(result, typeof(WordSearch));
		}

	}
}