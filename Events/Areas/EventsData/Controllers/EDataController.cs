using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;

namespace Events.Areas.EventsData.Controllers
{

    

    public class EDataController : Controller
    {

               // GET: EventsData/EData       

        public ActionResult Index(int id=0)
        {
           TempData["id"] = id;                        
            return View();
        }

        public JsonResult GetTodoLists(string sidx, string sord, int page, int rows)  //Gets the todo Lists.
        {
            DatabaseContext DatabaseContext = new DatabaseContext();
            DatabaseContext.Configuration.LazyLoadingEnabled = false;
            int id = Convert.ToInt32(TempData["id"]);
            TempData.Keep("id");
            IEnumerable<EventData> EventsData = new List<EventData>();
            using (UOW uow = new UOW())
            {
               var EventsData1 = uow._iEventsDataRepository.Get().ToList();
                EventsData = uow._iEventsDataRepository.Get().ToList().Where(x=>x.Eid==id);
                
            }

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var todoListsResults = EventsData.Select(
                    a => new
                    {
                        a.EventDataid,
                        a.Name,
                        a.Address,
                        a.District,
                        a.City,
                        a.Eid
                    });
            int totalRecords = todoListsResults.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                todoListsResults = todoListsResults.OrderByDescending(s => s.Name);
                todoListsResults = todoListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                todoListsResults = todoListsResults.OrderBy(s => s.Name);
                todoListsResults = todoListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = todoListsResults
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        //public string Create(EventData EventData)
        //{            
        //    string msg;            
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            //using (UOW uow = new UOW())
        //            //{
        //            //    uow._iEventsDataRepository.Add(objEventData);
        //            //    uow.SaveChanges();

        //            //}
        //            msg = "Saved Successfully";
        //        }
        //        else
        //        {
        //            msg = "Validation data not successfull";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = "Error occured:" + ex.Message;
        //    }
        //    return msg;
        //}


        [HttpGet]
        public ActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Create(EventData EventData)

        {
            string msg;
            try
            {
                //if (ModelState.IsValid)
                //{
                    using (UOW uow = new UOW())
                    {
                        uow._iEventsDataRepository.Add(EventData);
                        uow.SaveChanges();

                    }
                    msg = "Saved Successfully";
                //}
                //else
                //{
                    msg = "Validation data not successfull";
                //}
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return View();
        }
        public string Edit(EventData objEventData)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    using (UOW uow = new UOW())
                    {
                        uow._iEventsDataRepository.Update(objEventData);
                        uow.SaveChanges();

                    }
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        [HttpPost]
        public string Delete(int Id)
        {
            using (UOW uow = new UOW())
            {
                uow._iEventsDataRepository.DeleteFindByID(Id);
                uow.SaveChanges();

            }
            return "Deleted successfully";
        }
    }
}