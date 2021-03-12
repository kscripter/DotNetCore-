using System;
namespace BankManagwmwntSystemEFWeb.Interface.Service
{
    public interface IAccountService
    {


        bool Create(int accountHolderId, double accountBalance = 0.00, int accountPin = 0, int accountStatus = 1);

        void Remove();

        // Account FindByAccountNumber(string accountNumber);

        void Transfer(string accountNumber, double amountToTransfer);

        void WithdrawMoney(double amountToWithdraw);

        double CheckBalance();

        void SetPin(int pin);

        void ChangePin(int pin);

        // public List<Account> ListAccounts();

    }
}
