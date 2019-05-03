using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCTemplate.Controllers
{
	public class WordCounterController: Controller
	{
		[HttpGet("/wordcounter")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
