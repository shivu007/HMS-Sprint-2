using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DbHelper
    {
        public HMSEntities context = new HMSEntities();
        /*---------------------------------------------------------Patients-----------------------------------------------------------*/
        public List<PATIENT> GetPATIENTs()
        { 
            return context.PATIENTs.ToList();
        }

       
        //public PATIENT GetPATIENTs(string id)
        //{
        //    var pid = context.PATIENTs.FirstOrDefault(i => i.PID == id);
        //    if (pid != null)
        //    { 
        //        return pid;
        //    }
        //    return null;
        //}

        public bool AddPatient(PATIENT patient)
        {
            try
            {

                context.PATIENTs.Add(patient);
                context.SaveChanges();
                return true;
            }
            catch 
            {
                
            }
            return false;
        }


        /*---------------------------------------------------------User-----------------------------------------------------------*/
        public bool AddUser(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChangesAsync();
                return true;
            }
            catch
            {

            }
            return false;
        }

        public User ValidateUser(string username, string password)
        {
            var u = context.Users.FirstOrDefault(us => us.Username == username && us.Pass == password);
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public User GetUsers(string uname)
        {
            return context.Users.FirstOrDefault(u=> u.Username == uname);
        }

        public List<User> GetUser()
        {
            return context.Users.ToList();
        }
        /*---------------------------------------------------------Appointment-----------------------------------------------------------*/
        public List<APPOINTMENT> GetAppointnments()
        {
            return context.APPOINTMENTs.ToList();
        }

        public bool AddAppointment(APPOINTMENT appointment)
        {
            try
            {
                context.APPOINTMENTs.Add(appointment);
                context.SaveChanges();
                return true;
            }
            catch
            {

            }
            return false;
        }

        public APPOINTMENT GetAppointnments(string appid)
        {
            return context.APPOINTMENTs.Find(appid);
        }

        /*---------------------------------------------------------Doctor-----------------------------------------------------------*/
        public List<DOCTOR> GetDoctors()
        {
            return context.DOCTORs.ToList();
        }

        public bool AddDoctor(DOCTOR doctor)
        {
            try
            {
                context.DOCTORs.Add(doctor);
                context.SaveChanges();
                return true;
            }
            catch
            {

            }
            return false;

        }

        /*---------------------------------------------------------Test-----------------------------------------------------------*/
        public List<Test> GetTests()
        {
            return context.Tests.ToList();
        }

        public bool AddTest(Test test)
        {
            try
            {
                context.Tests.Add(test);
                context.SaveChanges();
                return true;
            }
            catch
            {

            }
            return false;

        }
        /*---------------------------------------------------------OBILL-----------------------------------------------------------*/
        public List<OBILL> GetOBILLs()
        {
            return context.OBILLs.ToList();
        }

        public bool AddOBILL(OBILL oBILL)
        {
            try
            {
                context.OBILLs.Add(oBILL);
                context.SaveChanges();
                return true;
            }
            catch
            {

            }
            return false;

        }
        /*---------------------------------------------------------IBILL-----------------------------------------------------------*/
        public List<IBILL> GetIBILLs()
        {
            return context.IBILLs.ToList();
        }

        public bool AddIBILL(IBILL iBILL)
        {
            try
            {
                context.IBILLs.Add(iBILL);
                context.SaveChanges();
                return true;
            }
            catch
            {

            }
            return false;

        }
        /*---------------------------------------------------------OutPatient-----------------------------------------------------------*/
        public List<OPATIENT> GetOPATIENT()
        {
            return context.OPATIENTs.ToList();
        }

        public bool AddOPATIENT(OPATIENT oPATIENT)
        {
            try
            {
                context.OPATIENTs.Add(oPATIENT);
                context.SaveChanges();
                return true;
            }
            catch
            {

            }
            return false;

        }

        //public OPATIENT GetOPatients(string opid)
        //{
        //    return context.OPATIENTs.Find(opid);
        //}
    }
}
