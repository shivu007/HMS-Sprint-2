
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;

namespace HMSWebAPI.Controllers
{
    

    public class AppointmentAPIController : ApiController
    {
        DbHelper dBHelper = new DbHelper();
        List<APPOINTMENT> apps=new List<APPOINTMENT>();

        List<APPOINTMENT> appsbydocs=new List<APPOINTMENT>();


        // GET api/<controller>
        public List<APPOINTMENT> Get()
        {
            apps = dBHelper.GetAppointnments();
            return apps;
        }
      

        // GET api/<controller>/5
        public List<APPOINTMENT> Get(string id)   
        {
            apps = dBHelper.GetAppointnments();
            foreach (APPOINTMENT a in apps)
            {
                if (a.DoctorID == id)
                {
                    appsbydocs.Add(a);
                }
            }
            
            return appsbydocs;

        }

        // POST api/<controller>
        public HttpResponseMessage Post(APPOINTMENT appointment)
        {
            if (appointment != null)
            {
                dBHelper.AddAppointment(appointment);
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