﻿using System;
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

        //---------------------------------------------IN Patient---------------------------------------
        public ActionResult InPatient()
        {
            return View();
        }


        public ActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Test(Test test)
        {
            try
            {
                // TODO: Add insert logic here
                using (HttpClient client = new HttpClient())
                {
                    string testobj = JsonConvert.SerializeObject(test);
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var appcontent = new StringContent(testobj, UnicodeEncoding.UTF8, "application/json");
                    HttpResponseMessage httpmsg = await client.PostAsync("/api/TestAPI/", appcontent);
                    if (httpmsg.IsSuccessStatusCode)
                    {
                        
                        return RedirectToAction("Dashboard", "Doctor", "");

                    }
                }


            }
            catch
            {
                return View();
            }
            return View();
        }
           
 
        public async Task<ActionResult> LoadAppointments()
        {
            string doctorname=TempData["lUsername"].ToString();
            List<APPOINTMENT> apps = new List<APPOINTMENT>();
            List<DOCTOR> docs = new List<DOCTOR>();
            string DID=null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage httpdoc = await client.GetAsync("/api/DoctorAPI");
                if (httpdoc.IsSuccessStatusCode)
                {
                    var response = httpdoc.Content.ReadAsStringAsync().Result;
                    docs = JsonConvert.DeserializeObject<List<DOCTOR>>(response);
                }
                foreach(DOCTOR d in docs)
                {
                    if (d.Username == doctorname)
                    {
                        DID = d.DID;
                    }
                    else
                    {
                        RedirectToAction("UserLogin", "LoginError");
                    }
                }
                HttpResponseMessage httpmsg = await client.GetAsync("/api/AppointmentAPI/"+ DID);
                if (httpmsg.IsSuccessStatusCode)
                {
                    var response = httpmsg.Content.ReadAsStringAsync().Result;
                    apps = JsonConvert.DeserializeObject<List<APPOINTMENT>>(response);
                }

            }


            string html = "<table border = 2 >";
            html += "<tr><th>Patient ID</th><th>Appointment ID</th><th>AppointmentDate</th><th>Doctor ID</th></tr>";
            foreach (APPOINTMENT a in apps)
            {
                html += "<tr><td>" + a.PID + "</td>";
                html += "<td>" + a.AppointmentID + "</td>";
                html += "<td>" + a.AppointmentDate + "</td>";
                html += "<td>" + a.DoctorID + "</td>";
            }
            html += "</html>";

            return new ContentResult() { Content = html, ContentType = "text/html" };
        }

        public ActionResult IBill()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> IBill(IBILL iBILL)
        {
            try
            {
                // TODO: Add insert logic here
                using (HttpClient client = new HttpClient())
                {
                    string ibillobj = JsonConvert.SerializeObject(iBILL);
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var appcontent = new StringContent(ibillobj, UnicodeEncoding.UTF8, "application/json");
                    HttpResponseMessage httpmsg = await client.PostAsync("/api/IBillAPI/", appcontent);
                    if (httpmsg.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Dashboard", "Doctor", "");

                    }
                }


            }
            catch
            {
                return View();
            }
            return View();
        }



        //---------------------------------------------IN Patient---------------------------------------
        public ActionResult OutPatient()
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
