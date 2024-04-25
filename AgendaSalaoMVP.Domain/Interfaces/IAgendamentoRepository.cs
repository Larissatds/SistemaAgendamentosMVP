using AgendaSalaoMVP.Domain.Entities;

namespace AgendaSalaoMVP.Domain.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<IEnumerable<Agendamento>> ObterAgendamentosAsync();

        Task<Agendamento> ObterAgendamentoPorIdAsync(decimal? id);

        Task<Agendamento> CriarAsync(Agendamento agendamento);

        Task<Agendamento> EditarAsync(Agendamento agendamento);

        Task<Agendamento> RemoverAsync(Agendamento agendamento);
    }
}
