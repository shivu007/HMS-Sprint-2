using HMSClientMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HMSClientMVC.Controllers
{
    public class UserLoginController : Controller
    {

        static string baseURL = "https://localhost:44309";
        List<User> users = new List<User>();
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        } 

      
        public  ActionResult Login()
        {
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(baseURL);

            //    HttpResponseMessage httpmsg = await client.GetAsync("/api/UserLoginapi");
            //    if (httpmsg.IsSuccessStatusCode)
            //    {
            //        var response = httpmsg.Content.ReadAsStringAsync().Result;
            //        users = JsonConvert.DeserializeObject<List<User>>(response);
                    
            //    }
            //}
           
            List<string> data1 = new List<string>() { "Doctor", "In Patient", "Out Patient" };
            ViewBag.categories = data1;
            return View();
        } 
      
        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            List<string> data1 = new List<string>() { "Doctor", "In Patient", "Out Patient" };
            ViewBag.categories = data1;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                KeyValuePair<string, string> username = new KeyValuePair<string, string>("username", user.Username);
                KeyValuePair<string, string> password = new KeyValuePair<string, string>("password", user.Pass);
                
                KeyValuePair<string, string> granttype = new KeyValuePair<string, string>("grant_type", "password");
                List<KeyValuePair<string, string>> authkey = new List<KeyValuePair<string, string>>();
                authkey.Add(username);
                authkey.Add(password);
                
                authkey.Add(granttype);
                //temp = user.Username;

                var formcontent = new FormUrlEncodedContent(authkey);
                HttpResponseMessage httpResMsg = await client.PostAsync("/token", formcontent);
                HttpResponseMessage httpmsg = await client.GetAsync("/api/UserLoginapi");
                if (httpmsg.IsSuccessStatusCode)
                {
                    var response = httpmsg.Content.ReadAsStringAsync().Result;
                    users = JsonConvert.DeserializeObject<List<User>>(response);

                }
                if (httpResMsg.IsSuccessStatusCode )
                {
                   
                    var token = JsonConvert.DeserializeObject<Token>(httpResMsg.Content.ReadAsStringAsync().Result);
                    Session["token"] = token.access_token;
                    Session["user"] = user;
                    foreach (User u in users)
                    {
                        if(u.Username == user.Username && u.Roles==user.Roles)
                        {
                            if (user.Roles == "In Patient")
                            {
                                return RedirectToAction("InPatient");
                            }
                            else if (user.Roles == "Out Patient")
                            {
                                return RedirectToAction("OutPatient");
                            }
                            else
                            {
                                return RedirectToAction("Doctor");
                            }
                        }
                    }
                    

                }
                ViewBag.Message = "UserName or password is wrong";
                return View();

            }
            
        }

        public ActionResult Logout()
        {
            if (Session["token"] != null)
                Session.Remove("token");
            if (Session["user"] != null)
                Session.Remove("user");

            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            List<string> data = new List<string>(){ "Doctor","In Patient","Out Patient"};
            ViewBag.categories = data;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(User user)
        {
            
            try
            {
                // TODO: Add insert logic here
                string loanobj = JsonConvert.SerializeObject(user);
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var usercontent = new StringContent(loanobj, UnicodeEncoding.UTF8, "application/json");
                    HttpResponseMessage httpmsg = await client.PostAsync("/api/UserLoginapi", usercontent);
                    

                    if (httpmsg.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Login");
                    }

                }
            }
            catch
            {

            }
            return View();
        }

        public ActionResult InPatient(string username)
        {
            return View();
        }

        public ActionResult OutPatient(string username)
        {
            return View();
        }


        public ActionResult Doctor(string username)
        {
            return View();
        }
        // GET: UserLogin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserLogin/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: UserLogin/Create
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

        // GET: UserLogin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserLogin/Edit/5
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

        // GET: UserLogin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserLogin/Delete/5
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
