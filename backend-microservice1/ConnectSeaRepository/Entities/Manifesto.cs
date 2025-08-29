namespace ConnectSeaRepository.Entities
{
    public class Manifesto
    {
        public int? Id {get;set;}
        public string? Numero {get;set;}
        public string? Tipo {get;set;}
        public string? Navio {get;set;}
        public string? Porto_origem {get;set;}
        public string? Porto_destino {get;set;}
    }
}