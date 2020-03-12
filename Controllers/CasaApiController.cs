using Microsoft.AspNetCore.Mvc;
using PartyHome.Data;
using PartyHome.Models;
using System.Linq;
using System;
using System.Collections.Generic;

namespace PartyHome.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CasaApiController : ControllerBase
    {

        private readonly ApplicationDbContext database;

        public CasaApiController(ApplicationDbContext database){
            this.database = database;
        }
        [HttpGet]
        public IActionResult Get(){
            var casadeshows = database.CasaDeShows.ToList();
            return Ok(casadeshows);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            try{
            CasaDeShow casadeshows = database.CasaDeShows.First(p => p.Id == id);
            return Ok(casadeshows);
            }catch(Exception){
                return BadRequest(new {msg = "id invalido"});
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CasaApi casaapi){
            if(casaapi != null){
                try{
                    if(casaapi.Nome.Length <= 1){
                    Response.StatusCode= 400;

                    return new ObjectResult(new {msg = "A casa não exite"});}

                    if(casaapi.Endereco.Length <= 1){
                    Response.StatusCode= 400;

                    return new ObjectResult(new {msg = "O endereço não exite"});}

            CasaDeShow a = new CasaDeShow();
            a.Nome = casaapi.Nome;
            a.Endereco = casaapi.Endereco;
            database.CasaDeShows.Add(a);
            database.SaveChanges();

            Response.StatusCode = 201;
            return new ObjectResult(new {msg = "Casa criada com sucesso!"}); 
                }catch(Exception){
                Response.StatusCode = 404;
                return new ObjectResult(new{msg = "Erro!!!"});

                }
            }else{
                Response.StatusCode = 404;
                return new ObjectResult(new{msg = "Erro!!!"});
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            try{
            CasaDeShow casadeshows = database.CasaDeShows.First(p => p.Id == id);
            database.CasaDeShows.Remove(casadeshows);
            database.SaveChanges();
            return Ok();
            }catch(Exception){
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] CasaDeShow casadeshow){
            
            if(casadeshow.Id > 0){

                try{
                var p = database.CasaDeShows.First(cApi => cApi.Id == casadeshow.Id);
                
                if(p != null){

                    p.Nome = casadeshow.Nome != null ? casadeshow.Nome : p.Nome;
                    p.Endereco = casadeshow.Endereco != null ? casadeshow.Endereco : p.Endereco;

                    database.SaveChanges();
                    return Ok();
                }else{
                    Response.StatusCode = 400;
                    return new ObjectResult(new{msg = "Produto nçao encontrado"});

                }
                
                }catch{
                    Response.StatusCode = 400;
                    return new ObjectResult(new {msg = "O id do casa é invalido!"});
                }
            }else{
                Response.StatusCode = 400;
                return new ObjectResult(new {msg = "O Id da casa é invalido"});

            }
        }
        [HttpGet("nome")]
        public IActionResult GetCasaByNome(string CasaApi){
            if(database.CasaDeShows.Count() > 0){
                if(database.CasaDeShows.Where(c => c.Nome == CasaApi).Count() == 0){
                    Response.StatusCode = 404;
                    return new ObjectResult("Nome invalido");
                }else{
                 try{ 
                     var casaNome = database.CasaDeShows.Where(c => c.Nome == CasaApi).ToList();
                    return Ok(casaNome);
                    }catch(Exception) 
                    {Response.StatusCode = 404;
                    return new ObjectResult("Casa invalida");

                    }
                }
            }else{
                    Response.StatusCode = 404;
                    return new ObjectResult("Nome invalido");

            }
        }
        [HttpGet("asc")]
        public IActionResult GetCasaByAsc(){
            var CasaDeShow = database.CasaDeShows.OrderBy(NomeA => NomeA.Nome).ToList();
            return Ok(CasaDeShow);
            }
        [HttpGet("desc")]
        public IActionResult GetCasaByDesc(){
            var CasaDeShow = database.CasaDeShows.OrderByDescending(NomeD => NomeD.Nome).ToList();
            return Ok(CasaDeShow);
            }
        public class CasaApi{
            public string Nome {get; set;}
            public string Endereco {get; set;}
        }
    }
}