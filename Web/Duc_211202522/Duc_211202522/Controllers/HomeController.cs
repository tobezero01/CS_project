using Duc_211202522.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Plugins;
using System.Diagnostics;

namespace Duc_211202522.Controllers
{
    public class HomeController : Controller
    {
        private QLHangHoaContext _context = new QLHangHoaContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
		public IActionResult ProductByCategoryID(int? id)
		{
			var items = _context.HangHoas.Where(i => i.MaLoai == id).ToList();
			return PartialView("ProductTable", items);
		}
        public IActionResult Index()
        {
            var items = _context.HangHoas.Where(i => i.Gia >= 100).ToList();
            return View(items);
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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaLoai,TenHang,Gia,Anh")] HangHoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                _context.HangHoas.Add(hanghoa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }
    }
}