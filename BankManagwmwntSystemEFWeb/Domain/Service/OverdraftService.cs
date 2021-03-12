//using System;
//using System.Collections.Generic;
//using BankManagwmwntSystemEFWeb.Domain.Repository;
//using BankManagwmwntSystemEFWeb.Interface.Repository;
//using BankManagwmwntSystemEFWeb.Interface.Service;
//using BankManagwmwntSystemEFWeb.Models.Entities;

//namespace BankManagwmwntSystemEFWeb.Domain.Service
//{
//    public class OverdraftService : IOverdraftService
//    {


//        private readonly IOverdraftService _overdraftService;



//        public OverdraftService(IOverdraftService overdraftService)
//        {
//            _overdraftService = overdraftService;
//        }



//        public List<Overdraft> GetAll()
//        {
//            return _overdraftService.GetAll();
//        }



//        public void AddOverdraft(int accountHolderId, double amount, double amountLeft)
//        {
//            Overdraft newOverdraft = new Overdraft
//            {
//                AccountHolderId = accountHolderId,
//                Amount = amount,
//                Status = 1,
//                AmountLeft = amount

//            };

//            try
//            {

//                List<Loan> allLoan = OverdraftRepository.FindAllOverdraftById(accountHolderId);

//                if (allOverdraft.Count < 1)
//                {

//                    _overdraftRepository.CreateLoan(newOverdraft);
//                }
//                else
//                {
//                    Loan activeOverdraft = FindActiveOverdraft(allOverdraft);
//                    if (activeOverdraft == null)
//                    {
//                        _overdraftRepository.CreateLoan(newOverdraft);


//                    }

//                    else
//                    {
//                        throw new Exception($"You currently have an unpaid loan of {activeLoan.AmountLeft}. Please pay up to qualify for another");
//                    }

//                }

//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }






//        public Overdraft AddOverdraft(Overdraft overdraft)
//        {
//            Overdraft newOverdraft = _overdraftRepository.AddLoan(loan);

//            return newOverdraft;
//        }







//        public void PayOverdraft(int accountHolderId, double amount)
//        {

//            //Console.WriteLine(accountHolderId);
//            //Console.WriteLine(amount);

//            List<Overdraft> allOverdraft = _overdraftRepository.FindAllLoansById(accountHolderId);

//            if (allOverdraft.Count < 1 || (FindActiveOverdraft(allOverdraft) == null))
//            {
//                //Console.WriteLine("You do not have any active loan ):");
//            }
//            else
//            {

//                Loan activeLoan = FindActiveOverdraft(allOverdraft);


//                if (activeLoan.AmountLeft < amount)
//                {
//                    //Console.WriteLine("Amount To Pay Is Greater Than Your Loan Balance");
//                }
//                else
//                {
//                    activeLoan.AmountLeft -= amount;
//                    if (activeLoan.AmountLeft <= 0) activeLoan.AmountLeft = 0;

//                    if (activeLoan.AmountLeft == 0) activeLoan.Status = 0;

//                    if (_loanRepository.UpdateLoan(activeLoan) != null)
//                    {
//                        //string message = (activeLoan.Status == 0) ? $"Congratulations: Your Loan has been completely paid." : $"You have successfully paid {amount}. You currently have {activeLoan.AmountLeft} left to pay";

//                        //Console.WriteLine(message);
//                    }
//                    else
//                    {
//                        //Console.WriteLine("An eeror occoured");
//                    }

//                }

//            }

//        }




//        public Overdraft UpdateOverdraft(Overdraft overdraft)
//        {
//            return _overdraftService.UpdateOverdraft(overdraft);
//        }
//    }
//}

