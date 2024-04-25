using AgendaSalaoMVP.Application.DTOs;

namespace AgendaSalaoMVP.WebUI.Interfaces
{
    public interface IClienteIntegracaoService
    {
        Task<IEnumerable<ClienteDTO>> Obter();

        Task<ClienteDTO> ObterPorId(decimal id);

        Task<decimal?> Criar(ClienteDTO clienteDto);

        Task<ClienteDTO> Editar(ClienteDTO clienteDto);

        Task<ClienteDTO> Deletar(decimal id);
    }
}
