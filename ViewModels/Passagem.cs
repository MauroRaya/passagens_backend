using System.ComponentModel.DataAnnotations;

namespace passagens_backend.ViewModels
{
    public class CreateAndUpdatePassagem
    {
        [Required(ErrorMessage = "Origem é obrigatória")]
        public string Origem { get; set; } = string.Empty;

        [Required(ErrorMessage = "Destino é obrigatório")]
        public string Destino { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data de partida é obrigatória")]
        [DataType(DataType.Date, ErrorMessage = "Data de partida deve ser uma data válida")]
        public DateTime DataPartida { get; set; }

        [Required(ErrorMessage = "Data de chegada é obrigatória")]
        [DataType(DataType.Date, ErrorMessage = "Data de chegada deve ser uma data válida")]
        public DateTime DataChegada { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
        public float Preco { get; set; }

        [Required(ErrorMessage = "Companhia aérea é obrigatória")]
        public string CompanhiaAerea { get; set; } = string.Empty;

        public string StatusReservada { get; set; } = string.Empty;
    }
}
