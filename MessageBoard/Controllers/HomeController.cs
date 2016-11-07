using MessageBoard.Models;
using MessageBoard.Services;
using MessageBoard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard.Controllers
{
    //[RequireHttps] // not added in tutorial
    public class HomeController : Controller
    {
        private IMailService _mail;
        private IMessageBoardRepository _repo;

        public HomeController(IMailService mail, IMessageBoardRepository repo)
        {
            _mail = mail;
            _repo = repo;
        }

        public ActionResult Index()
        {
            var topics = _repo.GetTopics()
                .OrderByDescending(t => t.Created)
                .Take(25)
                .ToList();

            return View(topics);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var message = String.Format("Comment From: {1}{0}Email:{2}{0}Website:{3}{0}Comment:{4}{0}",
                Environment.NewLine,
                model.Name,
                model.Email,
                model.Website,
                model.Comment);
            
            if (_mail.SendMail("noreply@dom.com", 
                "foo@dom.com", 
                "Website content", 
                message))
            {
                ViewBag.MailSent = true;
            }

            return View();
        }

        [Authorize]
        public ActionResult MyMessages()
        {
            return View();
        }

     // [Authorize(Roles = "Admin")]
        [Authorize(Users ="emazuroo@gmail.com")]
        public ActionResult Moderation()
        {
            return View();
        }
    }
}