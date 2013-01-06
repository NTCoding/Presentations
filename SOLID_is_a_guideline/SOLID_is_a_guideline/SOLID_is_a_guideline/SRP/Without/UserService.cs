using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace SOLID_is_a_guideline.SRP.Without
{
	// taken from: http://blog.gauffin.org/2011/07/single-responsibility-prinicple/

	public class UserService
	{
		private SmtpClient _smtpClient;
		private Db _database;

		public void Register(string email, string password)
		{
			if (!email.Contains("@"))
				throw new ValidationException("Email is not an email!");

			var user = new User(email, password);
			_database.Save(user);

			_smtpClient.Send(new MailMessage("mysite@nowhere.com", email) { Subject = "HEllo fool!" });
		}
	}
}