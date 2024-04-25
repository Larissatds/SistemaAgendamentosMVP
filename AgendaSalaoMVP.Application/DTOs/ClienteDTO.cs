using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaSalaoMVP.Application.DTOs
{
    public class ClienteDTO
    {
        public decimal IdCliente { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório.")]
        [MinLength(3, ErrorMessage = "O número mínimo de caracteres para o campo Nome é de 3 caracteres.")]
        [MaxLength(250, ErrorMessage = "O número máximo de caracteres para o campo Nome é de 250 caracteres.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é um campo obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Endereço")]
        [MaxLength(250, ErrorMessage = "O número máximo de caracteres para o campo Endereço é de 250 caracteres.")]
        public string? Endereco { get; set; }

        [MaxLength(250, ErrorMessage = "O número máximo de caracteres para o campo Bairro é de 250 caracteres.")]
        [DisplayName("Bairro")]
        public string? Bairro { get; set; }

        [MaxLength(250, ErrorMessage = "O número máximo de caracteres para o campo Cidade é de 250 caracteres.")]
        [DisplayName("Cidade")]
        public string? Cidade { get; set; }

        [MaxLength(250, ErrorMessage = "O número máximo de caracteres para o campo Estado é de 250 caracteres.")]
        [DisplayName("UF")]
        public string? Estado { get; set; }

        [Column(TypeName = "decimal(8,0)")]
        [DisplayFormat(DataFormatString = "{0:00000-000}")]
        [DisplayName("CEP")]
        public decimal? Cep { get; set; }

        [Required(ErrorMessage = "Telefone é um campo obrigatório.")]
        [Column(TypeName = "decimal(11,0)")]
        [DisplayFormat(DataFormatString = "{0:(00) 00000-0000}")]
        [DisplayName("Telefone")]
        public decimal Telefone { get; set; }

        [MaxLength(250, ErrorMessage = "O número máximo de caracteres para o campo E-mail é de 250 caracteres.")]
        [DisplayName("E-mail")]
        public string? Email { get; set; }
    }
}
