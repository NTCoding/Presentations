using System.Collections.Generic;

namespace SOLID_is_a_guideline.ISP.With
{
	// Is this all worth it?
	// There was no problem in the first place

	// It takes longer
	// adds more abstractions to our system
	// reduces cohesion

	// not really that dangerous, but not really that beneficial
	public class EmailSenders
	{
		// 1 client uses this
		public interface IUserRegisteredEmailSender
		{
			void SendRegistrationConfirmation(string recipient, string username, string templateFile);
		}

		// 1 client uses this pair
		public interface IWorkerRoleEmailsSender
		{
			void SendWorkerStartingNotification();

			void SendErrorInWorkerNotification(string message);
		}

		// 1 client uses these three
		public interface ITimeslotNotifierEmailsSender
		{
			void SendTimeslotStartupNotification(Timeslots timeSlot);

			void SendCompletedTimeslotNotification(Timeslots timeSlot);

			void SendErrorSendingReminderNotification(User user);
		}

		// 1 client uses just this method
		public interface IGroupedRemindersEmailSender
		{
			void SendGroupedRemindersFor(IEnumerable<LifeLessonGroup> groups, User user);
		}

		// 1 client uses just this method
		public interface IListRemindersEmailSender
		{
			void SendReminderFor(IEnumerable<LifeLesson> lessons, User user);
		}
	}
}