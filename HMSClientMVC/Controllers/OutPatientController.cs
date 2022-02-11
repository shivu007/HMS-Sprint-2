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
        List<OBILL> obill = new List<OBILL>();
        List<PATIENT> patients = new List<PATIENT>();
        List<OPATIENT> outp = new List<OPATIENT>();
        List<Test> test = new List<Test>();

        string uid;
        string uname;
        

        static string baseURL = "https://localhost:44309";
        // GET: OutPatient
        public ActionResult Index()
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
            List<string> data1 = new List<string>() { "Male", "Female" };
            ViewBag.categories = data1;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> OPatientRegister(PATIENT patient)
        {
            List<string> data1 = new List<string>() { "Male", "Female" };
            ViewBag.categories = data1;
            if (ModelState.IsValid)
            {
               
                patient.Username = TempData["lUsername"].ToString();
                patient.PatientType = "Out Patient";
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
            }
            return View();
        }

        public async Task<ActionResult> OBill()
        {
            uname = TempData["lUsername"].ToString();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage httpmsg = await client.GetAsync("/api/OBillAPI/");

                if (httpmsg.IsSuccessStatusCode)
                {
                    var response = httpmsg.Content.ReadAsStringAsync().Result;
                    obill = JsonConvert.DeserializeObject<List<OBILL>>(response);




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
                        HttpResponseMessage httpapp = await client.GetAsync("/api/OutPatientAPI/");
                        if (httpapp.IsSuccessStatusCode)
                        {
                            var responseapp = httpapp.Content.ReadAsStringAsync().Result;
                            outp = JsonConvert.DeserializeObject<List<OPATIENT>>(responseapp);
                            foreach (OPATIENT o in outp)
                            {
                                if (o.PID == uid)
                                {
                                    apid = o.ADMISSIONID;
                                }
                            }

                            string html = "<link href=\"/Content/Style.css\"  rel=\"stylesheet\" media=\"all\" />";
                            html += "  <table> ";


                            html += "<tr><th>Bill No.</th><th>Admission ID</th><th>Medicine Fees</th><th>Room Charges</th><th>Operation Charges</th><th>Lab Fees</th><th>Doctor Fees</th><th>Total Days</th><th>Total Amount</th></tr>";

                            foreach (OBILL i in obill)
                            {
                                if (i.ADMISSIONID == apid)
                                {



                                    html += "<tr><td>" + i.BillNo + "</td>";
                                    html += "<td>" + i.ADMISSIONID + "</td>";
                                    html += "<td>" + i.MedicineFees + "</td>";
                                    html += "<td>" + i.RoomCharges + "</td>";
                                    html += "<td>" + i.OperationCharges + "</td>";
                                    html += "<td>" + i.LabFees + "</td>";
                                    html += "<td>" + i.DoctorFees + "</td>";
                                    html += "<td>" + i.TotalDays + "</td>";
                                    html += "<td>" + i.TotalAmount + "</td>";

                                    html += "</html>";

                                    return new ContentResult() { Content = html, ContentType = "text/html" };
                                }
                            }
                        }
                    }

                }

            }
            return View();

        }


        public async Task<ActionResult> OViewReport()
        {
            uname = TempData["lUsername"].ToString();

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
                            string html = "<link href=\"/Content/Style.css\"  rel=\"stylesheet\" media=\"all\" />";
                            html += "  <table> ";
                            html += "<tr><th>Lab ID</th><th>Patient ID</th><th>Test Type</th><th>Test Date</th><th>Remark</th></tr>";

                            foreach (Test t in test)
                            {
                                if (t.PID == uid)
                                {
                                    apid = t.LabID;
                                    
                                    html += "<tr><td>" + t.LabID + "</td>";
                                    html += "<td>" + t.PID + "</td>";
                                    html += "<td>" + t.TestType + "</td>";
                                    html += "<td>" + t.TestDate + "</td>";
                                    html += "<td>" + t.Remark + "</td>";
                                    html += "</html>";
                                  
                                    return new ContentResult() { Content = html, ContentType = "text/html" };
                                }
                            }
                        }
                    }
            }
            return View();
        }
    }
}
