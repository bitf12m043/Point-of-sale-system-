using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using BusinessObjects;
namespace BLL
{
    public class MakePaymentBll
    {
       private double total,payed,currentpayment;
        private customerBll c_info;
        private Counters count;
        private ReceiptDal r_add;
        private customer c;
         private SaleInfo s;
         private saleDal info;

         //=======================================
         //Start new payment
         //=======================================
        public void startPayment(int order_id)
        {
           
            r_add = new ReceiptDal();
            info=new saleDal();
            s= info.getInfo(order_id);
            c_info = new customerBll();
            c = c_info.Search(s.CostumerId1);
            calculateTotal();
            calCulatePayed();

            
        }
        //=======================================
        //Return total against given sale id
        //=======================================
        public double getTotal()
        {
              return total;
        }
        //=======================================
        //Return total of receipt against given sale id
        //=======================================
        public double getPaid()
        {
            return payed;

        }
        //=======================================
        //Return costumer name
        //=======================================
        public string Customer_Name()
        {
            return c.Name;
        }
        //=======================================
        //Calculate the total of give sale id
        //=======================================
        public void calculateTotal()
        {
            List<SaleLine> totalCal = info.getSaleByOrder(s.OrderId);

            for (int i = 0; i < totalCal.Count; i++)
                total += (totalCal[i].Quantity * totalCal[i].Amount);
        }
        //=======================================
        //Calculate total payed against the give sale 
        //id 
        //=======================================
        public void calCulatePayed()
        {
            payed = 0;
            List<Receipt> r_p = r_add.getReciepts(s.OrderId);

            if (r_p != null)
            {
                Console.WriteLine("i cal payed");

                for (int i = 0; i < r_p.Count; i++)
                {
                    payed += r_p[i].Amount;
                    Console.WriteLine("i cal payed", r_p[i].Amount);
                }

            }
        }
        //=======================================
        //Record new payment
        //=======================================
        public void update(double payment)
        {
            c.Payables -= payment;
            c_info.updateCustomer(c);
            count = c_info.getCounter();            
            Receipt r = new Receipt();
            count.RecieptNo = count.RecieptNo + 1;
            r.R_id = (count.RecieptNo);
            r.Order_id = s.OrderId;
            r.Amount = payment;
            c_info.updateCounters(count);
            DateTime dt = DateTime.Now;
            string dta = dt.ToString("d");
            r.Creationdate = dta;
            r_add.SaveReceipt(r);

            if ((total - payed) - payment <= 0)
                updateStatus();

        }
        //=======================================
        //Update the satus in sale file 
        //If all the payment is clear
        //=======================================
        public void updateStatus()
        {
            List<SaleInfo> li = info.getAllSale();

            for (int i = 0; i < li.Count; i++)
                if (li[i].OrderId.Equals(s.OrderId))
                    li[i].Status = true;

            info.UpdateSaleRecord(li);
        }
    }
}
