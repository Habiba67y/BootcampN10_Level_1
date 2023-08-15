using N24_T3;
var emailService = new EmailService();
emailService.emails = new List<Email>
{
    new Email("john@example.com", "jane@example.com", "Meeting Reminder", "Don't forget about the meeting tomorrow.", DateTime.Now.AddDays(1), false),
    new Email("mary@example.com", "robert@example.com", "Vacation Plans", "Let's discuss our vacation plans next week.", DateTime.Now.AddDays(2), false),
    new Email("david@example.com", "linda@example.com", "Project Update", "Here's an update on the current project status.", DateTime.Now.AddHours(6), false),
    new Email("susan@example.com", "michael@example.com", "Important Announcement", "Please read the attached document for an important announcement.", DateTime.Now.AddHours(12), true),
    new Email("william@example.com", "emily@example.com", "New Opportunity", "We have an exciting new opportunity for you. Let's discuss.", DateTime.Now.AddDays(3), false),
    new Email("james@example.com", "sarah@example.com", "Birthday Party Invitation", "You're invited to my birthday party next week. Don't miss it!", DateTime.Now.AddDays(7), false),
    new Email("richard@example.com", "barbara@example.com", "Weekly Report", "Attached is the weekly progress report. Please review.", DateTime.Now.AddDays(1), false),
    new Email("kevin@example.com", "amanda@example.com", "Travel Itinerary", "Your travel itinerary for the upcoming trip is attached.", DateTime.Now.AddDays(5), true),
    new Email("alex@example.com", "jessica@example.com", "Job Interview", "We're pleased to invite you for a job interview on the specified date.", DateTime.Now.AddHours(3), true),
    new Email("daniel@example.com", "laura@example.com", "Party Reminder", "Just a reminder about the party we're hosting this weekend.", DateTime.Now.AddDays(2), false),
    new Email("chris@example.com", "ashley@example.com", "Meeting Agenda", "Here's the agenda for our upcoming meeting. Please review.", DateTime.Now.AddHours(2), false),
    new Email("jason@example.com", "kim@example.com", "Product Launch", "Our new product will be launched next month. Stay tuned!", DateTime.Now.AddDays(10), false),
    new Email("patrick@example.com", "rachel@example.com", "Training Session", "The training session for the new software will be on the specified date.", DateTime.Now.AddDays(5), true),
    new Email("nathan@example.com", "jennifer@example.com", "Congratulations!", "Congratulations on your recent achievement. Well done!", DateTime.Now.AddDays(1), false),
    new Email("brian@example.com", "melissa@example.com", "Feedback Request", "We'd appreciate your feedback on our recent service. Thank you.", DateTime.Now.AddDays(3), false),
    new Email("peter@example.com", "natalie@example.com", "Webinar Invitation", "Join our upcoming webinar on the specified topic. Register now!", DateTime.Now.AddDays(7), false),
    new Email("george@example.com", "olivia@example.com", "Payment Reminder", "Please remember to make the payment for the invoice due on the specified date.", DateTime.Now.AddDays(2), true),
    new Email("eric@example.com", "ava@example.com", "Volunteer Opportunity", "We're looking for volunteers for the upcoming event. Join us!", DateTime.Now.AddDays(4), false),
    new Email("ryan@example.com", "grace@example.com", "Newsletter Subscription", "Thank you for subscribing to our newsletter. Stay updated!", DateTime.Now.AddDays(1), false),
    new Email("jacob@example.com", "mia@example.com", "Meeting Request", "I'd like to schedule a meeting with you to discuss the project.", DateTime.Now.AddHours(5), false)
};
Console.WriteLine();
emailService.GetBySender("j", 5,1).ForEach(Console.WriteLine);
Console.WriteLine();
emailService.GetByReceiver("br", 5, 1).ForEach(Console.WriteLine);
Console.WriteLine();
emailService.Get(new EmailfFlterModel(null, null, null, 10, 1)).ForEach(Console.WriteLine);
