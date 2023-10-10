using System.Data;

namespace DomainLayer.Interfaces.Repository
{
    public interface IDbContext 
    {
        IDbConnection CreateConnection {  get; }
    }
}
