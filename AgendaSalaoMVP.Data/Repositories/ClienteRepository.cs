using AgendaSalaoMVP.Domain.Entities;
using AgendaSalaoMVP.Domain.Interfaces;
using AgendaSalaoMVP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgendaSalaoMVP.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ObterClientesAsync()
        {
            return await _context.Clientes.OrderBy(c => c.Nome).ToListAsync();
        }

        public async Task<Cliente> ObterClientePorIdAsync(decimal? id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            return cliente;
        }

        public async Task<Cliente> CriarAsync(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> EditarAsync(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> RemoverAsync(Cliente cliente)
        {
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
