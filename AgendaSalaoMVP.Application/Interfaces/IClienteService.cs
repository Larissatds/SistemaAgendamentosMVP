using AgendaSalaoMVP.Application.DTOs;

namespace AgendaSalaoMVP.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> ObterClientesAsync();

        Task<ClienteDTO> ObterClientePorIdAsync(decimal? id);

        Task<decimal?> CriarAsync(ClienteDTO cliente);

        Task EditarAsync(ClienteDTO cliente);

        Task RemoverAsync(decimal? id);
    }
}
