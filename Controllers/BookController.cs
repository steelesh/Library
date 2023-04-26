using IT3047C_FinalProj.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT3047C_FinalProj.Controllers
{
    public class BookController : Controller
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = _context.Genres.OrderBy(g => g.Name).ToList();
            return View("Edit", new Book());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = _context.Genres.OrderBy(g => g.Name).ToList();
            var book = _context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.BookId == 0)
                    _context.Books.Add(book);
                else
                    _context.Books.Update(book);
                _context.SaveChanges();
                return RedirectToAction("Index", "DatabaseInfo");
            }
            else
            {
                ViewBag.Action = (book.BookId == 0) ? "Add" : "Edit";
                ViewBag.Genres = _context.Genres.OrderBy(g => g.Name).ToList();
                return View(book);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index", "DatabaseInfo");
        }
    }
}
