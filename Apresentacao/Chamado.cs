using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.OleDb;

namespace projetoinfrastart.Apresentacao
{
    public partial class Chamado : Form
    {
        private string strconn = @"server=127.0.0.1;user id=root;database=bd_infrastart";
        MySqlConnection objConect = null;
        MySqlCommand objCommand = null;
        public Chamado()
        {
            InitializeComponent();
        }
        public void listaGrid()
        {
            string strmy = "select * from chamado";

            objConect = new MySqlConnection(strconn);
            objCommand = new MySqlCommand(strmy, objConect);

            try
            {
                MySqlDataAdapter objAdp = new MySqlDataAdapter(objCommand);
                DataTable dtListe = new DataTable();
                objAdp.Fill(dtListe);
                dgLista.DataSource = dtListe;
            }
            catch
            {
                MessageBox.Show("erro liste");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            listaGrid();
        }

        private void Chamado_Load(object sender, EventArgs e)
        {
            listaGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection objcon = new MySqlConnection("server = 127.0.0.1; user id, nome = root; database = bd_infrastart");
                objcon.Open();

                MySqlCommand objCmd = new MySqlCommand("delete from chamado where id_cha, nome_cha = ?",objcon);
                objCmd.Parameters.Clear();
                objCmd.Parameters.Add("@id_cha", MySqlDbType.Int32).Value = txId.Text;
                objCmd.Parameters.Add("@nome_cha", MySqlDbType.Int32).Value = txNome.Text;


                objCmd.CommandType = CommandType.Text;
                objCmd.ExecuteNonQuery();

                objcon.Close();

                MessageBox.Show("Cliente exluido com sucesso");

            }
            catch(Exception erro)
            {
                MessageBox.Show("Nao foi possivel deletar" + erro);
            }

           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Alterar cad = new Alterar();
            cad.Show();

        }

        private void txId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
