using Mvc.Mailer;
using MvcApplication.Models;

namespace MvcApplication.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
        public OrderForm OrderForm { get; set; }
		public UserMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage Welcome()
		{
            ////ViewBag.Data = someObject;
            //return Populate(x =>
            //{
            //    x.Subject = "Welcome";
            //    x.ViewName = "Welcome";
            //    x.To.Add("some-email@example.com");
            //});

            var mailMessage = new MvcMailMessage { Subject = "在线订单" };
            mailMessage.To.Add("angela.qiandan@gmail.com");
		    ViewBag.OrderForm = this.OrderForm;
            PopulateBody(mailMessage, viewName: "Welcome");
            return mailMessage;
		}

        public virtual MvcMailMessage GoodBye()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "GoodBye";
				x.ViewName = "GoodBye";
				x.To.Add("some-email@example.com");
			});
		}
 	}
}