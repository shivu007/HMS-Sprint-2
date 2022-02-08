using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;

namespace HMSWebAPI.Controllers
{
    public class UserLoginAPIController : ApiController
    {
        DbHelper dBHelper = new DbHelper();
       
        public HttpResponseMessage Post(User user)
        {

            if (user != null)
            {
                dBHelper.AddUser(user);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);

        }

        
    }
}
