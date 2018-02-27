using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
   public class customer
    {

        //=======================================
        //Business objet for costumer
        //=======================================
        private int customerId;
        //=======================================
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        //=======================================
        private string name, address, phone, email;
        //=======================================
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        //=======================================
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        //=======================================
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        //=======================================
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //=======================================
        private double saleLimit;
        //=======================================
        public double SaleLimit
        {
            get { return saleLimit; }
            set { saleLimit = value; }
        }
       //========================================
        private double payables;
        //=======================================
        public double Payables
        {
            get { return payables; }
            set { payables = value; }
        }      
    }
}
