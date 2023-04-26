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
            return View("EditFavorite", new Book());
        }

        [HttpGet]
        public IActionResult EditFavorite(int bookId, int memberId)
        {
            ViewBag.Action = "Edit";
            ViewBag.ActionName = GetMemberActionName(memberId);
            ViewBag.MemberId = memberId;
            ViewBag.Genres = _context.Genres.OrderBy(g => g.Name).ToList();

            Member member = _context.Members.Include(m => m.Favorites).FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
            {
                return NotFound();
            }

            Book book = member.Favorites.FirstOrDefault(f => f.BookId == bookId);
            if (book == null)
            {
                return NotFound();
            }

            return View("EditFavorite", book);
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
                return View("EditFavorite", book);
            }
        }

        [HttpGet]
        public IActionResult DeleteFavorite(int bookId, int memberId)
        {
            Member member = _context.Members.Include(m => m.Favorites).FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
            {
                return NotFound();
            }

            Book book = member.Favorites.FirstOrDefault(f => f.BookId == bookId);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.ActionName = GetMemberActionName(memberId);
            ViewBag.MemberId = memberId;
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

            ViewBag.ActionName = GetMemberActionName(memberId);
            ViewBag.MemberId = memberId;
            member.Favorites.Remove(existingBook);
            _context.SaveChanges();
            return RedirectToAction(GetMemberActionName(memberId));
        }

        [HttpGet]
        public IActionResult AddCurrentlyReading(int memberId)
        {
            ViewBag.Action = "Add";
            ViewBag.ActionName = GetMemberActionName(memberId);
            ViewBag.MemberId = memberId;
            ViewBag.Genres = _context.Genres.OrderBy(g => g.Name).ToList();
            return View("EditCurrentlyReading", new Book());
        }

        [HttpGet]
        public IActionResult EditCurrentlyReading(int bookId, int memberId)
        {
            ViewBag.Action = "Edit";
            ViewBag.ActionName = GetMemberActionName(memberId);
            ViewBag.MemberId = memberId;
            ViewBag.Genres = _context.Genres.OrderBy(g => g.Name).ToList();

            Member member = _context.Members.Include(m => m.CurrentlyReading).FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
            {
                return NotFound();
            }

            Book book = member.CurrentlyReading.FirstOrDefault(f => f.BookId == bookId);
            if (book == null)
            {
                return NotFound();
            }

            return View("EditCurrentlyReading", book);
        }

        [HttpPost]
        public IActionResult EditCurrentlyReading(Book book, int memberId)
        {
            if (ModelState.IsValid)
            {
                Member member = _context.Members.Include(m => m.CurrentlyReading).FirstOrDefault(m => m.MemberId == memberId);
                if (member == null)
                {
                    return NotFound();
                }

                Book existingBook = member.CurrentlyReading.FirstOrDefault(f => f.BookId == book.BookId);
                if (existingBook == null)
                {
                    member.CurrentlyReading.Add(book);
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
                return View("EditCurrentlyReading", book);
            }
        }

        [HttpGet]
        public IActionResult DeleteCurrentlyReading(int bookId, int memberId)
        {
            Member member = _context.Members.Include(m => m.CurrentlyReading).FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
            {
                return NotFound();
            }

            Book book = member.CurrentlyReading.FirstOrDefault(f => f.BookId == bookId);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.ActionName = GetMemberActionName(memberId);
            ViewBag.MemberId = memberId;
            return View(book);
        }

        [HttpPost]
        public IActionResult DeleteCurrentlyReading(Book book, int memberId)
        {
            Member member = _context.Members.Include(m => m.CurrentlyReading).FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
            {
                return NotFound();
            }

            Book existingBook = member.CurrentlyReading.FirstOrDefault(f => f.BookId == book.BookId);
            if (existingBook == null)
            {
                return NotFound();
            }

            ViewBag.ActionName = GetMemberActionName(memberId);
            ViewBag.MemberId = memberId;
            member.CurrentlyReading.Remove(existingBook);
            _context.SaveChanges();
            return RedirectToAction(GetMemberActionName(memberId));
        }

        // START OF WANTTOREAD

        [HttpGet]
        public IActionResult AddWantToRead(int memberId)
        {
            ViewBag.Action = "Add";
            ViewBag.ActionName = GetMemberActionName(memberId);
            ViewBag.MemberId = memberId;
            ViewBag.Genres = _context.Genres.OrderBy(g => g.Name).ToList();
            return View("EditWantToRead", new Book());
        }

        [HttpGet]
        public IActionResult EditWantToRead(int bookId, int memberId)
        {
            ViewBag.Action = "Edit";
            ViewBag.ActionName = GetMemberActionName(memberId);
            ViewBag.MemberId = memberId;
            ViewBag.Genres = _context.Genres.OrderBy(g => g.Name).ToList();

            Member member = _context.Members.Include(m => m.WantToRead).FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
            {
                return NotFound();
            }

            Book book = member.WantToRead.FirstOrDefault(f => f.BookId == bookId);
            if (book == null)
            {
                return NotFound();
            }

            return View("EditWantToRead", book);
        }

        [HttpPost]
        public IActionResult EditWantToRead(Book book, int memberId)
        {
            if (ModelState.IsValid)
            {
                Member member = _context.Members.Include(m => m.WantToRead).FirstOrDefault(m => m.MemberId == memberId);
                if (member == null)
                {
                    return NotFound();
                }

                Book existingBook = member.WantToRead.FirstOrDefault(f => f.BookId == book.BookId);
                if (existingBook == null)
                {
                    member.WantToRead.Add(book);
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
                return View("EditWantToRead", book);
            }
        }

        [HttpGet]
        public IActionResult DeleteWantToRead(int bookId, int memberId)
        {
            Member member = _context.Members.Include(m => m.WantToRead).FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
            {
                return NotFound();
            }

            Book book = member.WantToRead.FirstOrDefault(f => f.BookId == bookId);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.ActionName = GetMemberActionName(memberId);
            ViewBag.MemberId = memberId;
            return View(book);
        }

        [HttpPost]
        public IActionResult DeleteWantToRead(Book book, int memberId)
        {
            Member member = _context.Members.Include(m => m.WantToRead).FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
            {
                return NotFound();
            }

            Book existingBook = member.WantToRead.FirstOrDefault(f => f.BookId == book.BookId);
            if (existingBook == null)
            {
                return NotFound();
            }

            ViewBag.ActionName = GetMemberActionName(memberId);
            ViewBag.MemberId = memberId;
            member.WantToRead.Remove(existingBook);
            _context.SaveChanges();
            return RedirectToAction(GetMemberActionName(memberId));
        }

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
