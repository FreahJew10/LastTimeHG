using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class Sub_to_teacherDB : BaseDB<Sub_to_teacher>
    {
        protected override async Task<List<Sub_to_teacher>> CreateListModelAsync(List<object[]> rows)
        {
           List<Sub_to_teacher>list=new List<Sub_to_teacher>();
            foreach (object[] row in rows)
            {
                Sub_to_teacher sub= await CreateModelAsync(row);
                list.Add(sub);
            }
            return list;
        }

        protected async override  Task<Sub_to_teacher> CreateModelAsync(object[] row)
        {
            Sub_to_teacher s =new Sub_to_teacher();
            s.teacherid = int.Parse(row[0].ToString());
            s.subjectid=int.Parse(row[1].ToString());
            return s;

        }

        protected override List<string> GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "teacherid", "subjactid" };
            return list;
        }

        protected override string GetTableName()
        {
            return "sub_to_teechers";
        }
    }
}
