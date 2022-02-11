﻿using Newtonsoft.Json;
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
        List<IBILL> ibill = new List<IBILL>();
        List<Test> test = new List<Test>();
        List<PATIENT> patients = new List<PATIENT>();
        List<APPOINTMENT> app = new List<APPOINTMENT>();
        string uid;
        string uname;
        static string baseURL = "https://localhost:44309";
        // GET: InPatient
        public ActionResult Index()
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


        public async Task<ActionResult> IBill()
        {
            uname = TempData["lUsername"].ToString();

            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    HttpResponseMessage httpmsg = await client.GetAsync("/api/IBillAPI/");

                    if (httpmsg.IsSuccessStatusCode)
                    {
                        var response = httpmsg.Content.ReadAsStringAsync().Result;
                        ibill = JsonConvert.DeserializeObject<List<IBILL>>(response);




                        HttpResponseMessage httppat = await client.GetAsync("/api/PatientAPI/");
                        if (httppat.IsSuccessStatusCode)
                        {
                            var responseap = httppat.Content.ReadAsStringAsync().Result;
                            patients = JsonConvert.DeserializeObject<List<PATIENT>>(responseap);
                            foreach (PATIENT p in patients)
                            {
                                if (p.Username == uname)
                                {
                                    uid = p.PID;
                                }
                            }

                            string apid = "";
                            HttpResponseMessage httpapp = await client.GetAsync("/api/AppointmentAPI/");
                            if (httpapp.IsSuccessStatusCode)
                            {
                                var responseapp = httpapp.Content.ReadAsStringAsync().Result;
                                app = JsonConvert.DeserializeObject<List<APPOINTMENT>>(responseapp);

                                foreach (APPOINTMENT a in app)
                                {
                                    if (a.PID == uid)
                                    {
                                        apid = a.AppointmentID;
                                    }
                                }

                                string html = "<link href=\"/Content/Style.css\"  rel=\"stylesheet\" media=\"all\" />";
                                html += "  <table> ";


                                html += "<tr><th>Bill No.</th><th>Appointment ID</th><th>Medicine Fees</th><th>Operation Charges</th><th>Lab Fees</th><th>Doctor Fees</th><th>Total Amount</th></tr>";

                                foreach (IBILL i in ibill)
                                {
                                    if (i.APPOINTMENTID == apid)
                                    {



                                        html += "<tr><td>" + i.BillNo + "</td>";
                                        html += "<td>" + i.APPOINTMENTID + "</td>";
                                        html += "<td>" + i.MedicineFees + "</td>";
                                        html += "<td>" + i.OperationCharges + "</td>";
                                        html += "<td>" + i.LabFees + "</td>";
                                        html += "<td>" + i.DoctorFees + "</td>";
                                        html += "<td>" + i.TotalAmount + "</td>";


                                    }
                                }
                                html += "</html>";
                                
                                return new ContentResult() { Content = html, ContentType = "text/html" };
                            }
                        }

                    }
                }
            }
            return View();
           
        }

        public async Task<ActionResult> IViewReport()
        {
            uname = TempData["lUsername"].ToString();
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);

                    HttpResponseMessage httppat = await client.GetAsync("/api/PatientAPI/");
                    if (httppat.IsSuccessStatusCode)
                    {
                        var responseap = httppat.Content.ReadAsStringAsync().Result;
                        patients = JsonConvert.DeserializeObject<List<PATIENT>>(responseap);
                        foreach (PATIENT p in patients)
                        {
                            if (p.Username == uname)
                            {
                                uid = p.PID;
                            }
                        }

                        string apid = "";
                        HttpResponseMessage httptest = await client.GetAsync("/api/TestAPI/");
                        if (httptest.IsSuccessStatusCode)
                        {
                            var responseapp = httptest.Content.ReadAsStringAsync().Result;
                            test = JsonConvert.DeserializeObject<List<Test>>(responseapp);
                            string html1 = "<link href=\"/Content/Style.css\"  rel=\"stylesheet\" media=\"all\" />";
                            html1 += "  <table> ";
                            html1 += "<tr><th>Lab ID</th><th>Patient ID</th><th>Test Type</th><th>Test Date</th><th>Remark</th></tr>";

                            foreach (Test t in test)
                            {
                                if (t.PID == uid)
                                {
                                    apid = t.LabID;

                                    html1 += "<tr><td>" + t.LabID + "</td>";
                                    html1 += "<td>" + t.PID + "</td>";
                                    html1 += "<td>" + t.TestType + "</td>";
                                    html1 += "<td>" + t.TestDate + "</td>";
                                    html1 += "<td>" + t.Remark + "</td>";




                                    html1 += "</html>";

                                    //return new ContentResult() { Content = html1, ContentType = "text/html" };
                                    return View();

                                }
                            }
                        }
                    }
                }
            }
            return View();
        }

    }
}
