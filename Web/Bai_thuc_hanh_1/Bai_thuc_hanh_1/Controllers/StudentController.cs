using Microsoft.AspNetCore.Mvc;
using Bai_thuc_hanh_1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bai_thuc_hanh_1.Controllers
{
    [Route("Admin/Student")]   
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
       public StudentController() 
        {
            //Tạo danh sách sinh viên với 4 dữ liệu mẫu
            listStudents = new List<Student>()
            {
                new Student()
                {
                    Id = 101,
                    Name = "Nguyễn Thế Trung",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = " Hoàng Mai",
                    Email = "Trung@g.com"
                },
                new Student()
                               {
                                    Id = 102,
                                    Name = "Nguyễn Tiến Tùng",
                                    Branch = Branch.BE,
                                    Gender = Gender.Female,
                                    IsRegular = true,
                                    Address = " Quốc Oai",
                                    Email = "Tung@g.com"
                                },
                new Student()
                {
                Id = 103,
                Name = "Nhữ Đình Đức",
                Branch = Branch.CE,
                Gender = Gender.Male,
                IsRegular = false,
                Address = " Hải Dương",
                Email = "Duc@g.com"
                },
                new Student()
                {
                    Id = 104,
                    Name = "Xuân Mai",
                    Branch = Branch.EE,
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "Cầu Giấy",
                    Email = "Mai@g.com"
                }


            };
        }
        [Route("List")]
        public IActionResult Index()
        {
            return View(listStudents);
        }
        [HttpGet("Add")]
        public IActionResult Create()
        {
            //lấy danh sách các giá trị Gender để hiển thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            //lấy danh sách các giá trị Branch để hiển thị select-option trên form
            //Để hiển thị select-option trên View cần dùng List<SelectListItem>
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem{ Text ="IT",Value="1"},
                new SelectListItem{ Text ="BE",Value="2"},
                new SelectListItem{ Text ="CE",Value="3"},
                new SelectListItem{ Text ="EE",Value="4"}
            };
            return View();
        }
        [HttpPost("Add")]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last<Student>().Id + 1;
                listStudents.Add(s);
                return View("Index", listStudents);
            }
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
 };
            return View();
        }
    }
}
