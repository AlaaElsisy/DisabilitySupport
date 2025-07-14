using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Hubs;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using Microsoft.AspNetCore.SignalR;

namespace DisabilitySupport.BLL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository notificationRepository;
       
        public NotificationService(INotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
           
        }


        async Task<List<Notification>> INotificationService.GetNotificationsAsync(string userId, int pageNumber)
        {
           return await notificationRepository.GetAll(userId,pageNumber);

        }
    }
}
