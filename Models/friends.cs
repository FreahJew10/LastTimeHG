using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class friends
    {
        public friends() { }
        public friends(int studentid,int studentfriendId)
        { 
        this.studentid = studentid;
            this.studentfriendId=studentfriendId;
        
        }

        public int studentid {  get; set; }
        public int studentfriendId { get; set; }

    }
}
