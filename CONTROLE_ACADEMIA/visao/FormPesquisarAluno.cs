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

namespace CONTROLE_ACADEMIA.visao
{
    public partial class FormPesquisarAluno : Form
    {
        public FormPesquisarAluno()
        {
            InitializeComponent();
        }

        internal Academia BoaForma { get; set; }
        internal int Matricula { get; set; }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string filtro = "";
            if (rbInicio.Checked) filtro = "I";
            else if (rbFinal.Checked) filtro = "F";
            else filtro = "M";
            BindingSource bs = new BindingSource();
            bs.DataSource = BoaForma.Pesquisar(txtNome.Text.ToUpper(), filtro);
            dgvPesquisa.DataSource = bs;
            dgvPesquisa.AutoResizeColumns();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (dgvPesquisa.Rows.Count == 0) return;

            string valor = dgvPesquisa.CurrentRow.Cells["Cod"].Value.ToString();
            Matricula = Int32.Parse(valor);
            this.Dispose();
        }
    }
}
