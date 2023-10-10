using Dapper;
using DomainLayer.Interfaces.Repository;
using DomainLayer.Interfaces.Repository;
using DomainLayer.Interfaces.Service;
using InfrastructureLayer.Data.Repository;
using ServiceLayer;

namespace ApplicationLayer.Configuration
{
    /// <summary>
    /// Classe responsável por gerencias as dependencias
    /// </summary>
    public static class DependencyInjectionConfig
    {
        /// <summary>
        /// configura as dependencias das camadas
        /// </summary>
        /// <param name="services"></param>
        public static void Configure(IServiceCollection services) 
        {
            ConfigureApplicationLayer(services);
            ConfigureDomainLayer(services);
            ConfigureInfrastructureLayer(services);
            ConfigureServiceLayer(services);

            services.AddLogging();
        }

        /// <summary>
        /// configura as dependencias da camada de aplicação
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureApplicationLayer(IServiceCollection services) { }

        /// <summary>
        /// configura as dependencias da camada de dominio
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureDomainLayer(IServiceCollection services) { }

        /// <summary>
        /// configura as dependencias da camada de infraestrutura
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureInfrastructureLayer(IServiceCollection services) 
        {
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddSingleton<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ISqlServerConnectionProvider, SqlServerConnectionProvider>();
            services.AddScoped<IDbContext, DbContext>();
            SqlMapper.AddTypeHandler(new DateOnlyHandler());
        }


        /// <summary>
        /// configura as dependencias da camada de aplicação
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureServiceLayer(IServiceCollection services) 
        {
            services.AddSingleton<IProfessorService, ProfessorService>();
            services.AddSingleton<IAlunoService, AlunoService>();
        }


    }
}
