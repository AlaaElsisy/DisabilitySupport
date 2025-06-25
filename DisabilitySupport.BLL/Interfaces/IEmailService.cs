using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models.Authentication;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface IEmailService
    {
        void sendEmail(Message message);
    }
}
