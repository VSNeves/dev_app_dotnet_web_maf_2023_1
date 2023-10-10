using DomainLayer.Interfaces.Repository;
using DomainLayer.Models.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace InfrastructureLayer.Data.Repository
{
    public class SqlServerConnectionProvider : ISqlServerConnectionProvider
    {
        private readonly IConfiguration _configuration;

        public SqlServerConnectionProvider(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(BuilderConnectionString());
        }

        private string BuilderConnectionString() 
        {
            var builder = new SqlConnectionStringBuilder();
            var dataSource = SetDataSource();

            builder.UserID = dataSource.UserId;
            builder.Password = dataSource.Password;
            builder.DataSource = dataSource.DataSource;
            builder.InitialCatalog = dataSource.InitialCatalog;
            builder.ConnectTimeout = dataSource.ConnectTimeout;
            builder.MaxPoolSize = dataSource.MaxPoolSize;
            builder.Pooling = dataSource.Pooling;
            builder.TrustServerCertificate = dataSource.TrustServerCertificate;
            builder.PersistSecurityInfo = dataSource.PersistSecurityInfo;
            builder.Encrypt = dataSource.Encrypt;
            return builder.ConnectionString;
        }

        public SqlServerDataSource SetDataSource()
        {
            return new SqlServerDataSource()
            {
                UserId = _configuration.GetValue<string>("SqlSettings:User")!,
                Password = _configuration.GetValue<string>("SqlSettings:Password")!,
                DataSource = _configuration.GetValue<string>("SqlSettings:DataSource")!,
                InitialCatalog = _configuration.GetValue<string>("SqlSettings:InitialCatalog")!,
                ConnectTimeout = _configuration.GetValue<int>("SqlSettings:ConnectTimeout")!,
                MaxPoolSize = _configuration.GetValue<int>("SqlSettings:MaxPoolSize")!,
                Pooling = _configuration.GetValue<bool>("SqlSettings:Pooling")!,
                TrustServerCertificate = _configuration.GetValue<bool>("SqlSettings:TrustServerCertificate")!,
                PersistSecurityInfo = _configuration.GetValue<bool>("SqlSettings:PersistSecurityInfo")!,
                Encrypt = _configuration.GetValue<bool>("SqlSettings:Encrypt")!,
                CommandTimeout = _configuration.GetValue<int>("SqlSettings:CommandTimeout")!

            };

        }
    }
}
