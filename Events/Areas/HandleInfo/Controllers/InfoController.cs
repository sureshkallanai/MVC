using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;

namespace Events.Areas.HandleInfo.Controllers
{
    [Authorize]
    public class InfoController : Controller
    {
        // GET: HandleInfo/Info
        public ActionResult Index()
        {
            IEnumerable<EventsName> ListEventsName = new List<EventsName>();
            using (UOW uow = new UOW())
            {               
                ListEventsName = uow._iEventsRepository.Get().ToList();            }
                return View(ListEventsName);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        //[Route("Info/Create")]
        [HttpPost]
        public ActionResult Create(EventsName EventsName)
        {
           
            if (EventsName != null)
            {
                using (UOW uow = new UOW())
                {
                    EventsName eventsName = uow._iEventsRepository.Get().ToList().Where(x=>x.EventName.ToLower()==EventsName.EventName.ToLower()).FirstOrDefault();
                    if (eventsName == null)
                    {
                        uow._iEventsRepository.Add(EventsName);
                        uow.SaveChanges();
                    }
                }
               
            }
            return  RedirectToAction("Create", "Info");
        }
    }
}