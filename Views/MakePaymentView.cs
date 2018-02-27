using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BLL;
namespace Views
{
    public class MakePaymentView
    {
        private int orderId;
        private MakePaymentBll record;

        //========================================
        // Ask the user enter sale id to make payment       
        //========================================
        public void MakePayment()
        {
            record = new MakePaymentBll();
            Console.Clear();
            int id = 0;
            Boolean ok = false;
            while (!ok)
            {
                try
                {
                    Console.Write("Enter sale id:");
                    id = int.Parse(Console.ReadLine());
                    ok = true;
                }
                catch
                {
                    ok = false;
                }
            }

            orderId = id;

            record.startPayment(orderId);
            showData();
            addAmount();
            
        }
        //========================================
        // Shoe detail of previous payment against 
        //given sale id
        //========================================
        void showData()
        {
            double total = record.getTotal();
            double payed = record.getPaid();
            Console.WriteLine("Sale id :{0}", orderId);
            Console.WriteLine("Name: {0}", record.Customer_Name());
            Console.WriteLine("Total: {0}", total);
            Console.WriteLine("Payed: {0}",payed);            
            Console.WriteLine("Remaining Amount:{0}", (total-payed));

        }
        //========================================
        // Ask the user to enter amount to 
        //pay against the give sale id
        //========================================
        void addAmount()
        {
           
            double amount = 0;
            Boolean ok = false;
            while (!ok)
            {
                try
                {
                    Console.Write("Amount to be payed:}");
                    amount= double.Parse(Console.ReadLine());
                    ok = true;
                }
                catch
                {
                    ok = false;
                }
            }
            record.update(amount);

            Console.WriteLine("Press any key to go back to main");
            Console.ReadKey();
        }
    }
}
