using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface INotificationService
    {
        Task<List<Notification>> GetNotificationsAsync(string userId);
    }
}
