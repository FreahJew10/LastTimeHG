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

        public async Task SendNotificationToInformIAdedYouAsFriend(string friendemail, string notification, string email)// שולחת התראת "הוספתי אותך כחבר" כאשר אדם מוסיף כחבר בנוסף יכולה לשלוח את ההודעה לכמה חיבורים
        {
            Console.WriteLine( "dwadawd");
            if (await StaticNotificationHub.IsThisSpecificEmailExistIn_multyconidFORnotifications(friendemail))
            {
                Console.WriteLine(  "gethere");
                List<string> tourconid = StaticNotificationHub.multyconidFORnotificationsForstudents[friendemail];
                IReadOnlyList<string> friendcon = tourconid.ToList();
                foreach (string s in friendcon)
                {
                    Console.WriteLine(s);
                }


                await Clients.Clients(friendcon).SendAsync("GetNotificationToInformIAdedYouAsFriend", email, notification);
            }
           //await Clients.All.SendAsync("GetNotificationToInformIAdedYouAsFriend", email, notification);
           //await Clients.AllExcept(friendcon).SendAsync("GetNotificationToInformIAdedYouAsFriend", email, notification);
           //await Clients.Caller.SendAsync("GetNotificationToInformIAdedYouAsFriend", email, notification);
         
        }
        public async Task SendNotificationToInformTeacherThatIwantPrivateClass(string notification, string myemail,string email,int eventrandomcod)//    שולחת למורה הודעה שאני רוצה שיעור פרטי,הפעולה מקבלת אמייל שלי אמייל של מורה ואת ההתראה וכמובן את מספר האיוונט על מנת להציג את זה ישר בדף ההתראות
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

                await Clients.Clients(friendcon).SendAsync("GetToInformTeacherThatIwantPrivateClass", myemail, notification,eventrandomcod);

            }
        }
        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
