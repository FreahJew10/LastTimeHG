using Models;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class Sub_to_teacherDB : BaseDB<Sub_to_teacher>
    {
        public async Task<bool> DellsubtoT(int teacherid, int subjectid)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("teacherid", teacherid);
            dict.Add("subjectId", subjectid);

            return await base.DeleteAsync(dict) > 0; 
            
        }
        public async Task<bool> Insertsubtoteacher(Sub_to_teacher sub)
        {

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("teacherid", sub.teacherid);
            data.Add("subjectid", sub.subjectid);
            int num = await base.InsertAsync(data);
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        //private async Task<bool> Updatsubtoteacher(Sub_to_teacher s)
        //{
        //    Dictionary<string, object> fillValues = new Dictionary<string, object>();

        //    fillValues.Add("subjectid", s.subjectid);

        //    Dictionary<string, object> filterValues = new Dictionary<string, object>();
        //    filterValues.Add("teacherid", s.teacherid);
            
        //    int num = await base.UpdateAsync(fillValues, filterValues);
        //    return (num > 0);

        //}
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
            List<string> list = new List<string>() { "teacherid", "subjectid" };
            return list;
        }

        protected override string GetTableName()
        {
            return "sub_to_teachers";
        }
    }
}
