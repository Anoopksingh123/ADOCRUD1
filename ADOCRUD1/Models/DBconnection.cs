using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ADOCRUD1.Models
{
    public class DBconnection
    {
        public SqlConnection Connection;
        public DBconnection()
        {
            Connection = new SqlConnection
                (DBConfi.connectionstr);
        }
    }
}
