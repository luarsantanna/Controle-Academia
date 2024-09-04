using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONTROLE_ACADEMIA.modelo;
using System.IO;

namespace CONTROLE_ACADEMIA.visao
{
    public partial class FormAcademia : Form
    {
        public FormAcademia()
        {
            InitializeComponent();
        }

        Academia BoaForma;
        BindingSource bs;

        private void FormAcademia_Load(object sender, EventArgs e)
        {
            CriarBancoDados();
            BoaForma = new Academia();
            controle.AlunoDB tabela = new controle.AlunoDB();
            tabela.Select(BoaForma.Alunos);
            bs = new BindingSource();
            bs.DataSource = BoaForma.Alunos;
            dgvAlunos.DataSource = bs;
            bn.BindingSource = bs;
            dgvAlunos.AutoResizeColumns();
        }

        private void CriarBancoDados()
        {
            string banco = "academia.sqlite";
            if (!File.Exists(banco))
            {
                controle.ServidorSQL servidor = new controle.ServidorSQL();
                if(servidor.CreateDataBase(banco))
                {
                    MessageBox.Show("Banco de Dados Academia criado com sucesso!");
                    servidor.CriarTabelaAluno();
                    MessageBox.Show("Tabela Aluno criado com sucesso!");
                    if (File.Exists("lista.txt"))
                    {
                        CarregarLista();
                        MessageBox.Show("Lista.txt Transferido para a tabela ALUNO com sucesso!");
                    }
                }
            }
        }

        private void CarregarLista()
        {
            string arquivo = "lista.txt";
            string[] linhas = File.ReadAllLines(arquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(';');
                Aluno reg = new Aluno
                {
                    Cod = Int64.Parse(campos[0]),
                    Nome = campos[1].ToUpper().TrimStart(),
                    Nascimento = Convert.ToDateTime(campos[2]),
                    Documento = campos[3],
                    Contato = campos[4],
                    Peso = Double.Parse(campos[5]),
                    Altura = Math.Round(Double.Parse(campos[6]) / 100, 1),
                    Sexo = campos[7]
                };

                controle.AlunoDB Tabela = new controle.AlunoDB();
                Tabela.Insert(reg);
            }
        }

        private void btnMatricula_Click(object sender, EventArgs e)
        {
            FormMatricula Ficha = new FormMatricula();
            Ficha.Registro = null;
            Ficha.ShowDialog();
            if(Ficha.Registro != null)
            {
                BoaForma.matricular(Ficha.Registro);
                bs.ResetBindings(true);
                bs.MoveLast();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormMatricula Ficha = new FormMatricula();
            Ficha.Registro = (Aluno)bs.Current;
            Ficha.ShowDialog();
            if (Ficha.Registro != null)
            {
                BoaForma.Editar(Ficha.Registro);
                bs.ResetBindings(true);
                dgvAlunos.AutoResizeColumns();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (BoaForma.Alunos.Count() == 0) return;

            Aluno Registro = (Aluno)bs.Current;
            DialogResult op = MessageBox.Show("Deseja Excluir:" +
                Registro.Nome, "ALERTA", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (op == DialogResult.Yes)
            {
                BoaForma.Excluir(Registro);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FormPesquisarAluno pesquisa = new FormPesquisarAluno();
            pesquisa.BoaForma = BoaForma;
            pesquisa.ShowDialog();
            if (pesquisa.Matricula != 0)
            {
                Aluno reg = BoaForma.Alunos.First(i => i.Cod == pesquisa.Matricula);
                bs.Position = bs.IndexOf(reg);
                btnEditar_Click(sender, e);
            }

        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            FormRelatorio relatorio = new FormRelatorio();
            relatorio.Text = "Relatorios de alunos cadastrados";
            DataSet Banco = new DataSet();
            BoaForma.Relatorio(Banco);
            relatorio.DS = Banco;
            relatorio.Arquivo =
                @"C:\Users\Aluno\Downloads\ACADEMIA\CONTROLE_ACADEMIA\relatorio\aluno.rdlc";
            relatorio.Show();
        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            FormRelatorio relatorio = new FormRelatorio();
            relatorio.Text = "Relatorios de alunos cadastrados";
            DataSet Banco = new DataSet();
            BoaForma.Relatorio(Banco);
            relatorio.DS = Banco;
            relatorio.Arquivo =
                @"C:\Users\Aluno\Downloads\ACADEMIA\CONTROLE_ACADEMIA\relatorio\graficoAluno.rdlc";
            relatorio.Show();
        }

        private void dgvAlunos_Paint(object sender, PaintEventArgs e)
        {
            Aluno Registro = (Aluno)bs.Current;

            string caminho = Environment.CurrentDirectory +
               "\\fotos\\" + Registro.Cod.ToString().PadLeft(5, '0') + ".jpg";

            lbNome.Text = Registro.Nome;
            if (File.Exists(caminho))
            {
                pbFoto.CreateGraphics().DrawImage(Image.FromFile(caminho),
                    0, 0, pbFoto.Width, pbFoto.Height);
            }
            else
            {
                pbFoto.CreateGraphics().Clear(Color.DarkSlateGray);
            }
        }
    }
}
