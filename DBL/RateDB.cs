using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class RateDB : BaseDB<Rate>
    {
//        public async Task<double> GetRate(int teacherid)
//        {
//            string q = $@"SELECT 
//    teacherid,
//    AVG(rate) AS average_rating
//FROM 
//    mylastyear.rate
//WHERE 
//    teacherid = @teacherid
//GROUP BY 
//    teacherid;";
//            Dictionary<string, object> dic = new Dictionary<string, object>();
//            dic.Add("teacherid", teacherid);
           


//        }

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
