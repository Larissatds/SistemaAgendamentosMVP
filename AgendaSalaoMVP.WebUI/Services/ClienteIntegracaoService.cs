using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.WebUI.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace AgendaSalaoMVP.WebUI.Services
{
    public class ClienteIntegracaoService : IClienteIntegracaoService
    {
        Uri url = new Uri("https://localhost:7168/api/clientes");
        private readonly HttpClient _httpClient;

        public ClienteIntegracaoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = url;
        }

        public async Task<IEnumerable<ClienteDTO>> Obter()
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var jsonString = await response.Content.ReadAsStringAsync();

            IEnumerable<ClienteDTO?> jsonObject = JsonConvert.DeserializeObject<IEnumerable<ClienteDTO>>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new List<ClienteDTO>();

        }

        public async Task<ClienteDTO> ObterPorId(decimal id)
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();

            ClienteDTO? jsonObject = JsonConvert.DeserializeObject<ClienteDTO>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new ClienteDTO();

        }

        public async Task<decimal?> Criar(ClienteDTO clienteDto)
        {
            var jsonParametros = JsonConvert.SerializeObject(clienteDto);

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

        public async Task<ClienteDTO> Editar(ClienteDTO clienteDto)
        {
            var jsonParametros = JsonConvert.SerializeObject(clienteDto);

            var conteudo = new StringContent(jsonParametros, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(_httpClient.BaseAddress + $"?id={clienteDto.IdCliente}", conteudo);
            var jsonString = await response.Content.ReadAsStringAsync();

            ClienteDTO? jsonObject = JsonConvert.DeserializeObject<ClienteDTO>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new ClienteDTO();
        }

        public async Task<ClienteDTO> Deletar(decimal id)
        {
            var response = await _httpClient.DeleteAsync(_httpClient.BaseAddress + $"/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();

            ClienteDTO? jsonObject = JsonConvert.DeserializeObject<ClienteDTO>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new ClienteDTO();
        }
    }
}
