using Microsoft.AspNetCore.Mvc;
//để dùng model phải using
using test1_22_8_23.Models;

namespace test1_22_8_23.Controllers
{
    public class HelloController : Controller
    {

        //acction này để hiển thị form
        [Route("MyRoute/index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //lấy dữ liệu từ form
        //chỉnh method = post trong index.cshtml và phải có [HttpPost] thì đoạn code index ở dưới mới chạy được
        public IActionResult Index(Message model)//nhận dữ liệu từ người dùng
            //là 2 biến kiểu string và int và id
        {
            //gửi giữ liệu về view dùng viewbag
            //viewbag là vùng bộ nhớ chia sẻ giữa action và view;
            //hoạt động như 1 collection
            
            ViewBag.Message = model.msg;
            ViewBag.Page = model.pgnum;
            ViewBag.Date = DateTime.Now;
            //tạo ra một đối tượng model model truyền tham số dữ liệu cần lấy
            Message m = new Message(model.msg, model.pgnum);
            
            //trả về view SayHello

            // dùng model chỉ cần thêm tham số m vừa khai báo ở trên vào return
            //đối tượng m sẽ trả về cho view dưới dạng model
            return View("SayHello",m);
        }
        public ActionResult SayHello()
        {
            ViewBag.Message = "Welcome to ASP.NET 7.0";
            //return Content("" + "Hello Welcome to ASP.NET MVC 7.0");
            return View();
        }
    }
}
