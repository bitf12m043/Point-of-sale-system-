using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Dal;
namespace BLL
{
    public class ItemBll
    {
        private List<item> data;
        CounterDal DataCount;
        itemDal itemdal;
        //========================================
        //Constructor of this class 
        //========================================
        public ItemBll()
        {
            itemdal = new itemDal();
            data = itemdal.getItem();
            DataCount = new CounterDal();
        }
        //========================================
        //addItem(item obj) add new item to file 
        //========================================
        public void addItem(item obj)
        {
            data.Add(obj);
            itemdal.addOneItems(obj);
        }
        //========================================
        //updateItem() update the existing item 
        //========================================
        public void updateItem()
        {
            itemdal.updateItems(data);
        }
        //========================================
        //removeItem() remove the existing item 
        //========================================
        public bool removeItem(item obj)
        {
            if (obj.Quantity.Equals(0))
            {
                data.Remove(obj);
                itemdal.updateItems(data);
                return true;
            }

            return false;
        }
        //========================================
        //  findByDate(string date) find the existing
        //item based on addition date 
        //========================================     
        public List<item> findByDate(string date)
        {
            return null;
        }
        //========================================
        // Search(int id) find the existing
        //item based on its id 
        //======================================== 
        public item Search(int id)
        {
            if (data != null)
            {
                for (int i = 0; i < data.Count; i++)
                    if (data[i].ItemId.Equals(id))
                    {

                        return data[i];
                    }
            }
            else
                Console.WriteLine("data is null");

            return null;

        }
        //========================================
        // findByDescription(string description) find 
        //the existing item based on its name 
        //========================================
        public List<item> findByDescription(string description)
        {
            List<item> il = new List<item>();

            for (int i = 0; i < data.Count; i++)
                if (data[i].Description.Equals(description))
                {
                    il.Add(data[i]);
                   
                }

            return il;
        }
        //========================================
        // findByPrice(double price ) find 
        //the existing item based on its price 
        //========================================
        public List<item> findByPrice(double price )
        {
            List<item> il = new List<item>();

            for (int i = 0; i < data.Count; i++)
                if (data[i].Price.Equals(price))
                {
                    
                    il.Add(data[i]);

                }

            return il;
        }
        //========================================
        // findByquantity(int q) find 
        //the existing item based on its quantity
        //========================================
        public List<item> findByquantity(int q)
        {
            List<item> il = new List<item>();


            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Quantity.Equals(q))
                {
                    il.Add(data[i]);

                }
            }
            return il;
        }
        //========================================
        // getCounter() return counter type object         
        //========================================
        public Counters getCounter()
        {
            return DataCount.getItemCounter();
        }
        //========================================
        // updateCounter() update counter in ths file         
        //========================================
        public void updateCounters(Counters c)
        {
            DataCount.updateCountes(c);
        }
        //========================================
        // Return a list of all existing items       
        //========================================
        public List<item> getItem()
        {
            return data;
        }

    }
}
