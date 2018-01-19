using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class OutletBLL
    {
        bool status = false;
        OutletDAL outletDal = new OutletDAL();
        internal bool Create(Outlet outlet)
        {

            status = outletDal.Create(outlet);
            return status;
        }



        internal bool Update(Outlet outlet)
        {
            status = outletDal.Update(outlet);
            return status;
        }

        internal bool Delete(int id)
        {
            status = outletDal.Delete(id);
            return status;
        }

        internal Outlet GetById(int? id)
        {
            Outlet outlet = outletDal.GetById(id);
            return outlet;
        }

        internal List<Outlet> GetAll()
        {
            List<Outlet> listOfOutlet = outletDal.GetAll();
            return listOfOutlet;
        }

        Random randomCode = new Random();
        internal string GetOutletCode()
        {
            string generatedCode = "";

            int code = randomCode.Next(1000, 10000);

            generatedCode = "C" + code.ToString();

            List<Outlet> listOfOutletCode = outletDal.GetAllCode();
            if (listOfOutletCode != null)
            {

                foreach (var outlet in listOfOutletCode)
                {
                    if (generatedCode == outlet.Code)
                    {
                        return GetOutletCode();
                    }
                }
            }
            return generatedCode;
        }

        internal bool CheckOutletName(string outletName, int organization)
        {
            status = outletDal.CheckOutletName(outletName, organization);
            return status;
        }
    }
}