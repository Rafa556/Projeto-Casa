using Microsoft.AspNetCore.Mvc;
using PartyHome.Data;
using System.Linq;
using PartyHome.Models;
using System;

namespace PartyHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasApiController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public VendasApiController(ApplicationDbContext database){
        this.database = database;
        }
        [HttpGet(" Listar todas as vendas")]
        public IActionResult Get(){
            var vendas = database.VendasApi.ToList();
            var cont = vendas.Count();
            {
                if(cont > 0){
                    return Ok(vendas);
                }else{
                    Response.StatusCode= 404;
                    return new ObjectResult("Não existe vendas!");
                }
            }
        }
        [HttpGet("{id} Buscar Id")]
        public IActionResult Get(int id){
            try{
            VendaApi venda = database.VendasApi.First(q => q.Id == id);
            return Ok(venda);
            }catch(Exception){
                Response.StatusCode = 404;
                return new ObjectResult(new{msg = "Id inválido!!"});
            }
        }
    }
}