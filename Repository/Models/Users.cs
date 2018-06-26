using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository
{
    public class Users
    {
        [Key]
        public int Uid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Rid { get; set; }
        public Roles Role { get; set; }
    }
}