using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.BLL;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class SettingsController : Controller
    {
        SettingsManager settingsManager = new SettingsManager();

        public ActionResult Index()
        {
            var seeker = Session["user"] as Seeker;
            var employer = Session["user"] as Employer;

            if (seeker == null && employer == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }
            return View();
        }

        public ActionResult UpdatePassword()
        {
            var seeker = Session["user"] as Seeker;
            var employer = Session["user"] as Employer;

            if (seeker == null && employer == null )
            {
                return RedirectToAction("LoginAccount", "Login");
            }

            ViewBag.message = "";
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePassword(Settings settings)
        {
            var seeker = Session["user"] as Seeker;
            var employer = Session["user"] as Employer;

            if (seeker == null && employer == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }

            string message = "";
            
            if (seeker != null)
            {
                string seekerEmail = seeker.Email;
                message = settingsManager.UpdateSeekerPassword(settings, seekerEmail);
            }
            else if (employer != null)
            {
                string employerEmail = employer.ContactPersonEmail;
                message = settingsManager.UpdateEmployerPassword(settings, employerEmail);
            }


            ViewBag.message = message;
            return View();
        }
	}
}