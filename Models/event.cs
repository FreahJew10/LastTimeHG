using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Event
    {
        public Event()
        { }
        public Event(string eventname, DateTime date, int teacherid,string kindofevent,int randomuniqcode, DateTime enddate)
        {
            
            this.date = date;
            this.teacherid = teacherid;
            this.kinofevent = kindofevent;
            this.randomuniqcode = randomuniqcode;
            this.enddate = enddate;
        }
      
        public Event(string eventname, DateTime date, string kindofevent, DateTime enddate)
        {
            this.eventname = eventname;
            this.date = date;
            this.teacherid = 0;
            this.kinofevent = kindofevent;
            this.enddate = enddate;
        }
        public Event(string eventname, string kindofevent)
        {
            DateTime date = DateTime.Now;
            this.eventname = eventname;
            this.date = date;
            this.teacherid = 0;
            this.kinofevent= kindofevent;
            DateTime enddate = DateTime.Now;
        }
        public Event(string eventname, int teacherid)
        {
            DateTime date = DateTime.Now;
            this.eventname = eventname;
            this.date = date;
            this.teacherid = teacherid;
            DateTime enddate=DateTime.Now;
        }
       

        public string eventname { get; set; }
        public DateTime date { get; set; }
        public int teacherid { get; set; }
        public string kinofevent { get; set; }
        public int randomuniqcode {  get; set; }
        public DateTime enddate { get; set; }

    }
}
