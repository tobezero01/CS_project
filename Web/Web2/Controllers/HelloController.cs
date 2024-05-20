using Microsoft.AspNetCore.Mvc;

namespace Web2.Controllers
{
    public class HelloController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult helloResult()
        {
            ViewBag.Message = "Hello ";
            return View();
        }   
    }
}
