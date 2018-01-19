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
    public class OutletDAL
    {
        SuperShopDbContext db = new SuperShopDbContext();
        bool status = false;
        internal bool Create(Outlet outlet)
        {
            db.Outlets.Add(outlet);
            int count = db.SaveChanges();
            if (count > 0)
            {
                status = true;
            }
            return status;
        }

        internal bool Update(Outlet outlet)
        {
            db.Outlets.Attach(outlet);
            db.Entry(outlet).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        internal bool Delete(int id)
        {
            Outlet Outlet = db.Outlets.Find(id);
            Outlet.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        internal List<Outlet> GetAll()
        {
            return db.Outlets.Where(model => model.IsDeleted == false && model.Organization.IsDeleted == false).ToList();

        }

        internal Outlet GetById(int? id)
        {
            Outlet Outlet = db.Outlets.SingleOrDefault(model => model.Id == id && model.IsDeleted == false);
            return Outlet;
        }

        internal List<Outlet> Get(Expression<Func<Outlet, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        internal List<Outlet> Search(Outlet Outlet)
        {
            throw new NotImplementedException();
        }

        internal List<Outlet> GetAllCode()
        {
            var listOfOutletCode = db.Outlets.Where(model => model.IsDeleted == false).ToList();
            return listOfOutletCode;
        }

        internal bool CheckOutletName(string outletName, int organization)
        {
            if (db.Outlets.Any(model => model.Name == outletName && model.OrganizationId == organization && model.IsDeleted == false))
            {
                status = true;
            }
            return status;
        }
    }
}