using Senai.SpMedGroup.Manha.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.Manha.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly string StringConexao = "Data Source=.\\SQLEXPRESS;Initial Catalog=SPMEDGROUP;User ID = sa; Password = 132;";

        //Método que o adm atualiza as consultas
        //public void AtualizarAdm(Consultas consulta)
        //{
        //    string Update = "UPDATE CONSULTAS SET CRM_MEDICO =  @CRM_MEDICO, DATA_CONSULTA = @DATA_CONSULTA,  STATUS_CONSULTA = @STATUS_CONSULTA, ID_PRONTUARIO = @ID_PRONTUARIO WHERE CONSULTAS.ID = @ID";
        //    using (SqlConnection con = new SqlConnection(StringConexao))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand(Update, con);
        //        cmd.Parameters.AddWithValue("@ID", consulta.Id);
        //        cmd.Parameters.AddWithValue("@CRM_MEDICO", consulta.CrmMedico);
        //        cmd.Parameters.AddWithValue("@DATA_CONSULTA", consulta.DataConsulta);
        //        cmd.Parameters.AddWithValue("@STATUS_CONSULTA", consulta.StatusConsulta);
        //        cmd.Parameters.AddWithValue("@ID_PRONTUARIO", consulta.IdProntuario);
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        public void AtualizarResultado(Consultas consulta)
        {
            string Update = "UPDATE CONSULTAS SET DATA_CONSULTA = @DATA_CONSULTA,  STATUS_CONSULTA = @STATUS_CONSULTA, RESULTADO = @RESULTADO WHERE CONSULTAS.ID = @ID";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Update, con);
                cmd.Parameters.AddWithValue("@ID", consulta.Id);               
                cmd.Parameters.AddWithValue("@DATA_CONSULTA", consulta.DataConsulta);
                cmd.Parameters.AddWithValue("@STATUS_CONSULTA", consulta.StatusConsulta);
                cmd.Parameters.AddWithValue("@RESULTADO", consulta.Resultado);
                cmd.ExecuteNonQuery();
            }
        }

        public void Cadastrar(Consultas consulta)
        {
            string Insert = "INSERT INTO CONSULTAS(CRM_MEDICO, DATA_CONSULTA, STATUS_CONSULTA, ID_PRONTUARIO) VALUES(@CRM_MEDICO, @DATA_CONSULTA, @STATUS_CONSULTA, @ID_PRONTUARIO)";
            using (SqlConnection con = new SqlConnection(StringConexao)) {
                con.Open();
                SqlCommand cmd = new SqlCommand(Insert, con);
                cmd.Parameters.AddWithValue("@CRM_MEDICO", consulta.CrmMedico);
                cmd.Parameters.AddWithValue("@DATA_CONSULTA", consulta.DataConsulta);
                cmd.Parameters.AddWithValue("@STATUS_CONSULTA", consulta.StatusConsulta);
                cmd.Parameters.AddWithValue("@ID_PRONTUARIO", consulta.IdProntuario);
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Consultas> ListarConsultas() => new SpMedGroupContext().Consultas.ToList();

        public List<Consultas> ListarConsultasDoMedico()
        {
            string Select = "SELECT C.STATUS_CONSULTA, C.RESULTADO, C.DATA_CONSULTA, U.NOME, U.DATA_NASCIMENTO, C.ID_PRONTUARIO, P.CPF, P.RG FROM MEDICOS M JOIN CONSULTAS C ON M.CRM = C.CRM_MEDICO JOIN PRONTUARIOS P ON C.ID_PRONTUARIO = P.ID JOIN USUARIOS U ON U.ID = P.ID_USUARIO WHERE M.CRM = C.CRM_MEDICO";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                List<Consultas> consultasMedico = new List<Consultas>();
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Select, con)) { 
                SqlDataReader sqr = cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    while (sqr.Read())
                    {
                            Consultas consulta = new Consultas()
                            {
                                CrmMedico = sqr["CRM"].ToString(),
                                DataConsulta = Convert.ToDateTime(sqr["DATA_CONSULTA"]),
                                IdProntuario = Convert.ToInt32(sqr["ID_PRONTUARIO"]),
                                StatusConsulta = Convert.ToInt32(sqr["STATUS_CONSULTA"]),
                                Resultado = sqr["RESULTADO"].ToString(),
                            };
                            consultasMedico.Add(consulta);
                    }
                    }
                    return consultasMedico;
                }
            }
        }

        public List<Consultas> ListarConsultasDoUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
