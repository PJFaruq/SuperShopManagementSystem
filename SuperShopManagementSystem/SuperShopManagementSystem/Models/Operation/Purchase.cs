using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.Operation
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Outlet")]
        public int OutletId { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name ="Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [Display(Name ="Supplier")]
        public int PartyId { get; set; }

        [DataType(DataType.MultilineText)]
        public string  Remarks { get; set; }


        public decimal Total { get; set; }


        public decimal AmountDue { get; set; }


        public bool IsDeleted { get; set; }

        public virtual Outlet Outlet { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Party Party { get; set; }

        public virtual List<PurchaseDetail> PurchaseDetails { get; set; }

    }
}