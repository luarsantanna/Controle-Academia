using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;

namespace CONTROLE_ACADEMIA.visao
{
    public partial class FormRelatorio : Form
    {
        public FormRelatorio()
        {
            InitializeComponent();
        }

        internal DataSet DS { get; set; }
        internal string Arquivo { get; set; }

        private void FormRelatorio_Load(object sender, EventArgs e)
        {
            try
            {
                rp.LocalReport.DataSources.Clear();
                ReportDataSource source = null;
                source = new ReportDataSource(DS.DataSetName, DS.Tables[0]);
                rp.LocalReport.DataSources.Add(source);
                rp.LocalReport.ReportPath = @Arquivo;
                rp.ProcessingMode = ProcessingMode.Local;
                this.rp.RefreshReport();
            }
            catch (Exception Erro)
            {

                MessageBox.Show("Erro ao abrir relatório:"
                    + Erro.Message);
            }

            
        }
    }
}
