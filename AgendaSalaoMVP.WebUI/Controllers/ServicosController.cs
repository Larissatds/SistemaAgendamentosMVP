using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.WebUI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSalaoMVP.WebUI.Controllers
{
    public class ServicosController : Controller
    {
        private readonly IServicoIntegracaoService _servicoIntegracaoService;
        public ServicosController(IServicoIntegracaoService servicoIntegracaoService)
        {
            _servicoIntegracaoService = servicoIntegracaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientes = await _servicoIntegracaoService.Obter();

            return View(clientes);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ServicoDTO servicoDTO)
        {
            if (ModelState.IsValid)
            {
                await _servicoIntegracaoService.Criar(servicoDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(servicoDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(decimal id)
        {
            var servicoDTO = await _servicoIntegracaoService.ObterPorId(id: id);

            if (servicoDTO == null) return NotFound();


            return View(servicoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ServicoDTO clienteDto)
        {
            if (ModelState.IsValid)
            {
                await _servicoIntegracaoService.Editar(clienteDto);
                return RedirectToAction(nameof(Index));
            }
            return View(clienteDto);
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(decimal id)
        {
            var servicoDTO = await _servicoIntegracaoService.ObterPorId(id: id);

            if (servicoDTO == null)
            {
                return NotFound();
            }

            return View(servicoDTO);
        }

        [HttpPost(), ActionName("Excluir")]
        public async Task<IActionResult> ConfirmarExlusao(decimal id)
        {
            await _servicoIntegracaoService.Deletar(id);
            return RedirectToAction("Index");
        }
    }
}
