using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoinfrastart.Apresentacao
{
    public partial class Alterar : Form
    {
        public Alterar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection objcon = new MySqlConnection("server = 127.0.0.1; user id = root; database = bd_infrastart");
                objcon.Open();
                MySqlCommand objCmd = new MySqlCommand("update chamado set nome_cha = ?, sobrenome_cha = ?, email_cha = ?, tel_cha = ?, servico_cha = ?, msg_cha = ? where id_cha = ?", objcon);
                objCmd.Parameters.Clear();
                objCmd.Parameters.Add("@nome_cha", MySqlDbType.VarChar, 25).Value = textNome.Text;
                objCmd.Parameters.Add("@sobrenome_cha", MySqlDbType.VarChar, 255).Value = textSobre.Text;
                objCmd.Parameters.Add("@email_cha", MySqlDbType.VarChar, 255).Value = textEmail.Text;
                objCmd.Parameters.Add("@tel_cha", MySqlDbType.VarChar, 12).Value = textTel.Text;
                objCmd.Parameters.Add("@servico_cha", MySqlDbType.VarChar, 25).Value = comboServico.Text;
                objCmd.Parameters.Add("@msg_cha", MySqlDbType.VarChar, 900).Value = groupMsg.Text;
                objCmd.Parameters.Add("@id_cha", MySqlDbType.Int32).Value = textId.Text;
                
                objCmd.CommandType = CommandType.Text;
                objCmd.ExecuteNonQuery();

                objcon.Close();

                MessageBox.Show("Cliente alterado com sucesso");
            }
            catch(Exception erro)
            {
                MessageBox.Show("Cliente nao foi alterado" + erro);
            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection objcon = new MySqlConnection("server = 127.0.0.1; user id = root; database = bd_infrastart");
                objcon.Open();

                MySqlCommand objCmd = new MySqlCommand("select nome_cha, sobrenome_cha, email_cha, tel_cha, servico_cha, msg_cha from chamado where id_cha = ?", objcon);
                objCmd.Parameters.Clear();
                objCmd.Parameters.Add("@id_cha", MySqlDbType.Int32).Value = textId.Text;

                objCmd.CommandType = CommandType.Text;

                MySqlDataReader dr;
                dr = objCmd.ExecuteReader();
                dr.Read();

                textNome.Text = dr.GetString(0);
                textSobre.Text = dr.GetString(1);
                textEmail.Text = dr.GetString(2);
                textTel.Text = dr.GetString(3);
                comboServico.Text = dr.GetString(4);
                groupMsg.Text = dr.GetString(5);


                objcon.Close();


            }
            catch(Exception erro)
            {
                MessageBox.Show("Erro ao buscar" + erro);
            }

        }

        private void comboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void Alterar_Load(object sender, EventArgs e)
        {

        }

        private void textNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
