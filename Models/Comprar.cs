using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PartyHome.Models
{
    public class Comprar
    {
        public int Id{get; set;}
        public Evento Eventos { get; set; }
        public DateTime DataComprar { get; set;} 
        public float TotalComprar { get; set; }
        public float QtdIngressos { get; set; }
    }
}