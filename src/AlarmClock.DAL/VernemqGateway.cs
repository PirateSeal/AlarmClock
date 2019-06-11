using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmClock.DAL
{
    public class VernemqGateway
    {
        public VernemqGateway( string connectionString )
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString { get; }

      

    }
}
