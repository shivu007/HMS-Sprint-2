using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMSWebAPI.Controllers
{
    public class OBillAPIController : ApiController
    {
        // GET api/<controller>
        DbHelper dbHelper = new DbHelper();
        // GET api/<controller>
        public List<OBILL> Get()
        {
            return dbHelper.GetOBILLs();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        public HttpResponseMessage Post(OBILL oBILL)
        {
            if (oBILL != null)
            {
                dbHelper.AddOBILL(oBILL);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
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