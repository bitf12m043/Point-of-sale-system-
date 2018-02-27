   //This is the main view in View Layer
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BLL;
    using BusinessObjects;
    namespace Views
    {
        public class MainMenu
        {
            ItemView itemsHandler;
            CustomerView customerHandler;
            MakeSaleView sales;
            MakePaymentView payment;
            //========================================
            // Costructor for this class
            //========================================
            public MainMenu()
            {
                itemsHandler = new ItemView();
                customerHandler = new CustomerView();
           
            }
            //========================================
            // Show the main menu
            //========================================
            public void mainMenu()
            {
                //Console.Clear();
                int choice = 0;
                Boolean ok = false;
                Console.WriteLine("1-Manage items");
                Console.WriteLine("2-Manage costumer");
                Console.WriteLine("3-Make new sale");
                Console.WriteLine("4-Make Payment");
                Console.WriteLine("5-Exit");
           
                while (!ok)
                {
                    Console.WriteLine("Enter choice");
                    String key = Console.ReadLine();
                    try
                    {
                        choice = int.Parse(key);
                        ok = true;
                    }
                    catch
                    {
                        ok = false;
                    }
                    if (choice > 5 || choice < 1)
                        ok = false;
                }


                if (choice == 1)
                    itemsHandler.itemMenu();
                if (choice == 2)
                    customerHandler.customerMenu();
                if (choice == 3)
                {
                    sales = new MakeSaleView();
                    sales.makeSale();
                }
                if (choice == 4)
                {
                    payment = new MakePaymentView();
                    payment.MakePayment();
                
                }
                if (choice == 5)
                    System.Environment.Exit(0);

                mainMenu();
            
                }
        }
    }
