using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DBL
{
    public class teacherDB : BaseDB<teacher>
    {
        public async Task<List<teacher>> GetTeacherByPrimeryKey(int  primeryKey)
        {
            string q = $@"";
        }
        public async Task<List<teacher>> GetAllPrivateTeachersForThisSubjectId(int subjectId)
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
            List<teacher> lst = await SelectAllAsync(q, properties);

            if (lst.Count > 0 )
                return lst;

            return null;
            
        }
        public async Task<bool> updateAsync(teacher teacher)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            fillValues.Add("first_name", teacher.first_name);
            fillValues.Add("password", teacher.password);

            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            filterValues.Add("studentid", teacher.Id);

            int num = await base.UpdateAsync(fillValues, filterValues);
            return (num > 0);
        }
        public async Task<teacher> LoginAsync( string email, string password)
        {
            string sql = @"SELECT * FROM mylastyear.teachers where email=@email AND password=@password;";
            Dictionary<string, object> chackit = new Dictionary<string, object>();
            
            chackit.Add("email", email);
            chackit.Add("password", password);
            List<teacher> teachers = await SelectAllAsync(sql, chackit);
            if (teachers.Count == 1)
            {
                return teachers[0];

            }
            return null;
        }
        public teacherDB() { }
        public async Task<bool> inserteacher(teacher teacher)
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

        protected override async Task<List<teacher>> CreateListModelAsync(List<object[]> rows)
        {
            List<teacher> teachers = new List<teacher>();
            foreach (object[] row in rows)
            {
                teacher teacher = await CreateModelAsync(row);
                teachers.Add(teacher);

            }
            return teachers;
        }

        protected override async Task<teacher> CreateModelAsync(object[] row)
        {
            if (row.Length == 8)//בגלל הסיסמה שאני לא מכניס
            {
                teacher teacher = new teacher();
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
                teacher teacher = new teacher();
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
