﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository
{
    public class Roles
    {
        [Key]
        public int Rid { get; set; }
        public string Role { get; set; }       
    }
}