using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.ViewModel
{
    public class PurchaseResultVM
    {
        public int Id { get; set; }
        public string PurchaseNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PurchaseDate { get; set; }
        public string Supplier { get; set; }
        public string Outlet { get; set; }
        public string PurchaseBy { get; set; }
        public string Remarks { get; set; }

        [NotMapped]
        public List<PurchaseDetail> PurchaseDetails { get; set; }
    }
}