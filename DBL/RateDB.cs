using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DBL
{
    public class RateDB : BaseDB<Rate>
    {
        public async Task<bool>SubmitRate(Rate rate)
        {
            if (await IsMyRateExist(rate.studentid, rate.teacherid))
            {
              bool b=  await UpdateRate(rate);
                if(b)
                return true;
            }
            else
            {
               Dictionary<string,object> dict = new Dictionary<string,object>();
                dict.Add("rate", rate.rate);
                dict.Add("teacherid", rate.teacherid);
                dict.Add("studentid", rate.studentid);
                int num = await base.InsertAsync(dict);
                if (num > 0)
                {
                    return true;
                }
               
            }
            return false;



        }
        private async Task<bool>UpdateRate(Rate rate)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            
            fillValues.Add("rate", rate.rate);

            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            filterValues.Add("teacherid", rate.teacherid);
            filterValues.Add("studentid", rate.teacherid);
            int num = await base.UpdateAsync(fillValues, filterValues);
            return (num > 0);

        }

        public async Task<Rate> GetMyRate(int studentid,int teacherid)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("studentid", studentid);
            data.Add("teacherid", teacherid);
            List < Rate >my=await SelectAllAsync(data);
            if(my.Count>0)
            return my[0];

            return null;
        }
        private async Task<bool>IsMyRateExist(int studentid,int teacherid)
        {
            List<Rate> rateList =await SelectAllAsync();
            foreach (Rate rate in rateList)
            {
                if (rate.studentid == studentid && rate.teacherid == teacherid)
                {
                    return true;

                }
                }
                return false;

        }
        protected  override async Task<List<Rate>> CreateListModelAsync(List<object[]> rows)
        {
           List<Rate> list = new List<Rate>();
            foreach (object[] row in rows)
            {
                Rate rate =await CreateModelAsync(row);
                list.Add(rate);


            }
            return list;
        }

        protected async override Task<Rate> CreateModelAsync(object[] row)
        {
            Rate rate =new Rate();
            rate.rate = int.Parse(row[0].ToString());
            rate.teacherid=int.Parse(row[1].ToString());
            rate.studentid=int.Parse(row[2].ToString());
            return rate;
        }

        protected override List<string> GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "teacherid", "studentid" };
            return list;
        }

        protected override string GetTableName()
        {
            return "rate";
        }
    }
}
