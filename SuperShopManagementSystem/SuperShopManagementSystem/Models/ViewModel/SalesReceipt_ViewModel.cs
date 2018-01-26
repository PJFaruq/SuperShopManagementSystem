using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.ViewModel
{
    public class SalesReceipt_ViewModel
    {
        public int Id { get; set; }

        public int SalesNo { get; set; }
        public string SalesDate { get; set; }

        public string Outlet { get; set; }

        public string SoldBy { get; set; }
        public string CustomerName { get; set; }
        public string ContactNo { get; set; }

        public double TotalPrice { get; set; }
        public double GrandTotal { get; set; }

        public double VAT { get; set; }
        public double Discount { get; set; }

        public List<SalesDetail> SalesDetails { get; set; }
    }
}