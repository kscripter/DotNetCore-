using System;
using System.Collections.Generic;
using System.Linq;
using BankManagwmwntSystemEFWeb.Interface.Repository;
using BankManagwmwntSystemEFWeb.Interface.Service;
using BankManagwmwntSystemEFWeb.Models;
using BankManagwmwntSystemEFWeb.Models.Entities;


namespace BankManagwmwntSystemEFWeb.Domain.Service
{
    public class AccountHolderService : IAccountHolderService
    {

        // private readonly ApplicationContext _applicationContext;

        private readonly IAccountHolderRepository _accountHolderRepository;

        private readonly IAccountRepository _accountRepository;



        public AccountHolderService(IAccountHolderRepository accountHolderRepository, IAccountRepository accountRepository)
        {
            _accountHolderRepository = accountHolderRepository;
            _accountRepository = accountRepository;
        }


        public AccountHolder AddAccountHolder(AccountHolder accountHolder)
        {
            AccountHolder ac = _accountHolderRepository.AddAccountHolder(accountHolder);
            CreateAccount(ac.Id);
            return ac;
        }


        public List<AccountHolder> GetAll()
        {
            return _accountHolderRepository.GetAll();
            // return _applicationContext.AccountHolders.ToList();
            // return _accountHolderRepository.AccountHolders.GetAll();
        }



        public void DeleteAccountHolder(int id)
        {
            _accountHolderRepository.DeleteAccountHolder(id);
        }


        public AccountHolder GetDetails(int id)
        {
            return _accountHolderRepository.GetDetails(id);
        }


        public AccountHolder GetAccountHolder(int id)
        {
            return _accountHolderRepository.GetAccountHolder(id);
        }


        public AccountHolder UpdateAccountHolder(AccountHolder accountHolder)
        {
            return _accountHolderRepository.UpdateAccountHolder(accountHolder);
        }


        public bool Exists(int id)
        {
            return _accountHolderRepository.Exists(id);
        }



        public bool CreateAccountHolder(string firstName, string lastName, string middleName, DateTime dateOfBirth, string email, string phoneNumber, string address, string password, string checkPassword)
        {
            if (password.Equals(checkPassword))
            {
                AccountHolder newAccountHolder = new AccountHolder
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    DateOfBirth = dateOfBirth,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Address = address,
                    Password = password
                };
                int accountHolderId = _accountHolderRepository.CreateAccountHolder(newAccountHolder);

                if (accountHolderId != 0)
                {
                    return CreateAccount(accountHolderId);
                }
                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }



        public bool CreateAccount(int accountHolderId, double accountBalance = 0, int accountPin = 0, int accountStatus = 1)
        {
            string accountNumber = GenerateAccountNumber();

            Account newAccount = new Account
            {
                AccountHolderId = accountHolderId,
                AccountNumber = accountNumber,
                AccountBalance = accountBalance,
                Pin = accountPin,
                AccountStatus = accountStatus
            };

            bool hasCreate = _accountRepository.Create(newAccount);

            if (hasCreate)
            {
                //Console.WriteLine($"Account Created Successfully \n Your Account Number is {accountNumber}");
            }

            return hasCreate;

        }




        protected string GenerateAccountNumber()
        {
            Random random = new Random();

            string firstFive = random.Next(1, 10000).ToString("00000");
            string secondFive = random.Next(1, 10000).ToString("00000");

            string generatedNumber = $"{firstFive}{secondFive}";

            return generatedNumber;
        }

        public AccountHolder Login(string username, string password)
        {
            var accountHolder = _accountHolderRepository.FindByEmail(username);
            if (accountHolder == null || accountHolder.Password != password)
            {
                return null;
            }

            return accountHolder;
        }




    }
}

