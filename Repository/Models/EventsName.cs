using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository
{
    public class EventsName
    {
        public EventsName()
        {
            this.EventData = new HashSet<EventData>();
        }

        [Key]
        public int Eid { get; set; }
        public string EventName { get; set; }
        
        public virtual ICollection<EventData> EventData { get; set; }
    }
}