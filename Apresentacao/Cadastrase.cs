using projetoinfrastart.Modelo;
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
    public partial class Cadastrase : Form
    {
        public Cadastrase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
           String mensagem = controle.cadastrar(txLogin.Text, txSenha.Text, txConfirmar.Text);
            if (controle.mensagem.Equals(""))
            {
                if (controle.tem)
                {
                    MessageBox.Show(mensagem, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Chamado cha = new Chamado();
                    cha.Show();
                }
                else
                {
                    MessageBox.Show("Cadastro ja adcionado ou/ Campo incorreto" , "erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }

        private void txLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txConfirmar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
