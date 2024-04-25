using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSalaoMVP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;
        public AgendamentosController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoDTO>>> Obter()
        {
            var agendamentos = await _agendamentoService.ObterAgendamentosAsync();

            if (agendamentos == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            return await Task.FromResult(StatusCode(200, agendamentos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgendamentoDTO>> Obter(decimal id)
        {
            var agendamento = await _agendamentoService.ObterAgendamentoPorIdAsync(id: id);
            if (agendamento == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            return await Task.FromResult(StatusCode(200, agendamento));
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] AgendamentoDTO agendamentoDTO)
        {
            if (agendamentoDTO == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            var id = await _agendamentoService.CriarAsync(agendamentoDTO);

            return await Task.FromResult(StatusCode(201, id));
        }

        [HttpPut]
        public async Task<ActionResult> Editar(decimal id, [FromBody] AgendamentoDTO agendamentoDTO)
        {
            if (id != agendamentoDTO.IdAgendamento)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            if (agendamentoDTO == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            await _agendamentoService.EditarAsync(agendamentoDTO);

            return await Task.FromResult(StatusCode(200, agendamentoDTO));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AgendamentoDTO>> Deletar(decimal id)
        {
            var agendamento = await _agendamentoService.ObterAgendamentoPorIdAsync(id: id);
            if (agendamento == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            await _agendamentoService.RemoverAsync(id: id);

            return await Task.FromResult(StatusCode(200, agendamento));
        }
    }
}
