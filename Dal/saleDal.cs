using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.IO;
namespace Dal
{
    public class saleDal
    {

        //=======================================
        //Add new sale
        //=======================================
        public void recordSale(SaleInfo obj)
        {
            string itemToAdd = obj.OrderId+ ";" + obj.CostumerId1 + ";" + obj.Creationdate+";"+obj.Status;
            FileStream add = new FileStream("Sale.txt", FileMode.Append);
            StreamWriter addItem = new StreamWriter(add);
            addItem.WriteLine(itemToAdd);
            addItem.Close();
            add.Close();
        }
        //=======================================
        //Add sale status
        //=======================================
        public void UpdateSaleRecord(List<SaleInfo> obj)
        {
            FileStream add = new FileStream("Sale.txt", FileMode.Create);
            StreamWriter addItem = new StreamWriter(add);
            for (int i = 0; i < obj.Count; i++)
            {
                string itemToAdd = obj[i].OrderId+ ";" + obj[i].CostumerId1+ ";" + obj[i].Creationdate+ ";" + obj[i].Status;
                addItem.WriteLine(itemToAdd);
            }
            addItem.Close();
            add.Close();
        }
        //=======================================
        //Add new sale line object list to file
        //=======================================
        public void saleLine(List<SaleLine> obj)
        {          
            
            FileStream add = new FileStream("SaleLineItem.txt", FileMode.Append);
            StreamWriter addItem = new StreamWriter(add);
            for (int i = 0; i < obj.Count; i++)
            {
                string itemToAdd=obj[i].LinoNo+";"+obj[i].Order_id+";"+obj[i].ItemId+";"+obj[i].Quantity+";"+obj[i].Amount;
                addItem.WriteLine(itemToAdd);
            }               
            addItem.Close();
            add.Close();
        }
        //=======================================
        //Return the info of all the sale
        //=======================================
        public List<SaleInfo> getAllSale()
        {
            StreamReader sr = new StreamReader("Sale.txt");
            List<SaleInfo> sales=new List<SaleInfo> ();
            string data;
            while ((data = sr.ReadLine()) != null)
            {
                string[] breaker = data.Split(';');
                
                    SaleInfo i = new SaleInfo();
                    i.OrderId = int.Parse(breaker[0]);
                    i.CostumerId1 = int.Parse(breaker[1]);
                    i.Creationdate = breaker[2];
                    i.Status = Boolean.Parse(breaker[3]);
                    
                    sales.Add(i);            

            }
            sr.Close();
            return sales;
        }
        //=======================================
        //Return the sale info against give order id
        //From sale line item
        //=======================================
        public List<SaleLine> getSaleByOrder(int order)
        {
            List<SaleLine> sal=new List<SaleLine>();
           
            StreamReader sr = new StreamReader("SaleLineItem.txt");
            string data;

            while ((data = sr.ReadLine()) != null)
            {
                string[] dataParser = data.Split(';');

                SaleLine s = new SaleLine();
                s.LinoNo=int.Parse(dataParser[0]);
                s.Order_id = int.Parse(dataParser[1]);
                s.ItemId = int.Parse(dataParser[2]);
                s.Quantity = int.Parse(dataParser[3]);
                s.Amount = double.Parse(dataParser[4]);

                if (s.Order_id.Equals(order))
                    sal.Add(s);

            }

            sr.Close();

            return sal;
        }
        //=======================================
        //Return the sale info against give order id
        //From sale file
        //=======================================
        public SaleInfo getInfo(int order_Id)
        {
            SaleInfo i = new SaleInfo();
            StreamReader sr = new StreamReader("Sale.txt");

            string data;
            while ((data = sr.ReadLine()) != null)
            {
                string[] breaker = data.Split(';');             
                   
                    i.OrderId = int.Parse(breaker[0]);
                    i.CostumerId1= int.Parse(breaker[1]);
                   i.Creationdate = breaker[2];
                    i.Status = Boolean.Parse(breaker[3]);
                    if (i.OrderId.Equals(order_Id))
                    {
                        sr.Close();
                        return i;
                    }
                

            }

            sr.Close();
            return i;
        }
    }

}
