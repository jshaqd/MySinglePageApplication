using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Mailers;
using MvcApplication.Models;
using Mvc.Mailer;

namespace MvcApplication.Controllers.Api
{
    public class OrderController : Controller
    {
        private IUserMailer _mailer = new UserMailer();
        public IUserMailer Mailer
        {
            get { return _mailer; }
            set { _mailer = value; }
        }

        [System.Web.Http.HttpPost]
        public ActionResult Send(OrderForm orderForm)
        {
            UserMailer mailer = Mailer as UserMailer;
            mailer.OrderForm = orderForm;
            Mailer.Welcome().Send();
            return View();
        }
    }
}
