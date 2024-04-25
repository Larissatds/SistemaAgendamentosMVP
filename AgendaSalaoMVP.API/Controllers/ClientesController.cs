using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.Application.Interfaces;
using AgendaSalaoMVP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSalaoMVP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Obter()
        {
            var clientes = await _clienteService.ObterClientesAsync();

            if (clientes == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            return await Task.FromResult(StatusCode(200, clientes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> Obter(decimal id)
        {
            var cliente = await _clienteService.ObterClientePorIdAsync(id: id);
            if (cliente == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            return await Task.FromResult(StatusCode(200, cliente));
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] ClienteDTO clienteDTO)
        {
            if (clienteDTO == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            var id = await _clienteService.CriarAsync(clienteDTO);

            return await Task.FromResult(StatusCode(201, id));
        }

        [HttpPut]
        public async Task<ActionResult> Editar(decimal id, [FromBody] ClienteDTO clienteDTO)
        {
            if (id != clienteDTO.IdCliente)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            if (clienteDTO == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            await _clienteService.EditarAsync(clienteDTO);

            return await Task.FromResult(StatusCode(200, clienteDTO));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteDTO>> Deletar(decimal id)
        {
            var cliente = await _clienteService.ObterClientePorIdAsync(id: id);
            if (cliente == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            await _clienteService.RemoverAsync(id: id);

            return await Task.FromResult(StatusCode(200, cliente));
        }
    }
}
