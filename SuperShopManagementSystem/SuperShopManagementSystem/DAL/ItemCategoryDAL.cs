using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.DatabaseContex;

namespace SuperShopManagementSystem.DAL
{
    public class ItemCategoryDAL
    {
        SuperShopDbContext db = new SuperShopDbContext();
        bool status = false;
        internal bool Create(ItemCategory itemCategory)
        {

            db.ItemCategories.Add(itemCategory);
            int count = db.SaveChanges();
            if (count > 0)
            {
                status = true;
            }
            return status;
        }


        internal bool Update(ItemCategory itemCategory)
        {
            return status;
        }

        internal bool Delete(int id)
        {
            ItemCategory itemCategory = db.ItemCategories.Find(id);
            itemCategory.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        internal List<ItemCategory> GetAll()
        {
            return db.ItemCategories.Include(c => c.Parent).Where(model => model.IsDeleted == false).ToList();

        }

        internal ItemCategory GetById(int? id)
        {
            ItemCategory itemCategory = db.ItemCategories.SingleOrDefault(model => model.Id == id && model.IsDeleted == false);
            return itemCategory;
        }

        internal List<ItemCategory> Get(Expression<Func<ItemCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        internal List<ItemCategory> Search(ItemCategory itemCategory)
        {
            throw new NotImplementedException();
        }

        internal List<ItemCategory> GetAllCode()
        {
            var listOfCategoryCode = db.ItemCategories.ToList();
            return listOfCategoryCode;
        }

        internal bool CheckCategoryName(string categoryName)
        {
            if (db.ItemCategories.Any(model => model.Name == categoryName))
            {
                status = true;
            }
            return status;
        }

        internal List<ItemCategory> GetParentCategories()
        {
            List<ItemCategory> listOfItemCategory = db.ItemCategories.ToList();
            return listOfItemCategory;
        }
    }
}