using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Test
{
    internal class Connections
    {
        public const string sqlConstr = """
            Server = SOUF-X; 
            Database = EF_Test; 
            User Id = sa;
            Password = REPLACE_WITH_YOUR_DB_PASSWORD;
            TrustServerCertificate = True;
            """;
    }
}
