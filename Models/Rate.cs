using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rate
    {
        public Rate()
        {
        }

        public Rate(int rate, int teacherid, int studentid)
        {
            this.rate = rate;
            this.teacherid = teacherid;
            this.studentid = studentid;
        }

        public int rate { get; set; }
        public int teacherid { get; set; }
        public int studentid { get; set; }

    }
}
