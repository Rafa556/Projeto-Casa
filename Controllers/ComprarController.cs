using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyHome.Data;
using PartyHome.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace PartyHome.Controllers
{
    public class ComprarController : Controller
    {
        private readonly ApplicationDbContext database;
    
        public ComprarController(ApplicationDbContext database){
            this.database = database;
        }
        [Authorize]
        public IActionResult Buy(int? Id){
            if(Id == null){
                return NotFound();
            }

            var evento = database.Eventos.ToList();
            Comprar comprar = new Comprar();
            comprar.Eventos = database.Eventos.First(registro => registro.Id == Id);
            return View(comprar);
        }
        public IActionResult ConfirmBuy(Comprar comprar){
            comprar.Eventos = database.Eventos.First(registro => registro.Id == comprar.Eventos.Id);
            comprar.DataComprar = DateTime.Now;
            comprar.TotalComprar = comprar.QtdIngressos = comprar.Eventos.Custo;

            var ingresso = database.Eventos.First(registro => registro.Id == comprar.Eventos.Id);
            ingresso.QuantidadeIngressos -= comprar.QtdIngressos;

            database.Update(ingresso);
            database.Add(comprar);
            database.SaveChanges();
        
        return RedirectToAction("Index");
        }
        
        public IActionResult Comprar(){
            var Teste = database.Eventos.ToList();
            
            return View();
        }
        public IActionResult Historico(){
            return View();
        }
    }
}