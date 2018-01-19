using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Party
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(maximumLength: 50, ErrorMessage = "Name Should be in Between 2 and 50 Characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Contact Number is Required")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }

        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; }

        [Required(ErrorMessage ="Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "Maximum 500 Characters are Allowed")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        
        [Required(ErrorMessage ="Party type is required")]
        public string Type { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

    }
}