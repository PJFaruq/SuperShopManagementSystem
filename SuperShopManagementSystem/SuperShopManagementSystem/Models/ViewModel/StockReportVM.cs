using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.ViewModel
{
    public class StockReportVM
    {
        public int SerialNo { get; set; }
        public string ItemName { get; set; }
        public string CategoryPath { get; set; }
        public int StockQuantiy { get; set; }
        public decimal AvgPrice { get; set; }

    }
}