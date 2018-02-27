using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.IO;

namespace Dal
{
    public class ReceiptDal
    {
        //=======================================
        //Add new payment  
        //=======================================
        public void SaveReceipt(Receipt r)
        {
            FileStream f=new FileStream("Receipt.txt", FileMode.Append);
            StreamWriter sr = new StreamWriter(f);
            string recpiet=r.R_id+";"+r.Order_id+";"+r.Creationdate+";"+r.Amount;
            sr.WriteLine(recpiet);
            sr.Close();
            f.Close();
        }
        //=======================================
        //Return all the payments against give
        // sale id
        //=======================================
        public List<Receipt> getReciepts(int id)
        {
            List<Receipt> rLi = new List<Receipt>();

            StreamReader sr = new StreamReader("Receipt.txt");
            string data;
            while ((data = sr.ReadLine()) != null)
            {
                string[] parser = data.Split(';');
                Receipt r = new Receipt();

                //r.R_id = int.Parse(parser[0]);
                r.Order_id = int.Parse(parser[1]);
                //r.Creationdate = parser[2];
                r.Amount = int.Parse(parser[3]);
                if (r.Order_id.Equals(id))
                    rLi.Add(r);
            }

            sr.Close();
            return rLi;

        }
    }
}
