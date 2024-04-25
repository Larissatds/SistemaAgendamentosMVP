using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.WebUI.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace AgendaSalaoMVP.WebUI.Services
{
    public class ServicoIntegracaoService : IServicoIntegracaoService
    {
        Uri url = new Uri("https://localhost:7168/api/servicos");
        private readonly HttpClient _httpClient;

        public ServicoIntegracaoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = url;
        }

        public async Task<IEnumerable<ServicoDTO>> Obter()
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var jsonString = await response.Content.ReadAsStringAsync();

            IEnumerable<ServicoDTO?> jsonObject = JsonConvert.DeserializeObject<IEnumerable<ServicoDTO>>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new List<ServicoDTO>();

        }

        public async Task<ServicoDTO> ObterPorId(decimal id)
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();

            ServicoDTO? jsonObject = JsonConvert.DeserializeObject<ServicoDTO>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new ServicoDTO();

        }

        public async Task<decimal?> Criar(ServicoDTO servicoDTO)
        {
            var jsonParametros = JsonConvert.SerializeObject(servicoDTO);

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

        public async Task<ServicoDTO> Editar(ServicoDTO servicoDTO)
        {
            var jsonParametros = JsonConvert.SerializeObject(servicoDTO);

            var conteudo = new StringContent(jsonParametros, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(_httpClient.BaseAddress + $"?id={servicoDTO.IdServico}", conteudo);
            var jsonString = await response.Content.ReadAsStringAsync();

            ServicoDTO? jsonObject = JsonConvert.DeserializeObject<ServicoDTO>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new ServicoDTO();
        }

        public async Task<ServicoDTO> Deletar(decimal id)
        {
            var response = await _httpClient.DeleteAsync(_httpClient.BaseAddress + $"/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();

            ServicoDTO? jsonObject = JsonConvert.DeserializeObject<ServicoDTO>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new ServicoDTO();
        }
    }
}
