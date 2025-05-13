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
        public async Task<List<comment>> GetAllCommentsForEvent(int randomuniqcode)
        {
            string q = $@"Select
    mylastyear.comments.id_of_comment,
    mylastyear.comments.thecomment,
    mylastyear.comments.student_senderID,
    mylastyear.comments.teacher_senderID,
    mylastyear.comments.timeofcomment
From
    mylastyear.comments Inner Join
    mylastyear.commentinevent On mylastyear.commentinevent.id_of_comment = mylastyear.comments.id_of_comment Inner Join
    mylastyear.event On mylastyear.commentinevent.randomuniqcode = mylastyear.event.randomuniqcode
    where mylastyear.event.randomuniqcode=@randomuniqcode";
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("randomuniqcode", randomuniqcode);
            List<comment> comments = new List<comment>();
            return await SelectAllAsync(q, properties);
        }

        public async Task<bool> InsertComment(comment comment)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("id_of_comment", comment.id_of_comment);
            data.Add("thecomment", comment.thecomment);
            data.Add("timeofcomment", comment.timeopcomment);
            if (comment.student_senderID != 0)
            {
                data.Add("student_senderID", comment.student_senderID);
            }
            else { data.Add("teacher_senderID", comment.teacher_senderID); }
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
        protected override async Task<List<comment>> CreateListModelAsync(List<object[]> rows)
        {
            List<comment> comments = new List<comment>();
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
            if (row[2] != null)
            {
                comment.student_senderID = int.Parse(row[2].ToString());
                comment.teacher_senderID = 0;
            }
            else
            {
                comment.teacher_senderID = int.Parse(row[3].ToString());
                comment.student_senderID = 0;
            }
           
            comment.timeopcomment = DateTime.Parse(row[4].ToString());
            return comment;
        }

        protected override List<string> GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "id_of_comment" };

            return list;
        }

        protected override string GetTableName()
        {
            return "comments";
        }
    }
}
