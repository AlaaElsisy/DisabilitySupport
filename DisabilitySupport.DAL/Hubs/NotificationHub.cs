using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Models;
using Microsoft.AspNetCore.SignalR;

namespace DisabilitySupport.DAL.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly ApplicationDbContext dbContext;

        public NotificationHub(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SendNotificationToAll(string message)
        {
            Notification notification = new Notification()
            {
                Message = message,
                NotificationDateTime = DateTime.UtcNow,
                MessageType = "All",
                UserId = "All"

            };
            dbContext.Notifications.Add(notification);
            await dbContext.SaveChangesAsync();
            await Clients.All.SendAsync("ReceivedNotification", message);
        }

        public async Task SendNotificationToClient(string message, string userId)
        {

            Notification notification = new Notification()
            {
                Message = message,
                NotificationDateTime = DateTime.UtcNow,
                MessageType = "Personal",
                UserId = userId

            };

            dbContext.Notifications.Add(notification);
            await dbContext.SaveChangesAsync();

            var hubConnections = dbContext.HubConnections.Where(con => con.UserId == userId).ToList();
            foreach (var hubConnection in hubConnections)
            {
                await Clients.Client(hubConnection.ConnectionId).SendAsync("ReceivedPersonalNotification", message, userId);
            }
        }


        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("OnConnected");
            return base.OnConnectedAsync();
        }

        public async Task SaveUserConnection(string userId)
        {
            var connectionId = Context.ConnectionId;
            HubConnection hubConnection = new HubConnection
            {
                ConnectionId = connectionId,
                UserId = userId
            };

            dbContext.HubConnections.Add(hubConnection);
            await dbContext.SaveChangesAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var hubConnection = dbContext.HubConnections.FirstOrDefault(con => con.ConnectionId == Context.ConnectionId);
            if (hubConnection != null)
            {
                dbContext.HubConnections.Remove(hubConnection);
                dbContext.SaveChangesAsync();
            }

            return base.OnDisconnectedAsync(exception);
        }
    }
}
