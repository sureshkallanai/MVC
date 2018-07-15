using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Repository;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace Events.Areas.HandleInfo.Controllers
{
    [Authorize]
    public class InfoController : Controller
    {
        // GET: HandleInfo/Info
        //public ActionResult Index()
        //{
        //    IEnumerable<EventsName> ListEventsName = new List<EventsName>();
        //    using (UOW uow = new UOW())
        //    {
        //        ListEventsName = uow._iEventsRepository.Get().ToList();
        //    }
            
        //    return View(ListEventsName);
        //}

        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:65214/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var id = 1;
                Dictionary<int, string> dic = new Dictionary<int, string>();
                //FormUrlEncodedContent formContent = new FormUrlEncodedContent(dic);
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/values");
                
                if (response.IsSuccessStatusCode)
                {
                   // IEnumerable<string> str = await response.Content.ReadAsAsync<IEnumerable<string>>();
                    // Get the URI of the created resource.  
                   Uri returnUrl = response.Headers.Location;
                   Console.WriteLine(returnUrl);
                }
            }
            return View();            
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