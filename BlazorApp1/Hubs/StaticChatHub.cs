using System.Collections.Generic;

namespace BlazorApp1.Hubs
{
    public static class StaticChatHub
    {
        public static Dictionary<string, string> conids { get; set; } = new Dictionary<string, string>();
        public static Dictionary<string, List<string>> multyconidFORnotifications { get; set; } = new Dictionary<string, List<string>>();

        public static async Task<bool> IsThisSpecificEmailExistIn_multyconidFORnotifications(string email)
        {
            if (multyconidFORnotifications.ContainsKey(email))
            {
               return true;
            }
            return false;
        }

        public static async Task<bool> IsThisSpesificConTO_Email_ExistIn_multyconidFORnotifications(string email, string conid)// תחת האמייל של היוזרmultyconidFORnotifications האם נמצא כבר חיבור לדף ב
        {
           
                if (multyconidFORnotifications.ContainsKey(email))
                {
                    foreach (string conids in multyconidFORnotifications[email])
                    {
                        if (conids == conid)
                        {
                            return true;
                        }
                    }
                }
                return false;
            
          
        }

        public static async Task<List<string>> GiveMyFriendConFORnotifications(string email)// multyconidFORnotifications עבור 
        {
            List<string> list = new List<string>();
            if (await IsMyFriendHereOrmeFORnotifications(email) > 0)
            {
                foreach (KeyValuePair<string, List<string>> entry in multyconidFORnotifications)
                {
                    if (entry.Key == email)
                    {
                        foreach(string con in  entry.Value)
                        { 
                        list.Add(con);
                        }
                    }

                }
            }
            return list;

        }
        public static async Task<int> IsMyFriendHereOrmeFORnotifications(string email)//עבורmultyconidFORnotifications 
        {
            int count = 0;
            foreach (KeyValuePair<string, List<string>> entry in multyconidFORnotifications)
            {
                if (entry.Key == email)
                {
                    count++;
                }

            }
            return await Task.FromResult(count);

        }
       



        /// <summary>
        /// עבור הספרייה הסטטית conids 
        /// שהיא בשביל צאט בין חברים
        /// ↓
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        

        public static async Task<int> IsMyFriendHereOrme(string email)
        {
            int count = 0;
            foreach (KeyValuePair<string, string> entry  in conids)
            {
               if (entry.Key== email)
               {
                    count++;
               }
            
            }
            return await Task.FromResult(count);

        }
        public static async Task<List<string>> GiveMyFriendCon(string email)
        {
           List<string> list = new List<string>();
            if ( await IsMyFriendHereOrme(email)>0)
            {
                foreach (KeyValuePair<string, string> entry in conids)
                {
                    if (entry.Key == email)
                    {
                       list.Add(entry.Value);
                    }

                }
            }
           return  list;
            
        }

        public static async Task< bool> IfKeyHasVal(string key) //בודק אם עבור מפתח מסויים שיש בספרייה יש גם ערך (נעשה בגלל בעיות שילוב של פעולות שפועלות בפתיחת הדף)
                                           // onafterrender&&OnInitializedAsync
        {

            foreach (KeyValuePair<string, string> entry in conids)
            {
                if (entry.Key == key)
                {
                    if( string.IsNullOrEmpty(entry.Value))
                        return await Task.FromResult(true);
                }

            }
            return await Task.FromResult(false);

        } 
    }
}
