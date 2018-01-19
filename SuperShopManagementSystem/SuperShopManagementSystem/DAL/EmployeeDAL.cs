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
    public class EmployeeDAL
    {
        SuperShopDbContext db = new SuperShopDbContext();
        bool status = false;
        internal bool Create(Employee employee)
        {
            db.Employees.Add(employee);
            int count = db.SaveChanges();
            if (count > 0)
            {
                status = true;
            }
            return status;
        }

        internal bool Update(Employee employee)
        {
            db.Employees.Attach(employee);
            db.Entry(employee).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        internal bool Delete(int id)
        {
            Employee Employee = db.Employees.Find(id);
            Employee.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        internal List<Employee> GetAll()
        {
            return db.Employees.Where(model => model.IsDeleted == false && model.Reference.IsDeleted == false && model.Outlet.IsDeleted==false).ToList();

        }

        internal Employee GetById(int? id)
        {
            Employee Employee = db.Employees.SingleOrDefault(model => model.Id == id && model.IsDeleted == false);
            return Employee;
        }

        internal List<Employee> Get(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        internal List<Employee> Search(Employee Employee)
        {
            throw new NotImplementedException();
        }

        internal List<Employee> GetAllCode()
        {
            var listOfEmployeeCode = db.Employees.Where(model => model.IsDeleted == false).ToList();
            return listOfEmployeeCode;
        }

        internal bool CheckEmployeeEmail(string employeeEmail)
        {
            if (db.Employees.Any(model => model.Email == employeeEmail && model.IsDeleted == false))
            {
                status = true;
            }
            return status;
        }
    }
}