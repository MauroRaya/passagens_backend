namespace passagens_backend.Models
{
    public class Passagem
    {
        public int Id { get; set; }
        public string Origem { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public DateTime DataPartida { get; set; }
        public DateTime DataChegada { get; set; }
        public float Preco { get; set; }
        public string CompanhiaAerea { get; set; } = string.Empty;
        public string StatusReservada { get; set; } = string.Empty;
    }
}
