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

        public PATIENT GetPATIENTs(int id)
        {
            return context.PATIENTs.Find(id);
        }

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
    }
}
