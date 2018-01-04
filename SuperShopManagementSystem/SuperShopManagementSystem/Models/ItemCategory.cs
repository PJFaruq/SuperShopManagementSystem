using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class ItemCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Chategory Name Should be in Between 2 and 50 Characters",MinimumLength =2)]
        public string Name { get; set; }


        [Required]
        public string Code { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength:100,ErrorMessage ="Maximum 100 Chararcters are Allowed")]
        public string Description { get; set; }
        public virtual List<Item> Items { get; set; }

    }
}