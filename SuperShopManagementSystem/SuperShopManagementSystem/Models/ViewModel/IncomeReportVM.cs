using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.ViewModel
{
    public class IncomeReportVM
    {
        public int Id { get; set; }

        [NotMapped]
        public  List<Sales> Sales { get; set; }
        [NotMapped]
        public  List<Purchase> Purchase { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalPurchase { get; set; }
        public decimal TotalProfit { get; set; }
    }
}