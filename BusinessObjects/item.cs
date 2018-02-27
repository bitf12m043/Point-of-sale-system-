using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
   public  class item
    {
        //=======================================
        //Business object for items 
        //=======================================
        private int itemId;       
        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
       //=================================================
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        //=================================================
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        //=================================================
        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        //=================================================
        string creationDate;        
        public string CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }


    }
}
