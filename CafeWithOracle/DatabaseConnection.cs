using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeWithOracle
{
    public static class DatabaseConnection
    {
        public static OracleConnection Connect()
        {

            string conString = "User Id=system; password=tiger;" +

            //How to connect to an Oracle DB without SQL*Net configuration file
            //also known as tnsnames.ora.
            "Data Source=localhost:1521/orcl; Pooling=false;";

            //How to connect to an Oracle Database with a Database alias.
            //Uncomment below and comment above.
            //"Data Source=pdborcl;Pooling=false;";

            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
            return con;

        }

    }
}
