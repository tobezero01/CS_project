using Bai_thuc_hanh_1.Data;
using Bai_thuc_hanh_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bai_thuc_hanh_1.Controllers
{
    public class LearnerController: Controller
    {
        private SchoolContext db;
        public LearnerController(SchoolContext context)
        {
            db = context;
        }
        public IActionResult Index(int? mid)
        {
           if(mid == null)
            {
                var learners = db.Learners.Include(m => m.Major).ToList();
                return View(learners);                    
            }
            else
            {
                var learners = db.Learners
                    .Where( l=> l.MajorID == mid)
                    .Include(m => m.Major).ToList();
                return View(learners);
            }
        }

        public IActionResult LearnerByMajorID(int mid)
        {
            var learners = db.Learners
                .Where ( l => l.MajorID == mid)
                .Include (m => m.Major).ToList();
            return PartialView("LearnerTable",learners);
        }
        public IActionResult SearchSort(int? mid, int? page, string? searchString, string? currentString)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentString;
            }
            IQueryable<Learner> items = db.Learners;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentString;
            }
            // Tìm kiếm
            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(p =>p.LastName.Contains(searchString) || p.FirstMidName.Contains(searchString));
            }

            // Sắp xếp
            //items = Sort_(items, sortProduct);
            // Phân trang
            var viewModel = Pagination(items, page);

            return View("/Learn/Index", viewModel);
            
        }
        private ViewModelTest Pagination(IQueryable<Learner> items, int? page)
        {
            Console.WriteLine("PAGE:" + page + " " + items.Count());
            int pageSize = 3;
            int totalItems = items.Count();
            int totalPage = (int)Math.Ceiling((double)totalItems / pageSize);
            List<int> pageNumbers = Enumerable.Range(1, totalPage).ToList();
            int start = ((page ?? 1) - 1) * pageSize;
            Console.WriteLine("Start: " + start);
            var pagedItems = items.Skip(start).Take(pageSize).ToList();
            
            var viewModel = new ViewModelTest
            {
                DataList = pagedItems,
                PageNumbers = pageNumbers,
                CurrentPage = page ?? 1,
                TotalPages = totalPage
            };
            return viewModel;
        }
        public IActionResult Create()
        {
            var majors = new List<SelectListItem>();
            foreach (var item in db.Majors)
            {
                majors.Add(new SelectListItem
                {
                    Text = item.MajorName,
                    Value = item.MajorID.ToString()
                });
            }
            ViewBag.MajorID = majors;
            //ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName"); //cach 2 return View();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if ( id == null || db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Find(id);
            if(learner == null)
            {
                return NotFound();
            }
            ViewBag.MajorId = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,
            [Bind("LearnerId,FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if(id != learner.LearnerId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorId = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }
        private bool LearnerExists(int id)
        {
            return(db.Learners?.Any(e=>e.LearnerId == id)).GetValueOrDefault();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }
            var learner = db.Learners.Include(l => l.Major)
            .Include(e => e.Enrollments)
            .FirstOrDefault(m => m.LearnerId == id);
            if (learner == null)
            {
                return NotFound();
            }
            if (learner.Enrollments.Count()>0)
            {
                return Content("This learner has some enrollments, can't delete!");
            }
           
            return View(learner);
        } 
 
        // POST: Learner/Delete/5 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (db.Learners == null)
            {
                return Problem("Entity set 'Learners' is null.");
            }
            var learner = db.Learners.Find(id);
            if (learner != null)
            {
                db.Learners.Remove(learner);
            }
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
               





    }

        }
