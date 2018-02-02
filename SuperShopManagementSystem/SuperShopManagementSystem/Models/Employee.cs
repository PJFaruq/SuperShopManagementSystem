using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(maximumLength: 50, ErrorMessage = "Name Should be in Between 2 and 50 Characters", MinimumLength = 2)]
        public string  Name { get; set; }

        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; }

        [Required(ErrorMessage ="Joining Date is Required")]
        [Display(Name="Joining Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime JoiningDate { get; set; }


        public byte[] Image { get; set; }

        [Display(Name = "Contact No.")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Emergency")]
        public string EmergencyContactNo { get; set; }

        [Display(Name = "National Id")]
        public string NID { get; set; }

        [Display(Name = "Father's Name")]
        public string FatherName { get; set; }

        [Display(Name = "Mother's Name")]
        public string MotherName { get; set; }

        [Display(Name = "Present Address")]
        [DataType(DataType.MultilineText)]
        public string PresentAddress { get; set; }

        [Display(Name = "Permanent Address")]
        [DataType(DataType.MultilineText)]
        public string PermanentAddress { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Display(Name = "Reference")]
        public int? ReferenceId { get; set; }
        public virtual Employee Reference { get; set; }
        public virtual List<Employee> Employees { get; set; }

        [Display(Name = "Outlet")]
        [Required(ErrorMessage ="Outlet Required")]
        public virtual int OutletId { get; set; }
        public virtual Outlet Outlet { get; set; }

        public virtual List<Purchase> Purchases { get; set; }
        public virtual List<Sales> Sales { get; set; }

        public virtual List<Expense> Expenses { get; set; }

    }
}