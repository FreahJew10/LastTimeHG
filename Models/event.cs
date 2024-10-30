using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class @event
    {
        public @event()
        { }
        public @event(string eventname, DateTime date, int teacherid)
        {
            this.eventname = eventname;
            this.date = date;
            this.teacherid = teacherid;

        }
        public @event(string eventname, int teacherid)
        {
            DateTime date = DateTime.Now;
            this.eventname = eventname;
            this.date = date;
            this.teacherid = teacherid;

        }
        public int eventid { get; set; }
        public string eventname { get; set; }
        public DateTime date { get; set; }
        public int teacherid { get; set; }


    }
}
