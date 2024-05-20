using Bai_thuc_hanh_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bai_thuc_hanh_1.ViewComponents
{
    public class RenderViewComponent:ViewComponent
    {
        private List<MenuItem> MenuItems = new List<MenuItem>();
        public RenderViewComponent()
        {
            MenuItems = new List<MenuItem>()
            {
                new MenuItem(){Id=1, Name="Branches", Link="Branches/List"},
                new MenuItem(){Id=2, Name="Students", Link="Students/List"},
                new MenuItem(){Id=3, Name="Subjects", Link="Subjects/List" },
                new MenuItem(){Id=4, Name="Courses", Link="Courses/List"}
            };
        }
        // Có 2 cách
        //1. Dùng truyền thông không đồng bộ
        public async Task<IViewComponentResult> InvokeAsync() //Hàm InvokeAsync chạy khi gọi đến ViewComponent
        {
            return View("RenderLeftMenu", MenuItems);
        }
        //2. Dùng truyền thông đồng bộ - truyền trên 1 tiến trình duy nhất--> hạn chế trải nghiệm người dùng
     //  public IViewComponentResult Invoke()
     //Khi sử dụng ViewComponent thì tên có view     
    }
}
