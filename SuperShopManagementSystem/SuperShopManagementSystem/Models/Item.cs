using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double ItemSalesPrice { get; set; }
        public double ItemPurchasePrice { get; set; }
        public int ItemCategoryId { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }

    }
}