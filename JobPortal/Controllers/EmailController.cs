using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class EmailController : Controller
    {
        //
        // GET: /Email/
        public ActionResult SendMail()
        {
            var seeker = Session["user"] as Seeker;
            var employer = Session["user"] as Employer;

            if (seeker == null && employer == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }
            ViewBag.message = "";
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendMail(Email email)
        {
            if (ModelState.IsValid)
            {

                var message = new MailMessage();
                message.To.Add(new MailAddress(email.To));  // replace with valid value 
                message.From = new MailAddress(email.UserID);  // replace with valid value
                message.Subject = email.Subject;
                message.Body = email.Body;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = email.UserID,  // replace with valid value
                        Password = email.Password // replace with valid value
                    };
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);

                    ViewBag.message = "Send Email Successfully";
                    
                }
            }
            return View(email);
        }

        //[HttpPost]
        //public ActionResult SendMail(Email email)
        //{



        //    using (MailMessage mail = new MailMessage())
        //    {
        //        mail.From = new MailAddress(email.UserID);
        //        mail.To.Add(email.To);
        //        mail.Subject = email.Subject;
        //        mail.Body = email.Body;
        //        mail.IsBodyHtml = true;


        //        using (SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587))
        //        {
        //            smtp.UseDefaultCredentials = false;
        //            smtp.Credentials = new NetworkCredential(email.UserID, email.Password);
        //            smtp.EnableSsl = true;
        //            smtp.Send(mail);

        //            ViewBag.message = "Send Email Successfully";
        //        }
        //    }



        //    return View();
        //}                                    
    }
}