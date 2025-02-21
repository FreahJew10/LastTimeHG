using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace DBL
{
    public class EventDB : BaseDB<Event>
    {

        /* public static List<int> alloftheeventsid = new List<int>();

          public static async Task  AddCodeTobuilalloftheeventsid(int randomcode)
          {
           alloftheeventsid.Add(randomcode);
          }

          public static  async Task builalloftheeventsid()
          {
              if (alloftheeventsid.Count == 0)
              {
                  EventDB eventDB = new EventDB();
                  List<Event> events = new List<Event>();
                  events = await eventDB.GetAllRandomCode();
                  for (int i=0; i<events.Count;i++ )
                  {
                      events.Add(events[i]);
                  }
              }

          }
          public  async Task<List<Event>> GetAllRandomCode()
          {
              List<Event> cods = new List<Event>();
              string q = @$"Select
                         mylastyear.event.randomuniqcode
                        From
                       mylastyear.event";
              List<Event> events = new List<Event>();
              cods = await SelectAllAsync(q);

              return cods;

          }*/
        public async Task<bool> UpdateTheKindOfEvent(Event @event)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            fillValues.Add("kindofevent",@event.kinofevent);
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            filterValues.Add("randomuniqcode", @event.randomuniqcode);
            int num = await base.UpdateAsync(fillValues, filterValues);
            return (num > 0);
        }


        public async Task<List<Event>> GetAllNotificationsForTeacher(int teacherid)
        {
            List<Event> events = new List<Event>();
            string sql = $@"Select
    event.randomuniqcode,
    event.eventname,
    event.date,
    event.teacherid,
    event.kindofevent,
    event.enddate
From
    event
    where event.teacherid=@teacherid;";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("teacherid", teacherid);
            events = await SelectAllAsync(sql, data);

            if (events.Count > 0) { return events; }
            else { return null; }
        }
        public async Task<List<Event>>GetAllNotificationsForStudent(int studentid)
        {
          List<Event>events = new List<Event>();
            string sql = $@"Select
                           event.randomuniqcode,
                           event.eventname,
                           event.date,
                           event.teacherid,
                           event.kindofevent,
                           event.enddate
                           From
                           student Inner Join
                           studentinevent On studentinevent.studentid = student.studentid Inner Join
                           event On studentinevent.randomuniqcode = event.randomuniqcode
                                where student.studentid=@srudentid AND event.kindofevent rlike ""notification""";
            Dictionary <string,object> data = new Dictionary <string,object> ();
            data.Add("studentid", studentid);
            events = await SelectAllAsync(sql, data);
            
            if (events.Count > 0) { return events; }
            else { return null; }
        }

        public async Task<List<Event>> GetEventsForStudentInRange(int studentId,DateTime startdate, DateTime enddate)
        {
            string sql = $@" Select mylastyear.event.randomuniqcode,
          mylastyear.event.eventname,
          mylastyear.event.date,
          mylastyear.event.teacherid,
          mylastyear.event.kindofevent,
          mylastyear.event.enddate
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
          mylastyear.event.kindofevent,
          mylastyear.event.enddate
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
          mylastyear.event.kindofevent,
          mylastyear.event.enddate
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
            data.Add("enddate",@event.enddate);
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
            if (row[1] != null)
            {
                even_t.eventname = row[1].ToString();
                even_t.date = DateTime.Parse(row[2].ToString());
                even_t.teacherid = int.Parse(row[3].ToString());
                even_t.kinofevent = row[4].ToString();
                even_t.enddate = DateTime.Parse(row[5].ToString());
            }
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
