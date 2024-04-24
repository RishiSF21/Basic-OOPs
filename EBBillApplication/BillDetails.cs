using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBillApplication
{
    public class BillDetails
    {   
        private static int m_meterID = 2300;
        public BillDetails(){
            m_meterID++;
            MeterID = "EBB"+ m_meterID;
        }
        
        public string MeterID { get; set; }
        public static int Unit {get; set;}
        public string UserName { get; set; }
        public long Phone { get; set; }
        public string MailID { get; set; }

    }
}