using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingServiceMock.EmailManager
{
    public interface IMailingManager
    {
        void SendEmailBookedResource(int id);
    }
}
