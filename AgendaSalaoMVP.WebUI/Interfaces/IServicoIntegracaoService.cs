using AgendaSalaoMVP.Application.DTOs;

namespace AgendaSalaoMVP.WebUI.Interfaces
{
    public interface IServicoIntegracaoService
    {
        Task<IEnumerable<ServicoDTO>> Obter();

        Task<ServicoDTO> ObterPorId(decimal id);

        Task<decimal?> Criar(ServicoDTO servicoDTO);

        Task<ServicoDTO> Editar(ServicoDTO servicoDTO);

        Task<ServicoDTO> Deletar(decimal id);
    }
}
