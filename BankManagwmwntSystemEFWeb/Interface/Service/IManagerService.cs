using System;
using System.Collections.Generic;
using System.Linq;
using BankManagwmwntSystemEFWeb.Interface.Repository;
using BankManagwmwntSystemEFWeb.Models;
using BankManagwmwntSystemEFWeb.Models.Entities;

namespace BankManagwmwntSystemEFWeb.Interface.Service
{
    public interface IManagerService
    {


        public bool CreateManager(string firstName, string lastName, string middleName, string email, string password, string checkPassword);


        public Manager AddManager(Manager manager);


        public Manager GetManager(int id);


        public void DeleteManager(int id);


        public List<Manager> GetAll();


        public Manager UpdateManager(Manager manager);


    }
}
