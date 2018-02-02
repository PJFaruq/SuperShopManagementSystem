using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class EmployeeBLL
    {
        bool status = false;
        EmployeeDAL employeeDal = new EmployeeDAL();
        internal bool Create(Employee employee)
        {

            status = employeeDal.Create(employee);
            return status;
        }



        internal bool Update(Employee employee)
        {
            status = employeeDal.Update(employee);
            return status;
        }

        internal bool Delete(int id)
        {
            status = employeeDal.Delete(id);
            return status;
        }

        internal Employee GetById(int? id)
        {
            Employee employee = employeeDal.GetById(id);
            return employee;
        }

        internal List<Employee> GetAll()
        {
            List<Employee> listOfEmployee = employeeDal.GetAll();
            return listOfEmployee;
        }

        Random randomCode = new Random();
        internal string GetEmployeeCode()
        {
            string generatedCode = "";

            int code1 = randomCode.Next(100, 1000);
            int code2 = randomCode.Next(10000000, 100000000);

            generatedCode = "C" + code1.ToString() + "-" + code2.ToString();

            List<Employee> listOfEmployeeCode = employeeDal.GetAllCode();
            if (listOfEmployeeCode != null)
            {

                foreach (var employee in listOfEmployeeCode)
                {
                    if (generatedCode == employee.Code)
                    {
                        return GetEmployeeCode();
                    }
                }
            }
            return generatedCode;
        }

        internal bool CheckEmployeeEmail(string employeeEmail)
        {
            status = employeeDal.CheckEmployeeEmail(employeeEmail);
            return status;
        }

        internal object GetParentCategories()
        {
            throw new NotImplementedException();
        }
    }
}