using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice
{
    public class Invoice
    {
        private String invoiceNumber;
        private DateTime dateInvoice;
        private DateTime dueDate;

        public String InvoiceNumber { get { return invoiceNumber; } set { invoiceNumber = value; } }
        public DateTime DateInvoice { get { return dateInvoice; } set { dateInvoice = value; } }
        public DateTime DueDate { get { return dueDate; } set { dueDate = value; } }
        public Boolean IsOverDue
        {
            get
            {
                return dueDate < DateTime.Now;
            }
        }

        public Invoice()
        {
        }

        public Invoice(string invoiceNumber, DateTime dateInvoice, DateTime dueDate)
        {
            this.invoiceNumber = invoiceNumber;
            this.dateInvoice = dateInvoice;
            this.dueDate = dueDate;
        }

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2}{3}", InvoiceNumber, DateInvoice, DueDate, IsOverDue ? "\t!!!" : "");
        }

    }
}
