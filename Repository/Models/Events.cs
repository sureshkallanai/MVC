﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository
{
    public class Events
    {
        [Key]
        public int Eid { get; set; }
        public string EventName { get; set; }
    }
}