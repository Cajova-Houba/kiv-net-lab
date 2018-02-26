using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLab3
{

    /// <summary>
    /// Units used in invoice.
    /// </summary>
    public enum InvoiceUnits
    {
        /// <summary>
        /// 1 item.
        /// </summary>
        ITEM,

        /// <summary>
        /// 1 kg.
        /// </summary>
        KG,

        /// <summary>
        /// 1 liter.
        /// </summary>
        L

    }

    /// <summary>
    /// Structure which represents one item billed in invoice.
    /// </summary>
    public struct InvoiceItem
    {
        private String name;
        private InvoiceUnits unit;
        private double pricePerUnit;
        private int unitCount;

        /// <summary>
        /// Gets or sets the name of this item.
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Gets or sets unit of this item.
        /// </summary>
        public InvoiceUnits Unit { get => unit; set => unit = value; }

        /// <summary>
        /// Gets or sets price per one unit of this item.
        /// </summary>
        public double PricePerUnit { get => pricePerUnit; set => pricePerUnit = value; }

        /// <summary>
        /// Gets or sets unit count of this item. 
        /// </summary>
        public int UnitCount { get => unitCount; set => unitCount = value; }

        /// <summary>
        /// Returns total price without DPH.
        /// </summary>
        public double TotalPrice { get => unitCount * pricePerUnit; }

        /// <summary>
        /// Return total price with DPH included.
        /// </summary>
        public double TotalPriceDPH { get => 1.21 * TotalPrice; }

        /// <summary>
        /// Returns DPH for this item.
        /// </summary>
        public double DPH { get => 0.21 * TotalPrice; }
    
        public InvoiceItem(string name, InvoiceUnits unit, double pricePerUnit, int unitCount)
        {
            this.name = name;
            this.unit = unit;
            this.pricePerUnit = pricePerUnit;
            this.unitCount = unitCount;
        }

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2:0.##}\t{3}\t{4:0.##}\t{5:0.####}\t{6:0.####}", Name, Unit, PricePerUnit, UnitCount, DPH, TotalPrice, TotalPriceDPH);
        }
    }
}
