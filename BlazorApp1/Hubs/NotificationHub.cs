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
            Console.WriteLine( "dwadawd");
            IReadOnlyList<string> friendcon = tourconid.ToList();
            foreach(string s in friendcon)
            {
                Console.WriteLine(s);
            }

            await Clients.Clients(friendcon).SendAsync("GetNotificationToInformIAdedYouAsFriend", email, notification);
           //await Clients.All.SendAsync("GetNotificationToInformIAdedYouAsFriend", email, notification);
           //await Clients.AllExcept(friendcon).SendAsync("GetNotificationToInformIAdedYouAsFriend", email, notification);
           //await Clients.Caller.SendAsync("GetNotificationToInformIAdedYouAsFriend", email, notification);
         
        }
        public async Task SendNotificationToInformTeacherThatIwantPrivateClass(string notification, string myemail,string email)// שולחת למורה הודעה שאני רוצה שיעור פרטי,הפעולה מקבלת אמייל שלי אמייל של מורה ואת ההתראה
        {
            if (await StaticNotificationHub.IsThisSpecificEmailExistIn_multyconidFORnotificationsFORteacher(email))
            {
                List<string> tourconid = StaticNotificationHub.multyconidFORnotificationsForteacher[email];
            Console.WriteLine("dwadawd");
                IReadOnlyList<string> friendcon = tourconid.ToList();
                foreach (string s in friendcon)
                {
                    Console.WriteLine(s);
                }

                await Clients.Clients(friendcon).SendAsync("GetToInformTeacherThatIwantPrivateClass", myemail, notification);

            }
        }
        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
