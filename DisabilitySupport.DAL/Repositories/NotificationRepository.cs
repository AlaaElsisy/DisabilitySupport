using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DisabilitySupport.DAL.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>,INotificationRepository
    {
        
        public NotificationRepository(ApplicationDbContext context) : base(context) {

            
        }

   

        public async Task<List<Notification>> GetAll(string userId)
        {
          return  await _Context.Notifications.Where(x=>x.UserId==userId || x.MessageType == "All").ToListAsync();
        }
    }
}
