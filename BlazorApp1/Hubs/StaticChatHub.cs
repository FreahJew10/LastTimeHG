using System.Collections.Generic;

namespace BlazorApp1.Hubs
{
    public static class StaticChatHub
    {
        public static Dictionary<string,List< string>> conids { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        /// עבור הספרייה הסטטית conids 
        /// שהיא בשביל צאט בין חברים
        /// ↓
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        

        public static async Task<int> IsEmailHere(string email)
        {

            if(conids.ContainsKey(email))
                return 1;

        return 0;

        }
        public static async Task<List<string>> GiveMyFriendCon(string email)
        {
           List<string> list = new List<string>();
            if ( await IsEmailHere(email)>0)
            {
                foreach (KeyValuePair<string,List< string>> entry in conids)
                {
                    if (entry.Key == email)
                    {
                       list=conids[entry.Key];
                    }

                }
            }
           return  list;
            
        }

        public static async Task< bool> IfKeyHasVal(string key) //בודק אם עבור מפתח מסויים שיש בספרייה יש גם ערך (נעשה בגלל בעיות שילוב של פעולות שפועלות בפתיחת הדף)
                                           // onafterrender&&OnInitializedAsync
        {

            foreach (KeyValuePair<string,List< string>> entry in conids)
            {
                if (entry.Key == key)
                {
                    
                        return await Task.FromResult(true);
                }

            }
            return await Task.FromResult(false);

        } 
    }
}
