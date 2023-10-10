using DomainLayer.Interfaces.Repository;
using System.Data;

namespace InfrastructureLayer.Data.Repository
{
    public class DbContext : IDbContext
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;
        public DbContext(ISqlServerConnectionProvider sqlServerConnectionProvider) 
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }
        
        public IDbConnection CreateConnection => _sqlServerConnectionProvider.CreateConnection();
    }
}
