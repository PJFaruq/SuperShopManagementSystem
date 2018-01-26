using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;

namespace SuperShopManagementSystem.BLL
{

    public class DropDownBLL
    {
        DropDownDAL dropDownDal=new DropDownDAL();
        internal SelectList GetAllItemCategory()
        {
            SelectList selectListOfItemCategory = dropDownDal.GetAllItemCategory();
            return selectListOfItemCategory;
        }
        internal SelectList GetAllItemCategoryById(int? id)
        {
            SelectList selectListOfItemCategory = dropDownDal.GetAllItemCategoryById(id);
            return selectListOfItemCategory;
        }

        internal SelectList GetAllItem()
        {
            SelectList selectListOfItem = dropDownDal.GetAllItem();
            return selectListOfItem;
        }

        internal SelectList GetAllExpenseItem()
        {
            SelectList selectListOfItem = dropDownDal.GetAllExpenseItem();
            return selectListOfItem;
        }

        internal SelectList GetAllExpenseCategory()
        {
            SelectList selectListOfExpenseCategory = dropDownDal.GetAllExpenseCategory();
            return selectListOfExpenseCategory;
        }

        internal SelectList GetAllOutlet()
        {
            SelectList selectListOfOutlet = dropDownDal.GetAllOutlet();
            return selectListOfOutlet;
        }

        internal SelectList GetAllEmployee()
        {
            SelectList selectListOfEmployee = dropDownDal.GetAllEmployee();
            return selectListOfEmployee;
        }

        internal SelectList GetAllOrganization()
        {
            SelectList listOfOrganization = dropDownDal.GetAllOrganization();
            return listOfOrganization;
        }

        internal SelectList GetAllExpenseCategoryById(int? id)
        {
            SelectList selectListOfExpenseCategory = dropDownDal.GetAllExpenseCategoryById(id);
            return selectListOfExpenseCategory;
        }


        internal SelectList GetAllSupplier()
        {
            SelectList selectListOfSupplier = dropDownDal.GetAllSupplier();
            return selectListOfSupplier;
        }
    }
}