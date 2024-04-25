using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaSalaoMVP.Domain.Entities
{
    [Table("TB_SERVICOS")]
    public class Servico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_SERVICO")]
        public decimal IdServico { get; set; }

        [Column("NOME_SERVICO")]
        public string NomeServico { get; set; }

        [Column("VALOR_SERVICO")]
        public decimal ValorServico { get; set; }

        [Column("TEMPO_GASTO")]
        public TimeSpan TempoGasto { get; set; }
    }
}
