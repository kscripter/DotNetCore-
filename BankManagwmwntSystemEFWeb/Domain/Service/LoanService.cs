using System;
using System.Collections.Generic;
using BankManagwmwntSystemEFWeb.Domain.Repository;
using BankManagwmwntSystemEFWeb.Interface.Repository;
using BankManagwmwntSystemEFWeb.Interface.Service;
using BankManagwmwntSystemEFWeb.Models;
using BankManagwmwntSystemEFWeb.Models.Entities;

namespace BankManagwmwntSystemEFWeb.Domain.Service
{
    public class LoanService : ILoanService
    {

        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }


        public List<Loan> GetAll()
        {

            return _loanRepository.GetAll();

        }


        public void AddLoan(int accountHolderId, double amount, string type)
        {
            Loan newLoan = new Loan
            {
                AccountHolderId = accountHolderId,
                Amount = amount,
                Status = 1,
                TypeOfLoan = type,
                AmountLeft = amount

            };

            try
            {

                List<Loan> allLoan = _loanRepository.FindAllLoansById(accountHolderId);

                if (allLoan.Count < 1)
                {

                    _loanRepository.CreateLoan(newLoan);
                }
                else
                {
                    Loan activeLoan = FindActiveLoan(allLoan);
                    if (activeLoan == null)
                    {
                        _loanRepository.CreateLoan(newLoan);


                    }

                    else
                    {
                        throw new Exception($"You currently have an unpaid loan of {activeLoan.AmountLeft}. Please pay up to qualify for another");
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public Loan AddLoan(Loan loan)
        {
            Loan newLoan = _loanRepository.AddLoan(loan);

            return newLoan;
        }


        public Loan FindActiveLoan(List<Loan> allLoan)
        {
            return allLoan.Find(x => x.Status == 1);
        }




        public double checkLoanBalance(int accountHolderId)
        {
            double balance = 0;

            Loan activeLoan = _loanRepository.FindActiveLoanById(accountHolderId);

            if (activeLoan != null)
            {

                balance = activeLoan.AmountLeft;

            }

            return balance;
        }




        public void PayLoan(int accountHolderId, double amount)
        {

            //Console.WriteLine(accountHolderId);
            //Console.WriteLine(amount);

            List<Loan> allLoan = _loanRepository.FindAllLoansById(accountHolderId);

            if (allLoan.Count < 1 || (FindActiveLoan(allLoan) == null))
            {
                //Console.WriteLine("You do not have any active loan ):");
            }
            else
            {

                Loan activeLoan = FindActiveLoan(allLoan);


                if (activeLoan.AmountLeft < amount)
                {
                    //Console.WriteLine("Amount To Pay Is Greater Than Your Loan Balance");
                }
                else
                {
                    activeLoan.AmountLeft -= amount;
                    if (activeLoan.AmountLeft <= 0) activeLoan.AmountLeft = 0;

                    if (activeLoan.AmountLeft == 0) activeLoan.Status = 0;

                    if (_loanRepository.UpdateLoan(activeLoan) != null)
                    {
                        //string message = (activeLoan.Status == 0) ? $"Congratulations: Your Loan has been completely paid." : $"You have successfully paid {amount}. You currently have {activeLoan.AmountLeft} left to pay";

                        //Console.WriteLine(message);
                    }
                    else
                    {
                        //Console.WriteLine("An eeror occoured");
                    }

                }

            }

        }











        //public bool CreateLoan(int accountHolderId, double amount, string type)
        //{
        //    throw new NotImplementedException();
        //}



        public Loan UpdateLoan(Loan loan)
        {
            return _loanRepository.UpdateLoan(loan);
        }
    }
}