using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
namespace RLIB
{
    public class mysqltestClass
    {
        MySqlConnection c = new MySqlConnection();
        public mysqltestClass()
        {
            c.ConnectionString = "server=localhost;user id=root;database=6369;port=3306;password=;";
            c.Open();
            Console.WriteLine("KONEKSI SUKSES");
        }
    }
}
