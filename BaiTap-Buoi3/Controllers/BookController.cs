using BaiTap_Buoi3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BaiTap_Buoi3.Controllers
{
    public class BookController : Controller
    {
      
        private BookManagerContext context = new BookManagerContext();

     
        public ActionResult Index()
        {
            return View(context.Books.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        public ActionResult Buy(int id)
        {
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Title,Author,Description,Images,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = context.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Author,Description,Images,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                context.Entry(book).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = context.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = context.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = context.Books.Find(id);
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

       
        
    }
}
