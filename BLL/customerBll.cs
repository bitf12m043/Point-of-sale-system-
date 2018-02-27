using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Dal;
namespace BLL
{
  public  class customerBll
    {
        private List<customer> data;
        private CounterDal count;
        private CustomerDal customer;    
         //=======================================
         //Constructor for this class
        //=======================================
        public customerBll()
        {
           
            count = new CounterDal();
            customer = new CustomerDal();
            data = customer.getCostumers();
        }
        //=======================================
        //Add new costumer to file      
        //=======================================
        public void addCustomer(customer obj)
        {
            
            obj.Payables = 0;
            data.Add(obj);
            customer.addCostumer(obj);
        }
        //=======================================
        //Search costumer by id
        //=======================================
        public customer Search(int id)
       {
           if (data != null)
           {
               for (int i = 0; i < data.Count; i++)
                   if (data[i].CustomerId.Equals(id))
                   {
                       
                       return data[i];
                   }
           }
           else
               Console.WriteLine("data is null");

           return null;

       }
        //=======================================
        //Update existing costumer
        //=======================================
        public void updateCustomer(customer obj)
        {
           
            customer.updateCostumer(data);
        }
        //=======================================
        //Remove existing costumer
        //=======================================
        public bool removeCustomer(customer obj)
        {
            if (obj.Payables.Equals(0))
            {
                data.Remove(obj);                
                customer.updateCostumer(data);
                return true;
            }
            return false;
        }
        //=======================================
        //Search costumer by id
        //=======================================
        public List<customer> findCostumerById(int id)
        {
            List<customer> cus = new List<customer>();
            for (int i = 0; i < data.Count; i++)
                if (data[i].CustomerId.Equals(id))
                {
                    cus.Add(data[i]);
                    
                }
            return cus;
        }
        //=======================================
        //Search costumer by name
        //=======================================
        public List<customer> findByName(string name)
        {
            List<customer> cus = new List<customer>();
            for (int i = 0; i < data.Count; i++)
                if (data[i].Name.Equals(name))
                {
                    cus.Add(data[i]);

                }
            return cus;
        }
        //=======================================
        //Search costumer by phone number
        //=======================================
        public List<customer> findByPhone(string phonenum)
        {
            List<customer> cus = new List<customer>();
            for (int i = 0; i < data.Count; i++)
                if (data[i].Phone.Equals(phonenum))
                {
                    cus.Add(data[i]);

                }
            return cus;
        }
        //=======================================
        //Search costumer by email
        //=======================================
        public List<customer> findByEmail(string email_Id)
        {
            List<customer> cus = new List<customer>();
            for (int i = 0; i < data.Count; i++)
                if (data[i].Email.Equals(email_Id))
                {
                    cus.Add(data[i]);

                }
            return cus;
        }
        //=======================================
        //Return counter type object
        //=======================================
        public Counters getCounter()
        {
            return count.getItemCounter();
        }
        //=======================================
        //Search costumer by sale limit
        //=======================================
        public List<customer> findBySaleLimit(double saleLimit)
        {
            Console.WriteLine("In limit");
            List<customer> cus = new List<customer>();
            for (int i = 0; i < data.Count; i++)
                if (data[i].SaleLimit.Equals(saleLimit))
                {
                    Console.WriteLine("In limit");
                    cus.Add(data[i]);

                }
            return cus;
        }
        //=======================================
        //Update counters in the file
        //=======================================
        public void updateCounters(Counters c)
        {
            count.updateCountes(c);
        }
    }

}
