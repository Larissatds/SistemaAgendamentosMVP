using AgendaSalaoMVP.Application.DTOs;
using System.Web.Mvc;

namespace AgendaSalaoMVP.WebUI.Interfaces
{
    public interface IAgendamentoIntegracaoService
    {
        Task<IEnumerable<AgendamentoDTO>> Obter();

        Task<AgendamentoDTO> ObterPorId(decimal id);

        Task<decimal?> Criar(AgendamentoDTO agendamentoDTO);

        Task<AgendamentoDTO> Editar(AgendamentoDTO agendamentoDTO);

        Task<AgendamentoDTO> Deletar(decimal id);


        Task<IEnumerable<SelectListItem>> ClienteSelectList();

        Task<IEnumerable<SelectListItem>> ServicoSelectList();
    }
}
