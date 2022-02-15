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

        List<IBILL> ibill = new List<IBILL>();
        static List<DOCTOR> docs = new List<DOCTOR>();
        List<Test> test = new List<Test>();
        List<PATIENT> patients = new List<PATIENT>();
        List<PATIENT> pari = new List<PATIENT>();
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
        public async Task<ActionResult> Create()
        {
           using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage httpmsg = await client.GetAsync("/api/DoctorAPI/");

                if (httpmsg.IsSuccessStatusCode)
                {
                    var response = httpmsg.Content.ReadAsStringAsync().Result;
                    docs = JsonConvert.DeserializeObject<List<DOCTOR>>(response);
                    ViewBag.doctor = docs;
                    
                }
            
            }
            return View();
        }

        // POST: InPatient/Create

        [HttpPost]
        public async Task<ActionResult> Create(APPOINTMENT appointment)
        {
            ViewBag.doctor = docs;
          
            try
            {
                // TODO: Add insert logic here
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    HttpResponseMessage httpmsgp = await client.GetAsync("/api/PatientAPI/");
                    string pname = TempData["lUsername"].ToString();
                    if (httpmsgp.IsSuccessStatusCode)
                    {
                        var response = httpmsgp.Content.ReadAsStringAsync().Result;
                        pari = JsonConvert.DeserializeObject<List<PATIENT>>(response);
                        foreach (PATIENT p in pari)
                        {
                            if (p.Username == pname)
                            {
                                appointment.PID = p.PID;
                            }
                        }

                    }
                    string appobj = JsonConvert.SerializeObject(appointment);
                    
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
            List<IBILL> ibills = new List<IBILL>();
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
                                        foreach (IBILL i in ibill)
                                        {
                                            
                                            if (i.APPOINTMENTID == apid)
                                            {
                                                ibills.Add(i);
                                            }
                                           
                                        }
                                    }
                                }


                                return View(ibills);


                            }
                        }

                    }
                }
            }
            return View();
           
        }

        public async Task<ActionResult> IViewReport()
        {
            List<Test> tests = new List<Test>();
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

                      
                        HttpResponseMessage httptest = await client.GetAsync("/api/TestAPI/");
                        if (httptest.IsSuccessStatusCode)
                        {
                            var responseapp = httptest.Content.ReadAsStringAsync().Result;
                            test = JsonConvert.DeserializeObject<List<Test>>(responseapp);
                            
                            foreach (Test t in test)

                            {
                                if (t.PID == uid)
                                {

                                    tests.Add(t);
                                }
                              
                            }
                            return View(tests);
                        }
                    }
                }
            }
            return View();
        }

    }
}
