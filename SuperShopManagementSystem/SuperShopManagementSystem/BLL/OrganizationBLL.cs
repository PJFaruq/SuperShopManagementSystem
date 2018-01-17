using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperShopManagementSystem.DAL;

namespace SuperShopManagementSystem.BLL
{
    public class OrganizationBLL
    {
        bool status = false;
        OrganizationDAL organizationDal = new OrganizationDAL();
        internal bool Create(Organization organization)
        {

            status = organizationDal.Create(organization);
            return status;
        }



        internal bool Update(Organization organization)
        {
            status = organizationDal.Update(organization);
            return status;
        }

        internal bool Delete(int id)
        {
            status = organizationDal.Delete(id);
            return status;
        }

        internal Organization GetById(int? id)
        {
            Organization organization = organizationDal.GetById(id);
            return organization;
        }

        internal List<Organization> GetAll()
        {
            List<Organization> listOfOrganization = organizationDal.GetAll();
            return listOfOrganization;
        }

        Random randomCode = new Random();
        internal string GetOrganizationCode()
        {
            string generatedCode = "";

            int code = randomCode.Next(1000, 10000);

            generatedCode = "C" + code.ToString();

            List<Organization> listOfOrganizationCode = organizationDal.GetAllCode();
            if (listOfOrganizationCode != null)
            {

                foreach (var organization in listOfOrganizationCode)
                {
                    if (generatedCode == organization.Code)
                    {
                        return GetOrganizationCode();
                    }
                }
            }
            return generatedCode;
        }

        internal bool CheckOrganizationName(string organizationName)
        {
            status = organizationDal.CheckOrganizationName(organizationName);
            return status;
        }

        internal object GetParentCategories()
        {
            throw new NotImplementedException();
        }
    }
}