using Senai.SpMedGroup.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Senai.SpMedGroup.Manha.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly string StringConexao = "Data Source=.\\SQLEXPRESS;Initial Catalog=SPMEDGROUP;User ID = sa; Password = 132;";

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


        public List<Consultas> ListarConsultas() {

            string Select = "SELECT C.ID,  M.CRM, M.ID_USUARIO AS ID_MEDICO, SC.SITUACAO, C.RESULTADO, C.DATA_CONSULTA, U.NOME, U.DATA_NASCIMENTO, C.ID_PRONTUARIO, P.CPF, P.RG FROM MEDICOS M JOIN CONSULTAS C ON M.CRM = C.CRM_MEDICO JOIN PRONTUARIOS P ON C.ID_PRONTUARIO = P.ID JOIN USUARIOS U ON U.ID = P.ID_USUARIO JOIN STATUS_CONSULTA SC ON SC.ID = C.STATUS_CONSULTA";

            List<Consultas> consultasUsuario = new List<Consultas>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Select, con))
                {                   
                    SqlDataReader sqr = cmd.ExecuteReader();
                    if (sqr.HasRows)
                    {
                        while (sqr.Read())
                        {
                            Consultas consulta = new Consultas()
                            {
                                Id = Convert.ToInt32(sqr["ID"]),
                                DataConsulta = Convert.ToDateTime(sqr["DATA_CONSULTA"]),
                                IdProntuarioNavigation = new Prontuarios()
                                {
                                    
                                    Cpf = sqr["CPF"].ToString(),
                                    Rg = sqr["RG"].ToString(),
                                    IdUsuarioNavigation = new Usuarios()
                                    {
                                        Nome = sqr["NOME"].ToString(),
                                        DataNascimento = Convert.ToDateTime(sqr["DATA_NASCIMENTO"])
                                    }
                                },
                                CrmMedicoNavigation = new Medicos()
                                {
                                    IdUsuario = Convert.ToInt32(sqr["ID_MEDICO"])
                                },
                                CrmMedico = sqr["CRM"].ToString(),
                                StatusConsultaNavigation = new StatusConsulta()
                                {
                                    Situacao = sqr["SITUACAO"].ToString()
                                },
                                Resultado = sqr["RESULTADO"].ToString(),
                            };

                            consultasUsuario.Add(consulta);
                        }
                    }
                    return consultasUsuario;
                }
            }
        }

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
    }
}
