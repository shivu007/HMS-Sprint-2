using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;
namespace HMSWebAPI.Controllers
{
    public class TestAPIController : ApiController
    {
        DbHelper dbHelper=new DbHelper();
        // GET api/<controller>
        public List<Test> Get()
        {
            return dbHelper.GetTests();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Test test)
        {
            if (test != null)
            {
                dbHelper.AddTest(test);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}