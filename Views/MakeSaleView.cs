//This View is used for sale management
using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BLL;
    using BusinessObjects;
    namespace Views
    {
        class MakeSaleView
        {
            private saleBll record;
            private string dta;
            private customer c;
            private Counters SaleId;
            //========================================
            // Constructor for this class       
            //========================================
            public MakeSaleView()
            {
                record = new saleBll();
            }
            //========================================
            // Ask the user to enter costumer id to
            //start sale
            //========================================
            public void makeSale()
            {
                DateTime dt = DateTime.Now;
                dta = dt.ToString("d");
                SaleId = record.get();           
                Console.WriteLine("Sale Id:" + SaleId.OrderCounter);
                Console.WriteLine("Sale date:" + dta);
                //-----------------------------------------
                int id = 0;
                Boolean ok = false;
                while (!ok)
                {
                    try
                    {
                        Console.Write("Enter Customer id:");
                        id = int.Parse(Console.ReadLine());
                        ok = true;
                    }
                    catch
                    {
                        ok = false;
                    }
                }
                 record.recordCustomer(id);
                c = record.getCustomer();
            
                addNewItem();
            }
            //========================================
            // Show sale menu       
            //========================================
            public void SaleMenu()
                {
                    int choice = 0;
                    Boolean ok = false;
                    Console.WriteLine("\n\n\n1-Enter new item:");
                    Console.WriteLine("2-End sale");
                    Console.WriteLine("3-Remove existing item from sale");
                    Console.WriteLine("4-Cancel sale");         
                    //------------------------------------------
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
                        if (choice > 4 || choice < 1)
                            ok = false;
                    }
                    //------------------------------------------

                    if (choice == 1)
                      addNewItem();
                    if (choice == 2)
                    {
                        EndSale();
                        return;
                    }
                    if (choice == 3)
                       removeItem();
                    if (choice == 4)
                        cancelSale();
            
                }
            //========================================
            // Show the list of item purchased        
            //========================================
            private void ShowList(List<item> obj,List<SaleLine> s)
                {
                     
                    if (obj != null)
                    {
                         Console.WriteLine("{0} {1} {2} {3}","id","Desc","quantity","price");
                        Console.WriteLine("==================================================");
                        for (int i = 0; i < obj.Count; i++)
                        {
                            Console.WriteLine("{0} {1} {2} {3}",obj[i].ItemId ,obj[i].Description,
                                s[i].Quantity,obj[i].Price);
                    
                   
                            Console.WriteLine("==================================================");
                        }
                    }
                    else
                        Console.WriteLine("Nothing To show");
            }
            //========================================
            // Add new item to current sale        
            //========================================
            private void addNewItem()
            {
                Console.Clear();
                int id = 0;
                Boolean ok = false;
                while (!ok)
                {
                    try
                    {
                        Console.Write("Enter item id:");
                        id = int.Parse(Console.ReadLine());
                        ok = true;
                    }
                    catch
                    {
                        ok = false;
                    }
                }
                item c=record.addItemToList(id);
                Console.WriteLine("id:{0}",c.ItemId);
                Console.WriteLine("Descrpition:{0}", c.Description);
                Console.WriteLine("Price:{0}", c.Price);
                Console.Write("Quantity:");

                Boolean ok1 = false;
                while (!ok1)
                {
                    try
                    {
                    
                        c.Quantity = int.Parse(Console.ReadLine());
                        ok1 = true;
                    }
                    catch
                    {
                        ok1 = false;
                    }
                }
                Console.WriteLine("Sub Total:{0}",(c.Quantity*c.Price));
                if(!(record.updateQuantity(c.ItemId, c.Quantity)))
                    Console.WriteLine("Item in required quantity is not available...");
                SaleMenu();

            }
            //========================================
            //Remove the item from sale       
            //========================================
            public void removeItem()
            {
                Console.Clear();
                int id = 0;
                Boolean ok = false;
                while (!ok)
                {
                    try
                    {
                        Console.Write("Enter item id to remove from list:");
                        id = int.Parse(Console.ReadLine());
                        ok = true;
                    }
                    catch
                    {
                        ok = false;
                    }
                }

                record.removeItem(id);

                SaleMenu();
            }
            //========================================
            // End the current sale
            //========================================
            private void EndSale()
            {
                List<item> li=record.getAllItems();
                customer c = record.getCustomer();
                Console.WriteLine("Order Id: {0}   Costumer id:{1}", record.getOrderCount(),c.CustomerId);
                Console.WriteLine("Sale Date: {0}   Costumer name:{1}", dta, c.Name);
                double total = record.Total();
                ShowList(record.getAllItems(), record.getItemPurchsed());
                Console.WriteLine("Total {0} ",record.Total());
                record.setCounter();                
                record.update(dta);   
                          
           }
            //========================================
            // Cancel the current sale
            //========================================
            private void cancelSale()
            {
                record.Cancel();
                return;
            }
   
        }
    }
