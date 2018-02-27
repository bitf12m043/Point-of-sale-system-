    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BusinessObjects;
    using BLL;
    namespace Views
    {
       public  class CustomerView
        {
           private customerBll dataBll;
           //========================================
           // Constructor for this class        
           //========================================
           public CustomerView()
           {
              dataBll = new customerBll();
           }
           //========================================
           // customerMenu() main menu of costumer 
           //management      
           //========================================
            public void customerMenu()
            {
                //Console.Clear();
                int choice = 0;
                Boolean ok = false;
                Console.WriteLine("1-Add new customer");
                Console.WriteLine("2-Update costumer detail");
                Console.WriteLine("3-Find customer");
                Console.WriteLine("4-Remove customer item");
                Console.WriteLine("5-Back to main");

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
                    addCustomer();
                if (choice == 2)
                    UpdateCustomer();
                if (choice == 3)
                    FindCustomer();
                if (choice == 4)
                    removeCustomer();
                if (choice == 5)
                    return;
            }
            //========================================
            // addCustomer() take input to add new
            //costumer      
            //========================================
            private void addCustomer()
            {
                customer data = new customer();
                Counters c =dataBll.getCounter();
                int newCount = c.CostumerCounter;
                newCount++;
                c.CostumerCounter = newCount;
                data.CustomerId = c.CostumerCounter;
                Console.WriteLine("Id: {0}",c.CostumerCounter);
                Console.Write("Enter name:");
                data.Name = Console.ReadLine();
                Console.Write("Enter Address:");
                data.Address = Console.ReadLine();
                Console.Write("Enter phone number:");
                data.Phone = Console.ReadLine();
                Console.Write("Enter Email:");
                data.Email = Console.ReadLine();

                Boolean ok = false;
                while (!ok)
                {
                    Console.Write("Enter Sale limit:");
                    try
                    {
                        data.SaleLimit = double.Parse(Console.ReadLine());
                        ok=true;
                    }
                    catch
                    {
                        ok = false;
                    }
                }
                dataBll.addCustomer(data);
                dataBll.updateCounters(c);
                customerMenu();
            }
            //========================================
            // updateCustomer() take input to update 
            // existing costumer      
            //========================================
            private void UpdateCustomer()
            {           
                int id=0;
                Boolean ok = false;
                while (!ok)
                {               
                    try
                    {
                        Console.Write("Enter id to update costumer data");
                         id= int.Parse(Console.ReadLine());
                        ok = true;
                    }
                    catch
                    {
                        ok = false;
                    }
                }
                customer c = dataBll.Search(id);

                Show(c);
                //====================================================
               //customer data = new customer();
              // Counters c = dataBll.getCounter();

               Console.WriteLine("Do you want to update information");
               string choice = "n";
               choice = Console.ReadLine();

               if (choice == "y" || choice == "Y")
               {
                   Console.WriteLine("Id: {0}", c.CustomerId);
                   Console.Write("Enter name:");
                   c.Name = Console.ReadLine();
                   Console.Write("Enter Address:");
                   c.Address = Console.ReadLine();
                   Console.Write("Enter phone number:");
                   c.Phone = Console.ReadLine();
                   Console.Write("Enter Email:");
                   c.Email = Console.ReadLine();

                   Boolean ok1 = false;
                   while (!ok1)
                   {
                       Console.Write("Enter Sale limit:");
                       try
                       {
                           c.SaleLimit = double.Parse(Console.ReadLine());
                           ok1 = true;
                       }
                       catch
                       {
                           ok1 = false;
                       }
                   }
                   dataBll.updateCustomer(c);
               }

                customerMenu();
            }
            //========================================
            // removeCustomer() take costumer id to add 
            //existing costumer      
            //========================================
            private void removeCustomer()
            {
                Console.Write("Enter costumer id to remove costumer");
                int id = 0;
                Boolean ok = false;
                while (!ok)
                {
                    try
                    {
                        Console.Write("Enter id to update costumer data");
                        id = int.Parse(Console.ReadLine());
                        ok = true;
                    }
                    catch
                    {
                        ok = false;
                    }
                }
                customer c = dataBll.Search(id);

                if (c != null)
                {
                    Console.WriteLine("Do you want to do you want to information");
                    string choice = "n";
                    choice = Console.ReadLine();

                    if (choice == "y" || choice == "Y")
                    {
                        if(dataBll.removeCustomer(c))
                            Console.WriteLine("Costumer deleted");
                        else
                            Console.WriteLine("Costumer can not be deleted");

                    }
                }
                customerMenu();
            }
            //========================================
            // show() it shows costumer information                
            //========================================
            private void Show(customer c)
            {
                Console.Clear();
                if (c != null)
                {
                    Console.WriteLine("Id:" + c.CustomerId);
                    Console.WriteLine("Name:" + c.Name);
                    Console.WriteLine("Address:" + c.Address);
                    Console.WriteLine("Phone:" + c.Phone);
                    Console.WriteLine("Email:" + c.Email);
                    Console.WriteLine("Sale limit:" + c.SaleLimit);
                }
                else
                    Console.WriteLine("object not exist");
            }
            //========================================
            // FindCustomer() take any costumer attribute 
            //to find costumer      
            //========================================
            private void FindCustomer()
            {

                customer data = new customer();

                Console.Write("Enter Id:");
                string id = Console.ReadLine();
                if (id.Length.Equals(0))
                {
                
                    data.CustomerId = -1;
                }
                else
                {
                    try
                    {
                        data.CustomerId = int.Parse(id);
                        //Show(dataBll.Search(data.CustomerId));
                    }
                    catch
                    {
                        data.CustomerId = -1;
                    }
                }
                Console.Write("Enter name:");
                data.Name = Console.ReadLine();
            
                Console.Write("Enter Address:");
                data.Address = Console.ReadLine();
                Console.Write("Enter phone number:");
                data.Phone = Console.ReadLine();
                Console.Write("Enter Email:");
                data.Email = Console.ReadLine();
                Console.Write("Enter Sale Limit:");

                string limit = Console.ReadLine();
                if (limit.Length.Equals(0))
                    data.SaleLimit = -1;
                else
                {
                    try
                    {
                        data.SaleLimit = double.Parse(limit);
                    }
                    catch
                    {
                        data.SaleLimit = -1;
                    }
                }

                /*if (data.CustomerId.Equals(-1) && data.Email.Length.Equals(0) && data.Name.Length.Equals(0)
                    && data.Address.Length.Equals(0) && data.Phone.Length.Equals(0) && data.SaleLimit.Equals(-1))
                {
                    customerMenu();
                }*/

                if (!(data.CustomerId.Equals(-1)))
                    Show(dataBll.Search(data.CustomerId));
                else if (!(data.Name.Length.Equals(0)))
                    dataBll.findByName(data.Name);
                else if (!(data.Email.Length.Equals(0)))
                    ShowList(dataBll.findByEmail(data.Email));            
                else if (!(data.Phone.Length.Equals(0)))
                    ShowList(dataBll.findByPhone(data.Phone));
                else if (!(data.SaleLimit.Equals(-1)))
                    ShowList(dataBll.findBySaleLimit(data.SaleLimit));

                customerMenu();

            }
            //========================================
            // ShowList() show all the costumer in given 
            //List     
            //========================================
            private void ShowList(List<customer> datac)
            {
                if (datac.Count.Equals(0))
                    Console.WriteLine("No record found");
                else
                {
                    for (int i = 0; i < datac.Count; i++)
                    {
                        Console.WriteLine("Id:" + datac[i].CustomerId);
                        Console.WriteLine("Name:" + datac[i].Name);
                        Console.WriteLine("Address:" + datac[i].Address);
                        Console.WriteLine("Phone:" + datac[i].Phone);
                        Console.WriteLine("Email:" + datac[i].Email);
                        Console.WriteLine("Sale limit:" + datac[i].SaleLimit);
                    }
                }
            }
        }
    }
