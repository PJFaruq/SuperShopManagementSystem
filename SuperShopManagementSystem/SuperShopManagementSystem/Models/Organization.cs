﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(maximumLength: 100, ErrorMessage = "Name Should be in Between 2 and 100 Characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; }

        [Display(Name="Contact No.")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }

        [Display(Name="Logo")]
        public byte[] Image { get; set; }

        [Required(ErrorMessage ="Address is Required")]
        [StringLength(maximumLength: 500, ErrorMessage = "Maximum 500 Characters are Allowed")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public virtual List<Outlet> Outlets { get; set; }

    }
}