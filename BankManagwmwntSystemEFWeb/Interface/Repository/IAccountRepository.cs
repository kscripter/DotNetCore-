using System;
using System.Collections.Generic;
using BankManagwmwntSystemEFWeb.Models.Entities;

namespace BankManagwmwntSystemEFWeb.Interface.Repository
{
    public interface IAccountRepository
    {

        //public List<Account> ListAccounts();
        public bool Create(Account account);
        public Account FindById(int id);
        public Account Update(Account account);

        public bool UpdateMultiple(List<Account> accounts);
        public Account FindByAccountNumber(string accountNumber);
        //public bool Update(Account account, int accountHolderId);
        //public Account FindByAccountNumber(string accountNumber);

    }
}
