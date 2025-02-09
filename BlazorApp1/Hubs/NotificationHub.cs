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
 
    public class NotificationHub:Hub
    {

        public async Task SendNotificationToInformIAdedYouAsFriend(List<string> tourconid, string notification, string email)// שולחת התראת "הוספתי אותך כחבר" כאשר אדם מוסיף כחבר בנוסף יכולה לשלוח את ההודעה לכמה חיבורים
        {
            IReadOnlyList<string> friendcon = tourconid.ToList();
            await Clients.Clients(friendcon).SendAsync("GetNotificationToInformIAdedYouAsFriend", email, notification);
        }
    }
}
