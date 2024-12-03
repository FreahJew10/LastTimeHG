using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class friendsDB : BaseDB<friends>
    {


        public async Task<bool> insertFriends(friends friends)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("studentid", friends.studentid);
            data.Add("studentfriendId", friends.studentfriendId);
           

            int num = await base.InsertAsync(data);
            if (num > 0)
            {
                return true;
            }
            else { return false; }

        }
        public async Task<List<Person>> GiveAll_AreWeBothFriends_(Student me)//מביאה את כל החברים שלי שאני גם חבר שלהם
        {
            List<Person> we_are_both_friends = new List<Person>();
            foreach (Person friend in me.friends)
            {
                Person temp = await GiveMyFriend(me.Id, friend.Id);
                if (temp != null)
                {
                    we_are_both_friends.Add(temp);
                }


            }

            return we_are_both_friends;
        }

        private async Task<Person> GiveMyFriend(int myId, int friendid)//פעולה שמביאה חבר שאני גם חבר שלו
        {
            if (await AreWeBothFriends(myId, friendid) == 1)
            {
                PersonStudentDB studentDB = new PersonStudentDB();
                return await studentDB.SelectByPkAsync(friendid);
            }
            return null;
        }
        public async Task<int> AreWeBothFriends(int mystudentid, int friendid)//בודקת האם שנינו חברים אחד של השני
        {
            if (await DoesRelationshipExist(mystudentid, friendid) && await DoesRelationshipExist(friendid, mystudentid))
            {
                return 1;
            }
            else if(await DoesRelationshipExist(mystudentid, friendid))//רק אני חבר שלו
                { return 2; }
            else if(await DoesRelationshipExist(friendid, mystudentid))//vהוא חבר שלי ואני לא שלו
            {
                return 3;
            }
            return 0;//לא חברים בכלל
        }
        public async Task<bool> DoesRelationshipExist(int mystudentid, int friendid)//האם הוא חבר שלי?
        {
            string sql = @$"Select
            mylastyear.friends.studentid,
            mylastyear.friends.studentfriendId
            From
            mylastyear.friends
            Where
            mylastyear.friends.studentid = @mystudentid And
            mylastyear.friends.studentfriendId = @friendid";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("mystudentid", mystudentid);
            data.Add("friendid", friendid);
            List<friends> friends = await SelectAllAsync(sql, data);
            if (friends.Count == 1)
                return true;
            else
                return false;
        }
        protected override async Task<List<friends>> CreateListModelAsync(List<object[]> rows)
        {
            List<friends> friends = new List<friends>();
            foreach (object[] row in rows)
            {
                friends student = await CreateModelAsync(row);
                friends.Add(student);

            }
            return friends;
        }

        protected override async Task<friends> CreateModelAsync(object[] row)
        {
            friends myfriend = new friends();
            myfriend.studentid = int.Parse(row[0].ToString());
            myfriend.studentfriendId = int.Parse(row[1].ToString());
            return myfriend;
        }

        protected override List<string> GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "studenid", "studentfriendId" };
            return list;
        }

        protected override string GetTableName()
        {
            return "friends";
        }
    }
}
