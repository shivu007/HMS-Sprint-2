using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;

namespace HMSWebAPI.Controllers
{
    public class PatientAPIController : ApiController
    {
        DbHelper dbHelper=new DbHelper();
        //GET api/<controller>
        public List<PATIENT> Get()
        {
          return dbHelper.GetPATIENTs();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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