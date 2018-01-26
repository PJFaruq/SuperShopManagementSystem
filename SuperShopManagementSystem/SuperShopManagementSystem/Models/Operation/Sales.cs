using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.Operation
{
    public class Sales
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Outlet")]
        public int OutletId { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Sales Date")]
        public DateTime SalesDate { get; set; }

        [Required(ErrorMessage ="Please Enter Customer Name")]
        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Customer Contact")]
        public string  CustomerContact { get; set; }

        [Required(ErrorMessage ="Sub-Total is Required")]
        [Display(Name ="Sub-Total")]
        public decimal SubTotal { get; set; }


        public decimal VAT { get; set; }

        public decimal Discount { get; set; }

        [Required(ErrorMessage ="Total Amount in Required")]
        public decimal Total { get; set; }
        public decimal AmountDue { get; set; }
        public bool  IsDeleted { get; set; }
        public virtual Outlet Outlet { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual List<SalesDetail > SalesDetails { get; set; }

    }
}