using AgendaSalaoMVP.Domain.Entities;
using AgendaSalaoMVP.Domain.Interfaces;
using AgendaSalaoMVP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgendaSalaoMVP.Infra.Data.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        ApplicationDbContext _context;
        public ServicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Servico>> ObterServicosAsync()
        {
            return await _context.Servicos.OrderBy(c => c.NomeServico).ToListAsync();
        }

        public async Task<Servico> ObterServicoPorIdAsync(decimal? id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            return servico;
        }

        public async Task<Servico> CriarAsync(Servico servico)
        {
            _context.Add(servico);
            await _context.SaveChangesAsync();
            return servico;
        }

        public async Task<Servico> EditarAsync(Servico servico)
        {
            _context.Update(servico);
            await _context.SaveChangesAsync();
            return servico;
        }

        public async Task<Servico> RemoverAsync(Servico servico)
        {
            _context.Remove(servico);
            await _context.SaveChangesAsync();
            return servico;
        }
    }
}
