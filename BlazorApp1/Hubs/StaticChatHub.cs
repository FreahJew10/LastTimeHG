using System.Collections.Generic;

namespace BlazorApp1.Hubs
{
    public static class StaticChatHub
    {
        public static Dictionary<string, string> conids { get; set; } = new Dictionary<string, string>();

        public static async Task<int> IsMyFriendHere(string email)
        {
            int count = 0;
            foreach (KeyValuePair<string, string> entry  in conids)
            {
               if (entry.Key==email)
               {
                    count++;
               }
            
            }
            return count;

        }
        public static async Task<List<string>> GiveMyFriendCon(string email)
        {
           List<string> list = new List<string>();
            if ( await IsMyFriendHere(email)>0)
            {
                foreach (KeyValuePair<string, string> entry in conids)
                {
                    if (entry.Key == email)
                    {
                       list.Add(entry.Value);
                    }

                }
            }
           return list;
            
        }
        public static async Task< bool> IfKeyHasVal(string key) //בודק אם עבור מפתח מסויים שיש בספרייה יש גם ערך (נעשה בגלל בעיות שילוב של פעולות שפועלות בפתיחת הדף)
                                           // onafterrender&&OnInitializedAsync
        {

            foreach (KeyValuePair<string, string> entry in conids)
            {
                if (entry.Key == key)
                {
                    if(string.IsNullOrEmpty(entry.Value))
                        return true;
                }

            }
            return false;

        } 
    }
}
