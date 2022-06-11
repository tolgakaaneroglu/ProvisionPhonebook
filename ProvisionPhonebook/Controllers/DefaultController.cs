using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvisionPhonebook.Models.EntityFramework;

namespace ProvisionPhonebook.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbProvisionEntities db = new DbProvisionEntities();
        public ActionResult Index()
        {
            var kisi = db.TblKisi.ToList();
            return View(kisi);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }   
        [HttpPost]
        public ActionResult Add(TblKisi a)
        {
            db.TblKisi.Add(a);
            db.SaveChanges();
            return View();
        } 


        public ActionResult Delete(int id)
        {
            var kisi = db.TblKisi.Find(id);
            db.TblKisi.Remove(kisi);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
        public ActionResult Bring(int id)
        {
            var kisi = db.TblKisi.Find(id);
            return View("Bring", kisi);
        } 
        public ActionResult Update(TblKisi a)
        {
            var kisi = db.TblKisi.Find(a.KisiID);
            kisi.KisiAd = a.KisiAd;
            kisi.KisiSoyad = a.KisiSoyad;
            kisi.KisiTel = a.KisiTel;
            kisi.KisiTelTip = a.KisiTelTip;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

    }
}