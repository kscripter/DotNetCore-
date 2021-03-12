using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagwmwntSystemEFWeb.Interface.Service;
using BankManagwmwntSystemEFWeb.Models;
using BankManagwmwntSystemEFWeb.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



namespace BankManagwmwntSystemEFWeb.Controllers
{
    public class ManagerController : Controller
    {


        private readonly IManagerService _managerService;


        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }



        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View(_managerService.GetAll());
        }



        //[HttpGet]
        //HttpGetAttribute
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Manager manager)
        {
            if (ModelState.IsValid)
            {
                _managerService.AddManager(manager);
            }

            //return View();
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = _managerService.GetManager(id.Value);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }




        [HttpPost]
        public IActionResult Edit(int id, Manager manager)
        {
            if (id != manager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _managerService.UpdateManager(manager);
                return RedirectToAction(nameof(Index));
            }

            return View(manager);
        }




        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = _managerService.GetManager(id.Value);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }




        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _managerService.DeleteManager(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
