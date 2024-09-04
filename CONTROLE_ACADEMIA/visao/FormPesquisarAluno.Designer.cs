namespace CONTROLE_ACADEMIA.visao
{
    partial class FormPesquisarAluno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPesquisarAluno));
            this.pnTop = new System.Windows.Forms.Panel();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.pnLateral = new System.Windows.Forms.Panel();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbMeio = new System.Windows.Forms.RadioButton();
            this.rbFinal = new System.Windows.Forms.RadioButton();
            this.rbInicio = new System.Windows.Forms.RadioButton();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPesquisa = new System.Windows.Forms.DataGridView();
            this.pnTop.SuspendLayout();
            this.pnLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTop.Controls.Add(this.lbTitulo);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(10, 10);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(915, 119);
            this.pnTop.TabIndex = 0;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitulo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Image = ((System.Drawing.Image)(resources.GetObject("lbTitulo.Image")));
            this.lbTitulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Padding = new System.Windows.Forms.Padding(5);
            this.lbTitulo.Size = new System.Drawing.Size(913, 117);
            this.lbTitulo.TabIndex = 1;
            this.lbTitulo.Text = "PESQUISA DE ALUNOS MATRICULADOS";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnLateral
            // 
            this.pnLateral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLateral.Controls.Add(this.btnAbrir);
            this.pnLateral.Controls.Add(this.btnPesquisar);
            this.pnLateral.Controls.Add(this.rbMeio);
            this.pnLateral.Controls.Add(this.rbFinal);
            this.pnLateral.Controls.Add(this.rbInicio);
            this.pnLateral.Controls.Add(this.txtNome);
            this.pnLateral.Controls.Add(this.label1);
            this.pnLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLateral.Location = new System.Drawing.Point(10, 129);
            this.pnLateral.Name = "pnLateral";
            this.pnLateral.Size = new System.Drawing.Size(266, 477);
            this.pnLateral.TabIndex = 1;
            // 
            // btnAbrir
            // 
            this.btnAbrir.Image = global::CONTROLE_ACADEMIA.Properties.Resources.lista;
            this.btnAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrir.Location = new System.Drawing.Point(15, 375);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(230, 52);
            this.btnAbrir.TabIndex = 6;
            this.btnAbrir.Text = "ABRIR FICHA";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = global::CONTROLE_ACADEMIA.Properties.Resources.avatar_de_perfil;
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(15, 288);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(230, 52);
            this.btnPesquisar.TabIndex = 5;
            this.btnPesquisar.Text = "PESQUISAR NOME";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // rbMeio
            // 
            this.rbMeio.AutoSize = true;
            this.rbMeio.Location = new System.Drawing.Point(15, 221);
            this.rbMeio.Name = "rbMeio";
            this.rbMeio.Size = new System.Drawing.Size(211, 22);
            this.rbMeio.TabIndex = 4;
            this.rbMeio.Text = "Em Qualquer Posição";
            this.rbMeio.UseVisualStyleBackColor = true;
            // 
            // rbFinal
            // 
            this.rbFinal.AutoSize = true;
            this.rbFinal.Location = new System.Drawing.Point(15, 166);
            this.rbFinal.Name = "rbFinal";
            this.rbFinal.Size = new System.Drawing.Size(149, 22);
            this.rbFinal.TabIndex = 3;
            this.rbFinal.Text = "Final do Nome";
            this.rbFinal.UseVisualStyleBackColor = true;
            // 
            // rbInicio
            // 
            this.rbInicio.AutoSize = true;
            this.rbInicio.Checked = true;
            this.rbInicio.Location = new System.Drawing.Point(15, 108);
            this.rbInicio.Name = "rbInicio";
            this.rbInicio.Size = new System.Drawing.Size(156, 22);
            this.rbInicio.TabIndex = 2;
            this.rbInicio.TabStop = true;
            this.rbInicio.Text = "Inicio do Nome";
            this.rbInicio.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(15, 61);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(230, 27);
            this.txtNome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // dgvPesquisa
            // 
            this.dgvPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisa.Location = new System.Drawing.Point(285, 139);
            this.dgvPesquisa.Name = "dgvPesquisa";
            this.dgvPesquisa.Size = new System.Drawing.Size(638, 466);
            this.dgvPesquisa.TabIndex = 2;
            // 
            // FormPesquisarAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 616);
            this.Controls.Add(this.dgvPesquisa);
            this.Controls.Add(this.pnLateral);
            this.Controls.Add(this.pnTop);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPesquisarAluno";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPesquisarAluno";
            this.pnTop.ResumeLayout(false);
            this.pnLateral.ResumeLayout(false);
            this.pnLateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel pnLateral;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbMeio;
        private System.Windows.Forms.RadioButton rbFinal;
        private System.Windows.Forms.RadioButton rbInicio;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPesquisa;
    }
}