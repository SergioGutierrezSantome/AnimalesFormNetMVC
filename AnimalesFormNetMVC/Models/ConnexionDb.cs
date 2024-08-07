using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnimalesFormNetMVC.Models
{
    public class ConnexionDb
    {
        private readonly string connectionString = "Server=200.234.224.123,54321;Database=SergioGutierrezAnimales;User Id=sa;Password=Sql#123456789;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}