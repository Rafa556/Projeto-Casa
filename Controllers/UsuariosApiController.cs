using Microsoft.AspNetCore.Mvc;
using PartyHome.Data;
using System;
using System.Linq;
using PartyHome.Models;

namespace PartyHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioApiController : ControllerBase
    {
         private readonly ApplicationDbContext database;

        public UsuarioApiController(ApplicationDbContext database){
            this.database = database;
            
        }     
      [HttpGet(" Listar todos os Id")]
      public IActionResult Get() {
           if (database.Users.Count() > 0) 
           { var usuario = database.Users.Select(u => new { u.Id, u.Email }).ToList();
            return Ok(usuario); 
            } else { 
            Response.StatusCode = 404;
             return new ObjectResult("Não existem usuarios cadastrados"); 
             }
             }
              [HttpGet("{id} Buscar id")]
              public IActionResult Get (int id) 
              { try {
            UsuarioAPI usuarios = database.UsuariosAPI.First(p => p.Id == id);
              return Ok(usuarios); 
              } catch (Exception) { 
                  Response.StatusCode = 404;
                   return new ObjectResult("Id inválido"); 
                   }
                    } 
                    public class UserTemp {
                    public string Id {get; set;}
                    public string Email {get; set;} }
    }
}