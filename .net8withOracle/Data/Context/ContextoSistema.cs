using Microsoft.EntityFrameworkCore;

namespace vlife.Data
{
    public class ContextoSistema : DbContext
    {
        private const string SESSION_CONNECTION_STRING = "User Id=;Password=;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=)(PORT=))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=)));";
        private string _connectionString { get; set; }
        private IConfiguration _configuration { get; set; }

        public ContextoSistema() : base()
        {
            _connectionString = SESSION_CONNECTION_STRING;
        }

        public ContextoSistema(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        public ContextoSistema(DbContextOptions options) : base(options)
        {
        }

        public ContextoSistema(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString == null)
            {
                _connectionString = SESSION_CONNECTION_STRING;
            }

            string connectionString = "User Id=;Password=;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=)(PORT=))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=)));";

            if (connectionString == null)
            {
                throw new Exception("ConnectionString -> não está definida no projeto");
            }

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle(connectionString);
            }
        }
    
    }
}