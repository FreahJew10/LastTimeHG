using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class friendsDB : BaseDB<friends>
    {
        protected override Task<List<friends>> CreateListModelAsync(List<object[]> rows)
        {
            throw new NotImplementedException();
        }

        protected override Task<friends> CreateModelAsync(object[] row)
        {
            throw new NotImplementedException();
        }

        protected override List<string> GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "studenid", "studentfriendId" };
            return list ;
        }

        protected override string GetTableName()
        {
            return "friends";
        }
    }
}
