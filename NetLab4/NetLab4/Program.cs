using NetLab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting
{
    class Program
    {
        static List<Invoice> invoices;
        static bool closed = false;

        static void Main(string[] args)
        {
            invoices = new List<Invoice>()
            {
                new Invoice()
                {
                    InvoiceNumber = "18I0201",
                },
                new Invoice()
                {
                    InvoiceNumber = "18I0202",
                },
            };

            invoices[0].Add(new InvoiceItem() { Item = "rohlik", PricePerUnit = 1.2m, Units = 10 });
            invoices[0].Add(new InvoiceItem() { Item = "pivo", PricePerUnit = 14.5m, Units = 3 });
            invoices[0].Add(new InvoiceItem() { Item = "klobasa", PricePerUnit = 53m, Units = 1 });

            invoices[1].Add(new InvoiceItem() { Item = "maslo", PricePerUnit = 32.5m, Units = 1 });
            invoices[1].Add(new InvoiceItem() { Item = "marmelada", PricePerUnit = 45m, Units = 1 });
            invoices[1].Add(new InvoiceItem() { Item = "chleba", PricePerUnit = 28m, Units = 1 });

            Menu menu = new Menu();
            menu.AddMenuItem(new MenuItem()
            {
                HotKey = 'l',
                Title = "Seznam faktur",
                Func = List
            });
            menu.AddMenuItem(new MenuItem()
            {
                HotKey = 'q',
                Title = "Konec",
                Func = a => closed = true
            });

            while(!closed)
            {
                Console.Clear();
                menu.Print();
                char c = Console.ReadKey().KeyChar;
                menu.Execute(c);
            }

        }

        static void List(MenuFuncArgs args)
        {
            foreach(var invoice in invoices)
            {
                Console.WriteLine(invoice);
            }

            Console.WriteLine("Stistkni ENTER");
            Console.ReadLine();
        }
    }    

    /// <summary>
    /// Faktura
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Cislo faktury - pro jedndouchost jako retezec
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Polozky faktury
        /// </summary>
        private List<InvoiceItem> items = new List<InvoiceItem>();

        /// <summary>
        /// Verejne vystavene jako IEnumerable
        /// </summary>
        public IEnumerable<InvoiceItem> Items { get { return items;  } }

        public void Add(InvoiceItem item)
        {
            items.Add(item);
        }

        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(x => x.PriceTotalVAT);
            }
        }

        public override string ToString()
        {
            return $"{ InvoiceNumber}   {TotalPrice}";
        }


    }

    /// <summary>
    /// Polozka faktury
    /// </summary>
    public class InvoiceItem
    {
        /// <summary>
        /// DPH - pro zjednoduseni prikladu jako kosntanta
        /// </summary>
        static decimal VAT = 0.21m;

        /// <summary>
        /// Nazev polozky
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Cena za mernou jednotku
        /// </summary>
        public decimal PricePerUnit { get; set; }

        /// <summary>
        /// Pocet jednotek
        /// </summary>
        public decimal Units { get; set; }

        /// <summary>
        /// Celkova cena bez DPH
        /// </summary>
        public decimal PriceTotal { get { return PricePerUnit * Units; } }

        /// <summary>
        /// Celkova cena s DPH
        /// </summary>
        public decimal PriceTotalVAT { get { return PriceTotal * (1+VAT); } }

        public override string ToString()
        {
            return string.Format($"{Item}\t{PricePerUnit:2C}\t{Units:2C}\t{PriceTotal:2C}\t{VAT:2P}\t{PriceTotalVAT:C}");
        }
    }

    public static class Extensions
    {
    }
}
