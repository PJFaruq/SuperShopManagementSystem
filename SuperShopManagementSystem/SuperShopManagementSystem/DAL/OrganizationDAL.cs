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
    public class OrganizationDAL
    {
        SuperShopDbContext db = new SuperShopDbContext();
        bool status = false;
        internal bool Create(Organization organization)
        {
            db.Organizations.Add(organization);
            int count = db.SaveChanges();
            if (count > 0)
            {
                status = true;
            }
            return status;
        }

        internal bool Update(Organization organization)
        {
            db.Organizations.Attach(organization);
            db.Entry(organization).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        internal bool Delete(int id)
        {
            Organization organization = db.Organizations.Find(id);
            organization.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        internal List<Organization> GetAll()
        {
            return db.Organizations.Where(model => model.IsDeleted == false).ToList();

        }

        internal Organization GetById(int? id)
        {
            Organization Organization = db.Organizations.SingleOrDefault(model => model.Id == id && model.IsDeleted == false);
            return Organization;
        }

        internal List<Organization> Get(Expression<Func<Organization, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        internal List<Organization> Search(Organization Organization)
        {
            throw new NotImplementedException();
        }

        internal List<Organization> GetAllCode()
        {
            var listOfCategoryCode = db.Organizations.Where(model => model.IsDeleted == false).ToList();
            return listOfCategoryCode;
        }

        internal bool CheckOrganizationName(string organizationName)
        {
            if (db.Organizations.Any(model => model.Name == organizationName && model.IsDeleted == false))
            {
                status = true;
            }
            return status;
        }

    }
}