using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.Application.Interfaces;
using AgendaSalaoMVP.Application.Services;
using AgendaSalaoMVP.WebUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendaSalaoMVP.WebUI.Controllers
{
    public class AgendamentosController : Controller
    {
        private readonly IAgendamentoIntegracaoService _agendamentoIntegracaoService;

        public AgendamentosController(IAgendamentoIntegracaoService agendamentoIntegracaoService)
        {
            _agendamentoIntegracaoService = agendamentoIntegracaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var agendamento = await _agendamentoIntegracaoService.Obter();

            return View(agendamento);
        }

        [HttpGet]
        public async Task<IActionResult> Criar()
        {
            var selectCliente = await _agendamentoIntegracaoService.ClienteSelectList();

            ViewBag.Clientes = new SelectList(selectCliente, "Value", "Text");

            var selectServico = await _agendamentoIntegracaoService.ServicoSelectList();

            ViewBag.Servicos = new SelectList(selectServico, "Value", "Text");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(AgendamentoDTO agendamentoDto)
        {
            if (ModelState.IsValid)
            {
                await _agendamentoIntegracaoService.Criar(agendamentoDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var selectCliente = await _agendamentoIntegracaoService.ClienteSelectList();

                ViewBag.Clientes = new SelectList(selectCliente, "Value", "Text");

                var selectServico = await _agendamentoIntegracaoService.ServicoSelectList();

                ViewBag.Servicos = new SelectList(selectServico, "Value", "Text");
            }
            return View(agendamentoDto);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(decimal id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamentoDto = await _agendamentoIntegracaoService.ObterPorId(id: id);

            if (agendamentoDto == null) return NotFound();

            var selectCliente = await _agendamentoIntegracaoService.ClienteSelectList();

            ViewBag.Clientes = new SelectList(selectCliente, "Value", "Text");

            var selectServico = await _agendamentoIntegracaoService.ServicoSelectList();

            ViewBag.Servicos = new SelectList(selectServico, "Value", "Text");

            return View(agendamentoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(AgendamentoDTO agendamentoDto)
        {
            if (ModelState.IsValid)
            {
                await _agendamentoIntegracaoService.Editar(agendamentoDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var selectCliente = await _agendamentoIntegracaoService.ClienteSelectList();

                ViewBag.Clientes = new SelectList(selectCliente, "Value", "Text");

                var selectServico = await _agendamentoIntegracaoService.ServicoSelectList();

                ViewBag.Servicos = new SelectList(selectServico, "Value", "Text");
            }

            return View(agendamentoDto);
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(decimal id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamentoDto = await _agendamentoIntegracaoService.ObterPorId(id: id);

            if (agendamentoDto == null)
            {
                return NotFound();
            }

            return View(agendamentoDto);
        }

        [HttpPost(), ActionName("Excluir")]
        public async Task<IActionResult> ConfirmarExlusao(decimal id)
        {
            await _agendamentoIntegracaoService.Deletar(id);
            return RedirectToAction("Index");
        }
    }
}
