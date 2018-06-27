using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository
{
    public class EventData
    {
        [Key]
        public int EventDataid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public int Eid { get; set; }

        public EventsName Event { get; set; }
    }
}