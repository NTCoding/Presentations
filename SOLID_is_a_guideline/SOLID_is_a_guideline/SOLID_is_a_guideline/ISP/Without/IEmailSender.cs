using System.Collections.Generic;

namespace SOLID_is_a_guideline.ISP.Without
{
	// Most clients use 1 or 2 of these methods
	// but changes to the ones they don't use will not impact them
	
	// If I change any signature - or add/delete - will it break the registration handler?

	public interface IEmailSender
	{
		void SendRegistrationConfirmation(string recipient, string username, string templateFile);

		void SendWorkerStartingNotification();

		void SendTimeslotStartupNotification(Timeslots timeSlot);

		void SendCompletedTimeslotNotification(Timeslots timeSlot);

		void SendErrorSendingReminderNotification(User user);

		void SendErrorInWorkerNotification(string message);

		void SendReminderFor(IEnumerable<LifeLesson> lessons, User user);

		void SendGroupedRemindersFor(IEnumerable<LifeLessonGroup> groups, User user);
	}

	public class RegistrationHandler
	{
		private readonly IEmailSender emailer;

		public RegistrationHandler(IEmailSender emailer)
		{
			this.emailer = emailer;
		}

		public void Handle(UserSignUpRequest request)
		{
			emailer.SendRegistrationConfirmation("me", "username", "blah");
		}
	}

	public class UserSignUpRequest
	{
	}
}