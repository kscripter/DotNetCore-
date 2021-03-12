using System;
namespace BankManagwmwntSystemEFWeb.Models.Entities
{
    public abstract class LoanOverdraftDetails : BaseEntity
    {



        public AccountHolder AccountHolder { get; set; }

        public int AccountHolderId { get; set; }

        public double Amount { get; set; }

        public int Status { get; set; }



    }
}






//public LoanOverdraftDetails(int accountHolderId, double amount, int status = 1)
//{
//    AccountHolderId = accountHolderId;
//    Amount = amount;
//    Status = status;
//}