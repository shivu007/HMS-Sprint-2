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
        List<PATIENT> patients = new List<PATIENT>();
        string check;
        List<PATIENT> InP = new List<PATIENT>();
        List<PATIENT> OnP = new List<PATIENT>();
        List<DOCTOR> docs = new List<DOCTOR>();
        List<APPOINTMENT> ap = new List<APPOINTMENT>();
        List<OPATIENT> ad = new List<OPATIENT>();
        string DID = null;

   

        //---------------------------------------------IN Patient---------------------------------------
        public ActionResult InPatient()
        {    
          return View();
        }


        public async Task<ActionResult> Test()
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage httppatients = await client.GetAsync("/api/PatientAPI");
                if (httppatients.IsSuccessStatusCode)
                {
                    var response = httppatients.Content.ReadAsStringAsync().Result;
                    patients = JsonConvert.DeserializeObject<List<PATIENT>>(response);
                    foreach (PATIENT p in patients)
                    {
                        if (p.PatientType == "In Patient" || p.PatientType == "In patient")
                            InP.Add(p);
                        else
                            OnP.Add(p);

                    }
                    check = TempData["InPat"].ToString();
                    if (check == "Inn")
                        ViewBag.categories = InP;

                    else if (check == "Out")
                        ViewBag.categories = OnP;

                }
            }
            
        
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Test(Test test)
        {
           
            if (check == "Inn")
                ViewBag.categories = InP;

            else if (check == "Out")
                ViewBag.categories = OnP;
        
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
           
            
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                
                HttpResponseMessage httpmsg = await client.GetAsync("/api/AppointmentAPI/");
                if (httpmsg.IsSuccessStatusCode)
                {
                    var response = httpmsg.Content.ReadAsStringAsync().Result;
                    apps = JsonConvert.DeserializeObject<List<APPOINTMENT>>(response);
                }
                HttpResponseMessage httpdoc = await client.GetAsync("/api/DoctorAPI/");
                if (httpdoc.IsSuccessStatusCode)
                {
                    var response = httpdoc.Content.ReadAsStringAsync().Result;
                    docs = JsonConvert.DeserializeObject<List<DOCTOR>>(response);
                }

            }

            string html = "<link href=\"/Content/Style.css\"  rel=\"stylesheet\" media=\"all\" />";
            html += "<table>";
            html += "<tr><th>Patient ID</th><th>Appointment ID</th><th>AppointmentDate</th><th>Doctor ID</th></tr>";
            string did = null;
            foreach (DOCTOR d in docs)
            {
                if (d.Username == doctorname)
                {
                    did = d.DID;
                    
                    foreach (APPOINTMENT a in apps)
                    {
                        if (a.DoctorID == did)
                        {
                            html += "<tr><td>" + a.PID + "</td>";
                            html += "<td>" + a.AppointmentID + "</td>";
                            html += "<td>" + a.AppointmentDate + "</td>";
                            html += "<td>" + a.DoctorID + "</td>";
                        }
                    }

                }
            }
            html += "</html>";

            return new ContentResult() { Content = html, ContentType = "text/html" };
        }

       



        //---------------------------------------------OUT Patient---------------------------------------
        public async Task<ActionResult> OutPatient()
        {
            using (HttpClient client = new HttpClient())
            {
                string doctorname = TempData["lUsername"].ToString();
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage httpdoc = await client.GetAsync("/api/DoctorAPI");
                if (httpdoc.IsSuccessStatusCode)
                {
                    var response = httpdoc.Content.ReadAsStringAsync().Result;
                    docs = JsonConvert.DeserializeObject<List<DOCTOR>>(response);
                }
               

            }
            


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

        public async Task<ActionResult> AdmitPatient()
        {
            List<string> room1 = new List<string>() { "Private Room", "General Room", "Semi Private Room" };
            ViewBag.rooms = room1;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage httppatients = await client.GetAsync("/api/PatientAPI");
                if (httppatients.IsSuccessStatusCode)
                {
                    var response = httppatients.Content.ReadAsStringAsync().Result;
                    patients = JsonConvert.DeserializeObject<List<PATIENT>>(response);
                    foreach (PATIENT p in patients)
                    {
                        if (p.PatientType == "In Patient" || p.PatientType == "In patient")
                            InP.Add(p);
                        else
                            OnP.Add(p);

                    }
                    check = TempData["InPat"].ToString();
                   

                    
                    ViewBag.categories = OnP;

                }
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AdmitPatient(OPATIENT oPATIENT)
        {
            List<string> room1 = new List<string>() { "Private Room", "General Room", "Semi Private Room" };
            ViewBag.rooms = room1;
            ViewBag.categories = OnP;

            string doctorname = TempData["lUsername"].ToString();
            using (HttpClient client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage httpdoc = await client.GetAsync("/api/DoctorAPI");
                if (httpdoc.IsSuccessStatusCode)
                {
                    var response = httpdoc.Content.ReadAsStringAsync().Result;
                    docs = JsonConvert.DeserializeObject<List<DOCTOR>>(response);
                }


            }
            foreach (DOCTOR d in docs)
            {
                if (d.Username == doctorname)
                {
                    oPATIENT.DID = d.DID;
                }
               
            }
            try
            {
                // TODO: Add insert logic here
                using (HttpClient client = new HttpClient())
                {
                    string ibillobj = JsonConvert.SerializeObject(oPATIENT);
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var appcontent = new StringContent(ibillobj, UnicodeEncoding.UTF8, "application/json");
                    HttpResponseMessage httpmsg = await client.PostAsync("/api/OutPatientAPI/", appcontent);
                   
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

        public async Task<ActionResult> OBill()
        {


            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage httpmsg = await client.GetAsync("/api/OutPatientAPI/");

                if (httpmsg.IsSuccessStatusCode)
                {
                    var response = httpmsg.Content.ReadAsStringAsync().Result;
                    ad = JsonConvert.DeserializeObject<List<OPATIENT>>(response);
                    ViewBag.admission = ad;
                   
                }
            }
            return View();

            
        }
        [HttpPost]
        public async Task<ActionResult> OBill(OBILL oBILL)
        {
           
            try
            {
                ViewBag.admission = ad;
                // TODO: Add insert logic here
                using (HttpClient client = new HttpClient())
                {
                    string ibillobj = JsonConvert.SerializeObject(oBILL);
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var appcontent = new StringContent(ibillobj, UnicodeEncoding.UTF8, "application/json");
                    HttpResponseMessage httpmsg = await client.PostAsync("/api/OBillAPI/", appcontent);
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

        public async Task<ActionResult> IBill()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage httpmsg = await client.GetAsync("/api/AppointmentAPI/");

                if (httpmsg.IsSuccessStatusCode)
                {


                    var response = httpmsg.Content.ReadAsStringAsync().Result;
                    ap = JsonConvert.DeserializeObject<List<APPOINTMENT>>(response);


                    ViewBag.appointment = ap;

                }

            }
            return View();



        }
        [HttpPost]
        public async Task<ActionResult> IBill(IBILL iBILL)
        {
            ViewBag.appointment = ap;
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





    }
}
