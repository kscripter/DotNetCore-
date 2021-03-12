//using System;
using System;
using System.Collections.Generic;
using System.Linq;
using BankManagwmwntSystemEFWeb.Interface.Repository;
using BankManagwmwntSystemEFWeb.Models;
using BankManagwmwntSystemEFWeb.Models.Entities;

namespace BankManagwmwntSystemEFWeb.Interface.Service
{
    public interface IAccountHolderService
    {

        public bool CreateAccountHolder(string firstName, string lastName, string middleName, DateTime dateOfBirth, string email, string phoneNumber, string address, string password, string checkPassword);


        //public int CreateAccountHolder(AccountHolder
        //    accountHolder);



        public AccountHolder AddAccountHolder(AccountHolder accountHolder);


        // public int LogInAccountHolder(string email, string password);


        public AccountHolder GetAccountHolder(int id);


        public void DeleteAccountHolder(int id);


        public List<AccountHolder> GetAll();


        public AccountHolder UpdateAccountHolder(AccountHolder accountHolder);


        public AccountHolder GetDetails(int id);


        public AccountHolder Login(string username, string password);



    }
}









//public List<AccountHolder> GetAccountHolders(AccountHolder accountHolder);



////public AccountHolder GetAccountHolder(string firstName);



//public AccountHolder AddAccountHolder(AccountHolder accountHolder);


//public bool Exists(int id);






























//private readonly ApplicationContext _applicationContext;


//public IAccountHolderService(ApplicationContext applicationContext)
//{
//    _applicationContext = applicationContext;
//}


//public AccountHolder AddAccountHolder(AccountHolder accountHolder)
//{
//    _applicationContext.AccountHolders.Add(accountHolder);
//    _applicationContext.SaveChanges();
//    return accountHolder;
//}


//public void DeleteAccountHolder(int id)
//{
//    var accountHolder = _applicationContext.AccountHolders.Find(id);

//    if (accountHolder != null)
//    {
//        _applicationContext.AccountHolders.Remove(accountHolder);
//        _applicationContext.SaveChanges();
//    }
//}

//public bool Exists(int id)
//{
//    return _applicationContext.AccountHolders.Any(a => a.Id == id);
//}


//public AccountHolder GetAccountHolder(string firstName)
//{
//    //return _applicationContext.Users.FirstOrDefault(a => a.FirstName == firstName);
//    return _applicationContext.AccountHolders.Find(firstName);
//}

//public List<AccountHolder> GetAccountHolders()
//{
//    return _applicationContext.AccountHolders.ToList();
//}


//public AccountHolder UpdateAccountHolder(AccountHolder accountHolder)
//{
//    _applicationContext.AccountHolders.Update(accountHolder);
//    _applicationContext.SaveChanges();
//    return accountHolder;
//}

//List<AccountHolder> IAccountHolderRepository.GetAccountHolders()
//{
//    throw new NotImplementedException();
//}
