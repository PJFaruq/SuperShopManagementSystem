using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.Operation
{
    public class ExpenseDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Select an Expense Item")]
        [Display(Name ="Item")]
        public int ExpenseItemId { get; set; }
        public virtual ExpenseItem ExpenseItem { get; set; }

        [Required(ErrorMessage ="Quantity is Required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage ="Amount is Required")]
        public decimal Amount { get; set; }

        [Display(Name="Line Total")]
        public decimal LineTotal { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(200,ErrorMessage ="Maximum 200 Charaters Allowed")]
        public string Reason { get; set; }

        public int ExpenseId { get; set; }
        public virtual Expense Expense { get; set; }

        public bool IsDeleted { get; set; }


    }
}