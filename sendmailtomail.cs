using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FeedBack.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Email()
        {
            String sHTML;
            
            sHTML = "<head><meta charset=\"utf-8\" /></head>" + "<h1>" + "Отправка писем" + "</h1>";
            MailMessage Message = new MailMessage();

            Message.Subject = "Письмо с твоего сайта";


            Message.IsBodyHtml = true;
            Message.Body = sHTML;

            Message.From = new System.Net.Mail.MailAddress("to@mail");

            Message.To.Add(new MailAddress("from@mail"));

            System.Net.Mail.SmtpClient Smtp = new SmtpClient();//эсли здесь заполнено то строчка ниже не нужна!!!!

            Smtp.Host = "smtp.mail.ru"; //например для gmail (smtp.gmail.com), mail.ru(smtp.mail.ru) 
            Smtp.Port = 25;

            Smtp.EnableSsl = true; // включение SSL для gmail нужно!!! для mail.ru  нада!!!

            Smtp.Credentials = new System.Net.NetworkCredential("mail", "password");


            Smtp.Send(Message);//отправка
            
            return View();
        }

    }
}
