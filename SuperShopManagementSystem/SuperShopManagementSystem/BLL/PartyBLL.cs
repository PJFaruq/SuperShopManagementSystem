using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class PartyBLL
    {
        bool status = false;
        PartyDAL partyDal = new PartyDAL();
        internal bool Create(Party party)
        {

            status = partyDal.Create(party);
            return status;
        }



        internal bool Update(Party party)
        {
            status = partyDal.Update(party);
            return status;
        }

        internal bool Delete(int id)
        {
            status = partyDal.Delete(id);
            return status;
        }

        internal Party GetById(int? id)
        {
            Party party = partyDal.GetById(id);
            return party;
        }

        internal List<Party> GetAll()
        {
            List<Party> listOfParty = partyDal.GetAll();
            return listOfParty;
        }

        Random randomCode = new Random();
        internal string GetPartyCode()
        {
            string generatedCode = "";
            string year = DateTime.Today.Year.ToString();
            string month = DateTime.Today.Month.ToString();
            if (month.Length < 2)
            {
                month = "0" + month;
            }
            int code = randomCode.Next(1000, 10000);

            generatedCode = year+" "+ month +" " +code.ToString();

            List<Party> listOfPartyCode = partyDal.GetAllCode();
            if (listOfPartyCode != null)
            {

                foreach (var party in listOfPartyCode)
                {
                    if (generatedCode == party.Code)
                    {
                        return GetPartyCode();
                    }
                }
            }
            return generatedCode;
        }

        internal bool CheckPartyEmail(string email,string type)
        {
            status = partyDal.CheckPartyEmail(email,type);
            return status;
        }

        internal object GetParentCategories()
        {
            throw new NotImplementedException();
        }
    }
}