using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Outlet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(maximumLength: 50, ErrorMessage = "Name Should be in Between 2 and 50 Characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; }

        [Display(Name = "Contact No.")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [StringLength(maximumLength: 500, ErrorMessage = "Maximum 500 Characters are Allowed")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required(ErrorMessage ="Please Select an Organization")]
        public virtual int OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual List<Employee> Employees { get; set; }

        public virtual List<Purchase> Purchases { get; set; }

        public virtual List<Sales> Saleses { get; set; }
        public virtual List<Expense> Expenses { get; set; }
    }
}