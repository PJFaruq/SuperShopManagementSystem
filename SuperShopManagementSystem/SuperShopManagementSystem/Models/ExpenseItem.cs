using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class ExpenseItem
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Name is Required")]

        [StringLength(maximumLength: 50, ErrorMessage = "Chategory Name Should be in Between 2 and 50 Characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 1000, ErrorMessage = "Maximum 1000 Chararcters are Allowed")]
        public string Description { get; set; }


        [Required]
        public bool IsDeleted { get; set; }


        [Required(ErrorMessage = "Select an Item Category")]
        [Display(Name = "Category")]
        public virtual int ExpenseCategoryId { get; set; }


        public virtual ExpenseCategory ExpenseCategory { get; set; }
    }
}