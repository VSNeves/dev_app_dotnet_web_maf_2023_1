using System.Data.SqlClient;

namespace DomainLayer.Interfaces.Repository
{
    public interface ISqlServerConnectionProvider
    {
        SqlConnection CreateConnection();
        
    }
}
