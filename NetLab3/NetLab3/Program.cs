using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating invoice items...");
            LinkedList<InvoiceItem> invoiceItems = new LinkedList<InvoiceItem>();
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                double rDouble = r.NextDouble();
                InvoiceUnits unit = rDouble < 0.3 ? InvoiceUnits.ITEM : (rDouble < 0.6 ? InvoiceUnits.KG : InvoiceUnits.L);
                InvoiceItem item = new InvoiceItem("Item " + i, unit, r.NextDouble() * (r.Next(100) + 1), r.Next(1000) + 1);
                Console.WriteLine(item);
                invoiceItems.AddLast(item);
            }
            Console.WriteLine("Done.");

            var totalPriceDPHQuery =
                from item in invoiceItems
                select item.TotalPriceDPH;

            var totalPriceQuery =
                from item in invoiceItems
                select item.TotalPrice;

            Console.WriteLine(String.Format("Total price (excluding DPH): {0:0.####} Kč", totalPriceQuery.Sum()));
            Console.WriteLine(String.Format("Total price (including DPH): {0:0.####} Kč", totalPriceDPHQuery.Sum()));
            Console.Read();
        }
    }
}
