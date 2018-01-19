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
    public class PartyDAL
    {
        SuperShopDbContext db = new SuperShopDbContext();
        bool status = false;
        internal bool Create(Party party)
        {
            db.Parties.Add(party);
            int count = db.SaveChanges();
            if (count > 0)
            {
                status = true;
            }
            return status;
        }
            
        internal bool Update(Party party)
        {
            db.Parties.Attach(party);
            db.Entry(party).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        internal bool Delete(int id)
        {
            Party Party = db.Parties.Find(id);
            Party.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        internal List<Party> GetAll()
        {
            return db.Parties.Where(model => model.IsDeleted == false).ToList();

        }

        internal Party GetById(int? id)
        {
            Party Party = db.Parties.SingleOrDefault(model => model.Id == id && model.IsDeleted == false);
            return Party;
        }

        internal List<Party> Get(Expression<Func<Party, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        internal List<Party> Search(Party party)
        {
            throw new NotImplementedException();
        }

        internal List<Party> GetAllCode()
        {
            var listOfPartyCode = db.Parties.Where(model => model.IsDeleted == false).ToList();
            return listOfPartyCode;
        }

        internal bool CheckPartyEmail(string email,string type)
        {
            if (db.Parties.Any(model => model.Email == email && model.Type==type &&  model.IsDeleted == false))
            {
                status = true;
            }
            return status;
        }
    }
}