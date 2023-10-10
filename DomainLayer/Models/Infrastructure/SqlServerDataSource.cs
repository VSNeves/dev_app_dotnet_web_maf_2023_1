namespace DomainLayer.Models.Infrastructure
{
    public class SqlServerDataSource
    {
        public string DataSource { get; set; } = default!;
        public string InitialCatalog { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int ConnectTimeout { get; set; } = 60;
        public int MaxPoolSize { get; set; } = 5;
        public bool Pooling { get; set; } = true;
        public bool TrustServerCertificate { get; set; } = true;
        public bool PersistSecurityInfo { get; set; } = true;
        public bool Encrypt { get; set; } = true;
        public int CommandTimeout { get; set; } = 300;


    }
}
