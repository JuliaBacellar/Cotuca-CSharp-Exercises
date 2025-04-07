using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apListaLigada_1_a_4
{
    public partial class FrmListaLigada : Form
    {
        ListaSimples<Aluno> lista1;
        public FrmListaLigada()
        {
            InitializeComponent();
        }

        // tratador do evento Load
        // esse evento ocorre quanto o formulário está criado
        // na memória e logo será exibido (antes de ser exibido)
        private void FrmListaLigada_Load(object sender, EventArgs e)
        {
            lista1 = new ListaSimples<Aluno>();
        }

        // esse método será chamado automaticamente quando o usuário
        // clicar no btnIncluir
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtRA.Text != "" && txtNome.Text != "")
            {
                var novoAluno = new Aluno(txtRA.Text, txtNome.Text,
                                            (double)udNota.Value);
                lista1.InserirAposFim(novoAluno);
                lista1.Listar(lsbUm);
            }
        }

        private void btnLerArquivo1_Click(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                lista1 = new ListaSimples<Aluno>();
                var arquivo = new StreamReader(dlgAbrir.FileName);
                while (!arquivo.EndOfStream)
                {
                    var linhaLida = arquivo.ReadLine();
                    var novoAluno = new Aluno(linhaLida);
                    lista1.InserirAposFim(novoAluno);
                }
                arquivo.Close();
                lista1.Listar(lsbUm);
            }
        }
    }
}
