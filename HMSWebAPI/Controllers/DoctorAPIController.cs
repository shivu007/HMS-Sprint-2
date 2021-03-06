using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMSWebAPI.Controllers
{
    public class DoctorAPIController : ApiController
    {
        DbHelper dBHelper = new DbHelper();
        // GET api/<controller>
        public List<DOCTOR> Get()
        {
            return dBHelper.GetDoctors();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Post(DOCTOR doctor)
        {
            if (doctor != null)
            {
                dBHelper.AddDoctor(doctor);
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