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



     
        public async Task SendMessageToFriend(List<string>friendcon, string massage,Person me)//פעולה כדי לשלוח לחבר ספציפי בחיבור ספציפי
        {

            await Clients.Clients(friendcon).SendAsync("ReceiveMassage",me,massage);
        }
        public async Task SendMessageToFriendisFriendconnected(List<string> friendcon)//ברגע שהחבר מתחבר הפעולה תשלח שהוא אכן מחובר
        {
            bool b=true;
            await Clients.Clients(friendcon[0]).SendAsync("Receivethatmyfriendisconnected",true);
        }

        


       


    }
    
}
