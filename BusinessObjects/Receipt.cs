using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Receipt
    {
        //=======================================
        //Business object for savinf reciept
        //=======================================
        private int r_id, order_id;
        //=======================================
        public int Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }
        //=======================================
        public int R_id
        {
            get { return r_id; }
            set { r_id = value; }
        }
        //=======================================
        private double amount;
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        //=======================================
        private string creationdate;
        public string Creationdate
        {
            get { return creationdate; }
            set { creationdate = value; }
        }

        
    }
}
