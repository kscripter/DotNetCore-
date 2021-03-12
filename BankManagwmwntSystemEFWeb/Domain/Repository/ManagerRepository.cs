using System;
using System.Collections.Generic;
using System.Linq;
using BankManagwmwntSystemEFWeb.Interface.Repository;
using BankManagwmwntSystemEFWeb.Models;
using BankManagwmwntSystemEFWeb.Models.Entities;

namespace BankManagwmwntSystemEFWeb.Domain.Repository
{
    public class ManagerRepository : IManagerRepository
    {

        private readonly ApplicationContext _applicationContext;

        public ManagerRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }



        public Manager AddManager(Manager manager)
        {
            _applicationContext.Managers.Add(manager);
            _applicationContext.SaveChanges();
            return manager;
        }


        public int CreateManager(Manager manager)
        {
            try
            {
                _applicationContext.Managers.Add(manager);
                _applicationContext.SaveChanges();
                return manager.Id;


            }
            catch (Exception ea)
            {
                Console.WriteLine($"err2: {ea.Message}");
            }



            return 0;
        }



        public void DeleteManager(int id)
        {
            var manager = _applicationContext.Managers.Find(id);
            _applicationContext.Remove(manager);
            _applicationContext.SaveChanges();
        }


        public Manager FindByEmail(string email)
        {
            return _applicationContext.Managers.FirstOrDefault(e => e.Email == email);
        }



        public Manager FindById(int id)
        {
            return _applicationContext.Managers.FirstOrDefault(i => i.Id == id);
        }

        public List<Manager> GetAll()
        {
            return _applicationContext.Managers.ToList();
        }


        public Manager GetManager(int id)
        {
            return _applicationContext.Managers.Find(id);
        }



        public Manager Update(Manager manager)
        {
            _applicationContext.Managers.Update(manager);
            _applicationContext.SaveChanges();
            return manager;
        }

        public Manager UpdateManager(Manager manager)
        {
            _applicationContext.Managers.Update(manager);
            _applicationContext.SaveChanges();
            return manager;
        }


    }
}



//        AccountService accountService = new AccountService(new AccountRepository());

//        public static AccountHolder LoggedInAccountHolder;
//        public static Manager LoggedInManager;
//        private Databasecon databasecon = new Databasecon();
//        private MySqlConnection _connection;

//        public static Manager loggedinManager;
//        public static Account loggedinAccount;

//        public ManagerRepository()
//        {
//            _connection = databasecon.getconnection();
//        }

//        public List<AccountHolder> ListAccountHolders()
//        {
//            List<AccountHolder> accountHolders = new List<AccountHolder>();
//            try
//            {

//                _connection.Open();

//                string query = "SELECT * FROM accountholders";

//                MySqlCommand command = new MySqlCommand(query, _connection);

//                MySqlDataReader reader = command.ExecuteReader();

//                while (reader.Read())
//                {
//                    {

//                    }

//                    Console.WriteLine($"{reader[0]} -- {reader[1]}");
//                }

//                reader.Close();
//                _connection.Close();
//            }
//            catch (Exception ea)
//            {
//                throw new Exception(ea.Message);
//            }

//            return accountHolders;
//        }

//        public int CreateManager(string firstName, string lastName, string middleName, string email, string password)
//        {
//            try
//            {
//                _connection.Open();

//                string query = "INSERT INTO manager(firstName, lastName, middleName, email, password) VALUES('" + firstName + "', '" + lastName + "','" + middleName + "', '" + email + "', '" + password + "')";

//                MySqlCommand command = new MySqlCommand(query, _connection);

//                int count = command.ExecuteNonQuery();
//                if (count > 0)
//                {
//                    _connection.Close();

//                    Manager manager = FindByEmail(email);

//                    return manager.Id;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            _connection.Close();

//            return 0;
//        }

//        public Manager FindByEmail(string email)
//        {
//            _connection.Open();
//            Manager manager = null;

//            try
//            {
//                string query = "SELECT * FROM manager WHERE email = '" + email + "'";

//                MySqlCommand command = new MySqlCommand(query, _connection);

//                MySqlDataReader reader = command.ExecuteReader();

//                if (reader.Read())
//                {
//                    int id = reader.GetInt32(0);
//                    string firstName = reader.GetString(1);
//                    string lastName = reader.GetString(2);
//                    string middleName = reader.GetString(3);
//                    string password = reader.GetString(5);

//                    manager = new Manager(id, firstName, lastName, middleName, email, password);

//                    _connection.Close();
//                    return manager;
//                }

//                _connection.Close();
//                return manager;

//            }
//            catch (Exception ex)
//            {
//                _connection.Close();
//                Console.WriteLine(ex.Message);
//                return manager;
//            }


//        }

//        public bool RemoveAccountHolder(int id)
//        {
//            try
//            {
//                _connection.Open();
//                var sql = "delete from accountholders where id='" + id + "'";
//                MySqlCommand command = new MySqlCommand(sql, _connection);

//                int count = command.ExecuteNonQuery();
//                if (count > 0)
//                {
//                    _connection.Close();
//                    return true;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);

//            }
//            _connection.Close();
//            return false;
//        }
//        public bool UpdateAccountHolder(AccountHolder accountHolder)
//        {
//            try
//            {
//                _connection.Open();
//                var sql = "update accountHolders set firstName ='" + accountHolder.FirstName + "',lastName='" + accountHolder.LastName + "',middleName='" + accountHolder.MiddleName + "',phoneNumber='" + accountHolder.PhoneNumber + "',address='" + accountHolder.Address + "',password='" + accountHolder.Password + "' where id='" + accountHolder.Id + "'";
//                MySqlCommand command = new MySqlCommand(sql, _connection);
//                int count = command.ExecuteNonQuery();
//                if (count > 0)
//                {
//                    _connection.Close();
//                    return true;
//                }

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            _connection.Close();
//            return false;
//        }

//        bool IManagerRepository.CreateManager(string firstName, string lastName, string middleName, string email, string password)
//        {
//            throw new NotImplementedException();
//        }

//    }
//}
