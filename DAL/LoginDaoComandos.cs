using projetoinfrastart.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetoinfrastart.Modelo
{
    class LoginDaoComandos
    {
        public bool tem = false;
        public string mensagem = "";
        MySqlCommand cmd = new MySqlCommand();
        Conexao con = new Conexao();
        MySqlDataReader dr;
        public bool verificarLogin(string login, string senha)
        {
            cmd.CommandText = "select * from login where login = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = con.conectar();
                 dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    tem = true;
                }
                con.desconectar();
                dr.Close();
            }
            catch (MySqlException)
            {
                this.mensagem = "Erro com o banco de dados! ";
            }
            return tem;
        }

        public string cadastrar(string login, string senha, string confSenha)
        {
            tem = false;
            if (senha.Equals(confSenha))
            {
                cmd.CommandText = "insert into login (login, senha) values (@lo,@se)";
                cmd.Parameters.AddWithValue("@lo", login);
                cmd.Parameters.AddWithValue("@se", senha);

                try
                {
                    cmd.Connection = con.conectar();
                    cmd.ExecuteNonQuery();
                    con.desconectar();
                    this.mensagem = " Cadastrado com sucesso";
                    tem = true;
                }
                catch (MySqlException)
                {
                    this.mensagem = "erro com o banco! cadastro";
                }

            }
            else
            {
                this.mensagem = "Senhas não correspondem";
            }
            return mensagem;

        }
    }
}
