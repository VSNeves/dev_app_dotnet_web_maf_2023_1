using DomainLayer.Interfaces.Service;
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
            ConfigureInfrastructure(services);
            ConfigureServiceLayer(services);
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
        private static void ConfigureInfrastructure(IServiceCollection services) { }

        /// <summary>
        /// configura as dependencias da camada de aplicação
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureServiceLayer(IServiceCollection services) 
        {
            services.AddSingleton<IProfessorService, ProfessorService>();
        }


    }
}
