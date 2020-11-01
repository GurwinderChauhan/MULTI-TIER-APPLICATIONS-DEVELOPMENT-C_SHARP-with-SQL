using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gurwinder1811213Midterm.DataAccess
{
    public static class UtilityDB
    {
        public static SqlConnection connectDB()
        {
            SqlConnection conndb = new SqlConnection(@"Data Source=DESKTOP-KRA1Q79\MSSQLSERVER2017;Initial Catalog=midterm;Integrated Security=True");
            conndb.Open();
            return conndb;
        }

    }
}
