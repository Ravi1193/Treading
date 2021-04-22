using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Treading.Models;
namespace Treading.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Patient()
        {
            return View();
        }

        public ActionResult PatientGetById(int Id)
        {
            Patient p = new Patient();
            ViewBag.Patiant = p.GetPatient(Id);
            return View();
        }



    }
}