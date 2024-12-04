using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DBL
{
    public class StudentInEventDB : BaseDB<StudentInEvent>
    {
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
            studentInEvent.studentid = int.Parse(row[0].ToString());
            studentInEvent.eventid = int.Parse(row[1].ToString());
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
