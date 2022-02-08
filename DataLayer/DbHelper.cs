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


    }
}
