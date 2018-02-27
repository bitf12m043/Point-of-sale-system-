using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class SaleLine
    {
        //=======================================
        //Object for saleLine item
        //=======================================
        private int order_id, itemId, quantity, linoNo;
        //=======================================
        public int LinoNo
        {
            get { return linoNo; }
            set { linoNo = value; }
        }
        //=======================================
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        //=======================================
        public int Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }
        //=======================================
        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        //=======================================
        private double amount;
        //=======================================
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

    }
}
