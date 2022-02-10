using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DbHelper
    {
        
        public HMSEntities context = new HMSEntities();
        /*---------------------------------------------------------Patients-----------------------------------------------------------*/
        
        int ipid;
        string spid;
        public List<PATIENT> GetPATIENTs()
        {
            ipid = GeTLASTGENID();
            
            return context.PATIENTs.ToList();
        }
        public int GeTLASTGENID()
        {
            ObjectParameter returnId = new ObjectParameter("pid", typeof(int));

            var value= context.last_generated_id(returnId);
            int id = Convert.ToInt32(returnId.Value);
            return id;
        }
        public string lastgenid()
        {
      
            ipid++;
            if (ipid < 10)
                spid = "P00" + ipid;
            else if (ipid < 100)
                spid = "P0" + ipid;
            else
                spid = "P" + ipid;
            return spid;

           
        }

        public bool AddPatient(PATIENT patient)
        {
            ipid = GeTLASTGENID();
            spid = lastgenid();
            patient.PID = spid;
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

        int iaid;
        string said;

        public List<APPOINTMENT> GetAppointnments()
        {
            iaid = GeTLASTGENAID();
            return context.APPOINTMENTs.ToList();
        }


        public int GeTLASTGENAID()
        {
            ObjectParameter returnId = new ObjectParameter("appid", typeof(int));

            var value = context.last_generated_Appoinmentid(returnId);
            int id = Convert.ToInt32(returnId.Value);
            return id;
        }
        public string lastgenaid()
        {

            iaid++;
            if (iaid < 10)
                said = "A00" + iaid;
            else if (iaid < 100)
                said = "A0" + iaid;
            else
                said = "A" + iaid;
            return said;


        }

        public bool AddAppointment(APPOINTMENT appointment)
        {

            iaid = GeTLASTGENAID();
            said = lastgenaid();
            appointment.AppointmentID = said;
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

        int idid;
        string sdid;
        public List<DOCTOR> GetDoctors()
        {

            idid = GeTLASTGENDID();
            return context.DOCTORs.ToList();
        }

        public int GeTLASTGENDID()
        {
            ObjectParameter returnId = new ObjectParameter("Did", typeof(int));

            var value = context.last_generated_Doctorid(returnId);
            int id = Convert.ToInt32(returnId.Value);
            return id;
        }
        public string lastgendid()
        {

            idid++;
            if (idid < 10)
                sdid = "D00" + idid;
            else if (iaid < 100)
                sdid = "D0" + idid;
            else
                sdid = "D" + idid;
            return sdid;


        }
        public bool AddDoctor(DOCTOR doctor)
        {
            idid = GeTLASTGENDID();
            sdid = lastgendid();
            doctor.DID = sdid;
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
        int itid;
        string stid;
        public List<Test> GetTests()
        {
            itid = GeTLASTGENTID();
            return context.Tests.ToList();
        }

        public int GeTLASTGENTID()
        {
            ObjectParameter returnId = new ObjectParameter("Labid", typeof(int));

            var value = context.last_generated_Labid(returnId);
            int id = Convert.ToInt32(returnId.Value);
            return id;
        }
        public string lastgentid()
        {

            itid++;
            if (itid < 10)
                stid = "L00" + itid;
            else if (itid < 100)
                stid = "L0" + itid;
            else
                stid = "L" + itid;
            return stid;


        }
        public bool AddTest(Test test)
        {
            itid = GeTLASTGENTID();
            stid = lastgentid();
            test.LabID = stid;
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
        int iOBid;
        string sOBid;
        public List<OBILL> GetOBILLs()
        {
            iOBid = GeTLASTGENOBID();
            return context.OBILLs.ToList();
        }
        public int GeTLASTGENOBID()
        {
            ObjectParameter returnId = new ObjectParameter("billOUTid", typeof(int));

            var value = context.last_generated_OUTBillid(returnId);
            int id = Convert.ToInt32(returnId.Value);
            return id;
        }
        public string lastgenobid()
        {

            iOBid++;
            if (iOBid < 10)
                sOBid = "BO00" + iOBid;
            else if (iOBid < 100)
                sOBid = "BO0" + iOBid;
            else
                sOBid = "BO" + iOBid;
            return sOBid;


        }
        public bool AddOBILL(OBILL oBILL)
        {
            iOBid = GeTLASTGENOBID();
            sOBid = lastgenobid();
            oBILL.BillNo = sOBid;
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
        int iIBid;
        string sIBid;
        public List<IBILL> GetIBILLs()
        {
            iIBid = GeTLASTGENIBID();
            return context.IBILLs.ToList();
        }
        public int GeTLASTGENIBID()
        {
            ObjectParameter returnId = new ObjectParameter("billINid", typeof(int));

            var value = context.last_generated_INBillid(returnId);
            int id = Convert.ToInt32(returnId.Value);
            return id;
        }
        public string lastgenibid()
        {

            iIBid++;
            if (iIBid < 10)
                sIBid = "BI00" + iIBid;
            else if (iIBid < 100)
                sIBid = "BI0" + iIBid;
            else
                sIBid = "BI" + iIBid;
            return sIBid;


        }
        public bool AddIBILL(IBILL iBILL)
        {
            iIBid = GeTLASTGENIBID();
            sIBid = lastgenibid();
            iBILL.BillNo = sIBid;
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
        int iopid;
        string sopid;
        public List<OPATIENT> GetOPATIENT()
        {
            iopid = GeTLASTGENOPID();
            return context.OPATIENTs.ToList();
        }
        public int GeTLASTGENOPID()
        {
            ObjectParameter returnId = new ObjectParameter("OPid", typeof(int));

            var value = context.last_generated_OpatientId(returnId);
            int id = Convert.ToInt32(returnId.Value);
            return id;
        }
        public string lastgenopid()
        {

            iopid++;
            if (iopid < 10)
                sopid = "BI00" + iopid;
            else if (iopid < 100)
                sopid = "BI0" + iopid;
            else
                sopid = "BI" + iopid;
            return sopid;


        }

        public bool AddOPATIENT(OPATIENT oPATIENT)
        {
            iopid = GeTLASTGENOPID();
            sopid = lastgenopid();
            oPATIENT.ADMISSIONID = sopid;
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
