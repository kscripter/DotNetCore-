using System;
namespace BankManagwmwntSystemEFWeb.Models.Entities
{
    public class Account
    {


        public AccountHolder AccountHolder { get; set; }

        public string AccountNumber { get; set; }

        public double AccountBalance { get; set; }

        public int AccountHolderId { get; set; }

        public int Pin { get; set; }

        public int AccountStatus { get; set; }




















        //public Account(int accountHolderId, string accountNumber, double accountBalance, int pin, int accountStatus)
        //{
        //    AccountNumber = accountNumber;
        //    AccountBalance = accountBalance;
        //    AccountHolderId = accountHolderId;
        //    Pin = pin;
        //    AccountStatus = accountStatus;
        //}
    }
}
