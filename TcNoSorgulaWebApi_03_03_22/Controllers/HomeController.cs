using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TcNoSorgulaWebApi_03_03_22.Models;
using TcNoSorgulaWebApi_03_03_22.Repository;

namespace TcNoSorgulaWebApi_03_03_22.Controllers
{
    public class HomeController : Controller
    {
        public PersonRepository<Person> rep = new PersonRepository<Person>();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Person model, string tcNo)
        {
            tcnosorgula.KPSPublic kps = new tcnosorgula.KPSPublic();
            bool kontrol = kps.TCKimlikNoDogrula(long.Parse(tcNo), model.Name.ToUpper(), model.Surname.ToUpper(), int.Parse(model.BirthDate));
            if (kontrol)
            {
                byte[] tcNoHash, tcNoSalt;
                rep.CreateTcNoHash(tcNo, out tcNoHash, out tcNoSalt);
                model.TcNumberHash = tcNoHash;
                model.TcNumberSalt = tcNoSalt;
                
                if(rep.VerifyTcNoHash(tcNo, tcNoHash, tcNoSalt))
                {                    
                    rep.CreatePerson(model);
                    ViewBag.Sonuc = "olumlu";
                    return View("KontrolSonuc",model);
                }
                else
                {
                    ViewBag.Sonuc = "olumsuz";
                    return View("KontrolSonuc", model);
                }               
            }
            ViewBag.Sonuc = "yok";
            return View("KontrolSonuc", model);
        }
    }
}