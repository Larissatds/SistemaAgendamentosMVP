using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.Domain.Interfaces;
using AgendaSalaoMVP.WebUI.Interfaces;
using Newtonsoft.Json;
using System.Text;
using System.Web.Mvc;

namespace AgendaSalaoMVP.WebUI.Services
{
    public class AgendamentoIntegracaoService : IAgendamentoIntegracaoService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IServicoRepository _servicoRepository;

        Uri url = new Uri("https://localhost:7168/api/agendamentos");
        private readonly HttpClient _httpClient;

        public AgendamentoIntegracaoService
            (
                IClienteRepository clienteRepository,
                IServicoRepository servicoRepository
            )
        {
            _clienteRepository = clienteRepository;
            _servicoRepository = servicoRepository;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = url;
        }

        public async Task<IEnumerable<AgendamentoDTO>> Obter()
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var jsonString = await response.Content.ReadAsStringAsync();

            IEnumerable<AgendamentoDTO?> jsonObject = JsonConvert.DeserializeObject<IEnumerable<AgendamentoDTO>>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new List<AgendamentoDTO>();

        }

        public async Task<AgendamentoDTO> ObterPorId(decimal id)
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();

            AgendamentoDTO? jsonObject = JsonConvert.DeserializeObject<AgendamentoDTO>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new AgendamentoDTO();

        }

        public async Task<decimal?> Criar(AgendamentoDTO agendamentoDTO)
        {
            var jsonParametros = JsonConvert.SerializeObject(agendamentoDTO);

            var conteudo = new StringContent(jsonParametros, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_httpClient.BaseAddress, conteudo);
            var jsonString = await response.Content.ReadAsStringAsync();

            decimal? jsonObject = JsonConvert.DeserializeObject<decimal>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return 0;
        }

        public async Task<AgendamentoDTO> Editar(AgendamentoDTO agendamentoDTO)
        {
            var jsonParametros = JsonConvert.SerializeObject(agendamentoDTO);

            var conteudo = new StringContent(jsonParametros, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(_httpClient.BaseAddress + $"?id={agendamentoDTO.IdAgendamento}", conteudo);
            var jsonString = await response.Content.ReadAsStringAsync();

            AgendamentoDTO? jsonObject = JsonConvert.DeserializeObject<AgendamentoDTO>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new AgendamentoDTO();
        }

        public async Task<AgendamentoDTO> Deletar(decimal id)
        {
            var response = await _httpClient.DeleteAsync(_httpClient.BaseAddress + $"/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();

            AgendamentoDTO? jsonObject = JsonConvert.DeserializeObject<AgendamentoDTO>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new AgendamentoDTO();
        }

        public async Task<IEnumerable<SelectListItem>> ClienteSelectList()
        {
            var clientes = await _clienteRepository.ObterClientesAsync();
            var selectListCliente = new List<SelectListItem>
                 {
                     new SelectListItem { Value = "", Text = "Selecione um cliente" }
                 };

            selectListCliente.AddRange(clientes
                .OrderBy(u => u.Nome)
                .Select(cliente => new SelectListItem
                {
                    Value = cliente.IdCliente.ToString(),
                    Text = cliente.Nome
                }));

            return selectListCliente;
        }

        public async Task<IEnumerable<SelectListItem>> ServicoSelectList()
        {
            var servicos = await _servicoRepository.ObterServicosAsync();
            var selectListServico = new List<SelectListItem>
                 {
                     new SelectListItem { Value = "", Text = "Selecione um serviço" }
                 };

            selectListServico.AddRange(servicos
                .OrderBy(u => u.NomeServico)
                .Select(servico => new SelectListItem
                {
                    Value = servico.IdServico.ToString(),
                    Text = servico.NomeServico
                }));

            return selectListServico;
        }
    }
}
