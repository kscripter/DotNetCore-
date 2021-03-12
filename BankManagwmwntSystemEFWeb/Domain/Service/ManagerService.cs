using System;
using System.Collections.Generic;
using BankManagwmwntSystemEFWeb.Interface.Repository;
using BankManagwmwntSystemEFWeb.Interface.Service;
using BankManagwmwntSystemEFWeb.Models.Entities;

namespace BankManagwmwntSystemEFWeb.Domain.Service
{
    public class ManagerService : IManagerService
    {

        private readonly IManagerRepository _managerRepository;



        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;

        }

        public Manager AddManager(Manager manager)
        {
            Manager mn = _managerRepository.AddManager(manager);

            return mn;
        }

        public bool CreateManager(string firstName, string lastName, string middleName, string email, string password, string checkPassword)
        {
            if (password.Equals(checkPassword))
            {
                Manager newManager = new Manager
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    Email = email,
                    Password = password
                };
                int managerId = _managerRepository.CreateManager(newManager);

                return true;
            }
            else
            {
                return false;
            }




        }

        public void DeleteManager(int id)
        {
            _managerRepository.DeleteManager(id);
        }

        public List<Manager> GetAll()
        {
            return _managerRepository.GetAll();
        }

        public Manager GetManager(int id)
        {
            return _managerRepository.GetManager(id);
        }

        public Manager UpdateManager(Manager manager)
        {
            return _managerRepository.UpdateManager(manager);
        }



    }
}
