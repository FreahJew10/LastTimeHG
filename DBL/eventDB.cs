using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DBL
{
    public class eventDB : BaseDB<@event>
    {
        protected override async Task<List<@event>> CreateListModelAsync(List<object[]> rows)
        {
            List<@event> events = new List<@event>();
            foreach (object[] row in rows)
            {
               @event @event = await CreateModelAsync(row);
                events.Add(@event);

            }
            return events;
        }

        protected override async Task<@event> CreateModelAsync(object[] row)
        {
            @event even_t = new @event();
            even_t.eventid = int.Parse(row[0].ToString());
            even_t.eventname = row[1].ToString();
            even_t.date = DateTime.Parse(row[2].ToString());
            even_t.teacherid = int.Parse(row[3].ToString());
            
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
