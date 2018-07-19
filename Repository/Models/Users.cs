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
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int Rid { get; set; }
        public virtual ICollection<Roles> Role { get; set; }
    }
}