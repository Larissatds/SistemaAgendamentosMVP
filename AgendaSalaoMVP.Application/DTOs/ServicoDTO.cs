using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaSalaoMVP.Application.DTOs
{
    public class ServicoDTO
    {
        public decimal IdServico { get; set; }

        [Required(ErrorMessage = "Nome do Serviço é um campo obrigatório.")]
        [DisplayName("Nome do Serviço")]
        public string NomeServico { get; set; }

        [Required(ErrorMessage = "Valor do Serviço é um campo obrigatório.")]
        [Range(1, double.MaxValue)]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Valor do Serviço")]
        public decimal ValorServico { get; set; }

        [Required(ErrorMessage = "Tempo Gasto é um campo obrigatório.")]
        [DisplayName("Tempo Gasto")]
        public TimeSpan TempoGasto { get; set; }
    }
}
