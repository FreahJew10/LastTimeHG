namespace BlazorApp1.Hubs
{
    public static class StaticNotificationHub
    {
        public static Dictionary<string, List<string>> multyconidFORnotifications { get; set; } = new Dictionary<string, List<string>>();
        public static async Task<bool> IsThisSpecificEmailExistIn_multyconidFORnotifications(string email)
        {
            if (multyconidFORnotifications.ContainsKey(email))
            {
                return true;
            }
            return false;
        }
        public static async Task<bool> IsThisSpesificConTO_Email_ExistIn_multyconidFORnotifications(string email, List<string> conid)//עבור רשימה של חיבורים
        {
            if (multyconidFORnotifications.ContainsKey(email))
            {
                foreach (string con in conid)
                {
                    if (await IsThisSpesificConTO_Email_ExistIn_multyconidFORnotifications(email, con))
                    {
                        return true;
                    }
                }

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
                        foreach (string con in entry.Value)
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

    }
}
