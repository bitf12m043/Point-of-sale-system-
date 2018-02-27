//This Business Logic is used for making sale 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Dal;
namespace BLL
{
    public class saleBll
    {
        private customerBll c_Info;
        private List<SaleLine> saleLineItems;
        private List<item> itemPurchased;
        private ItemBll i_Info;
        private customer purchaser;
        private saleDal recordDate;
        private CounterDal countReader;
        private Counters count;
        //========================================
        //Constructor of this class 
        //========================================
        public saleBll()
        {           
            c_Info = new customerBll();
            i_Info = new ItemBll();
            recordDate=new saleDal();
            itemPurchased = new List<item>();
            countReader = new CounterDal();
            count = new Counters();
            count = countReader.getItemCounter();      
            
        }
        //========================================
        //RecordCostumer() save the information of the 
        //costumer who is purchasing items
        //========================================
        public void recordCustomer(int id)
        {
            saleLineItems = new List<SaleLine>();
            purchaser = c_Info.Search(id);
            count.OrderCounter = count.OrderCounter + 1;
        }
        //========================================
        // addItemToList() is saving the information of the 
        //item that is being purchased
        //========================================
        public item addItemToList(int itemId)
        {
            item c=i_Info.Search(itemId);
            item obj = new item();
            obj.ItemId = c.ItemId;
            obj.Price = c.Price;
            obj.Quantity = 0;
            obj.Description = c.Description;
            itemPurchased.Add(obj);
            return obj;
        }
        //========================================
        // updateQuantity(int id, int quantity) is updating item quantity 
        //in the file
        //========================================
        public bool updateQuantity(int id, int quantity)
        {
            
            item c = i_Info.Search(id);
            if (c.Quantity >= quantity)
            {
                c.Quantity = c.Quantity - quantity;
                // i_Info.updateItem();
                SaleLine s = new SaleLine();
                count.LineNo = count.LineNo + 1;
                s.LinoNo = count.LineNo;
                s.Order_id = count.OrderCounter;
                s.Quantity = quantity;
                s.Amount = c.Price;
                s.ItemId = id;
                saleLineItems.Add(s);
                i_Info.updateItem();

                return true;
            }


            return false;
        }
        //========================================
        //Total() calulating the total of current items that are purchased
        //========================================
        public double Total()
        {
            double total = 0.0;
            for (int i = 0; i < saleLineItems.Count; i++)
            {
                total += (saleLineItems[i].Quantity * saleLineItems[i].Amount);
            }

            return total;
        }
        //========================================
        //getCustomer() return the costumer who is purchasing items
        //========================================
        public customer getCustomer()
        {
            return purchaser;
        }
        //========================================
        //getAllItems()return all the items purchased
        //========================================
        public List<item> getAllItems()
        {
            return itemPurchased;
        }
        public List<SaleLine> getItemPurchsed()
        {
            return saleLineItems;
        }
        //========================================
        // get() return the counter type object
        //========================================
        public Counters get()
        {
            return count;
        }
        //========================================
        // update() Add the total of current bill in costumer payables and save sale information
        //========================================
        public void update(string dta)
        {

            purchaser.Payables = purchaser.Payables + Total();
            c_Info.updateCustomer(purchaser);
            SaleInfo s = new SaleInfo();
            s.CostumerId1 = purchaser.CustomerId;
            s.OrderId = count.OrderCounter;
            s.Creationdate = dta;
            s.Status = false;
            recordDate.recordSale(s);
            recordDate.saleLine(saleLineItems);            
            itemPurchased = null;
            
        }
        //========================================
        // setCounter() update the counters in the file 
        //========================================
        public void setCounter()
        {
            countReader.updateCountes(count);
        }
        //========================================
        // removeItem() remove any item from the items purchsed and again update items quantity in the file
        //========================================
        public void removeItem(int id)
        {
            Boolean found = false;
            int countIndex=0;
            for (int i = 0; i < saleLineItems.Count; i++)
            {
                if (saleLineItems[i].ItemId.Equals(id))
                {
                    found = true;
                    countIndex=i;
                    item c = i_Info.Search(id);
                    c.Quantity += saleLineItems[i].Quantity;
                    i_Info.updateItem();
                    saleLineItems.Remove(saleLineItems[i]);
                    
                }
            }

            if (found)
            {
                for (int i =countIndex ; i < saleLineItems.Count; i++)
                {
                    saleLineItems[i].LinoNo = saleLineItems[i].LinoNo - 1;
                }
                count.LineNo -= 1;
            }

        }
        //========================================
        // getOrderCount() return the current order id 
        //========================================
        public int getOrderCount()
        {
            return count.OrderCounter;
        }
        //========================================
        // Cancel() Cancel the current sale
        //========================================
        public void Cancel()
        {
            for (int i = 0; i < itemPurchased.Count; i++)
            {
                item c = i_Info.Search(itemPurchased[i].ItemId);
                c.Quantity += itemPurchased[i].Quantity;

            }

            i_Info.updateItem();
        }
    }
}
