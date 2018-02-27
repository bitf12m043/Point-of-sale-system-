using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
   public  class SaleInfo
    {
        //=======================================
        //Business object for sale saving
        //=======================================
        int orderId, CostumerId;
        //=======================================
        public int CostumerId1
        {
            get { return CostumerId; }
            set { CostumerId = value; }
        }
        //=======================================
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        //=======================================
        private Boolean status;
        //=======================================
        public Boolean Status
        {
            get { return status; }
            set { status = value; }
        }
        //=======================================
        private string creationdate;
        //=======================================
        public string Creationdate
        {
            get { return creationdate; }
            set { creationdate = value; }
        }
    }
}
