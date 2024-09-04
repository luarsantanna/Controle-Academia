using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using CONTROLE_ACADEMIA.modelo;
using System.ComponentModel;

namespace CONTROLE_ACADEMIA.controle
{
    class AlunoDB
    {
        public readonly ServidorSQL servidor = new ServidorSQL();
        public void Insert(Aluno Reg)
        {
            servidor.Open("academia.sqlite");
            using (var comando = new SQLiteCommand(servidor.Con))
            {
                string sql = String.Format(
                    "INSERT INTO ALUNO VALUES({0},'{1}','{2}'"
                    + ",'{3}','{4}',{5},{6},'{7}')",
                    Reg.Cod, Reg.Nome, Reg.Nascimento.Date, Reg.Documento,
                    Reg.Contato, Reg.Peso.ToString().Replace(',', '.'),
                    Reg.Altura.ToString().Replace(',', '.'),
                    Reg.Sexo);

                comando.CommandText = sql;
                comando.ExecuteNonQuery();
            }
        }
        public void Select(BindingList<Aluno> Alunos)
        {
            servidor.Open("academia.sqlite");
            using (var comando = new SQLiteCommand(servidor.Con))
            {
                string sql = "SELECT * FROM ALUNO ORDER BY COD";
                comando.CommandText = sql;
                SQLiteDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Aluno Reg = new Aluno
                    {
                        Cod = dr.GetInt32(0),
                        Nome = dr.GetString(1),
                        Nascimento = DateTime.Parse(dr.GetString(2)),
                        Documento = dr.GetString(3),
                        Contato = dr.GetString(4),
                        Peso = dr.GetDouble(5),
                        Altura = dr.GetDouble(6),
                        Sexo = dr.GetString(7),
                    };
                    Alunos.Add(Reg);
                }
                dr.Close();
            }
        }

        public void Delete(Aluno Reg)
        {
            servidor.Open("academia.sqlite");
            using (var comando = new SQLiteCommand(servidor.Con))
            {
                string sql = String.Format("DELETE FROM ALUNO WHERE COD = {0}",
                    Reg.Cod);
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
            }
        }

        public void Update(Aluno Reg)
        {
            servidor.Open("academia.sqlite");
            using (var comando = new SQLiteCommand(servidor.Con))
            {
                string sql = String.Format("UPDATE ALUNO  SET " +
                    "NOME = '{1}',NASCIMENTO = '{2}', DOCUMENTO = '{3}'," +
                    "CONTATO = '{4}', PESO = {5}, ALTURA = {6}, SEXO = '{7}'"
                    + " WHERE COD = {0}",
                    Reg.Cod, Reg.Nome, Reg.Nascimento.Date, Reg.Documento,
                    Reg.Contato, Reg.Peso.ToString().Replace(',', '.'),
                    Reg.Altura.ToString().Replace(',', '.'),
                    Reg.Sexo);

                comando.CommandText = sql;
                comando.ExecuteNonQuery();
            }
        }
    }
}
