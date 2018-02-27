    //This Data access tier is used for costumer management
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BusinessObjects;
    using System.IO;
    namespace Dal
    {
       public class CustomerDal
        {
            //=======================================
            //Update costumer information
            //=======================================
            public void updateCostumer(List<customer> obj)
            {
                FileStream add = new FileStream("Customer.txt", FileMode.Create);
                StreamWriter addItem = new StreamWriter(add);
                for (int i = 0; i < obj.Count; i++)
                {
                    if (obj[i].CustomerId != 0)
                    {
                        string CustomerToAdd = obj[i].CustomerId + ";" + obj[i].Name + ";" + obj[i].Address + ";" +
                    obj[i].Phone + ";" + obj[i].Email + ";" + obj[i].SaleLimit+";"+obj[i].Payables;
                        //addItem.Write(itemToAdd);
                        addItem.WriteLine(CustomerToAdd);
                    }
                }
                 addItem.Close();
                add.Close();

            }
            //=======================================
            //Return all the costumer in the file
            //=======================================
            public List<customer> getCostumers()
            {
           

                StreamReader sr = new StreamReader("Customer.txt");
                List<customer> read = new List<customer>();
                String data = null;
                while ((data = sr.ReadLine()) != null)
                {
                    string[] breaker = data.Split(';');
                    customer obj = new customer();
                    if (data != null)
                    {
                   
                        obj.CustomerId = int.Parse(breaker[0]);
                        obj.Name = breaker[1];
                        obj.Address = breaker[2];
                        obj.Phone = breaker[3];
                        obj.Email = breaker[4];
                        obj.SaleLimit = double.Parse(breaker[5]);
                        obj.Payables = double.Parse(breaker[6]);
                        read.Add(obj);
                    }
               
                }
                sr.Close();

                return read;
               // return null;
            }
            //=======================================
            //Add new costumer 
            //=======================================
            public void addCostumer(customer obj)
            {

                string itemToAdd = obj.CustomerId + ";" + obj.Name + ";" + obj.Address + ";" + 
                    obj.Phone+";"+obj.Email+";"+obj.SaleLimit+";"+obj.Payables;
                FileStream add = new FileStream("Customer.txt", FileMode.Append);
                StreamWriter addItem = new StreamWriter(add);
                addItem.WriteLine(itemToAdd);
                addItem.Close();
                add.Close();


            }

        }
    }
