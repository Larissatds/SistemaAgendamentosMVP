using AgendaSalaoMVP.Application.DTOs;

namespace AgendaSalaoMVP.Application.Interfaces
{
    public interface IServicoService
    {
        Task<IEnumerable<ServicoDTO>> ObterServicosAsync();

        Task<ServicoDTO> ObterServicoPorIdAsync(decimal? id);

        Task<decimal?> CriarAsync(ServicoDTO servico);

        Task EditarAsync(ServicoDTO servico);

        Task RemoverAsync(decimal? id);
    }
}
