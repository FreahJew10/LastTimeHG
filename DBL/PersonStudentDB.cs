using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class PersonStudentDB : BaseDB<Person>
    {
        public async Task<List<Person>> GiveAllFriends(int studentid)
        {
            string q = @$"Select
             student.first_name,
             student.last_name,
             student.email,
             student1.studentid,
             student.studentid As studentid1
             From
             student Inner Join
             friends On friends.studentfriendId = student.studentid Inner Join
             student student1 On friends.studentid = student1.studentid
             Where
             student1.studentid = @studentid";

            Dictionary<string,object> dic = new Dictionary<string,object>();
            dic.Add("studentid", studentid);
            List<Person> list =await SelectAllAsync(q, dic);
            return list;

        }
        protected override async Task<List<Person>> CreateListModelAsync(List<object[]> rows)
        {
            List<Person> friends = new List<Person>();
            foreach (object[] row in rows)
            {
                Person friend = await CreateModelAsync(row);
                friends.Add(friend);

            }
            return friends;
        }

        protected override async Task<Person> CreateModelAsync(object[] row)
        {
            Person student_friends=new Person();
            
            student_friends.first_name = row[0].ToString();
            student_friends.last_name = row[1].ToString();
            student_friends.email = row[2].ToString();
            student_friends.Id = int.Parse(row[4].ToString());
            return student_friends;
        }

        protected override List<string> GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "studenid" };
            return list;
        }

        protected override string GetTableName()
        {
            return "student";

        }
    }
}
