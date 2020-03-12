using Microsoft.AspNetCore.Mvc;
using PartyHome.Models;
using PartyHome.Data;
using System.Linq;
using PartyHome.Controllers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PartyHome.Controllers
{
    public class EventoController : Controller
    {
        private readonly ApplicationDbContext database; 
        public EventoController(ApplicationDbContext database){
            this.database = database;
        }
        public async Task<IActionResult> Index(){
            var evento  = database.Eventos.ToList();
            var ListaShow = database.CasaDeShows.ToList();
         ViewBag.CasaDeShows=database.CasaDeShows.ToList();
            return View(await database.Eventos.ToListAsync());
        }
        public IActionResult Cadastrar(){
         ViewBag.CasaDeShows = database.CasaDeShows.ToList();
            return View();
        }        

        public IActionResult Editar(int Id){
            ViewBag.CasaDeShows =database.CasaDeShows.ToList();
            Evento evento = database.Eventos.First(registro => registro.Id == Id);
            return View("Cadastrar", evento);
        }
        public IActionResult Deletar(int Id){
           Evento evento = database.Eventos.First(registro => registro.Id == Id);
            database.Eventos.Remove(evento);
            database.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Salvar( Evento evento){
                                    var Contagem = database.Eventos.ToList();
                                    if (ModelState.IsValid){
                                      Evento evento1 = new Evento(); 

                                      evento1.Event = evento.Event;
                                      evento1.Capacidade = evento.Capacidade;
                                      evento1.QtdIngressos = evento.QtdIngressos;
                                      evento1.Data = evento.Data;
                                      evento1.Custo = evento.Custo;
                                      evento1.Genero = evento.Genero;
                                     evento1.CasaId = database.CasaDeShows.First(c => c.Id == evento.CasaId.Id);

                database.Eventos.Add(evento1);
                database.SaveChanges();
                return RedirectToAction("Index");}

       
           else{

            evento.CasaId = database.CasaDeShows.First(registroCasa => registroCasa.Id == evento.CasaId.Id);

            database.Update(evento);
            }  
            ViewBag.CasaDeShow = database.CasaDeShows.ToList();
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}