using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.Operation
{
    public class PurchaseDetail
    {
        public int Id { get; set; }

        [Display(Name ="Item")]
        public int ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Total { get; set; }
        public bool  IsDeleted { get; set; }

        public int PurchaseId { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual Item  Item { get; set; }
    }
}