﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.DatabaseContex;

namespace SuperShopManagementSystem.DAL
{
    public class DropDownDAL
    {
        private  readonly SuperShopDbContext db=new SuperShopDbContext();
        internal SelectList GetAllItemCategory()
        {
            return new SelectList(db.ItemCategories.Where(model=>model.IsDeleted==false),"Id","Name");
        }

        internal SelectList GetAllItemCategoryById(int? id)
        {
            Item item = db.Items.Find(id);
            return new SelectList(db.ItemCategories.Where(model => model.IsDeleted == false), "Id", "Name",item.ItemCategoryId);
        }

        internal SelectList GetAllExpenseCategory()
        {
            return new SelectList(db.ExpenseCategories.Where(model => model.IsDeleted == false), "Id", "Name");
        }

        internal SelectList GetAllExpenseCategoryById(int? id)
        {
            ExpenseItem expenseItem = db.ExpenseItems.Find(id);
            return new SelectList(db.ExpenseCategories.Where(model => model.IsDeleted == false), "Id", "Name", expenseItem.ExpenseCategoryId);
        }

        internal SelectList GetAllEmployee()
        {
            return new SelectList(db.Employees.Where(m => m.IsDeleted == false), "Id", "Name");
        }

        internal SelectList GetAllOutlet()
        {
            return new SelectList(db.Outlets.Where(m => m.IsDeleted == false && m.Organization.IsDeleted == false),"Id","Name");
        }

        internal SelectList GetAllOrganization()
        {
            return new SelectList(db.Organizations.Where(model => model.IsDeleted == false), "Id", "Name");
        }
    }
}