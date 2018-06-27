using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository
{
    public class EventsRepository : BaseCRUD<EventsName, DbContext>, IEventsRepository<EventsName>
    {
        public EventsRepository(DbContext _DbContext):base(_DbContext)
        {

        }
    }
}