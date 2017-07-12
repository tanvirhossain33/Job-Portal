using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.BLL;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class SeekerController : Controller
    {
        SeekerManager seekerManager = new SeekerManager();



        public ActionResult ManageResume()
        {
            var seeker = Session["user"] as Seeker;

            if (seeker == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }
            ViewBag.message = "";
            return View();
        }

        

        public ActionResult CreateResume()
        {
            var seeker = Session["user"] as Seeker;

            if (seeker == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateResume(Seeker seeker, HttpPostedFileBase file)
        {

            seeker.CV = "sample Text";


            return View(seeker);
        }
       
        public ActionResult UploadResume()
        {
            var seeker = Session["user"] as Seeker;

            if (seeker == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }

            ViewBag.message = "";

            return View();
        }

        [HttpPost]
        public ActionResult UploadResume(Seeker seeker, HttpPostedFileBase file)
        {
            var session = Session["user"] as Seeker;
            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }

            int seekerID = session.SeekerID;
            
            //string message = seekerManager.UpdateResume(seeker, seekerID);

            if (file != null && file.ContentLength > 0)
                try
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var fileType = Path.GetExtension(fileName);
                    if (fileType != ".pdf")
                    {
                        ViewBag.message = "upload failed !! please upload PDF formate file";
                    }
                    else
                    {
                        fileName = seekerID + fileType;
                        var path = Path.Combine(Server.MapPath("~/App_Data/Resume"), fileName);
                        file.SaveAs(path);
                        ViewBag.message = "Resume uploaded successfully";
                    }
                    
                }
                catch (Exception ex)
                {
                    ViewBag.message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.message = "You have not specified a file.";
            }
            return View();

        }

        public ActionResult DownloadResume()
        {
            var session = Session["user"] as Seeker;
            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }
            int seekerID = session.SeekerID;
            string name = session.Name;

            ViewBag.message = "";

            var fileName = name + " Resume" + seekerID + ".pdf";

            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/App_Data/Resume/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles(seekerID+".pdf");

            if (fileNames.Length == 0)
            {
                //ViewBag.message = "Resume was not uploaded..";
                return RedirectToAction("ManageResume", "Seeker");
                
            }
            else
            {
                var data = File("~/App_Data/Resume/" + seekerID + ".pdf", System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                return data;
            }
            

            
        }

        
       
        
	}
}