namespace PartyHome.Models
{
    public class EventoApi
    {
        public int Id{get; set;}
        public string Event {get; set;}
        public int Capacidade{get; set;}
        public int QtdIngressos {get; set;}
        public string Data{get; set;}
        public float Custo {get; set;}
        public string Genero{get; set;}    
        public CasaDeShow CasaId {get; set;}
        public float QuantidadeIngressos { get; set; }
    }
}