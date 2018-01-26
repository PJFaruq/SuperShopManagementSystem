using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.Operation
{
    public class SalesDetail
    {
        public int Id { get; set; }

        [Display(Name = "Item")]
        public int ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Total { get; set; }

        public int SalesId { get; set; }

        public bool IsDeleted { get; set; }
        public virtual Sales Sales { get; set; }
        public virtual Item Item { get; set; }
    }
}