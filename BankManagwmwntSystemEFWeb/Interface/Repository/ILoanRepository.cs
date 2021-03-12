using System;
using System.Collections.Generic;
using BankManagwmwntSystemEFWeb.Models.Entities;

namespace BankManagwmwntSystemEFWeb.Interface.Repository
{
    public interface ILoanRepository
    {

        public Loan CreateLoan(Loan loan);

        // public void AddLoan(int accountHolderId, double amount, string type);

        public List<Loan> GetAll();

        public Loan AddLoan(Loan loan);

        public Loan UpdateLoan(Loan loan);

        public List<Loan> FindAllLoansById(int id);



        public Loan FindActiveLoanById(int id);

    }
}
