using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SignalrPersonMessage
    {
      public Person person{ get; set; }
        //public Person friend {  get; set; }
        public string massage { get; set; }
        public bool curruntperson { get; set; }
        public DateTime datesent { get; set; }
        
    }
}
