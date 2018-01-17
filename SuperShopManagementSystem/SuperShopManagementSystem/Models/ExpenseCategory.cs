﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class ExpenseCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(maximumLength: 50, ErrorMessage = "Chategory Name Should be in Between 2 and 50 Characters", MinimumLength = 2)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 100, ErrorMessage = "Maximum 100 Chararcters are Allowed")]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }


        [Display(Name = "Parent Category")]
        public Nullable<int> ParentId { get; set; }
        public virtual ExpenseCategory Parent { get; set; }

        public virtual List<ExpenseCategory> ExpenseCategories { get; set; }

        public virtual List<ExpenseItem> ExpenseItems { get; set; }
    }
}