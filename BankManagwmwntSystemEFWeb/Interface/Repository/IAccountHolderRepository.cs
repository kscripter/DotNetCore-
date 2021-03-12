using System;
using System.Collections.Generic;
using BankManagwmwntSystemEFWeb.Models;
using BankManagwmwntSystemEFWeb.Models.Entities;

namespace BankManagwmwntSystemEFWeb.Interface.Repository
{
    public interface IAccountHolderRepository
    {




        public int CreateAccountHolder(AccountHolder
            accountHolder);


        public AccountHolder AddAccountHolder(AccountHolder accountHolder);


        //   public List<AccountHolder> GetAccountHolders();

        public List<AccountHolder> GetAll();

        // public AccountHolder GetAccountHolder(string firstName);

        public AccountHolder GetAccountHolder(int id);


        public AccountHolder FindByEmail(string email);


        public AccountHolder GetDetails(int id);


        public AccountHolder FindById(int id);


        public AccountHolder Update(AccountHolder accountHolder);



        public AccountHolder UpdateAccountHolder(AccountHolder accountHolder);



        public void DeleteAccountHolder(int id);


        public bool Exists(int id);

    }
}
