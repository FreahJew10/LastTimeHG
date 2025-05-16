using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Event//
        
    {
        public Event()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventname"></param>חשוב לציין התכונה שם האיוונט נוצרה מתוך מחשבה לא נכונה,יותר נכון לקרוא לה תוכן האיוונט במקרים מסויימים 
        /// במקרים כמו למשל (ובעיקר) בהתראות זהו אינו השם (אלא התוכן שם גם מועבר למשל בקביעת שיעור פרטי זמן השיעור בנוסף גם הערות מוספות לתוך השם)כמובן ניתן להעביר גם את השם רך במקרה כזה ישנו סדר שבו הדבר יופיע
        /// בנוסף במקרים בהם השם הוא התראות ככל הנראה ברוב המקרים השם שיוצג למשתמש בפועל הוא הערך סוג האיוונט של העצם ולא השם בפועל 
        /// {Name//notes//{date of the wanted lesson}-בקביעת שיעור פרטי כאשר השם יכול לא להיות קיים
        /// <param name="date"></param>
        /// <param name="teacherid"></param>
        /// <param name="kindofevent"></param>
        /// התראה שנקראת "{notification(כלומר שם ההתראה)} - done"
        /// הינה התראה, שאושרה והפכה לאיונט (שיעור למשל) וגם במקרה של אישור חברים
        /// *done is a safe word*
        /// <param name="randomuniqcode"></param>
        /// <param name="enddate"></param>
        public Event(string eventname, DateTime date, int teacherid,string kindofevent,int randomuniqcode, DateTime enddate)
        {
            this.eventname = eventname;
            this.date = date;
            this.teacherid = teacherid;
            this.kinofevent = kindofevent;
            this.randomuniqcode = randomuniqcode;
            this.enddate = enddate;
        }
      
        //public Event(string eventname, DateTime date, string kindofevent, DateTime enddate)
        //{
        //    this.eventname = eventname;
        //    this.date = date;
        //    this.teacherid = 0;
        //    this.kinofevent = kindofevent;
        //    this.enddate = enddate;
        //    this.randomuniqcode= "honor is dead".GetHashCode();
        //}
        //public Event(string eventname, string kindofevent)
        //{
        //    DateTime date = DateTime.Now;
        //    this.eventname = eventname;
        //    this.date = date;
        //    this.teacherid = 0;
        //    this.kinofevent= kindofevent;
        //    DateTime enddate = DateTime.Now;
        //}
        //public Event(string eventname, int teacherid)
        //{
        //    DateTime date = DateTime.Now;
        //    this.eventname = eventname;
        //    this.date = date;
        //    this.teacherid = teacherid;
        //    DateTime enddate=DateTime.Now;
        //}
       

        public string eventname { get; set; }
        public DateTime date { get; set; }
        public int teacherid { get; set; }
        public string kinofevent { get; set; }
        public int randomuniqcode {  get; set; }
        public DateTime enddate { get; set; }

    }
}
