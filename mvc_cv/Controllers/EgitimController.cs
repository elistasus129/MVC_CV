using mvc_cv.Repositories;
using mvc_cv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_cv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<Tbl_Egitimlerim> repo = new GenericRepository<Tbl_Egitimlerim>();
        public ActionResult Index()
        {
            var yetenek = repo.List();
            return View(yetenek);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(Tbl_Egitimlerim p)
        {
            if (!ModelState.IsValid) {

                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
                return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(Tbl_Egitimlerim p)
        {

            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }
            var egitim = repo.Find(x => x.ID == p.ID);
            egitim.Baslik = p.Baslik;
            egitim.AltBaslik1 = p.AltBaslik1;
            egitim.AltBaslik2 = p.AltBaslik2;
            egitim.Tarih = p.Tarih;
            egitim.GNO = p.GNO;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}