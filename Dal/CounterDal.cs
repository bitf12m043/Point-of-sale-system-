using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.IO;
namespace Dal
{
    public class CounterDal
    {
        //=======================================
        //Update the counter in the file
        //=======================================
        public void updateCountes(Counters c)
        {
            FileStream fs = new FileStream("Counter.txt", FileMode.Create);
            StreamWriter sr = new StreamWriter(fs);
            string count = c.ItemCounter + ";" + c.CostumerCounter + ";" + c.OrderCounter+";"+c.LineNo+";"+c.RecieptNo;
            sr.Write(count);
            sr.Close();
            fs.Close();
        }
        //=======================================
        //Return counter from the file
        //=======================================
        public Counters getItemCounter()
        {
            Counters data = new Counters();
            StreamReader sr = new StreamReader("Counter.txt");
            string counts = sr.ReadLine();
            string [] Breaker = counts.Split(';');
            sr.Close();
            data.ItemCounter = int.Parse(Breaker[0]);
            data.CostumerCounter = int.Parse(Breaker[1]);
            data.OrderCounter = int.Parse(Breaker[2]);
            data.LineNo = int.Parse(Breaker[3]);
            data.RecieptNo = int.Parse(Breaker[4]);
            return data;
        }



    }
}
