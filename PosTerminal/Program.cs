    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Views;
    namespace PosTerminal
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime dt = DateTime.Now;
                string dta=dt.ToString("d");
                Console.WriteLine("Date {0}",dta);
                MainMenu sale = new MainMenu();
                sale.mainMenu();
                Console.ReadKey();
            }
        }
    }
