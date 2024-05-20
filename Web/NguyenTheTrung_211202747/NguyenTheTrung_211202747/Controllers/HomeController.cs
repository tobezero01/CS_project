using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenTheTrung_211202747.Models;
using System.Diagnostics;

namespace NguyenTheTrung_211202747.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private QLHangHoaContext db = new QLHangHoaContext();
		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var items =db.HangHoas.Where(p=>p.Gia>=2000).ToList();
            return View(items);
        }
        public IActionResult ProductByCategoryID(int id)
        {
            var items = db.HangHoas.Where(i=>i.MaLoai==id).ToList();
            return PartialView("ProductTable", items);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}