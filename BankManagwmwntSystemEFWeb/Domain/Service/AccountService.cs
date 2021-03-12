//using System;
//using BankManagwmwntSystemEFWeb.Domain.Repository;
//using BankManagwmwntSystemEFWeb.Models;
//using BankManagwmwntSystemEFWeb.Models.Entities;

//namespace BankManagwmwntSystemEFWeb.Domain.Service
//{
//    public class AccountService
//    {



//        private readonly AccountRepository _accountRepository;

//        private static Account loggedInAccount;


//        public AccountService(AccountRepository accountRepository)
//        {
//            _accountRepository = accountRepository;
//        }

//        //public void ChangePin(int newPin)
//        //{
//        //    loggedInAccount.Pin = newPin;
//        //    _accountRepository.Update(loggedInAccount, loggedInAccount.AccountHolderId);
//        //}





//        private readonly AccountRepository _accountRepository;
//        public static Account loggedInAccount;

//        public AccountService(AccountRepository accountRepository)
//        {
//            _accountRepository = accountRepository;
//        }

//        public void ChangePin(int newPin)
//        {
//            loggedInAccount.Pin = newPin;
//            _accountRepository.Update(loggedInAccount, loggedInAccount.AccountHolderId);
//        }

//        public bool Create(int accountHolderId, double accountBalance = 0, int accountPin = 0, int accountStatus = 1)
//        {
//            string accountNumber = GenerateAccountNumber();
//            bool hasCreate = _accountRepository.Create(accountHolderId, accountNumber);

//            if (hasCreate)
//            {
//                Console.WriteLine($"Account Created Successfully \n Your Account Number is {accountNumber}");
//            }

//            return hasCreate;

//        }

//        public BankManagementSystemDB.Account FindByAccountNumber(string accountNumber)
//        {
//            throw new NotImplementedException();
//        }

//        public bool SaveMoney(double userInput, int accountHolderId)
//        {
//            double Value = userInput + loggedInAccount.AccountBalance;
//            loggedInAccount.AccountBalance = Value;
//            _accountRepository.Update(loggedInAccount, accountHolderId);
//            return true;
//        }

//        public double CheckBalance()
//        {
//            return loggedInAccount.AccountBalance;

//        }



//        public List<BankManagementSystemDB.Account> ListAccounts()
//        {
//            throw new NotImplementedException();
//        }

//        public void Remove()
//        {
//            throw new NotImplementedException();
//        }

//        public void SetPin(int newPin)
//        {

//        }

//        public void Transfer(string accountNumber, double amountToTransfer)
//        {
//            Account accountToTransferTo = _accountRepository.FindByAccountNumber(accountNumber);

//            try
//            {
//                if (accountToTransferTo != null)
//                {
//                    Console.WriteLine($"Sending {amountToTransfer} to {accountToTransferTo.AccountHolderId}");


//                    accountToTransferTo.AccountBalance += amountToTransfer;

//                    Console.WriteLine($"New balance {accountToTransferTo.AccountBalance}");

//                    _accountRepository.Update(accountToTransferTo, accountToTransferTo.AccountHolderId);
//                    loggedInAccount.AccountBalance -= amountToTransfer;
//                    _accountRepository.Update(loggedInAccount, loggedInAccount.AccountHolderId);
//                }
//                else
//                {

//                    throw new Exception("Account not found");

//                }
//            }
//            catch (Exception e)
//            {

//                Console.WriteLine(e.Message);

//            }



//        }

//        //public void WithdrawMoney(double amountToWthdraw)
//        //{
//        //    loggedInAccount.AccountBalance -= amountToWthdraw;
//        //    _accountRepository.Update(loggedInAccount, loggedInAccount.AccountHolderId);
//        //}

//        //protected string GenerateAccountNumber()
//        //{
//        //    Random random = new Random();

//        //    string firstFive = random.Next(1, 10000).ToString("00000");
//        //    string secondFive = random.Next(1, 10000).ToString("00000");

//        //    string generatedNumber = $"{firstFive}{secondFive}";

//        //    return generatedNumber;
//        //}

//    }
//}
