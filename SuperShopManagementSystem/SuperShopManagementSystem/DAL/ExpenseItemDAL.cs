using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.DatabaseContex;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SuperShopManagementSystem.DAL
{
    public class ExpenseItemDAL
    {
            SuperShopDbContext db = new SuperShopDbContext();
            bool status = false;
            internal bool Create(ExpenseItem expenseItem)
            {
                db.ExpenseItems.Add(expenseItem);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    status = true;
                }
                return status;
            }

            internal bool Update(ExpenseItem expenseItem)
            {
                db.ExpenseItems.Attach(expenseItem);
                db.Entry(expenseItem).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }

            internal bool Delete(int id)
            {
                ExpenseItem expenseItem = db.ExpenseItems.Find(id);
                expenseItem.IsDeleted = true;
                return db.SaveChanges() > 0;
            }

            internal List<ExpenseItem> GetAll()
            {
                return db.ExpenseItems.Where(model => model.IsDeleted == false && model.ExpenseCategory.IsDeleted == false).ToList();

            }

            internal ExpenseItem GetById(int? id)
            {
                ExpenseItem expenseItem = db.ExpenseItems.SingleOrDefault(model => model.Id == id && model.IsDeleted == false);
                return expenseItem;
            }

            internal List<ExpenseItem> Get(Expression<Func<ExpenseItem, bool>> predicate)
            {
                throw new NotImplementedException();
            }

            internal List<ExpenseItem> Search(ExpenseItem expenseItem)
            {
                throw new NotImplementedException();
            }

            internal List<ExpenseItem> GetAllCode()
            {
                var listOfCategoryCode = db.ExpenseItems.Where(model => model.IsDeleted == false).ToList();
                return listOfCategoryCode;
            }

            internal bool CheckExpenseItemName(string expenseItemName, int expenseItemCategory)
            {
                if (db.ExpenseItems.Any(model => model.Name == expenseItemName && model.ExpenseCategoryId == expenseItemCategory && model.IsDeleted == false))
                {
                    status = true;
                }
                return status;
            }
    }
}