using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWIthDB
{
    public static class ConnectionData
    {
        private static readonly string server = "localhost";
        private static readonly string catalog = "ReglamentPeregovorov";
        private static readonly string trustedConnection = "True";

        public static readonly string connectionString = $"Data Source={server};" +
                                                         $"Initial Catalog={catalog};" +
                                                         $"Trusted_Connection={trustedConnection};";

    }
}

