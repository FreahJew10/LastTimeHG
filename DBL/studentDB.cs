using Models;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class studentDB : BaseDB<student>
    {

        public async Task<student> LoginAsync(string first_name, string email, string password)
        {
            string sql = @"SELECT * FROM mylastyear.student where first_name=@first_name AND email=@email AND password=@password;";
            Dictionary<string, object> chackit = new Dictionary<string, object>();
            chackit.Add("first_name", first_name);
            chackit.Add("email", email);
            chackit.Add("password", password);
            List<student> students = await SelectAllAsync(sql, chackit);
            if (students.Count == 1)
            {
                return students[0];

            }
            return null;
        }

        public async Task<bool> updateAsync(student student)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            fillValues.Add("first_name", student.first_name);
            fillValues.Add("password", student.password);

            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            filterValues.Add("studentid", student.Id);

            int num = await base.UpdateAsync(fillValues, filterValues);
            return (num > 0);
        }
        public async Task<bool> deletestudent(student student)
        {
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            filterValues.Add("Id", student.Id);

            int num = await base.DeleteAsync(filterValues);
            return (num > 0);

        }

        public async Task<bool> insertstudent(student student)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("first_name", student.first_name);
            data.Add("last_name", student.last_name);
            data.Add("email", student.email);
            data.Add("password", student.password);

            int num = await base.InsertAsync(data);
            if (num > 0)
            {
                return true;
            }
            else { return false; }

        }
        protected override async Task<List<student>> CreateListModelAsync(List<object[]> rows)
        {
            List<student> students = new List<student>();
            foreach (object[] row in rows)
            {
                student student = await CreateModelAsync(row);
                students.Add(student);

            }
            return students;
        }

        protected override async Task<student> CreateModelAsync(object[] row)
        {
            student student = new student();
            string chack_if_friend = "";
            int x = 0;
           try
            {
                x= int.Parse(row[0].ToString());
                chack_if_friend = "josh";
            }
            catch 
            {
                chack_if_friend = "17";
            
            }
            if (chack_if_friend=="josh")
            {
                student.Id = int.Parse(row[0].ToString());
                student.first_name = row[1].ToString();
                student.last_name = row[2].ToString();
                student.email = row[3].ToString();
                student.password = row[4].ToString();

                string query = @"Select
            mylastyear.student.first_name,
            mylastyear.student.last_name,
            mylastyear.student.email
            From
            mylastyear.student Inner Join
            mylastyear.friends On mylastyear.friends.studentfriendId = mylastyear.student.studentid
            where mylastyear.friends.studentid=@studentid";
                Dictionary<string, object> myprimerykey = new Dictionary<string, object>();
                myprimerykey.Add("studentid", student.Id);
                student.friends = await SelectAllAsync(query, myprimerykey);
                await Console.Out.WriteLineAsync("dd");
            } 
            else {
                student.first_name = row[1].ToString();
                student.last_name = row[2].ToString();
                student.email = row[3].ToString();
            }
            return student;
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
