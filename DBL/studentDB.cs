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
    public class studentDB : BaseDB<Student>
    {
       
        public async Task<Student>GetSudentByEmail(string email)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("email", email);
            List<Student>d = await base.SelectAllAsync( dic);
            return d[0];

        }
        public async Task<Dictionary<int,string>> GetTheNameOfEveryStudentInEvent(int randomuinqcod)
        {
            Dictionary<int,string>dic = new Dictionary<int,string>();
            List<Student> students = await GetAllStudentForEvent(randomuinqcod);
            if (students.Count > 0)
            {
                foreach (Student student in students)
                {
                    dic.Add(student.Id, student.first_name + " " + student.last_name);

                }

            }
            return dic;
        }
        public async Task<List<Student>>GetAllStudentForEvent(int randomuniqcode)
        {
            List<Student> students = new List<Student>();
            string sql = @"Select
    mylastyear.student.studentid,
    mylastyear.student.first_name,
    mylastyear.student.last_name,
    mylastyear.student.email
From
    mylastyear.student Inner Join
    mylastyear.studentinevent On mylastyear.studentinevent.studentid = mylastyear.student.studentid Inner Join
    mylastyear.event On mylastyear.studentinevent.randomuniqcode = mylastyear.event.randomuniqcode
    where mylastyear.studentinevent.randomuniqcode=@randomuniqcode";

            Dictionary< string,object >dic= new Dictionary< string,object >();
            dic.Add("randomuniqcode", randomuniqcode);
            students=await base.SelectAllAsync(sql,dic);
            return  students;
        }
        public async Task<Student> LoginAsync( string email, string password)
        {
            string sql = @"SELECT * FROM mylastyear.student where email=@email AND password=@password;";
            Dictionary<string, object> chackit = new Dictionary<string, object>();
            
            chackit.Add("email", email);
            chackit.Add("password", password);
            List<Student> students = await SelectAllAsync(sql, chackit);
            if (students.Count == 1)
            {
                return students[0];

            }
            return null;
        }

        public async Task<bool> updateAsync(Person student)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            fillValues.Add("first_name", student.first_name);
            fillValues.Add("password", student.password);

            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            filterValues.Add("studentid", student.Id);

            int num = await base.UpdateAsync(fillValues, filterValues);
            return (num > 0);
        }
        public async Task<bool> deletestudent(Student student)
        {
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            filterValues.Add("Id", student.Id);

            int num = await base.DeleteAsync(filterValues);
            return (num > 0);

        }

        public async Task<bool> insertstudent(Person student)
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
        protected override async Task<List<Student>> CreateListModelAsync(List<object[]> rows)
        {
            List<Student> students = new List<Student>();
            foreach (object[] row in rows)
            {
                Student student = await CreateModelAsync(row);
                students.Add(student);

            }
            return students;
        }

        protected override async Task<Student> CreateModelAsync(object[] row)
        {
            Student student = new Student();
         
             PersonStudentDB personStudentDB = new PersonStudentDB();
            if (row.Length == 5)
            {
                student.Id = int.Parse(row[0].ToString());
                student.first_name = row[1].ToString();
                student.last_name = row[2].ToString();
                student.email = row[3].ToString();
                student.password = row[4].ToString();
                student.friends = await personStudentDB.GiveAllFriends(student.Id);
            }
            else {
                student.Id = int.Parse(row[0].ToString());
                student.first_name = row[1].ToString();
                student.last_name = row[2].ToString();
                student.email = row[3].ToString();
                student.friends = await personStudentDB.GiveAllFriends(student.Id);
            }
           /* string query = @"Select
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
            await Console.Out.WriteLineAsync("dd");*/

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
