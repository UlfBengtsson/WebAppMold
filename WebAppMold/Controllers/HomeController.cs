using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;// for session to handle GetString & GetInt32 (and Set counterparts)
using Microsoft.AspNetCore.Mvc;
using WebAppMold.Models;

namespace WebAppMold.Controllers
{
    public class HomeController : Controller
    {
        //CarService _carService = new CarService();

        public IActionResult Index()
        {
            ViewBag.Memo = HttpContext.Session.GetString("Memo");

            return View("Index");//return View();
        }

        [HttpGet]
        public IActionResult AddMemo()
        {
            HttpContext.Session.SetInt32("numberToGuess", new Random().Next(1, 101));
            return View();
        }
        
        [HttpPost]
        public IActionResult AddMemo(string memo)
        {
            //bool result = _carService.ValidRegPlate(memo);

            HttpContext.Session.SetString("Memo", memo);

            return RedirectToAction(nameof(Index));
        }
    }
}
