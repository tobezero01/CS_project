using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Duc_211202522.Models;

namespace Duc_211202522.ViewComponents
{
	public class MenuViewComponent : ViewComponent
	{
		private QLHangHoaContext db;
		List<LoaiHang> loaihang;
		public MenuViewComponent(QLHangHoaContext _context)
		{
			db = _context;
			loaihang = db.LoaiHangs.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderMenu", loaihang);
		}
	}
}
