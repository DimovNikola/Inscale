using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
