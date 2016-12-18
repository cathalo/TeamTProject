using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using TeamTProject.Models;
using System.Text;
using System.Net;

namespace TeamTProject.Controllers
{

    public class HomeController : Controller
    {
        [RequireHttps]
        public ActionResult Index()
        {
            return View();
        }
        [RequireHttps]
        public ActionResult GameHost()
        {

            if (Session["email"] == null)
            {
                Response.Redirect("https://localhost:44364/");

            }

            //var numberOnline = HttpContext.Application["UsersOnline"] as string;
            //ViewBag.numberOnline = numberOnline;
            // return Redirect("http://127.0.0.1:8080/webGL/webGL/index.html");
            return View();
        }

        public ActionResult About()
        {
            
                
                if (Session["email"] == null)
                {
                    Response.Redirect("https://localhost:44364/");

                }
           

            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Game1()
        {


            if (Session["email"] == null)
            {
                Response.Redirect("https://localhost:44364/");

            }


            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModels c)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("https://localhost:44364/");

            }
            if (ModelState.IsValid)
            {
                try

                {
                    using (var client = new SmtpClient("smtp.gmail.com", 587))
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("hansfian837@gmail.com", "carpenter837");


                        string body = string.Format(
                            "First Name: {0}\nLast Name: {1}\nEmail: {2}\nComment: {3}",
                            c.FirstName,
                            c.LastName,
                            c.Email,
                            c.Comment
                        ); //In this block I added a new line \n to appear better when I receive the email.

                        var message = new MailMessage();
                        message.To.Add("cathalo@gmail.com");
                        message.From = new MailAddress(c.Email, c.FirstName);
                        message.Subject = String.Format("Contact Request From: {0} ", c.FirstName);
                        message.Body = body;
                        message.IsBodyHtml = false;
                        try
                        {
                            client.Send(message);

                        }

                        catch (Exception)
                        {
                            return View("Error");
                        }

                    }


                    return View("Success");
                }
                catch { return View("Error"); }


}

          //  ViewBag.Message = "Your contact page.";

            return View("Success");
        }
        
        public ActionResult Contact()
        {
            if (Session["email"] == null)
            {
                Response.Redirect("https://localhost:44364/");

           }

            return View();
       }
        public ActionResult UnityGame1()
        {
            if (Session["email"] == null)
            {
                Response.Redirect("https://localhost:44364/");

            }

            return View();
        }
        public ActionResult UnityGame2()
        {
            if (Session["email"] == null)
            {
                Response.Redirect("https://localhost:44364/");

            }

            return View();
        }
        public ActionResult UnityGame3()
        {
            if (Session["email"] == null)
            {
                Response.Redirect("https://localhost:44364/");

            }

            return View();
        }


    }
}