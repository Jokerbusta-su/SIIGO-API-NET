using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WASiigo.Model
{
    public class Product
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ReferenceManufactures { get; set; }
        public string ProductTypeKey { get; set; }
        public string MeasureUnit { get; set; }
        public string CodeBars { get; set; }
        public string Comments { get; set; }
        public long TaxAddID { get; set; }
        public long TaxDiscID { get; set; }
        public bool IsIncluded { get; set; }
        public decimal Cost { get; set; }
        public bool IsInventoryControl { get; set; }
        public int State { get; set; }
        public Nullable<decimal> PriceList1 { get; set; }
        public Nullable<decimal> PriceList2 { get; set; }
        public Nullable<decimal> PriceList3 { get; set; }
        public Nullable<decimal> PriceList4 { get; set; }
        public Nullable<decimal> PriceList5 { get; set; }
        public Nullable<decimal> PriceList6 { get; set; }
        public Nullable<decimal> PriceList7 { get; set; }
        public Nullable<decimal> PriceList8 { get; set; }
        public Nullable<decimal> PriceList9 { get; set; }
        public Nullable<decimal> PriceList10 { get; set; }
        public Nullable<decimal> PriceList11 { get; set; }
        public Nullable<decimal> PriceList12 { get; set; }
        public string Image { get; set; }
        public long AccountGroupID { get; set; }
        public int SubType { get; set; }
        public long TaxAdd2ID { get; set; }
        public Nullable<decimal> TaxImpoValue { get; set; }
    }
}