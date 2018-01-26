using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.Operation
{
    public class Expense
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Select an Outlet")]
        [Display(Name ="Outlet")]
        public int OutletId { get; set; }
        public virtual Outlet Outlet { get; set; }

        [Required(ErrorMessage ="Select an Employee")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required(ErrorMessage ="Date is Required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage ="Total Amount is Required")]
        public decimal Total { get; set; }

        public decimal? Due { get; set; }
        public bool  IsDeleted { get; set; }
        public virtual List<ExpenseDetail> ExpenseDetails { get; set; }
    }
}