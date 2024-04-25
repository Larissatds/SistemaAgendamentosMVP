using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.Application.Interfaces;
using AgendaSalaoMVP.Domain.Entities;
using AgendaSalaoMVP.Domain.Interfaces;
using AutoMapper;

namespace AgendaSalaoMVP.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteService
            (
                IClienteRepository clienteRepository,
                IMapper mapper
            )
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;   
        }

        public async Task<IEnumerable<ClienteDTO>> ObterClientesAsync()
        {
            var clientes = await _clienteRepository.ObterClientesAsync();

            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO> ObterClientePorIdAsync(decimal? id)
        {
            var cliente = await _clienteRepository.ObterClientePorIdAsync(id: id);

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<decimal?> CriarAsync(ClienteDTO clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);

            var retorno = await _clienteRepository.CriarAsync(cliente);

            return retorno.IdCliente;
        }

        public async Task EditarAsync(ClienteDTO clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);

            await _clienteRepository.EditarAsync(cliente);
        }

        public async Task RemoverAsync(decimal? id)
        {
            var cliente = _clienteRepository.ObterClientePorIdAsync(id: id).Result;

            await _clienteRepository.RemoverAsync(cliente);
        }
    }
}
