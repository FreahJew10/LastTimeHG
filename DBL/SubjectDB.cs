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
        public async Task<List<Subject>> SelectAllSubjects()
        {
            return await base.SelectAllAsync();
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
