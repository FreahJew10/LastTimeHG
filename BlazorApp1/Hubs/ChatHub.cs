using Microsoft.AspNetCore.SignalR;
using System.Net.Mail;
using Models;
using DBL;
using Org.BouncyCastle.Asn1.Ocsp;
namespace BlazorApp1.Hubs
{
    public class ChatHub:Hub
    {
         static Dictionary<string, List<string>> NtoIdMappingTable = new Dictionary<string, List<string>>();
        //public async Task SendMessage(Person Iperson,string massage,Person Fperson)
        //{
        //   // await Clients.User(Fperson.email).SendAsync("ReceiveMassage", Iperson.first_name, massage);
        //    await Clients.All.SendAsync("ReceiveMassage", Iperson, massage);
        //}
        public async Task SendMessage(Person person, string massage)
        {
            await Clients.All.SendAsync("ReceiveMassage", person, massage);
        }
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        //public async Task MessageBetweenFriends(Person user, Person receiver, string message)
        //{
        //    string userId = NtoIdMappingTable.GetValueOrDefault(receiver.email);

        //    await Clients.User(userId).SendAsync("ReceiveMessage", user, $"{message}(Private Mes)");
        //}

        //public override async Task OnConnectedAsync()
        //{
        //    var username = Context.User.Identity.Name;
        //    var userId = Context.UserIdentifier;
        //    List<string> userIds;

        //    if (!NtoIdMappingTable.TryGetValue(username, out userIds))
        //    {
        //        userIds = new List<string>();
        //        userIds.Add(userId);

        //        NtoIdMappingTable.Add(username, userIds);
        //    }
        //    else
        //    {
        //        userIds.Add(userId);
        //    }

        //    await base.OnConnectedAsync();
        //}



    }
    
}
