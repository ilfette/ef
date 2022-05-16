using EfremovaLR7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;


namespace EfremovaLR7.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
       // Сохраняем контекст EFCore
        private BooksDBContext db;
        public HomeController(BooksDBContext books)
        {
            db = books;
        }

        public IActionResult Index()
        {
            // Готовим данные для представления
            ViewData["Title"] = "Книги";
           // var books = MemoryDb.Books;
           // var books = db.Books.ToList();
            var books = db.Books.Include(a => a.Publisher).ToList();
            // Передаем управление "Представлению"
            return View(books);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Publishers = new SelectList(db.Publishers, "Id", "Name");
            Book book = new Book();
            return View(book);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(book);
        }


        [HttpGet]
        public IActionResult Edit_book(int Id)
        {
            var auto = db.Books.FirstOrDefault(p => p.Id == Id);
            ViewBag.Publishers = new SelectList(db.Publishers, "Id", "Name");
            return View(auto);
        }

        [HttpPost]
        public IActionResult Edit_book(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Update(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public IActionResult Delete(Book book)
        {
           
            db.Books.Attach(book);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Show_publisher(Book book)
        {
            int id = book.PublisherId;
            var instr = db.Publishers.FirstOrDefault(b => b.Id == id);
            var mus = db.Books.Where(x => x.PublisherId == id);
            ViewData["Books"] = mus;
            return View(instr);
        }

        [HttpGet]
        public IActionResult Edit_publisher(int Id)
        {
            var publisher = db.Publishers.FirstOrDefault(p => p.Id == Id);
            ViewBag.Compans = new SelectList(db.Publishers, "Id", "Name");
            return View(publisher);
        }

        [HttpPost]
        public IActionResult Edit_publisher(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Publishers.Update(publisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
