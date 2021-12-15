using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PartIDK.Models;

namespace PartIDK.Controllers
{
    public class TopController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: Top
        public ActionResult Index()
        {
            return View(db.Animes.ToList());
        }

        // GET: Top/Details/5
        public ActionResult Animes(int? id)
        {
            if (id == null)
            {
                var animes = db.Animes.OrderByDescending(m => m.rating).Take(10);
                return View(animes);
            }

            var an = db.Animes.OrderByDescending(m => m.rating).Take((int)id);
            if (an == null)
            {
                return HttpNotFound();
            }
            return View(an);
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
