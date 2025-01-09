using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Sub_to_teacher
    {
        public Sub_to_teacher(int teacherid,int subjectid)
        {
            this .teacherid = teacherid;    
            this .subjectid = subjectid;
        }
        public Sub_to_teacher() { }
        public int teacherid { get; set; }
        public int subjectid { get; set; }
    }
}
