using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagwmwntSystemEFWeb.Interface.Service;
using BankManagwmwntSystemEFWeb.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



namespace BankManagwmwntSystemEFWeb.Controllers
{
    public class LoanController : Controller
    {

        private readonly ILoanService _loanService;


        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }



        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View(_loanService.GetAll());
        }



        //[HttpGet]
        //HttpGetAttribute
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Loan loan)
        {
            if (ModelState.IsValid)
            {
                _loanService.AddLoan(loan);
            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult UpdateLoan(Loan loan)
        {
            if (ModelState.IsValid)
            {
                _loanService.UpdateLoan(loan);
                return RedirectToAction(nameof(Index));
            }
            return View(loan);
        }

        //[HttpPost]
        //public IActionResult CreateLoan(Loan loan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _loanService.AddLoan(loan);


        //    //return View();
        //    return RedirectToAction(nameof(Index));
        //}


    }
}
