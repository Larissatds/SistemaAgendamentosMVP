using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaSalaoMVP.Domain.Entities
{
    [Table("TB_AGENDAMENTOS")]
    public class Agendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_AGENDAMENTO")]
        public decimal IdAgendamento { get; set; }

        [Column("ID_CLIENTE")]
        public decimal IdCliente { get; set; }

        [Column("ID_SERVICO")]
        public decimal IdServico { get; set; }

        [Column("DATA_HORA_AGENDADA")]
        public DateTime DataHoraAgendada { get; set; }

        public Cliente Cliente { get; set; }

        public Servico Servico { get; set; }
    }
}
