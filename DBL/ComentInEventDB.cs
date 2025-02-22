using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DBL
{
    public class CommentInEventDB : BaseDB<CommentInEvent>
    {
        public async Task<bool> InsertCommentInEvent(CommentInEvent commentInEvent)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("randomuniqcode", commentInEvent.randomuniqcode);
            data.Add("id_of_comment", commentInEvent.id_of_comment);
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
        protected override async Task<List<CommentInEvent>> CreateListModelAsync(List<object[]> rows)
        {
            List<CommentInEvent> list = new List<CommentInEvent>();
            foreach (object[] row in rows)
            {
                CommentInEvent commentInEvent = await CreateModelAsync(row);
                list.Add(commentInEvent);

            }
            return list;
        }

        protected override async Task<CommentInEvent> CreateModelAsync(object[] row)
        {
            CommentInEvent commentInEvent =new CommentInEvent();
            commentInEvent.randomuniqcode=int.Parse(row[0].ToString());
            commentInEvent.id_of_comment = int.Parse(row[1].ToString());
            return commentInEvent;
        }

        protected override List<string> GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "randomuniqcode","id_of_comment" };

            return list;
        }

        protected override string GetTableName()
        {
            return "commentinevent";
        }
    }
}
