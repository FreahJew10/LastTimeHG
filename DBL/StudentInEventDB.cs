using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Models;
namespace DBL
{
    public class StudentInEventDB : BaseDB<StudentInEvent>
    {
        public async Task<List<StudentInEvent>> GetAllStudentsInEventForListOfEvents(List<Event> lst)
        {
            List<StudentInEvent> lstd = new List<StudentInEvent>();
            List<StudentInEvent> lstd2 = new List<StudentInEvent>();
           List <StudentInEvent>finellst= new List<StudentInEvent>();
            for (int i = 0; i < lst.Count - 1; i++)
            {
                lstd = await GetAllStudentInEvent_ForSpesificEvent(lst[i].randomuniqcode);
                lstd2 = await GetAllStudentInEvent_ForSpesificEvent(lst[i+1].randomuniqcode);
                lstd.Concat(lstd2).ToList();
                
                finellst.Concat(lstd).ToList();
            }
            return finellst;
        }

        public async Task<List<StudentInEvent> >GetAllStudentInEvent_ForSpesificEvent(int randomcode)
        { 
            Dictionary<string,object> data = new Dictionary<string,object>();
            data.Add("randomuniqcode",randomcode);
            return await SelectAllAsync(data);

        }
        public async Task insertStedentInEvent(List<StudentInEvent> studentInEvents)
        {
            foreach (StudentInEvent studentInEvent in studentInEvents)
            {
                await insertStedentInEvent(studentInEvent);

            }
        }

        public async Task<bool> insertStedentInEvent(StudentInEvent studentInEvent)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("studentid", studentInEvent.studentid);
            data.Add("randomuniqcode", studentInEvent.randomuniqcode);
            

            int num = await base.InsertAsync(data);
            if (num > 0)
            {
                return true;
            }
            else { return false; }
        }
        protected override async Task<List<StudentInEvent>> CreateListModelAsync(List<object[]> rows)
        {
            List<StudentInEvent> studentsInevent = new List<StudentInEvent>();
            foreach (object[] row in rows)
            {
                StudentInEvent studentinevent = await CreateModelAsync(row);
                studentsInevent.Add(studentinevent);

            }
            return studentsInevent;
        }

        protected override async Task<StudentInEvent> CreateModelAsync(object[] row)
        {
            StudentInEvent studentInEvent=new StudentInEvent();
            studentInEvent.studentid = int.Parse(row[1].ToString());
            studentInEvent.randomuniqcode = int.Parse(row[0].ToString());
            return studentInEvent;
        }

        protected override List<string> GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "studenid", "eventid"};
            return list;
        }

        protected override string GetTableName()
        {
            return "studentinevent";
        }
    }
}
