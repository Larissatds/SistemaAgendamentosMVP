using AgendaSalaoMVP.Domain.Entities;

namespace AgendaSalaoMVP.Domain.Interfaces
{
    public interface IServicoRepository
    {
        Task<IEnumerable<Servico>> ObterServicosAsync();

        Task<Servico> ObterServicoPorIdAsync(decimal? id);

        Task<Servico> CriarAsync(Servico servico);

        Task<Servico> EditarAsync(Servico servico);

        Task<Servico> RemoverAsync(Servico servico);
    }
}
