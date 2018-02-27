using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.IO;
namespace Dal
{
    public class itemDal
    {
        //=======================================
        //Update item information
        //=======================================
        public void updateItems(List<item> obj)
        {
            FileStream add = new FileStream("Item.txt", FileMode.Create);
            StreamWriter addItem = new StreamWriter(add);
            for (int i = 0; i < obj.Count; i++)
            {
                if (obj[i].ItemId != 0)
                {
                    string itemToAdd = obj[i].ItemId + ";" + obj[i].Description + ";" 
                        + obj[i].Price + ";" + obj[i].Quantity+";"+obj[i].CreationDate;
                    addItem.WriteLine(itemToAdd);
                    
                }
            }
            addItem.Close();
            add.Close();

        }
        //=======================================
        //Return all the citems in the file
        //=======================================
        public List<item> getItem()
        {
            StreamReader sr = new StreamReader("Item.txt");
            List<item> read = new List<item>();
            String data = null;
            while((data=sr.ReadLine())!=null)
            {
                string[] breaker = data.Split(';');
                item obj = new item();
                obj.ItemId = int.Parse(breaker[0]);
                obj.Description = breaker[1];
                obj.Price = double.Parse(breaker[2]);
                obj.Quantity = int.Parse(breaker[3]);
                obj.CreationDate = breaker[4];
                read.Add(obj);
            }

            sr.Close();
            return read;
        }
        //=======================================
        //Add new item
        //=======================================
        public void addOneItems(item obj)
        {

            string itemToAdd = obj.ItemId + ";" + obj.Description + ";" + obj.Price + ";" + obj.Quantity+";"+obj.CreationDate;
            FileStream add = new FileStream("Item.txt", FileMode.Append);
            StreamWriter addItem = new StreamWriter(add);
            addItem.WriteLine(itemToAdd);
            addItem.Close();
            add.Close();


        }        
    }
}
