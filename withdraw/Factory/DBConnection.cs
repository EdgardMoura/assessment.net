using System;
using Dapper;
using Npgsql;
using System.Collections.Generic;
using withdraw.Models;
using System.Linq;


namespace withdraw
{
    public class DBConnection
    {
        /*CONNECTION DB*/
        public String getStringConnection()
        {
            const string herokuConnectionString = @"
                                                      Host=ec2-3-233-43-103.compute-1.amazonaws.com;
                                                      Port=5432;
                                                      Username=ucrwnrhdvkpzdx;
                                                      Password=85cb02154b1e1de5e206d38509815dfe201080809ef1f596cd5d83940bea28e1;
                                                      Database=d43jo8egad9uj0;
                                                      Pooling=true;
                                                      SSL Mode=Require;
                                                      TrustServerCertificate=True;
                                                    ";
            return herokuConnectionString;
        }


        /*<<<<<<> CRUD <>>>>>>*/

        /*CREATE*/
        public string createCustomer(string idAdmin, string name, string email, string passwd, int bankbalance, bool admin)
        {
            using (var connection = new NpgsqlConnection(getStringConnection()))
                if (idAdmin == "1")

                {
                    connection.Query<Customer>("INSERT INTO public.customer (name, email, passwd, bankbalance, admin) " +
                        "VALUES ('" + name + "', '" + email + "', '" + passwd + "', '" + bankbalance + "', '" + admin + "')");
                    return "User successfully added!";
                }
                else
                {
                    return "Addition of new users allowed only to administrators!";
                }
        }

        /*READ*/
        public string readCustomerById(string idAdmin, string idCustomer)
        {
            using (var connection = new NpgsqlConnection(getStringConnection()))
            {
                int updateBalance = getCustomerBankBalance(idCustomer).First<int>();
                string getName = getCustomerName(idCustomer).First<string>();
                {
                    connection.Query<Customer>("SELECT name, bankbalance FROM public.customer WHERE id = '" + idCustomer + "'");
                    return "Name: " + getName + ", Balance: " + updateBalance;
                }
            }
        }


        /*UPDATE*/
        public string updateCustomer(string idAdmin, string name, string email, string passwd, int bankbalance, string idCustomer)
        {
            using (var connection = new NpgsqlConnection(getStringConnection()))
                if (idAdmin == "1")

                {
                    connection.Query<Customer>("UPDATE public.customer SET name =" +
                        " '" + name + "', email = '" + email + "', passwd = '" + passwd + "'," +
                        " bankbalance = '" + bankbalance + "' where id = '" + idCustomer + "'");
                    return "User updated successfully!";
                }
                else
                {
                    return "User updates can only be done by administrators!";
                }
        }

        /*DELETE*/
        public string deleteCustomer(string idAdmin, string id)
        {
            using (var connection = new NpgsqlConnection(getStringConnection()))
            {
                connection.Query<Customer>("DELETE FROM public.customer WHERE id =" + id);
                return "User deleted successfully!";
            }
        }

        /*SELECT ALL FROM ALL CUSTOMERS*/
        public List<Customer> getAllCustomers()
        {
            using (var connection = new NpgsqlConnection(getStringConnection()))
            {
                return (List<Customer>)connection.Query<Customer>("SELECT name, email, passwd, bankbalance, admin, id FROM public.customer order by id ");
            }
        }

        /*SELECT NAME BY ID*/
        public List<string> getCustomerName(string id)
        {
            using (var connection = new NpgsqlConnection(getStringConnection()))
            {
                return (List<string>)connection.Query<string>("SELECT name FROM public.customer where id = " + id + " LIMIT 1");
            }
        }

        /*SELECT BALANCE BY ID*/
        public List<int> getCustomerBankBalance(string id)
        {
            using (var connection = new NpgsqlConnection(getStringConnection()))
            {
                return (List<int>)connection.Query<int>("SELECT bankbalance FROM public.customer where id = " + id + " LIMIT 1");
            }
        }

        /*UPDATE BALANCE BY ID*/
        public List<int> setCustomerBankBalance(string id, int newBalance)
        {
            using (var connection = new NpgsqlConnection(getStringConnection()))
            {
                connection.Query("UPDATE public.customer SET bankbalance=" + newBalance.ToString() + " WHERE id= " + id);
                return (List<int>)connection.Query<int>("SELECT bankbalance FROM public.customer where id = " + id + " LIMIT 1");
            }
        }

        /*ADD BALANCE BY ID, ONLY ADM*/
        public string setNewDepositBank(string idAdmin, string idCustomer, int addAditionalValue)
        {
            using (var connection = new NpgsqlConnection(getStringConnection()))
            {
                int updateBalance = getCustomerBankBalance(idCustomer).First<int>();

                if (addAditionalValue > 0)
                {
                    connection.Query("UPDATE public.customer SET bankbalance=" + (addAditionalValue + updateBalance).ToString() + 
                        " WHERE public.customer.id=" + idCustomer + " and ((select public.customer.admin from public.customer " +
                        " WHERE (public.customer.id=" + idAdmin + ") = true))");//verificaçao se é admin
                    int afterUpdateBalance = getCustomerBankBalance(idCustomer).First<int>();
                    if (updateBalance < afterUpdateBalance)
                    {
                        return "{\"status\":\"Account update\",\"message\":\"Updated with success!\",\"value\":" + afterUpdateBalance.ToString() + "}";
                    }
                    else
                    {
                        return "{\"status\":\"Account not updated\",\"message\":\"Is not admin\",\"value\":" + afterUpdateBalance.ToString() + "}";
                    }
                }
                else
                {
                    return "{\"status\":\"Account not updated\",\"message\":\"Invalid value\",\"value\":" + updateBalance.ToString() + "}";
                }
            }
        }
    }
}
