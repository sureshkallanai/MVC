using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    //[Authorize]
    [BasicAuthentication]
    public class ValuesController : ApiController
    {
        // GET api/values

        //public async Task<ActionResult> Index()
        //{
        //    using (var client = new HttpClient())
        //    {

        //        client.BaseAddress = new Uri("http://localhost:61908/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //GET Method  
        //        HttpResponseMessage response = await client.GetAsync("api/values");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            IEnumerable<string> str = await response.Content.ReadAsAsync<IEnumerable<string>>();
        //            // Get the URI of the created resource.  
        //            Uri returnUrl = response.Headers.Location;
        //            Console.WriteLine(returnUrl);
        //        }
        //    }
        //}


        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
