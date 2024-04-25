using AgendaSalaoMVP.Application.Interfaces;
using AgendaSalaoMVP.Application.Mappings;
using AgendaSalaoMVP.Application.Services;
using AgendaSalaoMVP.Domain.Interfaces;
using AgendaSalaoMVP.Infra.Data.Context;
using AgendaSalaoMVP.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaSalaoMVP.Infra.IoC
{
    public static class DependencyInjectinAPI
    {
        public static IServiceCollection AddInfrastructureAPI
            (
                this IServiceCollection services,
                IConfiguration configuration
            )
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LocalDb"), b =>
                b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Injeção de Dependências Repositories
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();

            // Injeção de Dependências Services
            services.AddScoped<IAgendamentoService, AgendamentoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IServicoService, ServicoService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
