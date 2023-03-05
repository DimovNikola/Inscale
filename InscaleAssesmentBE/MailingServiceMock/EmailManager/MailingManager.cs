namespace MailingServiceMock.EmailManager
{
    public class MailingManager : IMailingManager
    {
        public void SendEmailBookedResource(int id)
        {
            Console.WriteLine($"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {id}");
        }
    }
}
