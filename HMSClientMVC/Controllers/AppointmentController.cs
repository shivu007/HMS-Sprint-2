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
        // GET: Appointment
        public async Task<ActionResult> Index()
        {
            List<APPOINTMENT> apps=new List<APPOINTMENT>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage httpmsg = await client.GetAsync("/api/AppointmentAPI/");
                if (httpmsg.IsSuccessStatusCode)
                {
                    var response = httpmsg.Content.ReadAsStringAsync().Result;
                     apps = JsonConvert.DeserializeObject<List<APPOINTMENT>>(response);

                }
            }
            return View(apps);
        }

        // GET: Appointment/Details/5
        public async Task<ActionResult> Details(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage httpmsg = await client.GetAsync("/api/AppointmentAPI/" + id);
                if (httpmsg.IsSuccessStatusCode)
                {
                    var response = httpmsg.Content.ReadAsStringAsync().Result;
                    APPOINTMENT app = JsonConvert.DeserializeObject<APPOINTMENT>(response);
                    return View(app);
                }
            }
            return View();
        }
        public ActionResult IPatientRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> IPatientRegister(PATIENT patient)
        {
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
        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public async Task<ActionResult> Create(APPOINTMENT appointment)
        {
            try
            {
                // TODO: Add insert logic here
                using (HttpClient client = new HttpClient())
                {
                    string appobj = JsonConvert.SerializeObject(appointment);
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var appcontent = new StringContent(appobj, UnicodeEncoding.UTF8, "application/json");
                    HttpResponseMessage httpmsg = await client.PostAsync("/api/AppointmentAPI/" , appcontent);
                    if (httpmsg.IsSuccessStatusCode)
                    {
                        return View();
                    }
                }
               
                
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
