using AgendaSalaoMVP.Domain.Entities;

namespace AgendaSalaoMVP.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ObterClientesAsync();

        Task<Cliente> ObterClientePorIdAsync(decimal? id);

        Task<Cliente> CriarAsync(Cliente cliente);

        Task<Cliente> EditarAsync(Cliente cliente);

        Task<Cliente> RemoverAsync(Cliente cliente);
    }
}
