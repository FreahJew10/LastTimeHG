using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DBL
{
    public class EventDB : BaseDB<Event>
    {
        public async Task<List<Event>> GetEventsForStudentInRange(int studentId,DateTime startdate, DateTime enddate)
        {
            string sql = $@" select
            mylastyear.event.randomuniqcode,
            mylastyear.event.eventname,
            mylastyear.event.date,
            mylastyear.event.teacherid,
            mylastyear.event.kindofevent
            From
            mylastyear.studentinevent Inner Join
            mylastyear.student On mylastyear.studentinevent.studentid = mylastyear.student.studentid Inner Join
            mylastyear.event On mylastyear.studentinevent.randomuniqcode = mylastyear.event.randomuniqcode

            Where
            mylastyear.studentinevent.studentid = @studentId and  mylastyear.event.date BETWEEN @startdate AND @enddate;";

            Dictionary<string, object> data = new Dictionary<string, object>();

            string endtime=enddate.ToString("yyyy-MM-dd");
            string startime=startdate.ToString("yyyy-MM-dd");
            List<Event> events = new List<Event>();
            data.Add("studentId", studentId);
            data.Add("startdate", startime);
            data.Add("enddate", endtime);
            events = await SelectAllAsync(sql, data);
           
          
            if (events.Count > 0) { return events; }
            else { return null; }
        }
        public async Task<List<Event>> GetAllEventsForSpecificStudenAndDate(int studentid,DateTime dateTime)
        {
            string sql = $@" 
          
         Select
          mylastyear.event.randomuniqcode,
          mylastyear.event.eventname,
          mylastyear.event.date,
          mylastyear.event.teacherid,
          mylastyear.event.kindofevent
          From
          mylastyear.studentinevent Inner Join
          mylastyear.student On mylastyear.studentinevent.studentid = mylastyear.student.studentid Inner Join
          mylastyear.event On mylastyear.studentinevent.randomuniqcode = mylastyear.event.randomuniqcode
          
          Where
          mylastyear.studentinevent.studentid = @studentid and event.date rlike @datetme";
            Dictionary <string,object> data = new Dictionary <string,object> ();
            string time=dateTime.ToString("yyyy-MM-dd");
            data.Add ("datetme", time);
            data.Add("studentid", studentid);
            List<Event> events = new List<Event>();
            events = await SelectAllAsync(sql, data);
            if (events.Count > 0) { return events; }
            else { return null; }
        }
        public async Task<List<Event>> GetAllEventsForSpecificStudent(int studentid)
        {
            string sql = @$"Select
          mylastyear.event.randomuniqcode,
          mylastyear.event.eventname,
          mylastyear.event.date,
          mylastyear.event.teacherid,
          mylastyear.event.kindofevent
          From
          mylastyear.studentinevent Inner Join
          mylastyear.student On mylastyear.studentinevent.studentid = mylastyear.student.studentid Inner Join
          mylastyear.event On mylastyear.studentinevent.randomuniqcode = mylastyear.event.randomuniqcode
          Where
          mylastyear.studentinevent.studentid = @studentid";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("studentid", studentid);
            List<Event> events = new List<Event>();
            events = await SelectAllAsync(sql, data);
            if (events.Count > 0) { return events; }
            else { return null; }
        }
        public async Task<bool> insertEvent(Event @event)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("eventname", @event.eventname);
            data.Add("date", @event.date);
            data.Add("teacherid",@event.teacherid);
            data.Add("kindofevent", @event.kinofevent);
            data.Add("randomuniqcode", @event.randomuniqcode);

            int num = await base.InsertAsync(data);
            if (num > 0)
            {
                return true;
            }
            else { return false; }

        }
        protected override async Task<List<Event>> CreateListModelAsync(List<object[]> rows)
        {
            List<Event> events = new List<Event>();
            foreach (object[] row in rows)
            {
               Event @event = await CreateModelAsync(row);
                events.Add(@event);

            }
            return events;
        }

        protected override async Task<Event> CreateModelAsync(object[] row)
        {
            Event even_t = new Event();
            even_t.randomuniqcode = int.Parse(row[0].ToString());
            even_t.eventname = row[1].ToString();
            even_t.date = DateTime.Parse(row[2].ToString());
            even_t.teacherid = int.Parse(row[3].ToString());
            even_t.kinofevent= row[4].ToString();
            return even_t;
        }

        protected override List<string> GetPrimaryKeyName()
        {
            List<string> list = new List<string>() { "eventid" };
            return list;
          
        }

        protected override string GetTableName()
        {
            return "event";
        }


    }
}
