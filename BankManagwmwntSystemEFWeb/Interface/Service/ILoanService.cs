using System;
using System.Collections.Generic;
using BankManagwmwntSystemEFWeb.Models.Entities;

namespace BankManagwmwntSystemEFWeb.Interface.Service
{
    public interface ILoanService
    {


        public void AddLoan(int accountHolderId, double amount, string type);

        public List<Loan> GetAll();

        public Loan AddLoan(Loan loan);


        public Loan UpdateLoan(Loan loan);

    }
}
