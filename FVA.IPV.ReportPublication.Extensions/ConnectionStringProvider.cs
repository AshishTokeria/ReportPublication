using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FVA.IPV.ReportPublication.Extensions
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString(DatabaseType dbType);
    }
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _config;
        public ConnectionStringProvider(IConfiguration config)
        {
            _config = config;
        }

        public string GetConnectionString(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.Create:
                    return _config.GetConnectionString("Create");
                case DatabaseType.MktData:
                    return _config.GetConnectionString("MktData");
                default:
                    throw new ArgumentException($"Cannot load connection string for databas {dbType} from application configuration.");
            }
        }
    }
}
