using Microsoft.AspNetCore.Mvc;
using PartyHome.Data;
using System;
using System.Linq;
using PartyHome.Models;

namespace PartyHome.Controllers
{
    [Route("api/v1/usuarios")]
    [ApiController]
    public class UsuarioApiController : ControllerBase
    {
         private readonly ApplicationDbContext database;

        public UsuarioApiController(ApplicationDbContext database){
            this.database = database;
            
        }     
      [HttpGet]
      public IActionResult Get() {
           if (database.Users.Count() > 0) 
           { var usuario = database.Users.Select(u => new { u.Id, u.Email }).ToList();
            return Ok(usuario); 
            } else { 
            Response.StatusCode = 404;
             return new ObjectResult("Não existem usuarios cadastrados"); 
             }
             }
              [HttpGet("{email}")] 
              public IActionResult Get (string email) 
              { try 
              { var usuario = database.Users.Select(user => new UserTemp { Id = user.Id, Email = user.Email }).First(c => c.Email == email); 
              return Ok(usuario); 
              } catch (Exception) { 
                  Response.StatusCode = 404;
                   return new ObjectResult("E-mail inválido"); 
                   }
                    } 
                    public class UserTemp {
                    public string Id {get; set;}
                    public string Email {get; set;} }
    }
}