using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Models;
namespace DBL
{
    public class teacherDB : BaseDB<Teacher>
    {
        public async Task<Teacher>GetTeacherByemail(string email)
        {
            string q = $@"Select
    teachers.teacherid,
    teachers.first_name,
    teachers.last_name,
    teachers.email,
    teachers.bio,
    teachers.hourly_rate,
    teachers.isprivate
From
    teachers
Where
    teachers.email = @email";
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("email", email);
            List<Teacher> d = await base.SelectAllAsync(q,dic);
            return d[0];
        }
        public async Task<List<Teacher>> GetAllPublicTeachers()
        {

            Dictionary<string,object> data = new Dictionary<string,object>();
            data.Add("isprivate", 0);
            return await SelectAllAsync(data);
        }

        public async Task<Teacher>GetTeacherByEvent(int randomuniqcode)
        {
            string q = @$"Select
    mylastyear.teachers.teacherid,
    mylastyear.teachers.first_name,
    mylastyear.teachers.last_name,
    mylastyear.teachers.email,
    mylastyear.teachers.bio,
    mylastyear.teachers.hourly_rate,
    mylastyear.teachers.isprivate
From
    mylastyear.teachers Inner Join
    mylastyear.event On mylastyear.event.teacherid = mylastyear.teachers.teacherid
    where mylastyear.event.randomuniqcode=@randomuniqcode";

            Dictionary<string,object> data = new Dictionary<string,object>();
            data.Add("randomuniqcode", randomuniqcode);
            List<Teacher>lst = await base.SelectAllAsync(q,data);
            if (lst.Count > 0)
            { return lst[0]; }
            return null;

        }
        public async Task<Teacher> GetTeacherByPrimeryKey(int  primeryKey)
        {
            string q = $@"Select
    mylastyear.teachers.teacherid,
    mylastyear.teachers.first_name,
    mylastyear.teachers.last_name,
    mylastyear.teachers.email,
    mylastyear.teachers.bio,
    mylastyear.teachers.hourly_rate,
    mylastyear.teachers.isprivate
From
    mylastyear.teachers
Where
    mylastyear.teachers.teacherid = @teacherid";

            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("teacherid", primeryKey);
            List<Teacher> list = await SelectAllAsync(q, p);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
        public async Task<List<Teacher>> GetAllPrivateTeachersForThisSubjectId(int subjectId,int hourly_rate)
        {
            string q = $@"Select
teachers1.teacherid,
    teachers1.first_name,
    teachers1.last_name,
    teachers1.email,
    teachers1.bio,
    teachers1.hourly_rate,
    teachers1.isprivate
From
    mylastyear.sub_to_teachers Inner Join
    mylastyear.teachers teachers1 On mylastyear.sub_to_teachers.teacherid = teachers1.teacherid Inner Join
    mylastyear.subject On mylastyear.sub_to_teachers.subjectId = mylastyear.subject.subjectId
Where
    (teachers1.isprivate = 1 or teachers1.isprivate = 3 )and mylastyear.subject.subjectId=@id and teachers1.hourly_rate<= @hourly_rate";
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("id", subjectId);
            properties.Add("hourly_rate", hourly_rate);
            List<Teacher> lst = await SelectAllAsync(q, properties);

            if (lst.Count > 0)
                return lst;

            return null;

        }
        public async Task<List<Teacher>> GetAllPrivateTeachersForThisSubjectId(int subjectId)
        {
            string q = $@"Select
teachers1.teacherid,
    teachers1.first_name,
    teachers1.last_name,
    teachers1.email,
    teachers1.bio,
    teachers1.hourly_rate,
    teachers1.isprivate
From
    mylastyear.sub_to_teachers Inner Join
    mylastyear.teachers teachers1 On mylastyear.sub_to_teachers.teacherid = teachers1.teacherid Inner Join
    mylastyear.subject On mylastyear.sub_to_teachers.subjectId = mylastyear.subject.subjectId
Where
    teachers1.isprivate = 1 and mylastyear.subject.subjectId=@id";
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("id", subjectId);
            List<Teacher> lst = await SelectAllAsync(q, properties);

            if (lst.Count > 0 )
                return lst;

            return null;
            
        }
        public async Task<bool> updateAsyncbio(Teacher teacher)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            fillValues.Add("bio", teacher.bio);
           

            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            filterValues.Add("teacherid", teacher.Id);

            int num = await base.UpdateAsync(fillValues, filterValues);
            return (num > 0);
        }
        public async Task<bool> updateAsync(Teacher teacher)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            fillValues.Add("first_name", teacher.first_name);
            fillValues.Add("password", teacher.password);

            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            filterValues.Add("teacherid", teacher.Id);

            int num = await base.UpdateAsync(fillValues, filterValues);
            return (num > 0);
        }
        public async Task<Teacher> LoginAsync( string email, string password)
        {
            string sql = @"SELECT * FROM mylastyear.teachers where email=@email AND password=@password;";
            Dictionary<string, object> chackit = new Dictionary<string, object>();
            
            chackit.Add("email", email);
            chackit.Add("password", password);
            List<Teacher> teachers = await SelectAllAsync(sql, chackit);
            if (teachers.Count == 1)
            {
                return teachers[0];

            }
            return null;
        }
        public teacherDB() { }
        public async Task<bool> inserteacher(Teacher teacher)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("first_name", teacher.first_name);
            data.Add("last_name", teacher.last_name);
            data.Add("email", teacher.email);
            data.Add("password", teacher.password);
            data.Add("bio", teacher.bio);
            data.Add("hourly_rate", teacher.hourly_rate);
            data.Add("isprivate", teacher.isprivate);
            int num = await base.InsertAsync(data);
            if (num > 0)
            {
                return true;
            }
            else { return false; }

        }

        protected override async Task<List<Teacher>> CreateListModelAsync(List<object[]> rows)
        {
            List<Teacher> teachers = new List<Teacher>();
            foreach (object[] row in rows)
            {
                Teacher teacher = await CreateModelAsync(row);
                teachers.Add(teacher);

            }
            return teachers;
        }

        protected override async Task<Teacher> CreateModelAsync(object[] row)
        {
            if (row.Length == 8)//בגלל הסיסמה שאני לא מכניס
            {
                Teacher teacher = new Teacher();
                teacher.Id = int.Parse(row[0].ToString());
                teacher.first_name = row[1].ToString();
                teacher.last_name = row[2].ToString();
                teacher.email = row[3].ToString();
                teacher.password = row[4].ToString();
                teacher.bio = row[5].ToString();
                teacher.hourly_rate = int.Parse(row[6].ToString());
                if (row[7] == null)
                {
                    teacher.isprivate = 1;
                }
                else
                {
                    teacher.isprivate = int.Parse(row[7].ToString());
                }
                return teacher;
            }
            else
            {
                Teacher teacher = new Teacher();
                teacher.Id = int.Parse(row[0].ToString());
                teacher.first_name = row[1].ToString();
                teacher.last_name = row[2].ToString();
                teacher.email = row[3].ToString();
                
                teacher.bio = row[4].ToString();
                teacher.hourly_rate = int.Parse(row[5].ToString());
                if (row[6] == null)
                {
                    teacher.isprivate = 1;
                }
                else
                {
                    teacher.isprivate = int.Parse(row[6].ToString());
                }
                return teacher;
            }
        }

        protected override List<string> GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "teacherid" };
            return list;
            
        }

        protected override string GetTableName()
        {
            return "teachers";
        }
    }
}
