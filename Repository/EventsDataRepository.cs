using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository
{
    public class EventsDataRepository : BaseCRUD<EventData,DbContext>, IEventsDataRepository<EventData>
    {
        public EventsDataRepository(DbContext _DbContext):base(_DbContext)
        {

        }
    }
}