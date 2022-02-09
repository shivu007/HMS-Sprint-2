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
            var u = context.Users.FirstOrDefault(us => us.Username == username && us.Pass == password );
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
    }
}
