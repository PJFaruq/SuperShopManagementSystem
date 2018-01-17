using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Item
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(maximumLength: 50, ErrorMessage = "Chategory Name Should be in Between 2 and 50 Characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; }

        public byte[] Image { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 1000, ErrorMessage = "Maximum 1000 Chararcters are Allowed")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Sales Price is Required")]
        [Display(Name = "Sales Price")]
        [DataType(DataType.Currency,ErrorMessage ="Enter Valid Price")]
        public double SalesPrice { get; set; }

        [Required(ErrorMessage = "Purchase Price is Required")]
        [Display(Name = "Purchase Price")]
        [DataType(DataType.Currency, ErrorMessage = "Enter Valid Price")]
        public double PurchasePrice { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required(ErrorMessage ="Select an Item Category")]
        [Display(Name = "Category")]
        public virtual int ItemCategoryId { get; set; }

                           
        public virtual ItemCategory ItemCategory { get; set; }

    }
}