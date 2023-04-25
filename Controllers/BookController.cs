﻿using Microsoft.AspNetCore.Mvc;
using IT3047C_FinalProj.Models;

namespace IT3047C_FinalProj.Controllers
{
    public class BookController : Controller
    {
        private BookContext context { get; set; }

        public BookController(BookContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            return View("Edit", new Book());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.BookId == 0)
                    context.Books.Add(book);
                else
                    context.Books.Update(book);
                context.SaveChanges();
                return RedirectToAction("Index", "DatabaseInfo");
            }
            else
            {
                ViewBag.Action = (book.BookId == 0) ? "Add" : "Edit";
                ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
                return View(book);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("Index", "DatabaseInfo");
        }
    }
}
