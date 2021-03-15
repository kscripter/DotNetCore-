using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BankManagwmwntSystemEFWeb.Interface.Service;
using BankManagwmwntSystemEFWeb.Models;
using BankManagwmwntSystemEFWeb.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



namespace BankManagwmwntSystemEFWeb.Controllers
{

    [Authorize(Roles = "AccountHolder")]
    public class AccountHolderController : Controller
    {

        private readonly IAccountHolderService _accountHolderService;


        public AccountHolderController(IAccountHolderService accountHolderService)
        {
            _accountHolderService = accountHolderService;

        }



        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            //var accountHolderList = _accountHolderService.GetAll();
            //return View(accountHolderList);
            return View(_accountHolderService.GetAll());
        }


        //[HttpGet]
        //HttpGetAttribute
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(AccountHolder accountHolder)
        {
            if (ModelState.IsValid)
            {
                _accountHolderService.AddAccountHolder(accountHolder);

                return RedirectToAction(nameof(Index));
            }


            return View(accountHolder);

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountHolder = _accountHolderService.GetAccountHolder(id.Value);
            if (accountHolder == null)
            {
                return NotFound();
            }

            return View(accountHolder);
        }



        [HttpPost]
        public IActionResult Edit(int id, AccountHolder accountHolder)
        {
            if (id != accountHolder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _accountHolderService.UpdateAccountHolder(accountHolder);
                return RedirectToAction(nameof(Index));
            }

            return View(accountHolder);
        }



        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountHolder = _accountHolderService.GetAccountHolder(id.Value);
            if (accountHolder == null)
            {
                return NotFound();
            }

            return View(accountHolder);
        }



        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _accountHolderService.DeleteAccountHolder(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string email, string password)
        {
            var accountHolder = _accountHolderService.Login(email, password);
            if (accountHolder == null)
            {
                ViewBag.Message = "Invalid Username/Password";
                return RedirectToAction("Login", "AccountHolder");
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{accountHolder.FirstName}"),

                    new Claim(ClaimTypes.GivenName, $"{accountHolder.FirstName} {accountHolder.LastName}"),

                    new Claim(ClaimTypes.NameIdentifier, accountHolder.Id.ToString()),

                    new Claim(ClaimTypes.Email, accountHolder.Email),

                    new Claim(ClaimTypes.Role, "AccountHolder"),
                };


                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction("Index", "AccountHolder");
            }
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            return View(_accountHolderService.GetDetails(id.Value));
        }


    }
}
