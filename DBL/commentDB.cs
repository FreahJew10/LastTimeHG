using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{

    public class commentDB : BaseDB<comment>
    {
        protected override async Task<List<comment>> CreateListModelAsync(List<object[]> rows)
        {
            List<comment>comments = new List<comment>();
            foreach (object[] row in rows)
            {
                comment comment = await CreateModelAsync(row);
                comments.Add(comment);

            }
            return comments;
        }

        protected override async Task<comment> CreateModelAsync(object[] row)
        {
            comment comment = new comment();
            comment.id_of_comment = int.Parse(row[0].ToString());
            comment.thecomment = row[1].ToString();
            

            return comment;
        }

        protected override List<string>  GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "id_of_comment" };

            return list ;
        }

        protected override string GetTableName()
        {
           return "comments";
        }
    }
}
