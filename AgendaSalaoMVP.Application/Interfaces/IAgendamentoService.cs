using AgendaSalaoMVP.Application.DTOs;

namespace AgendaSalaoMVP.Application.Interfaces
{
    public interface IAgendamentoService
    {
        Task<IEnumerable<AgendamentoDTO>> ObterAgendamentosAsync();

        Task<AgendamentoDTO> ObterAgendamentoPorIdAsync(decimal? id);

        Task<decimal?> CriarAsync(AgendamentoDTO agendamento);

        Task EditarAsync(AgendamentoDTO agendamento);

        Task RemoverAsync(decimal? id);
    }
}
