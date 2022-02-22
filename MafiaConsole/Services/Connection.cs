using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaConsole.Services
{
    static class Connection
    {
        private static string _sqlConnection = @"Data Source=(localdb)\ProjectModels;Initial Catalog=MusicConsoleDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static string sqlConnection()
        {
            return _sqlConnection;
        }
    }
}
