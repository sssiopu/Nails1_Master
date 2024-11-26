using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Nails1_Master
{
    internal class DB
    {
        SqlConnection SqlConnection = new SqlConnection(@"Data source=(localdb)\MSSQLLocalDB;Initial Catalog=Nails_Master; Integrated Security=True");
        public void openConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Closed)
            {
                SqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }

        public SqlConnection GetSqlConnection()
        {
            return SqlConnection;
        }
    }
}


