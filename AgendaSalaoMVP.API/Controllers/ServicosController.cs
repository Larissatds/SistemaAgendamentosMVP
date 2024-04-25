using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSalaoMVP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly IServicoService _servicoService;
        public ServicosController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicoDTO>>> Obter()
        {
            var servicos = await _servicoService.ObterServicosAsync();

            if (servicos == null)
            {
                return await Task.FromResult(StatusCode(404, null));

            }

            return await Task.FromResult(StatusCode(200, servicos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoDTO>> Obter(decimal id)
        {
            var servico = await _servicoService.ObterServicoPorIdAsync(id: id);
            if (servico == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            return await Task.FromResult(StatusCode(200, servico));
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromBody] ServicoDTO servicoDTO)
        {
            if (servicoDTO == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            var id = await _servicoService.CriarAsync(servicoDTO);

            return await Task.FromResult(StatusCode(201, id));
        }

        [HttpPut]
        public async Task<ActionResult> Editar(decimal id, [FromBody] ServicoDTO servicoDTO)
        {
            if (id != servicoDTO.IdServico)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            if (servicoDTO == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            await _servicoService.EditarAsync(servicoDTO);

            return await Task.FromResult(StatusCode(200, servicoDTO));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServicoDTO>> Deletar(decimal id)
        {
            var servico = await _servicoService.ObterServicoPorIdAsync(id: id);
            if (servico == null)
            {
                return await Task.FromResult(StatusCode(404, null));
            }

            await _servicoService.RemoverAsync(id: id);

            return await Task.FromResult(StatusCode(200, servico));
        }
    }
}
