using MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class ShipperController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        // GET: Shipper
        public ActionResult Index()
        {
            //List<Shipper> kargolar = new List<Shipper>();
            //kargolar = db.Shippers.ToList();
            //return View(kargolar);
            return View(db.Shippers.ToList());
        }

        //HTTPGet şle tetikleniyor. O yüzden üzerinde bir şey yazmama gerek yok.
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                db.Shippers.Add(shipper);
                db.SaveChanges();
                return RedirectToAction("Index"); //Index Action'a git dedim.
            }
            //return HttpNotFound();   ---> bu şekilde hata raporu da verebilirim.
            return View(shipper);

        }
    }
}