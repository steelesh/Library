using IT3047C_FinalProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT3047C_FinalProj.Controllers
{
    public class DatabaseInfoController : Controller
    {
        private readonly BookContext _context;

        public DatabaseInfoController(BookContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.Include(m => m.Genre)
            .OrderBy(m => m.Title).ToList();
            return View(books);
        }
    }
}
