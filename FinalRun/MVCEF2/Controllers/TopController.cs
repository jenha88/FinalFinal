using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCEF2.Models;

namespace MVCEF2.Controllers
{
    public class TopController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: Top
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m=>m.Director).OrderByDescending(m => m.gross).Take(10);
            return View(movies);
        }

        public ActionResult Movies(int? id)
        {
            if (id == null)
            {
            var mv = db.Movies.OrderByDescending(m => m.gross).Take(10);
                return View(mv);
            }
  
            var movies = db.Movies.OrderByDescending(m => m.gross).Take((int)id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
