using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Hubs;
using DisabilitySupport.DAL.Models;
using Microsoft.AspNetCore.SignalR;

namespace DisabilitySupport.BLL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContex;
        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContex = hubContext;
        }
        public async Task NotifiyUserAsync(string userId, string message)
        {
            await _hubContex.Clients.User(userId).SendAsync("ReceiveNotification", message);
        }
    }
}
