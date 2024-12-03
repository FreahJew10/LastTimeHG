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
        public async Task<bool> insertEvent(Event @event)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("eventname", @event.eventname);
            data.Add("date", @event.date);
            data.Add("teacherid",@event.teacherid);
            data.Add("kindofevent", @event.kinofevent);

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
            even_t.eventid = int.Parse(row[0].ToString());
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
