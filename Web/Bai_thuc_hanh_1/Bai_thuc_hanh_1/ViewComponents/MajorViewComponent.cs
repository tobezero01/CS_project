using Bai_thuc_hanh_1.Data;
using Microsoft.AspNetCore.Mvc;
using Bai_thuc_hanh_1.Models;
namespace Bai_thuc_hanh_1.ViewComponents
{
    public class MajorViewComponent: ViewComponent
    {
        SchoolContext db;
        List<Major> majors;
        public MajorViewComponent(SchoolContext _context)
        {
            db = _context;
            majors = db.Majors.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderMajor", majors);
        }
    }
}
