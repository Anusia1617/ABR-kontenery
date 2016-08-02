using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using KonteneryMVC.Models;
using System.IO;

namespace KonteneryMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactModels contactModels)
        {
            if (ModelState.IsValid)
            {
                string from = "admin@abrhandel.pl";
                string to = "biuro@abrkontenery.pl";
                string message = "<b>Wiadomość od: </b>" + contactModels.Name + "(" + contactModels.Email + ") - tel: " + contactModels.Phone + " <br /> <b>Treść wiadomości: </b><br />" + contactModels.Text;
                using (MailMessage mail = new MailMessage(from, to))
                {
                    mail.Subject = "kontakt z abrkontenery.pl";
                    mail.Body = message;

                    foreach( var file in contactModels.files)
                    {
                        if (file != null)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            mail.Attachments.Add(new Attachment(file.InputStream, fileName));
                        }
                        else
                        {
                            continue;
                        }
                    }
                   
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "masnetmail.home.pl";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(from, "#edcVfr4");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);
                    ViewBag.Message = "Sent";
                    return View("Index");
                }
            }
            else
            {
                return View();
            }
        }

    }
}