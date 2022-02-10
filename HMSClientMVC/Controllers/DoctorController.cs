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
    public class DoctorController : Controller
    {
        static string baseURL = "https://localhost:44309";
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult RegisterDoctor()
        {
            List<string> depts = new List<string>() { "Cardiologist","Dentist","Dermatologists","Gynaecologist","Neurologists","Radiologists"};
            ViewBag.categories = depts;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> RegisterDoctor(DOCTOR doctor)
        {
            List<string> depts = new List<string>() { "Cardiologist","Dentist","Dermatologists","Gynaecologist","Neurologists","Radiologists"};
            ViewBag.categories = depts;
            try
            {
                // TODO: Add insert logic here
                using (HttpClient client = new HttpClient())
                {
                    string doctorobj = JsonConvert.SerializeObject(doctor);
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var doccontent = new StringContent(doctorobj, UnicodeEncoding.UTF8, "application/json");
                    HttpResponseMessage httpmsg = await client.PostAsync("/api/DoctorAPI/", doccontent);
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
        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctor/Edit/5
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

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctor/Delete/5
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
