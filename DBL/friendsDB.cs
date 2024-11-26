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

            
            }

            return we_are_both_friends;
        }

        private async Task<Person> GiveMyFriend(int myId,int friendid)//פעולה שמביאה חבר שאני גם חבר שלו
        {
            if(await AreWeBothFriends(myId,friendid)==1)
            {
                PersonStudentDB studentDB = new PersonStudentDB();
                return await studentDB.SelectByPkAsync(friendid);
            }
            return null;
        }
        private async Task<int> AreWeBothFriends(int mystudentid,int friendid)//בודקת האם שנינו חברים אחד של השני
        {
            if(await DoesRelationshipExist(mystudentid, friendid)&& await DoesRelationshipExist(friendid,mystudentid))
            {
                return 1;
            }
            return 0;
        }
        private async Task<bool> DoesRelationshipExist(int mystudentid, int friendid)
        {
            string sql = @$"Select
            mylastyear.friends.studentid,
            mylastyear.friends.studentfriendId
            From
            mylastyear.friends
            Where
            mylastyear.friends.studentid = @mystudentid And
            mylastyear.friends.studentfriendId = @friendid";
            Dictionary<string,object> data = new Dictionary<string,object>();
            List<friends> friends = await SelectAllAsync(sql, data);
            if (friends.Count == 1)
                return  true;
            else
                return false;
        }
        protected  override async Task<List<friends>> CreateListModelAsync(List<object[]> rows)
        {
            List<friends> friends = new List<friends>();
            foreach (object[] row in rows)
        {
                friends student = await CreateModelAsync(row);
                friends.Add(student);

            }
            return friends;
        }

        protected async override Task<friends> CreateModelAsync(object[] row)
        {
            friends myfriend = new friends();
            myfriend.studentid = int.Parse(row[0].ToString());
            myfriend.studentfriendId = int.Parse(row[1].ToString());
            return myfriend;
        }

        protected override List<string> GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "studenid", "studentfriendId" };
            return list ;
        }

        protected override string GetTableName()
        {
            return "friends";
        }
    }
}
