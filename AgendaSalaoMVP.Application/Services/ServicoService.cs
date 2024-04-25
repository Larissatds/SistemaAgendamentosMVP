using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.Application.Interfaces;
using AgendaSalaoMVP.Domain.Entities;
using AgendaSalaoMVP.Domain.Interfaces;
using AutoMapper;

namespace AgendaSalaoMVP.Application.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IMapper _mapper;
        public ServicoService
            (
                IServicoRepository servicoRepository,
                IMapper mapper
            )
        {
            _servicoRepository = servicoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServicoDTO>> ObterServicosAsync()
        {
            var servicos = await _servicoRepository.ObterServicosAsync();

            return _mapper.Map<IEnumerable<ServicoDTO>>(servicos);
        }

        public async Task<ServicoDTO> ObterServicoPorIdAsync(decimal? id)
        {
            var servico = await _servicoRepository.ObterServicoPorIdAsync(id: id);

            return _mapper.Map<ServicoDTO>(servico);
        }

        public async Task<decimal?> CriarAsync(ServicoDTO servicoDto)
        {
            var servico = _mapper.Map<Servico>(servicoDto);

            var retorno = await _servicoRepository.CriarAsync(servico);

            return retorno.IdServico;
        }

        public async Task EditarAsync(ServicoDTO servicoDto)
        {
            var servico = _mapper.Map<Servico>(servicoDto);

            await _servicoRepository.EditarAsync(servico);
        }

        public async Task RemoverAsync(decimal? id)
        {
            var servico = _servicoRepository.ObterServicoPorIdAsync(id: id).Result;

            await _servicoRepository.RemoverAsync(servico);
        }
    }
}
