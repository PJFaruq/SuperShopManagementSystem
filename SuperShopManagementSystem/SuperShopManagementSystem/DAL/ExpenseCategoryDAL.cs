using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.DatabaseContex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SuperShopManagementSystem.DAL
{
    public class ExpenseCategoryDAL
    {
        SuperShopDbContext db = new SuperShopDbContext();
        bool status = false;
        internal bool Create(ExpenseCategory expenseCategory)
        {

            db.ExpenseCategories.Add(expenseCategory);
            int count = db.SaveChanges();
            if (count > 0)
            {
                status = true;
            }
            return status;
        }



        internal bool Update(ExpenseCategory expenseCategory)
        {
            return status;
        }

        internal bool Delete(int id)
        {
            ExpenseCategory expenseCategory = db.ExpenseCategories.Find(id);
            expenseCategory.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        internal List<ExpenseCategory> GetAll()
        {
            return db.ExpenseCategories.Where(model => model.IsDeleted == false).ToList();

        }

        internal ExpenseCategory GetById(int? id)
        {
            ExpenseCategory expenseCategory = db.ExpenseCategories.SingleOrDefault(model => model.Id == id && model.IsDeleted == false);
            return expenseCategory;
        }

        internal List<ExpenseCategory> Get(Expression<Func<ExpenseCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        internal List<ExpenseCategory> Search(ExpenseCategory expenseCategory)
        {
            throw new NotImplementedException();
        }

        internal List<ExpenseCategory> GetAllCode()
        {
            var listOfCategoryCode = db.ExpenseCategories.Where(model=>model.IsDeleted==false).ToList();
            return listOfCategoryCode;
        }

        internal bool CheckCategoryName(string categoryName)
        {
            if (db.ExpenseCategories.Any(model => model.Name == categoryName && model.IsDeleted==false))
            {
                status = true;
            }
            return status;
        }

        internal List<ExpenseCategory> GetParentCategories()
        {
            List<ExpenseCategory> listOfExpenseCategory = db.ExpenseCategories.Where(model=>model.IsDeleted==false).ToList();
            return listOfExpenseCategory;
        }
    }
}