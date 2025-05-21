using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class comment
    {
        public comment() { }
        

        public int id_of_comment { get; set; }
        public string thecomment{ get; set; }
        public int student_senderID {  get; set; }
        public int teacher_senderID { get; set; }
        public DateTime timeopcomment { get; set; }

    }
}
