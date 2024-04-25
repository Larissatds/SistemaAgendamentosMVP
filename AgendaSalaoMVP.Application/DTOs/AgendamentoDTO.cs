using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaSalaoMVP.Application.DTOs
{
    public class AgendamentoDTO
    {
        public decimal IdAgendamento { get; set; }

        [Required(ErrorMessage = "Cliente é um campo obrigatório.")]
        [DisplayName("Cliente")]
        public decimal IdCliente { get; set; }

        [Required(ErrorMessage = "Serviço é um campo obrigatório.")]
        [DisplayName("Serviço")]
        public decimal IdServico { get; set; }

        [Required(ErrorMessage = "Data e Hora é um campo obrigatório.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - HH:mm}")]
        [DisplayName("Data e Hora Agendamento")]
        public DateTime DataHoraAgendada { get; set; }

        public ClienteDTO? Cliente { get; set; }

        public ServicoDTO? Servico { get; set; }
    }
}
