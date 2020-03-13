using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartyHome.Data;
using PartyHome.Models;

namespace PartyHome.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventoApiController : ControllerBase
    {

        private readonly ApplicationDbContext database;

        public EventoApiController(ApplicationDbContext database){
            this.database = database;
        }
        [HttpGet(" Listar eventos")]

        public IActionResult Get(){
            var eventos = database.Eventos.ToList();
            return Ok(eventos);
        }

        [HttpGet("{id} Listar eventos pelo Id.")]

        public IActionResult Get(int id){
            try{
            Evento evento = database.Eventos.First(q => q.Id == id);
            return Ok(evento);
            }catch(Exception){
                return BadRequest(new {msg = "id invalido"});
            }
        }

        [HttpPost(" Adicionar Evento.")]

        public IActionResult Post([FromBody] EventoApi eApi){

            Evento e = new Evento();
            e.Event = eApi.Event;
            e.Capacidade = eApi.Capacidade;
            e.QtdIngressos = eApi.QtdIngressos;
            e.Data = eApi.Data;
            e.Custo = eApi.Custo;
            e.CasaId = eApi.CasaId;
            e.Genero=eApi.Genero;
            database.Eventos.Add(e);
            database.SaveChanges();

            Response.StatusCode = 201;
            return new ObjectResult(new {msg = "Evento criado!"});
        }

        [HttpDelete("{id} Deletar Evento.")]
        public IActionResult Delete(int id){
            try{
            Evento evento = database.Eventos.First(q => q.Id == id);
            database.Eventos.Remove(evento);
            database.SaveChanges();
            return Ok();
            }catch(Exception){
                Response.StatusCode = 404;
                return new ObjectResult(new{msg = "Erro!!!"});

            }
        }
        [HttpPatch(" Atualizar Evento.")]
        public IActionResult Patch([FromBody] Evento evento){
            
            if(evento.Id > 0){

                try{
                var p = database.Eventos.First(cApi => cApi.Id == evento.Id);
                
                if(p != null){

                    p.Event = evento.Event != null ? evento.Event : p.Event;
                    p.Capacidade = evento.Capacidade != 0 ? evento.Capacidade : p.Capacidade;
                    p.QtdIngressos = evento.QtdIngressos != 0 ? evento.QtdIngressos : p.QtdIngressos;
                    p.Data = evento.Data != null ? evento.Data : p.Data;
                    p.Custo = evento.Custo != 0 ? evento.Custo : p.Custo;
                    p.Genero = evento.Genero != null ? evento.Genero : p.Genero;



                    database.SaveChanges();
                    return Ok();

                }else{
                    Response.StatusCode = 400;
                    return new ObjectResult(new{msg = "Produto não encontrado"});
                }
                
                }catch{
                    Response.StatusCode = 400;
                    return new ObjectResult(new {msg = "O id do evento é invalido!"});
                }
            }else{
                Response.StatusCode = 400;
                return new ObjectResult(new {msg = "O Id do evento é invalido"});

            }
        }

        [HttpGet("nome/asc Listar eventos em ordem alfabética crescente por nome.")]
        public IActionResult GetEventoNomeByAsc(){
            var Evento = database.Eventos.OrderBy(NomeA => NomeA.Event).ToList();
            return Ok(Evento);
            }

        [HttpGet("nome/desc Listar eventos em ordem alfabética decrescente por nome.")]
        public IActionResult GetEventoNomeByDesc(){
            var Evento = database.Eventos.OrderByDescending(NomeA => NomeA.Event).ToList();
            return Ok(Evento);
            }

        [HttpGet("capacidade/asc Listar eventos em ordem alfabética crescente por capacidade.")]
        public IActionResult GetEventoCapacidadeByAsc(){
            var Evento = database.Eventos.OrderBy(CapA => CapA.Capacidade).ToList();
            return Ok(Evento);
            }

            [HttpGet("capacidade/desc Listar eventos em ordem alfabética decrescente por capacidade.")]
        public IActionResult GetEventoCapacidadeByDesc(){
            var Evento = database.Eventos.OrderByDescending(CapA => CapA.Capacidade).ToList();
            return Ok(Evento);
            }

        [HttpGet("preco/asc Listar eventos em ordem alfabética crescente por preço.")]
        public IActionResult GetEventoCustoByAsc(){
            var Evento = database.Eventos.OrderBy(PrecoA => PrecoA.Custo).ToList();
            return Ok(Evento);
            }

            [HttpGet("preco/desc Listar eventos em ordem alfabética decrescente por preço.")]
        public IActionResult GetEventoCustoByDesc(){
            var Evento = database.Eventos.OrderByDescending(PrecoA => PrecoA.Custo).ToList();
            return Ok(Evento);
            }
        [HttpGet("data/asc Listar eventos em ordem alfabética crescente por data.")]
        public IActionResult GetEventoDataByAsc(){
            var Evento = database.Eventos.OrderBy(DataA => DataA.Data).ToList();
            return Ok(Evento);
            }
            [HttpGet("data/desc Listar eventos em ordem alfabética decrescente por data.")]
        public IActionResult GetEventoDataByDesc(){
            var Evento = database.Eventos.OrderByDescending(DataA => DataA.Data).ToList();
            return Ok(Evento);
            }

        public class EventoApi{
        public string Event {get; set;}
        public int Capacidade{get; set;}
        public int QtdIngressos {get; set;}
        public string Data{get; set;}
        public float Custo {get; set;}
        public CasaDeShow CasaId {get; set;}
        public string Genero{get; set;} }
        
    }
}