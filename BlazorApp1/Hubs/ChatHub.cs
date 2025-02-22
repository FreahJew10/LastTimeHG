using Microsoft.AspNetCore.SignalR;
using System.Net.Mail;
using Models;
using DBL;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Google.Protobuf;
namespace BlazorApp1.Hubs
{

    public class ChatHub:Hub
    {

        // Called by the client to join a specific event group
        public async Task JoinGroup(string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        }

        public async Task LeaveGroup(string groupId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
        }

        public async Task SendMessage(int eventId, comment cmt)
        {
            // Must broadcast to the EXACT group name joined by the clients
            await Clients.Group(eventId.ToString()).SendAsync("ReceiveMessage", cmt);
        }



        //public async Task SendMessage(Person Iperson, string massage, Person Fperson)
        //{
        //    // await Clients.User(Fperson.email).SendAsync("ReceiveMassage", Iperson.first_name, massage);
        //    await Clients.All.SendAsync("ReceiveMassage", Iperson, massage + $@" {Context.ConnectionId}");
        //}

        //public async Task SendMessage(Person person, string massage)
        //{

        //    await Clients.All.SendAsync("ReceiveMassage", person, massage + $@"{Context.ConnectionId}");
        //}
        public async Task SendMessageToFriend(List<string>friendcon, string massage,Person me)//פעולה כדי לשלוח לחבר ספציפי בחיבור ספציפי
        {

            await Clients.Clients(friendcon[0]).SendAsync("ReceiveMassage",me,massage);
        }
        public async Task SendMessageToFriendisFriendconnected(List<string> friendcon)//ברגע שהחבר מתחבר הפעולה תשלח שהוא אכן מחובר
        {
            bool b=true;
            await Clients.Clients(friendcon[0]).SendAsync("Receivethatmyfriendisconnected",true);
        }

        



        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        public async Task getCon()//send to yourself
        {
            string me = Context.ConnectionId;
            await Clients.Caller.SendAsync("ReceiveMessage",me);
        }
        public async Task RequestUserId()
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? Context.ConnectionId;
            await Clients.Caller.SendAsync("ReceiveUserId", userId);
        }

        //public string GetUserId()
        //{
        //    // Method 1: Try multiple ways to get the user ID
        //    var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    if (string.IsNullOrEmpty(userId))
        //    {
        //        userId = Context.User?.Identity?.Name;
        //    }
        //    if (string.IsNullOrEmpty(userId))
        //    {
        //        userId = Context.ConnectionId; // Fallback to connection ID
        //    }
        //    return userId;
        //}






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
