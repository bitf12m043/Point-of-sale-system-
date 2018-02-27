    //This View in the view layer is used for items management 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BusinessObjects;
    using BLL;
    namespace Views
    {
        class ItemView
        {
       
            private ItemBll dataItemBll;
            //========================================
            // Constructor for this class        
            //========================================
            public ItemView()
            {
                dataItemBll = new ItemBll();
                          
            }
            //========================================
            // Item menu for this class        
            //========================================
            public void itemMenu()
            {
                int choice = 0;
                Boolean ok2 = false;
                Console.WriteLine("1-Add new items");
                Console.WriteLine("2-Update item detail");
                Console.WriteLine("3-Find item");
                Console.WriteLine("4-Remove existing item");
                Console.WriteLine("5-Back to main");

                while (!ok2)
                {
                    Console.WriteLine("Enter choice");
                    String key = Console.ReadLine();
                    try
                    {
                        choice = int.Parse(key);
                        ok2 = true;
                    }
                    catch
                    {
                        ok2 = false;
                    }
                    if (choice > 5 || choice < 1)
                        ok2 = false;
                }


                if (choice == 1)
                    addItem();
                if (choice == 2)
                    UpdateItem();
                if (choice == 3)
                    FindItem();
                if (choice == 4)
                    removeItem();
                if (choice == 5)
                    return;
            }
            //========================================
            // Add new item to system        
            //========================================
            private void addItem()
            {
            
                item data1 = new item();
                Counters c = dataItemBll.getCounter();
                int newCount = c.ItemCounter;
                newCount++;
                c.ItemCounter = newCount;
                data1.ItemId = c.ItemCounter;
                Console.WriteLine("Id: {0}", c.ItemCounter);
                Console.Write("Enter Description:");
                data1.Description = Console.ReadLine();   
                Boolean ok = false;
                while (!ok)
                {
                    Console.Write("Enter Quantity:");
                    try
                    {
                        data1.Quantity = int.Parse(Console.ReadLine());
                        ok = true;
                    }
                    catch
                    {
                        ok = false;
                    }
                }
                //=======================================================
                Boolean ok1 = false;
                while (!ok1)
                {
                    Console.Write("Enter Price:");
                    try
                    {
                        data1.Price = double.Parse(Console.ReadLine());
                        ok1 = true;
                    }
                    catch
                    {
                        ok1 = false;
                    }
                }
                //=======================================
                DateTime dt = DateTime.Now;
                data1.CreationDate = dt.ToString("d");
                //=======================================
                dataItemBll.addItem(data1);
                dataItemBll.updateCounters(c);
                itemMenu();
            }
            //========================================
            // Update existing item       
            //========================================
            private void UpdateItem()
            {
                int id = 0;
                Boolean ok = false;
                while (!ok)
                {
                    try
                    {
                        Console.Write("Enter id to update item data");
                        id = int.Parse(Console.ReadLine());
                        ok = true;
                    }
                    catch
                    {
                        ok = false;
                    }
                }
                item c = dataItemBll.Search(id);

                show(c);
                //====================================================  

            
                string choice = "n";
           
                if (c != null)
                {
                    Console.WriteLine("Do you want to update information");
                    choice = Console.ReadLine();
                    if (choice == "y" || choice == "Y")
                    {
                        Console.WriteLine("Id: {0}", c.ItemId);
                        Console.Write("Enter Description:");
                        c.Description = Console.ReadLine();


                        Boolean ok1 = false;
                        while (!ok1)
                        {
                            Console.Write("Enter price:");
                            try
                            {
                                c.Price = double.Parse(Console.ReadLine());
                                ok1 = true;
                            }
                            catch
                            {
                                ok1 = false;
                            }
                        }

                        //==========================================
                        Boolean ok3 = false;
                        while (!ok3)
                        {
                            Console.Write("Enter quantity:");
                            try
                            {
                                c.Quantity = int.Parse(Console.ReadLine());
                                ok3 = true;
                            }
                            catch
                            {
                                ok3 = false;
                            }
                        }

                        dataItemBll.updateItem();
                    }
                }
            
                itemMenu();
            }
            //========================================
            // emove existing item       
            //========================================
            private void removeItem()
            {
                           int id = 0;
                Boolean ok = false;
                while (!ok)
                {
                    try
                    {
                        Console.Write("Enter id to delete item");
                        id = int.Parse(Console.ReadLine());
                        ok = true;
                    }
                    catch
                    {
                        ok = false;
                    }
                }
                item c = dataItemBll.Search(id);

                if (c != null)
                {
                    Console.WriteLine("Do you want to delete item");
                    string choice = "n";
                    choice = Console.ReadLine();

                    if (choice == "y" || choice == "Y")
                    {
                        if (dataItemBll.removeItem(c))
                            Console.WriteLine("Item deleted");


                    }
                }
                else
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Item not available");
                    Console.WriteLine("--------------------------------------");
                }

                itemMenu();
            }
            //========================================
            // Find existing item       
            //========================================
            private void FindItem()
            {
                    item data = new item();

                    Console.Write("Enter Id:");
                    string id = Console.ReadLine();
                    if (id.Length.Equals(0))
                    {

                        data.ItemId = -1;
                    }
                    else
                    {
                        try
                        {
                            data.ItemId = int.Parse(id);
                    
                        }
                        catch
                        {
                            data.ItemId= -1;
                        }
                    }
                    Console.Write("Enter description:");
                    data.Description = Console.ReadLine();
                    Console.Write("Enter price:");
                    string limit = Console.ReadLine();
                    if (limit.Length.Equals(0))
                        data.Price = -1;
                    else
                    {
                        try
                        {
                            data.Price = double.Parse(limit);
                        }
                        catch
                        {
                            data.Price = -1;
                        }
                    }
                    //============================
                    Console.Write("Enter quantity:");
                    string quantity = Console.ReadLine();
                    if (quantity.Length.Equals(0))
                        data.Quantity = -1;
                    else
                    {
                        try
                        {
                            data.Quantity = int.Parse(quantity);
                        }
                        catch
                        {
                            data.Quantity = -1;
                        }
                }
               //=======================================================

                if (!(data.ItemId.Equals(-1)))
                    show(dataItemBll.Search(data.ItemId));
                else if (!(data.Description.Length.Equals(0)))
                    ShowList(dataItemBll.findByDescription(data.Description));
                else if (!(data.Price.Equals(-1)))
                    ShowList(dataItemBll.findByPrice(data.Price));
                else if (!(data.Quantity.Equals(0)))
                    ShowList(dataItemBll.findByquantity(data.Quantity));
                //==========================================================

                itemMenu();

            }
            //========================================
            // Show one item        
            //========================================
            private void show(item obj)
            {
                if (obj != null)
                {
                    Console.WriteLine("Id: {0}", obj.ItemId);
                    Console.WriteLine("descrition: {0}", obj.Description);
                    Console.WriteLine("Quantity {0}", obj.Quantity);
                    Console.WriteLine("price {0}", obj.Price);
                    Console.WriteLine("Creation date: {0}", obj.CreationDate);
                }
                else
                    Console.WriteLine("No record found");
            }
            //========================================
            // Show multiple items        
            //========================================
            private void ShowList(List<item> obj)
            {
                if (obj != null)
                {
                    Console.WriteLine("==================================================");
                    for (int i = 0; i < obj.Count; i++)
                    {
                        Console.WriteLine("Id: {0}", obj[i].ItemId);
                        Console.WriteLine("Descrition: {0}", obj[i].Description);
                        Console.WriteLine("Quantity: {0}", obj[i].Quantity);
                        Console.WriteLine("Price: {0}", obj[i].Price);
                        Console.WriteLine("Creation Date: {0}", obj[i].CreationDate);
                        Console.WriteLine("==================================================");
                    }
                }
                else
                    Console.WriteLine("Nothing To show");
                }
        
        }
    }
