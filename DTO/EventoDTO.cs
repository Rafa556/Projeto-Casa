using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace PartyHome.DTO
{
    public class EventoDTO
    {
        [Required]

        public int Id{get; set;}       
        [Required(ErrorMessage="O nome de Evento não foi preenchido, Amigão!")]
        public string Event {get; set;}
        [Required(ErrorMessage="O limite de Baladeiros não foi preenchido, Amigão!")]
        [StringLength(500,ErrorMessage="O limite de baladeiros na casa de show é de 500!")]
        [MinLength(1,ErrorMessage="Sem Baladeiros, sem Festa, cara!")] 
        public int Capacidade{get; set;}
        [Required(ErrorMessage="A quantidade de ingressos não foi preenchido, Amigão!")]
        public int QtdIngressos {get; set;}
        [Required(ErrorMessage="A data do Show não foi preenchido, Amigão!")]
        public string Data{get; set;}
        [Required(ErrorMessage="O preço dos ingressos não foi preenchido, Amigão!")]
        public float Custo {get; set;}
        [Required(ErrorMessage="O genero musical não foi preenchido, Amigão!")]
        public string Genero{get; set;}    
        
        public int CasaId {get; set;}  
        
    }
}