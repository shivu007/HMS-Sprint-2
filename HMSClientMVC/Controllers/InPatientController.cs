using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using HMSClientMVC.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HMSClientMVC.Controllers
{
    public class InPatientController : Controller
    {
        static string baseURL = "https://localhost:44309";
        // GET: InPatient
        public ActionResult Index()
        {
            return View();
        }

        // GET: InPatient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InPatient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InPatient/Create
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
                    HttpResponseMessage httpmsg = await client.PostAsync("/api/AppointmentAPI/", appcontent);
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

        // GET: InPatient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InPatient/Edit/5
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

        // GET: InPatient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InPatient/Delete/5
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
