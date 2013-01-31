using Mvc.Mailer;

namespace MvcApplication.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome();
			MvcMailMessage GoodBye();
	}
}