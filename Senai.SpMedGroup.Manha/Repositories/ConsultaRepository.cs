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


        public List<Consultas> ListarConsultas() => new SpMedGroupContext().Consultas.ToList();

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
