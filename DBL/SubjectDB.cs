using Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class SubjectDB : BaseDB<Subject>
    {
        public async Task<bool> InsertSubject(string subjectname)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("subjectName", subjectname);
            int num = await base.InsertAsync(data);
            if (num > 0)
            {
                return true;
            }
            else { return false; }

        }
        public async Task<List<Subject>> SelectAllSubjects()
        {
            return await base.SelectAllAsync();
        }
        public async Task<List<Subject>>SelectAllSubjectForTeacher(int id)
        {
            string q = $@"Select
mylastyear.subject.subjectName,
    mylastyear.subject.subjectId
   
From
    mylastyear.subject Inner Join
    mylastyear.sub_to_teachers On mylastyear.sub_to_teachers.subjectId = mylastyear.subject.subjectId Inner Join
    mylastyear.teachers On mylastyear.sub_to_teachers.teacherid = mylastyear.teachers.teacherid
Where
    mylastyear.teachers.teacherid = @teacherid";
     Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("teacherid", id);
            List<Subject> list = await SelectAllAsync(q, p);
            if (list.Count > 0)
                return list;
            else
                return null;


        }

        protected override async Task<List<Subject>> CreateListModelAsync(List<object[]> rows)
        {
            List<Subject> list = new List<Subject>();
            foreach (object[] row in rows)
            {
                Subject subject = await CreateModelAsync(row);
                list.Add(subject);
            }
            return list;

        }


        protected override async Task<Subject> CreateModelAsync(object[] row)
        {
            Subject subject = new Subject();
            subject.subjectName = row[0].ToString();
            subject.subjectid=int.Parse(row[1].ToString());
            return subject;
        }

        protected override List<string> GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "subjectId" };
            return list;
        }

        protected override string GetTableName()
        {
            return "subject";
        }
    }
}
