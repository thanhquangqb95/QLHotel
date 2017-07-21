using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QLHOTEL
{
    class CSDL
    {
        public static String server = "Data Source=LeThanhQuang;Initial Catalog = QLKHACHSAN; Integrated Security = True";
        public static DataTable dt = new DataTable();
        public static SqlConnection con = new SqlConnection(server);
    }
}
