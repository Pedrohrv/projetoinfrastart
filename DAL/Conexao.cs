using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetoinfrastart.DAL
{
     public class Conexao
    {
        
        MySqlConnection con = new MySqlConnection();
        public Conexao()
        {
            con.ConnectionString = @"server=127.0.0.1;user id=root;database=bd_infrastart";
        }
        public MySqlConnection conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
