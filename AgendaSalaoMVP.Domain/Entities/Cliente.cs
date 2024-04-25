using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaSalaoMVP.Domain.Entities
{
    [Table("TB_CLIENTES")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CLIENTE")]
        public decimal IdCliente { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("DATA_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("ENDERECO")]
        public string Endereco { get; set; }

        [Column("BAIRRO")]
        public string Bairro { get; set; }

        [Column("CIDADE")]
        public string Cidade { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; }

        [Column("CEP")]
        public decimal? Cep { get; set; }

        [Column("TELEFONE")]
        public decimal Telefone { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }     

    }
}
