using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;



namespace HMSWebAPI.Controllers
{
    public class OutPatientAPIController : ApiController
    {
        DbHelper dbHelper = new DbHelper();
        List<OPATIENT> op = new List<OPATIENT>();
        public List<OPATIENT> Get()
        {
            op = dbHelper.GetOPATIENT();

            return op;
        }

        // GET api/<controller>/5
        public OPATIENT Get(string id)
        {
            op = dbHelper.GetOPATIENT();
            foreach (OPATIENT o in op)
            {
                if (o.ADMISSIONID == id)
                { 
                    return o;
                }
                
            }
            return null;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(OPATIENT opatient)
        {
            if (opatient != null)
            {
                dbHelper.AddOPATIENT(opatient);
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