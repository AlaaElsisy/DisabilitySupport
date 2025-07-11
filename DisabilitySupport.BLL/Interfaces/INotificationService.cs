using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface INotificationService
    {
        Task NotifiyUserAsync(string userId,string message);
    }
}
