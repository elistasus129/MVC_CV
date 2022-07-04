using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_cv.Models.Entity;

namespace mvc_cv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        dbcvEntities db = new dbcvEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Hakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.Tbl_Deneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimlerim = db.Tbl_Egitimlerim.ToList();
            return PartialView(egitimlerim);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.Tblyetenekler.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobilerim()
        {
            var yetenekler = db.TblHobilerim.ToList();
            return PartialView(yetenekler);

        }

        public PartialViewResult Sertifikalar()
        {
            var sertifikalar = db.TblSertifikalarim.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}