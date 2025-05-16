using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CommentInEvent
    {
        public CommentInEvent()
        {
        }

        //public CommentInEvent(int randomuniqcode)
        //{
        //    this.randomuniqcode = randomuniqcode;
            
        //}

        public CommentInEvent(int randomuniqcode, int id_of_comment)
        {
            this.randomuniqcode = randomuniqcode;
            this.id_of_comment = id_of_comment;
        }

        public int randomuniqcode {  get; set; }
        public int id_of_comment {  get; set; }
    }
}
