using System;
using System.Collections.Generic;

#nullable disable

namespace ClientSideSaleNotify.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string Inventory { get; set; }
        public bool OnSale { get; set; }
    }
}
