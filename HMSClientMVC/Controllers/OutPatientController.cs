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
    public class OutPatientController : Controller
    {
        static string baseURL = "https://localhost:44309";
        // GET: OutPatient
        public ActionResult Index()
        {
            return View();
        }

        // GET: OutPatient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OutPatient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OutPatient/Create
        [HttpPost]
        public async Task<ActionResult> Admission(OPATIENT opatient)
        {
            try
            {
                // TODO: Add insert logic here
                using (HttpClient client = new HttpClient())
                {
                    string appobj = JsonConvert.SerializeObject(opatient);
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var appcontent = new StringContent(appobj, UnicodeEncoding.UTF8, "application/json");
                    HttpResponseMessage httpmsg = await client.PostAsync("/api/OutPatientAPI/", appcontent);
                    if (httpmsg.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }


            }
            catch
            {
                return View();
            }
            return View();
        }
        
        public ActionResult OPatientRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> OPatientRegister(PATIENT patient)
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
                        return RedirectToAction("", "OutPatient", "Index");
                    }
                }


            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: OutPatient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OutPatient/Edit/5
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

        // GET: OutPatient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OutPatient/Delete/5
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
