using Microsoft.AspNetCore.Mvc;
using PartyHome.Models;
using PartyHome.Data;
using System.Linq;
using PartyHome.Controllers;
using PartyHome.DTO;

namespace PartyHome.Controllers
{
    public class EventoController : Controller
    {
        private readonly ApplicationDbContext database; 
        public EventoController(ApplicationDbContext database){
            this.database = database;
        }
        public IActionResult Index(){
            var evento  = database.Eventos.ToList();
            var ListaShow = database.CasaDeShows.ToList();
         ViewBag.CasaDeShows=database.CasaDeShows.ToList();
            return View(evento);
        }
        public IActionResult Cadastrar(){
         ViewBag.CasaDeShows = database.CasaDeShows.ToList();
        var Contagem = database.Eventos.ToList();
        var aux = Contagem.Count;
        if(aux == 0){
            return View("Erro");
        }

            return View();
        }        

        public IActionResult Editar(int Id){
            Evento evento = database.Eventos.First(registro => registro.Id == Id);
            ViewBag.CasaDeShows=database.CasaDeShows.ToList();
            return View("Cadastrar", evento);
        }
        public IActionResult Deletar(int Id){
           Evento evento = database.Eventos.First(registro => registro.Id == Id);
            database.Eventos.Remove(evento);
            database.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Comprar(){
            return RedirectToAction();
        }
        [HttpPost]
        public IActionResult Salvar( Evento evento, EventoDTO eventoTemporario){
            if(evento.Id == 0){evento.CasaId = database.CasaDeShows.First(registroCasa => registroCasa.Id == evento.CasaId.Id);
                database.Eventos.Add(evento);
                
            }else{
               //Evento eventoDoBanco = database.Eventos.First(registro => registro.Id == evento.Id);
               evento.CasaId = database.CasaDeShows.First(registroCasa => registroCasa.Id == evento.CasaId.Id);

               /* eventoDoBanco.Event = evento.Event;
                eventoDoBanco.Capacidade = evento.Capacidade;
                eventoDoBanco.QtdIngressos = evento.QtdIngressos;
                eventoDoBanco.Data = evento.Data;
                eventoDoBanco.Custo = evento.Custo;
                eventoDoBanco.Local = evento.Local;
                eventoDoBanco.Genero = evento.Genero;*/

            database.Update(evento);
            }  
            ViewBag.CasaDeShow = database.CasaDeShows.ToList();
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}