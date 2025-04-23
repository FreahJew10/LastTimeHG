using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class doubleDBforRate:BaseDB<DoubleRate>
    {

        public async Task<DoubleRate> GetRate(int teacherid)
        {
            string q = $@"SELECT 
    AVG(rate) AS average_rating
FROM 
    mylastyear.rate
WHERE 
   teacherid = @teacherid
GROUP BY 
    teacherid;";
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("teacherid", teacherid);
            List<DoubleRate> list =await SelectAllAsync(q,dic);
            if (list.Count>0)
            {
                return list[0];
            }
            return null;


        }
        protected override async Task<List<DoubleRate>> CreateListModelAsync(List<object[]> rows)
        {
            List<DoubleRate> list = new List<DoubleRate>();
            foreach (object[] row in rows)
            {
                DoubleRate rate = await CreateModelAsync(row);
                list.Add(rate);


            }
            return list;
        }

        protected async override Task<DoubleRate> CreateModelAsync(object[] row)
        {
            DoubleRate rate = new DoubleRate();
           rate.Rate=double.Parse(row[0].ToString());
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
