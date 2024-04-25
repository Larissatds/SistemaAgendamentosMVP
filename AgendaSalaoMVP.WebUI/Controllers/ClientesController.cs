using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.Application.Interfaces;
using AgendaSalaoMVP.WebUI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSalaoMVP.WebUI.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteIntegracaoService _clienteIntegracaoService;
        public ClientesController(IClienteIntegracaoService clienteIntegracaoService)
        {
            _clienteIntegracaoService = clienteIntegracaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteIntegracaoService.Obter();

            return View(clientes);
        }

        [HttpGet]
        public IActionResult Criar()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ClienteDTO clienteDto)
        {
            if (ModelState.IsValid)
            {
                await _clienteIntegracaoService.Criar(clienteDto);
                return RedirectToAction(nameof(Index));
            }

            return View(clienteDto);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(decimal id)
        {
            var clienteDto = await _clienteIntegracaoService.ObterPorId(id: id);

            if (clienteDto == null) 
            { 
                return NotFound(); 
            }

            return View(clienteDto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ClienteDTO clienteDto)
        {
            if (ModelState.IsValid)
            {
                await _clienteIntegracaoService.Editar(clienteDto);
                return RedirectToAction(nameof(Index));
            }
            return View(clienteDto);
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(decimal id)
        {
            var clienteDto = await _clienteIntegracaoService.ObterPorId(id: id);

            if (clienteDto == null)
            { 
                return NotFound(); 
            }

            return View(clienteDto);
        }

        [HttpPost, ActionName("Excluir")]
        public async Task<IActionResult> ConfirmarExlusao(decimal id)
        {
            await _clienteIntegracaoService.Deletar(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detalhe(decimal id)
        {
            var clienteDto = await _clienteIntegracaoService.ObterPorId(id: id);

            if (clienteDto == null)
            {
                return NotFound();
            }

            return View("Endereco", clienteDto);
        }
    }
}
