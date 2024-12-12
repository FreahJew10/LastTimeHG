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
          mylastyear.studentinevent.studentid = @s";
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
            
            even_t.eventname = row[0].ToString();
            even_t.date = DateTime.Parse(row[1].ToString());
            even_t.teacherid = int.Parse(row[2].ToString());
            even_t.kinofevent= row[3].ToString();
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
