using System;
using System.Collections.Generic;
using BankManagwmwntSystemEFWeb.Models;
using BankManagwmwntSystemEFWeb.Models.Entities;

namespace BankManagwmwntSystemEFWeb.Interface.Repository
{
    public interface IManagerRepository
    {

        //public bool CreateManager(string firstName, string lastName, string middleName, string email, string password);


        public int CreateManager(Manager manager);

        public Manager AddManager(Manager manager);

        public Manager FindByEmail(string email);

        public Manager FindById(int id);

        public Manager Update(Manager manager);

        public Manager UpdateManager(Manager manager);


        public Manager GetManager(int id);

        public List<Manager> GetAll();


        // public Manager GetManager(string firstName);

        public void DeleteManager(int id);


    }
}
