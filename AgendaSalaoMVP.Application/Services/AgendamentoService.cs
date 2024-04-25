using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.Application.Interfaces;
using AgendaSalaoMVP.Domain.Entities;
using AgendaSalaoMVP.Domain.Interfaces;
using AutoMapper;

namespace AgendaSalaoMVP.Application.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMapper _mapper;
        public AgendamentoService
            (
                IAgendamentoRepository agendamentoRepository,
                IMapper mapper
            )
        {
            _agendamentoRepository = agendamentoRepository;
            _mapper = mapper;
        }     

        public async Task<IEnumerable<AgendamentoDTO>> ObterAgendamentosAsync()
        {
            var agendamentos = await _agendamentoRepository.ObterAgendamentosAsync();

            return _mapper.Map<IEnumerable<AgendamentoDTO>>(agendamentos);
        }

        public async Task<AgendamentoDTO> ObterAgendamentoPorIdAsync(decimal? id)
        {
            var agendamento = await _agendamentoRepository.ObterAgendamentoPorIdAsync(id: id);

            return _mapper.Map<AgendamentoDTO>(agendamento);
        }

        public async Task<decimal?> CriarAsync(AgendamentoDTO agendamentoDto)
        {
            var agendamento = _mapper.Map<Agendamento>(agendamentoDto);

            var retorno = await _agendamentoRepository.CriarAsync(agendamento);

            return retorno.IdServico;
        }

        public async Task EditarAsync(AgendamentoDTO agendamentoDto)
        {
            var agendamento = _mapper.Map<Agendamento>(agendamentoDto);

            await _agendamentoRepository.EditarAsync(agendamento);
        }

        public async Task RemoverAsync(decimal? id)
        {
            var agendamento = _agendamentoRepository.ObterAgendamentoPorIdAsync(id: id).Result;

            await _agendamentoRepository.RemoverAsync(agendamento);
        }         
    }
}
