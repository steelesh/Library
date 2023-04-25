using IT3047C_FinalProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT3047C_FinalProj.Controllers
{
    public class DatabaseInfoController : Controller
    {
        private BookContext context { get; set; }

        public DatabaseInfoController(BookContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var books = context.Books.Include(m => m.Genre)
            .OrderBy(m => m.Title).ToList();
            return View(books);
        }
    }
}
