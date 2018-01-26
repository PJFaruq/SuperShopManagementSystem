using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.ViewModel
{
    public class PurchaseSearchVM
    {
        public int? PurchaseCode { get; set; }
        public int? OutletId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}