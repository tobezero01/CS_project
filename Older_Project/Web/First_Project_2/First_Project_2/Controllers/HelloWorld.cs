using Microsoft.AspNetCore.Mvc;
using First_Project_2.Models;
namespace First_Project_2.Controllers
{
    public class HelloWorld : Controller
    {
        public IActionResult Index()
        {
  


            return View();
        }
        public ActionResult SayHello()
        {


            return View();
        }

        //Atribute method thực thi khi client gửi lên
        [HttpPost]
        public ActionResult SayHello(string msg, int pg)
        {
            //Gửi dữ liệu về view dùng ViewBag
            //ViewBag là vùng bộ nhớ chia sẻ giữa action và view
            //Hoạt động như một collection
            ViewBag.message = msg;
            ViewBag.pgnum = pg;
            Message m = new Message(msg,pg);
            return View("MyView",m);

        }
        public ActionResult MyView()
        {
            return View();
        }
    }
}
