using IT3047C_FinalProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT3047C_FinalProj.Controllers
{
    public class MembersController : Controller
    {

        private readonly BookContext _context;

        public MembersController(BookContext context)
        {
            _context = context;
        }

        private string GetMemberActionName(int memberId)
        {
            switch (memberId)
            {
                case 1:
                    return "Eric";
                case 2:
                    return "Miriam";
                case 3:
                    return "Steele";
                case 4:
                    return "Zion";
                default:
                    throw new ArgumentException("Invalid memberId");
            }
        }

        [HttpGet]
        public IActionResult AddFavorite(int memberId)
        {
            ViewBag.Action = "Add";
            ViewBag.ActionName = GetMemberActionName(memberId);
            ViewBag.MemberId = memberId;
            ViewBag.Genres = _context.Genres.OrderBy(g => g.Name).ToList();
            return View("Edit", new Book());
        }

        [HttpPost]
        public IActionResult EditFavorite(Book book, int memberId)
        {
            if (ModelState.IsValid)
            {
                Member member = _context.Members.Include(m => m.Favorites).FirstOrDefault(m => m.MemberId == memberId);
                if (member == null)
                {
                    return NotFound();
                }

                Book existingBook = member.Favorites.FirstOrDefault(f => f.BookId == book.BookId);
                if (existingBook == null)
                {
                    member.Favorites.Add(book);
                }
                else
                {
                    existingBook.Title = book.Title;
                    existingBook.Author = book.Author;
                    existingBook.PublicationYear = book.PublicationYear;
                    existingBook.GenreId = book.GenreId;
                }

                _context.SaveChanges();
                return RedirectToAction(GetMemberActionName(memberId));
            }
            else
            {
                ViewBag.Action = (book.BookId == 0) ? "Add" : "Edit";
                ViewBag.ActionName = GetMemberActionName(memberId);
                ViewBag.MemberId = memberId;
                ViewBag.Genres = _context.Genres.OrderBy(g => g.Name).ToList();
                return View("Edit", book);
            }
        }

        /*        [HttpGet]
                public IActionResult DeleteFavorite(int id, int memberId)
                {
                    Member member = _context.Members.Include(m => m.Favorites).FirstOrDefault(m => m.MemberId == memberId);
                    if (member == null)
                    {
                        return NotFound();
                    }

                    Book book = member.Favorites.FirstOrDefault(f => f.BookId == id);
                    if (book == null)
                    {
                        return NotFound();
                    }

                    return View(book);
                }

                [HttpPost]
                public IActionResult DeleteFavorite(Book book, int memberId)
                {
                    Member member = _context.Members.Include(m => m.Favorites).FirstOrDefault(m => m.MemberId == memberId);
                    if (member == null)
                    {
                        return NotFound();
                    }

                    Book existingBook = member.Favorites.FirstOrDefault(f => f.BookId == book.BookId);
                    if (existingBook == null)
                    {
                        return NotFound();
                    }

                    member.Favorites.Remove(existingBook);
                    _context.SaveChanges();
                    return RedirectToAction(GetMemberActionName(memberId));
                }*/

        public IActionResult Eric()
        {
            var member = _context.Members.Include(m => m.Favorites).Include(m => m.CurrentlyReading).Include(m => m.WantToRead).FirstOrDefault(m => m.MemberId == 1);
            return View(member);
        }

        public IActionResult Miriam()
        {
            var member = _context.Members.Include(m => m.Favorites).Include(m => m.CurrentlyReading).Include(m => m.WantToRead).FirstOrDefault(m => m.MemberId == 2);
            return View(member);
        }

        public IActionResult Steele()
        {
            var member = _context.Members.Include(m => m.Favorites).Include(m => m.CurrentlyReading).Include(m => m.WantToRead).FirstOrDefault(m => m.MemberId == 3);
            return View(member);
        }

        public IActionResult Zion()
        {
            var member = _context.Members.Include(m => m.Favorites).Include(m => m.CurrentlyReading).Include(m => m.WantToRead).FirstOrDefault(m => m.MemberId == 4);
            return View(member);
        }
    }
}
