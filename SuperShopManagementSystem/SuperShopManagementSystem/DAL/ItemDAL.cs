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
    public class ItemDAL
    {
        SuperShopDbContext db = new SuperShopDbContext();
        bool status = false;
        internal bool Create(Item item)
        {
            db.Items.Add(item);
            int count = db.SaveChanges();
            if (count > 0)
            {
                status = true;
            }
            return status;
        }

        internal bool Update(Item item)
        {
            db.Items.Attach(item);
            db.Entry(item).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        internal bool Delete(int id)
        {
            Item Item = db.Items.Find(id);
            Item.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        internal List<Item> GetAll()
        {
            return db.Items.Where(model => model.IsDeleted == false && model.ItemCategory.IsDeleted==false).ToList();

        }

        internal Item GetById(int? id)
        {
            Item Item = db.Items.SingleOrDefault(model => model.Id == id && model.IsDeleted == false);
            return Item;
        }

        internal List<Item> Get(Expression<Func<Item, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        internal List<Item> Search(Item Item)
        {
            throw new NotImplementedException();
        }

        internal List<Item> GetAllCode()
        {
            var listOfCategoryCode = db.Items.Where(model=>model.IsDeleted==false).ToList();
            return listOfCategoryCode;
        }

        internal bool CheckItemName(string itemName, int itemCategory)
        {
            if (db.Items.Any(model => model.Name == itemName && model.ItemCategoryId == itemCategory && model.IsDeleted==false))
            {
                status = true;
            }
            return status;
        }

    }
}