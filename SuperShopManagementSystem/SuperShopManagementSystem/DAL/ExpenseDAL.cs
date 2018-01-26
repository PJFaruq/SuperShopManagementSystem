using SuperShopManagementSystem.Models.DatabaseContex;
using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.DAL
{
    public class ExpenseDAL
    {
        SuperShopDbContext db = new SuperShopDbContext();
        bool status = false;

        internal bool Create(Expense expense)
        {
            db.Expenses.Add(expense);
            return db.SaveChanges() > 0;
        }

        internal Expense GetExpenseDetail(int? id)
        {
            Expense expense = db.Expenses.SingleOrDefault(model => model.Id == id && model.IsDeleted == false);
            return expense;

        }

        internal List<Expense> GetAll()
        {
            List<Expense> expense = db.Expenses.Where(model => model.IsDeleted == false).ToList();
            return expense;
        }
    }
}