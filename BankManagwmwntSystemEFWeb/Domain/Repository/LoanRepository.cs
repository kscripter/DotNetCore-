using System;
using System.Collections.Generic;
using System.Linq;
using BankManagwmwntSystemEFWeb.Interface.Repository;
using BankManagwmwntSystemEFWeb.Models;
using BankManagwmwntSystemEFWeb.Models.Entities;

namespace BankManagwmwntSystemEFWeb.Domain.Repository
{
    public class LoanRepository : ILoanRepository
    {

        private readonly ApplicationContext _applicationContext;


        public LoanRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Loan AddLoan(Loan loan)
        {
            _applicationContext.Loans.Add(loan);
            _applicationContext.SaveChanges();
            return loan;
        }

        public Loan CreateLoan(Loan loan)
        {
            _applicationContext.Loans.Add(loan);
            _applicationContext.SaveChanges();
            return loan;
        }


        public Loan FindActiveLoanById(int id)
        {
            return _applicationContext.Loans.Where(ln => ln.AccountHolderId == id && ln.Status == 1).FirstOrDefault();
        }

        public List<Loan> FindAllLoansById(int id)
        {
            return _applicationContext.Loans.Where(ln => ln.AccountHolderId == id).ToList();
        }


        public Loan UpdateLoan(Loan loan)
        {
            _applicationContext.Loans.Update(loan);
            _applicationContext.SaveChanges();
            return loan;
        }


        public List<Loan> GetAll()
        {
            return _applicationContext.Loans.ToList();
        }





    }
}
