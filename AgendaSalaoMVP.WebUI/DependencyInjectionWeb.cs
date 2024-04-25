using AgendaSalaoMVP.Application.Mappings;
using AgendaSalaoMVP.WebUI.Interfaces;
using AgendaSalaoMVP.WebUI.Services;

namespace AgendaSalaoMVP.Infra.IoC
{
    public static class DependencyInjectionWeb
    {
        public static IServiceCollection AddInfrastructureWeb(this IServiceCollection services)
        {

            // Injeção de Dependências Services
            services.AddScoped<IAgendamentoIntegracaoService, AgendamentoIntegracaoService>();
            services.AddScoped<IClienteIntegracaoService, ClienteIntegracaoService>();
            services.AddScoped<IServicoIntegracaoService, ServicoIntegracaoService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
