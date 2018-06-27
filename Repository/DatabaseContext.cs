using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() : base("Dbconnection") { }
        
        public DbSet<Users> User { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<EventsName> Event { get; set; }
        public DbSet<EventData> EventData { get; set; }
       
    }
}