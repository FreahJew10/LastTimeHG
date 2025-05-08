using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModelForAPIIDEndStartDate
    {
        public ModelForAPIIDEndStartDate()
        {
        }

        public ModelForAPIIDEndStartDate(int studentid, DateTime startdate, DateTime enddate)
        {
            this.studentid = studentid;
            this.startdate = startdate;
            this.enddate = enddate;
        }

        public int studentid {  get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
    }
}
