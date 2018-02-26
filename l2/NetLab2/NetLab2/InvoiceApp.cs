using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLab2
{
    class InvoiceApp
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Invoice App");
            Console.Out.WriteLine("Generating invoices, press any key to stop...");
            Console.Out.WriteLine("Number\tDate\tDue date\tOver due");
            Random r = new Random();
            while(!Console.KeyAvailable)
            {
                int invNum = r.Next(8999) + 1000;
                int invDateRange = r.Next(5) - 10;
                int dueDateRange = r.Next(5) - 3;
                Invoice.Invoice inv = new Invoice.Invoice(invNum.ToString(), DateTime.Now.AddDays(invDateRange), DateTime.Now.AddDays(dueDateRange));
                Console.WriteLine(inv);
                Thread.Sleep(1000);
            }
            Console.ReadKey();

            Console.Out.WriteLine("Done. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
