using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLE_ACADEMIA.modelo
{
    class Academia
    {
        public BindingList<Aluno> Alunos { get; set; }

        public Academia()
        {
            Alunos = new BindingList<Aluno>();
        }
        public void matricular(Aluno Reg)
        {
            if (Reg != null)
            {
                try
                {
                    controle.AlunoDB Tabela = new controle.AlunoDB();
                    Tabela.Insert(Reg);
                    Alunos.Add(Reg);
                }
                catch (Exception Erro)
                {
                    System.Windows.Forms.MessageBox.Show("Erro: " +
                        Erro.Message);
                }
            }
        }

        public void Editar(Aluno aluno)
        {
            Aluno old = Alunos.First(i => i.Cod == aluno.Cod);

            try 
            {
            controle.AlunoDB Tabela = new controle.AlunoDB();
            Tabela.Update(aluno);          
            old.Nome = aluno.Nome;
            old.Nascimento = aluno.Nascimento;
            old.Peso = aluno.Peso;
            old.Altura = aluno.Altura;
            old.Contato = aluno.Contato;
            old.Documento = aluno.Documento;
            old.Sexo = aluno.Sexo;
            }
            catch (Exception Erro)
            {
                System.Windows.Forms.MessageBox.Show("Erro: " +
                    Erro.Message);
            }
        }

        public void Excluir(Aluno Registro)
        {
            Aluno old = Alunos.First(i => i.Cod == Registro.Cod);
            try
            {
                controle.AlunoDB Tabela = new controle.AlunoDB();
                Tabela.Delete(Registro);
                Alunos.Remove(old);
            }
            catch (Exception Erro)
            {
                System.Windows.Forms.MessageBox.Show("Erro: " +
                    Erro.Message);
            }
        }

        public object Pesquisar (string Nome, string Filtro)
        {
            if (Filtro == "I") return Alunos.Where(i => i.Nome.StartsWith(Nome));
            else if (Filtro == "F") return Alunos.Where(i => i.Nome.EndsWith(Nome));
            else return Alunos.Where(i => i.Nome.Contains(Nome));
        }

        public void Relatorio(System.Data.DataSet Banco)
        {
            Banco.Tables.Add(new System.Data.DataTable());
            Banco.Tables[0].Columns.Add("Cod");
            Banco.Tables[0].Columns.Add("Nome");
            Banco.Tables[0].Columns.Add("Nascimento");
            Banco.Tables[0].Columns.Add("Contato");
            Banco.Tables[0].Columns.Add("Peso");
            Banco.Tables[0].Columns.Add("Altura");
            Banco.Tables[0].Columns.Add("IMC");
            Banco.Tables[0].Columns.Add("Classificacao");
            Banco.Tables[0].Columns.Add("Sexo");
            Banco.Tables[0].Columns.Add("Idade");
            foreach (Aluno reg in Alunos)
            {
                System.Data.DataRow row = Banco.Tables[0].NewRow();
                row["Cod"] = reg.Cod;
                row["Nome"] = reg.Nome;
                row["Nascimento"] = reg.Nascimento;
                row["Contato"] = reg.Contato;
                row["Peso"] = reg.Peso;
                row["Altura"] = reg.Altura;
                row["IMC"] = reg.IMC;
                row["Sexo"] = reg.Sexo;
                row["Idade"] = reg.Idade;
                row["Classificacao"] = reg.Classificacao;
                

                Banco.Tables[0].Rows.Add(row);
            }
            Banco.DataSetName = "dsAluno";
        }
    }
}
