using System;
namespace BankManagwmwntSystemEFWeb.Models.Entities
{
    public class Loan : LoanOverdraftDetails
    {




        public string TypeOfLoan { get; set; }

        public double AmountLeft { get; set; }

        public DateTime LoanDate { get; }




    }
}




//public Loan(int accountHolderId, double amount, int status = 1) : base(accountHolderId, amount, status)
//{

//}




//public Loan(int accountHolderId, double amount, DateTime loanDate, int status, double amountLeft) : base(accountHolderId, amount, status)
//{
//    LoanDate = loanDate;
//    AmountLeft = amountLeft;

//}
