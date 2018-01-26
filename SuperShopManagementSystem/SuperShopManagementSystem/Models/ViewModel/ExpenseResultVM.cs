using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.ViewModel
{
    public class ExpenseResultVM
    {
        public int Id { get; set; }

        public string ExpenseNo { get; set; }
        public string Outlet { get; set; }
        public string Employee { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public double Due { get; set; }
        public double Total { get; set; }
        public List<ExpenseDetail> ExpenseDetails { get; set; }
    }
}