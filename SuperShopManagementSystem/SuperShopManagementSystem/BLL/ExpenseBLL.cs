using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models.Operation;
using SuperShopManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class ExpenseBLL
    {
        ExpenseDAL expenseDal = new ExpenseDAL();
        bool status = false;

        internal bool Create(Expense expense)
        {
            status = expenseDal.Create(expense);
            return status;
        }

        internal ExpenseResultVM GetExpenseDetail(int? id)
        {
            Expense expense = expenseDal.GetExpenseDetail(id);
            ExpenseResultVM expenseResultVM = new ExpenseResultVM();
            if (expense != null)
            {
                expenseResultVM.ExpenseNo = expense.Id.ToString();
                expenseResultVM.Date = expense.Date;
                expenseResultVM.Outlet = expense.Outlet.Name;
                expenseResultVM.Employee = expense.Employee.Name;
                expenseResultVM.Total =Convert.ToDouble( expense.Total);
                expenseResultVM.Due = Convert.ToDouble( expense.Due);
                expenseResultVM.ExpenseDetails = expense.ExpenseDetails;
            }



            return expenseResultVM;
        }

        internal List<Expense> GetAll()
        {
            List<Expense> expense = expenseDal.GetAll();
            return expense;
        }
    }
}