using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs
{
    public class PayHub : Hub
    {
        public static readonly IDictionary<string, string> Transactionconnections = new Dictionary<string, string>();
        public void RegisterTransaction(string id)
        {
            var connectionId = Context.ConnectionId;
            Transactionconnections[id] = connectionId;
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var connectionId = Context.ConnectionId;
            var item = Transactionconnections.FirstOrDefault(x=>x.Value==connectionId);
            Transactionconnections.Remove(connectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
