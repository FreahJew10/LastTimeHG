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
        public Event(string eventname, DateTime date, int teacherid,string kindofevent,int randomuniqcode)
        {
            
            this.date = date;
            this.teacherid = teacherid;
            this.kinofevent = kindofevent;
            this.randomuniqcode = randomuniqcode;
        }
      
        public Event(string eventname, DateTime date, string kindofevent)
        {
            this.eventname = eventname;
            this.date = date;
            this.teacherid = 0;
            this.kinofevent = kindofevent;
        }
        public Event(string eventname, string kindofevent)
        {
            DateTime date = DateTime.Now;
            this.eventname = eventname;
            this.date = date;
            this.teacherid = 0;
            this.kinofevent= kindofevent;
        }
        public Event(string eventname, int teacherid)
        {
            DateTime date = DateTime.Now;
            this.eventname = eventname;
            this.date = date;
            this.teacherid = teacherid;

        }
       

        public string eventname { get; set; }
        public DateTime date { get; set; }
        public int teacherid { get; set; }
        public string kinofevent { get; set; }
        public int randomuniqcode {  get; set; }


    }
}
