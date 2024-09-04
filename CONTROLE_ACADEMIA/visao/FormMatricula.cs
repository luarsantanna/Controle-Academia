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
using System.Drawing.Imaging;

namespace CONTROLE_ACADEMIA.visao
{
    public partial class FormMatricula : Form
    {
        public FormMatricula()
        {
            InitializeComponent();
        }

        internal Aluno Registro { get; set; }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (Registro == null) Novo();
            else Editar();
            this.Dispose();
        }

        private void Editar()
        {
            string Tipo = "";

            if (rbMasculino.Checked) Tipo = "M";
            if (rbFeminino.Checked) Tipo = "F";
            if (rbOutros.Checked) Tipo = "O";

            Registro.Nome = txtNome.Text.ToUpper();
            Registro.Contato = txtContato.Text;
            Registro.Documento = txtDocumento.Text;
            Registro.Nascimento = dtNascimento.Value.Date;
            Registro.Peso = Double.Parse(txtPeso.Text);
            Registro.Altura = Double.Parse(txtAltura.Text);
            Registro.Sexo = Tipo;
            
        }

        private void Novo()
        {
            string Tipo = "";

            if (rbMasculino.Checked) Tipo = "M";
            if (rbFeminino.Checked) Tipo = "F";
            if (rbOutros.Checked) Tipo = "O";
            Registro = new Aluno
            {
                Cod = Int32.Parse(txtMatricula.Text),
                Nome = txtNome.Text.ToUpper(),
                Contato = txtContato.Text,
                Documento = txtDocumento.Text,
                Nascimento = dtNascimento.Value.Date,
                Peso = Double.Parse(txtPeso.Text),
                Altura = Double.Parse(txtAltura.Text),
                Sexo = Tipo
            };
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Registro = null;
            this.Dispose();
        }

        private void FormMatricula_Load(object sender, EventArgs e)
        {
            if (Registro != null)
            {
                txtMatricula.ReadOnly = true;
                txtMatricula.Text = Registro.Cod.ToString().PadLeft(5, '0');
                txtNome.Text = Registro.Nome;
                txtContato.Text = Registro.Contato;
                txtDocumento.Text = Registro.Documento;
                txtPeso.Text = Registro.Peso.ToString("N2");
                txtAltura.Text = Registro.Altura.ToString("N2");
                dtNascimento.Value = Registro.Nascimento;
                if (Registro.Sexo == "M") rbMasculino.Checked = true;
                if (Registro.Sexo == "F") rbFeminino.Checked = true;
                if (Registro.Sexo == "O") rbOutros.Checked = true;
                txtNome.Focus();
                txtNome.Select();
            }
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            string caminho = Environment.CurrentDirectory + "\\fotos\\" +
                txtMatricula.Text + ".jpg";
            if (Registro == null) return;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.FileName = "";
            openFile.Filter = "foto|*.jpg";
            openFile.ShowDialog();
            if(File.Exists(openFile.FileName)){
                Application.DoEvents(); // Processador AMD Ryzen
                pbFoto.Image = null;
                GC.Collect(); // Coletar o lixo na memoria RAM
                GC.WaitForPendingFinalizers(); // Espera a coleta terminar
                if(File.Exists(caminho))
                {
                    File.Delete(caminho);
                }
                File.Copy(openFile.FileName, caminho);
                MessageBox.Show("Foto Salva com Sucesso", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                pbFoto.Image = Image.FromFile(caminho);
            }
        }

        private void FormMatricula_Paint(object sender, PaintEventArgs e)
        {
            string caminho = Environment.CurrentDirectory + "\\fotos\\" +
                txtMatricula.Text + ".jpg";
            if (File.Exists(caminho))
            {
                pbFoto.Image = Image.FromFile(caminho);
            }
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            FormWebCam camera = new FormWebCam();
            camera.ShowDialog();
            string caminho = Environment.CurrentDirectory + "\\fotos\\" +
                txtMatricula.Text + ".jpg";
            if (camera.pbFoto == null)
            {
                MessageBox.Show("Foto não cadastrada");
                return;

            }
            if(File.Exists(caminho))
            {
                Application.DoEvents();
                pbFoto.Image = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(caminho);
            }
            camera.pbFoto.Image.Save(caminho, ImageFormat.Jpeg);
            pbFoto.Image = Image.FromFile(caminho);
        }
    }
}
