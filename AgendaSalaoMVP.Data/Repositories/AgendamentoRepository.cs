using AgendaSalaoMVP.Domain.Entities;
using AgendaSalaoMVP.Domain.Interfaces;
using AgendaSalaoMVP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgendaSalaoMVP.Infra.Data.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        ApplicationDbContext _context;
        public AgendamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Agendamento>> ObterAgendamentosAsync()
        {
            return await _context.Agendamentos
                .Join(
                    _context.Clientes, 
                    agendamento => agendamento.IdCliente,
                    cliente => cliente.IdCliente,
                    (agendamento, cliente) => new
                    {
                        Agendamento = agendamento,
                        Cliente = cliente
                    })
                .Join(
                    _context.Servicos,
                    agendamento => agendamento.Agendamento.IdServico,
                    servico => servico.IdServico,
                    (agendamento, servico) => new Agendamento
                    {
                        IdAgendamento = agendamento.Agendamento.IdAgendamento,
                        DataHoraAgendada = agendamento.Agendamento.DataHoraAgendada,
                        IdCliente = agendamento.Agendamento.IdCliente,
                        IdServico = agendamento.Agendamento.IdServico,
                        Cliente = agendamento.Cliente,
                        Servico = servico
                    })
                .OrderBy(c => c.DataHoraAgendada).ToListAsync();
        }

        public async Task<Agendamento> ObterAgendamentoPorIdAsync(decimal? id)
        {
            var agendamento = await _context.Agendamentos
                .Include(a => a.Cliente).Include(a => a.Servico)
                .FirstOrDefaultAsync(a => a.IdAgendamento == id);

            return agendamento ?? new Agendamento();
        }

        public async Task<Agendamento> CriarAsync(Agendamento agendamento)
        {
            _context.Add(agendamento);
            await _context.SaveChangesAsync();
            return agendamento;
        }

        public async Task<Agendamento> EditarAsync(Agendamento agendamento)
        {
            _context.Update(agendamento);
            await _context.SaveChangesAsync();
            return agendamento;
        }

        public async Task<Agendamento> RemoverAsync(Agendamento agendamento)
        {
            _context.Remove(agendamento);
            await _context.SaveChangesAsync();
            return agendamento;
        }
    }
}
