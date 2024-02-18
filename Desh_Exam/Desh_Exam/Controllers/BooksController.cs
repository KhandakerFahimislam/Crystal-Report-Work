using Desh_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace Desh_Exam.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookDbContext db;
        public BooksController()
        {
            db = new BookDbContext();
        }
        // GET: Books
        public async Task<ActionResult> Index(int pg = 1)
        {
            var data = await db.Books.OrderBy(a => a.BookId).ToPagedListAsync(pg, 5);
            return View(data);
        }
        public ActionResult Create(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(b);
                db.SaveChanges();

                return RedirectToAction("Create", new { message = "New Data saved successfully To Database" });
            }
            return View(b);
        }
        public ActionResult Edit(int id)
        {
            return View(db.Books.FirstOrDefault(a => a.BookId == id));
        }
        [HttpPost]
        public ActionResult Edit(Book b)
        {
            if (ModelState.IsValid)
            {
                db.Entry(b).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "Edit Data Change Saved successfully";
                return View("Edit", b);
            }
            return View(b);
        }
        [HttpPost]
       
        public ActionResult Delete(int id)
        {
            var b = db.Books.FirstOrDefault(a => a.BookId == id);
            if (b == null) return new HttpNotFoundResult();
            db.Books.Remove(b);
            db.SaveChanges();
            return Json(new { success = true, id });
           
        }

    }
}