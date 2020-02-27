using System;
using Microsoft.AspNetCore.Mvc;
using PartyHome.Data;
using System.Linq;
using PartyHome.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PartyHome.Controllers
{
    public class ComprarController : Controller
    {
        private readonly ApplicationDbContext database;
    
        public ComprarController(ApplicationDbContext database){
            this.database = database;
        }
        public IActionResult Buy(){
        return NotFound();
        }
        public IActionResult Historico(){
            return View();
        }
    }
}