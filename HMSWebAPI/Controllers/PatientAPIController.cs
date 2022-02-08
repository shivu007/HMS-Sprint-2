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
        public IEnumerable<PATIENT> Get()
        {
          return dbHelper.GetPATIENTs();
        }

        // GET api/<controller>/5
        //public PATIENT Get(string id)
        //{
        //    return dbHelper.GetPATIENTs(id);
        //}

        // POST api/<controller>
        public HttpResponseMessage Post(PATIENT patient)
        {
            if (patient != null)
            {
                dbHelper.AddPatient(patient);
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