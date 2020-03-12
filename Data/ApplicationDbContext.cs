using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PartyHome.Models;

namespace PartyHome.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<CasaDeShow> CasaDeShows {get; set;}
        public DbSet<CasaApi> CasaApiS {get; set;}
        public DbSet<Evento> Eventos {get; set;}
        public DbSet<EventoApi> EventoApis {get; set;}
        public DbSet<VendaApi> VendasApi {get; set;}
        public DbSet<UsuarioAPI> UsuariosAPI {get; set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
