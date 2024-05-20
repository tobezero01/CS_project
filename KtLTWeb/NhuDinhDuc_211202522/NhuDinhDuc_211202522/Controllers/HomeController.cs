using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NhuDinhDuc_211202522.Models;
using System.Configuration.Provider;
using System.Diagnostics;

namespace NhuDinhDuc_211202522.Controllers
{
	public class HomeController : Controller
	{
		private readonly NewShopContext _db = new NewShopContext();
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult ProductByProviderID(int? id)
		{
			var items = _db.Providers.Where(i => i.Id == id).ToList();
			return PartialView("ProductTable", items);
		}
		public IActionResult Index()
		{
			var list = _db.Products.OrderByDescending(h => h.Name).Take(6).ToList();
			return View(list);
		}

		//public IActionResult MainRight()
		//{
		//	var list = _db.Products.ToList();
		//	return PartialView("NhuDinhDuc_211202522_MainRight", list);
		//}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.MaLoai = new SelectList(_db.Categories, "Id", "NameVn");
			ViewBag.Nsx = new SelectList(_db.Providers, "Id", "ProviderName");
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Id, Name, UnitPrice, Image,Available, CategoryId, Description")]  Product product)
		{
			if (ModelState.IsValid)
			{
				_db.Products.Add(product);
				_db.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			ViewBag.MaLoai = new SelectList(_db.Categories, "Id", "NameVn");
			ViewBag.Nsx = new SelectList(_db.Providers, "Id", "ProviderName");
			return View();
		}
	}
}