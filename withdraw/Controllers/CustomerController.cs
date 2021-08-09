using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using withdraw.Models;
using withdraw.Utils;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace withdraw.Controllers
{
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        /*JSON CREATE*/
        private DBConnection dbConnection = new DBConnection();
        private static List<Customer> Customer = new List<Customer>();

        [AcceptVerbs("GET")]
        [Route("all")]
        public List<Customer> getAllCustomers()
        {
            return dbConnection.getAllCustomers();
        }


        /*<<<<<<> CRUD <>>>>>>*/

        /*CREATE*/
        [AcceptVerbs("POST")]
        [Route("insert/{idAdmin}/{name}/{email}/{passwd}/{bankbalance}/{admin}")]
        public string createCustomer(string idAdmin, string name, string email, string passwd, int bankbalance, bool admin)
        {

            return dbConnection.createCustomer(idAdmin, name, email, passwd, bankbalance, admin);
        }

        /*READ*/
        [AcceptVerbs("GET")]
        [Route("read/{idAdmin}/{idCustomer}")]
        public string readCustomerById(string idAdmin, string idCustomer)
        {
            return dbConnection.readCustomerById(idAdmin, idCustomer);
        }


        /*UPDATE*/
        [AcceptVerbs("PUT")]
        [Route("insert/{idAdmin}/{name}/{email}/{passwd}/{bankbalance}/{idCustomer}")]
        public string updateCustomer(string idAdmin, string name, string email, string passwd, int bankbalance, string idCustomer)
        {

            return dbConnection.updateCustomer(idAdmin, name, email, passwd, bankbalance, idCustomer);
        }

        /*DELETE*/
        [AcceptVerbs("DELETE")]
        [Route("delete/{idAdmin}/{idCustomer}")]
        public string deleteCustomer(string idAdmin, string idCustomer)
        {
            return dbConnection.deleteCustomer(idAdmin, idCustomer);
        }


        /*WITHDRAW ALL USERS, CHECK BALANCE LIMIT, COUNT NOTES, VALUE VALIDATION*/
        [AcceptVerbs("GET")]
        [Route("withdraw/{id}/{value}")]
        public Withdraw setCustomerBankBalance(string id, int value)
        {
            int bankBalance = dbConnection.getCustomerBankBalance(id).First<int>();
            try
            {
                if (bankBalance >= value)//
                {
                    CountBankNotes countBankNotes = new CountBankNotes();
                    return countBankNotes.GetWithdraw(value, id);
                }
                else
                {
                    Withdraw withdraw = new Withdraw();
                    withdraw.message = "insuficient limit";
                    withdraw.accountBalance = bankBalance;
                    return withdraw;
                }
            }
            catch (Exception ex)
            {
                Withdraw withdraw = new Withdraw();
                withdraw.message = "error: " + ex.ToString();
                withdraw.accountBalance = bankBalance;
                return withdraw;
            }
        }

        /*ADD BALANCE, ONLY ADM*/
        [AcceptVerbs("GET")]
        [Route("deposit/{idAdmin}/{idCustomer}/{addAditionalValue}")]
        public string setNewDepositBank(string idAdmin, string idCustomer, int addAditionalValue)
        {
            return dbConnection.setNewDepositBank(idAdmin, idCustomer, addAditionalValue);
        }
    }
}
