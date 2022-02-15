using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HMSClientMVC.Models;
using Newtonsoft.Json;

namespace HMSClientMVC.Controllers
{
    public class AppointmentController : Controller
    {
        static string baseURL = "https://localhost:44309";
        

      
       
        public ActionResult IPatientRegister()
        {
            List<string> data1 = new List<string>() { "Male", "Female" };
            ViewBag.categories = data1;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> IPatientRegister(PATIENT patient)
        {
            
            List<string> data1 = new List<string>() { "Male", "Female" };
            ViewBag.categories = data1;
           
                
                string uname = TempData["lUsername"].ToString();
                patient.Username = uname;
                patient.PatientType = "In Patient";
                try
                {
                    // TODO: Add insert logic here
                    using (HttpClient client = new HttpClient())
                    {
                        string patientobj = JsonConvert.SerializeObject(patient);
                        client.BaseAddress = new Uri(baseURL);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var appcontent = new StringContent(patientobj, UnicodeEncoding.UTF8, "application/json");
                        HttpResponseMessage httpmsg = await client.PostAsync("/api/PatientAPI/", appcontent);
                        if (httpmsg.IsSuccessStatusCode)
                        {
                            return RedirectToAction("", "InPatient", "Index");
                        }
                    }


                }
                catch
                {
                    return View();
                }
            
            return View();
        }
        
    }
}
