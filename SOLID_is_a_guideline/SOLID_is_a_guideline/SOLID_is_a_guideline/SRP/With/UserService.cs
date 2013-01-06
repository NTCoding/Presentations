using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace SOLID_is_a_guideline.SRP.With
{
	// taken from: http://blog.gauffin.org/2011/07/single-responsibility-prinicple/

	// Started out with 1 class, with 1 method, with 5 lines of code
	// now we've got 3 classes, 3 interfaces, all with very little logic
	
	// Is it worth it? Depends on your context. In this case I think not because:
	    // all changes are isolated to this one UserService class anyway
	    // there was no potential for fragile design
	    // new abstractions introduce their own readability/coupling problems
	    // if the requirements for this class change - we've now got to update 3 classes

	// Is it not better to ask "what is the simplest possible solution?"
	// ... and wait for the complexity to come 

	public class UserService
	{
		private Db _database;
		private readonly IEmailValidator emailValidator;
		private readonly IEmailService emailService;

		public UserService(IEmailValidator emailValidator, IEmailService emailService)
		{
			this.emailValidator = emailValidator;
			this.emailService = emailService;
		}

		public void Register(string email, string password)
		{
			if (!emailValidator.IsValid(email))
				throw new ValidationException("Email is not an email!");

			var user = new User(email, password);
			_database.Save(user);

			emailService.Send(new MailMessage("mysite@nowhere.com", email) { Subject = "HEllo fool!" });
		}
	}

	public interface IEmailService
	{
		void Send(MailMessage message);
	}

	public class EmailService : IEmailService
	{
		private SmtpClient smtpClient;

		public void Send(MailMessage message)
		{
			smtpClient.Send(message);
		}
	}

	public interface IEmailValidator
	{
		bool IsValid(string email);
	}

	public class EmailValidator : IEmailValidator
	{
		public bool IsValid(string email)
		{
			return email.Contains("@");
		}
	}
}