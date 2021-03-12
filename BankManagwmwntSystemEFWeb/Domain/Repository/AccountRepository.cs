using System;
using System.Collections.Generic;
using System.Linq;
using BankManagwmwntSystemEFWeb.Interface.Repository;
using BankManagwmwntSystemEFWeb.Models;
using BankManagwmwntSystemEFWeb.Models.Entities;

namespace BankManagwmwntSystemEFWeb.Domain.Repository
{
    public class AccountRepository : IAccountRepository
    {

        private readonly ApplicationContext _applicationContext;



        public AccountRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;

        }


        public bool Create(Account account)
        {


            _applicationContext.Accounts.Add(account);
            _applicationContext.SaveChanges();
            return true;
        }

        public Account FindByAccountNumber(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public Account FindById(int id)
        {
            return _applicationContext.Accounts.FirstOrDefault(a => a.AccountHolderId == id);
        }

        public Account Update(Account account)
        {
            _applicationContext.Accounts.Update(account);
            _applicationContext.SaveChanges();
            return account;
        }

        public bool UpdateMultiple(List<Account> accounts)
        {
            _applicationContext.Accounts.UpdateRange(accounts);
            _applicationContext.SaveChanges();
            return true;
        }








        //private Databasecon databasecon = new Databasecon();

        //private MySqlConnection connection;

        //public AccountRepository()
        //{
        //    connection = databasecon.getconnection();

        //}

        //public static Account LoggedInAccount;
        //public List<Account> ListAccounts()
        //{
        //    List<Account> accounts = new List<Account>();

        //    try
        //    {
        //        connection.Open();

        //        string query = "SELECT * FROM account";

        //        MySqlCommand command = new MySqlCommand(query, connection);

        //        MySqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            {
        //                int id = reader.GetInt32(0);
        //                int accountHolderId = reader.GetInt32(1);
        //                string accountNumber = reader.GetString(2);
        //                double accountBalance = reader.GetDouble(3);
        //                int pin = reader.GetInt32(4);
        //                int accountStatus = reader.GetInt32(5);
        //                DateTime createdAt = reader.GetDateTime(6);



        //                Account account = new Account(accountHolderId, accountNumber, accountBalance, pin, accountStatus);
        //            }

        //            Console.WriteLine($"{reader[0]} -- {reader[1]}");
        //        }

        //        reader.Close();
        //        connection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    connection.Close();
        //    return accounts;

        //}

        //public bool Create(int accountHolderId, string accountNumber, double accountBalance = 0.00, int accountPin = 0, int accountStatus = 1)
        //{

        //    try
        //    {
        //        connection.Open();

        //        string query = "INSERT INTO accounts(accountholderid, accountNumber, accountBalance, accountPin, accountStatus) VALUES('" + accountHolderId + "', '" + accountNumber + "', '" + accountBalance + "', '" + accountPin + "', '" + accountStatus + "')";

        //        MySqlCommand command = new MySqlCommand(query, connection);

        //        int count = command.ExecuteNonQuery();

        //        if (count > 0)
        //        {
        //            connection.Close();
        //            return true;
        //        }

        //        else
        //        {
        //            connection.Close();
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        connection.Close();
        //    }
        //    connection.Close();

        //    return false;
        //}

        //public bool Update(Account account, int accountHolderId)
        //{

        //    try
        //    {
        //        connection.Open();

        //        string query = $"Update `accounts` set `accounts`.`accountBalance` = {account.AccountBalance}, `accounts`.`accountPin` = {account.Pin}, `accounts`.`accountStatus` = {account.AccountStatus} WHERE `accounts`.`accountHolderId` = {accountHolderId};";

        //        MySqlCommand command = new MySqlCommand(query, connection);


        //        int count = command.ExecuteNonQuery();

        //        if (count > 0)
        //        {
        //            connection.Close();
        //            return true;
        //        }

        //        else
        //        {
        //            connection.Close();
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //        Console.ReadKey();
        //        connection.Close();
        //    }



        //    return true;

        //}

        //public Account FindByAccountNumber(string accountNumber)
        //{


        //    connection.Open();
        //    Account account = null;

        //    try
        //    {

        //        string query = "SELECT * FROM `accounts` WHERE `accounts`.`accountNumber` = '" + accountNumber + "'";

        //        MySqlCommand command = new MySqlCommand(query, connection);

        //        MySqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            int accountHolderid = reader.GetInt32(1);
        //            double accountBalance = reader.GetDouble(3);
        //            int accountpin = reader.GetInt32(4);
        //            int accountStatus = reader.GetInt32(5);




        //            account = new Account(accountHolderid, accountNumber, accountBalance, accountpin, accountStatus);
        //            Console.WriteLine($"Greeting from : {account.AccountHolderId}");
        //            connection.Close();

        //            return account;
        //        }
        //        connection.Close();

        //        return account;
        //    }
        //    catch (MySqlException ea)
        //    {
        //        Console.WriteLine($"read error: {ea.Message}");
        //        connection.Close();
        //        return account;

        //    }

        //    finally
        //    {
        //        connection.Close();
        //    }
        //}
    }
}
