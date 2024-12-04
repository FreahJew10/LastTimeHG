using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentInEvent
    {
        public StudentInEvent() { }
        public StudentInEvent(int studentid, int eventid)
        {
            this.studentid = studentid;
            this.eventid = eventid;
        }
    
        public int studentid { get; set; }
        public int eventid { get; set; }

    }
}
