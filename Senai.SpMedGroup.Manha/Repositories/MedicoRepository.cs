using Senai.SpMedGroup.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Senai.SpMedGroup.Manha.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly string StringConexao = "Data Source=.\\SQLEXPRESS;Initial Catalog=SPMEDGROUP;User ID = sa; Password = 132;";

        public void Cadastrar(Medicos medico)
        {
            using(SpMedGroupContext spmed = new SpMedGroupContext())
            {
                spmed.Medicos.Add(medico);
                spmed.SaveChanges();
            }
        }

        public List<Consultas> ListarConsultasDoMedico(int idMedico)
        {
            string Select = "SELECT C.STATUS_CONSULTA, C.RESULTADO, C.DATA_CONSULTA, U.NOME, U.ID, U.DATA_NASCIMENTO, C.ID_PRONTUARIO, P.ID_USUARIO, P.ID, P.CPF, P.RG FROM MEDICOS M JOIN CONSULTAS C ON M.CRM = C.CRM_MEDICO JOIN PRONTUARIOS P ON C.ID_PRONTUARIO = P.ID JOIN USUARIOS U ON U.ID = P.ID_USUARIO WHERE M.ID_USUARIO = @ID";
            List<Consultas> consultasMedico = new List<Consultas>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Select, con))
                {
                    cmd.Parameters.AddWithValue("@ID", idMedico);
                    SqlDataReader sqr = cmd.ExecuteReader();
                    if (sqr.HasRows)
                    {
                        while (sqr.Read())
                        {
                            Consultas consulta = new Consultas()
                            {
                                DataConsulta = Convert.ToDateTime(sqr["DATA_CONSULTA"]),
                                IdProntuarioNavigation = new Prontuarios()
                                {
                                    IdUsuario = Convert.ToInt32(sqr["ID_USUARIO"]),
                                    Cpf = sqr["CPF"].ToString(),
                                    Rg = sqr["RG"].ToString(),
                                    IdUsuarioNavigation = new Usuarios()
                                    { 
                                        Nome = sqr["NOME"].ToString(),
                                        DataNascimento = Convert.ToDateTime(sqr["DATA_NASCIMENTO"])
                                    },
                                },
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

        public List<Medicos> ListarMedicos()
        {
            List<Medicos> medicos = new List<Medicos>();

            string QueryMedicos = "SELECT  M.CRM, U.NOME, E.ID, E.ESPECIALIZACAO, C.RAZAO_SOCIAL FROM MEDICOS M JOIN USUARIOS U ON U.ID = M.ID_USUARIO JOIN ESPECIALIZACOES E ON E.ID = M.ID_ESPECIALIZACAO JOIN CLINICA C ON C.ID = M.ID_CLINICA";
            
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(QueryMedicos, con))
                {
                    SqlDataReader sqr = cmd.ExecuteReader();

                    if (sqr.HasRows)
                    {
                        while (sqr.Read())
                        {
                            Medicos medico = new Medicos()
                            {
                                Crm = sqr["CRM"].ToString(),
                                IdUsuarioNavigation = new Usuarios()
                                {
                                    Nome = sqr["NOME"].ToString()
                                },
                                IdEspecializacaoNavigation = new Especializacoes()
                                {
                                    Id = Convert.ToInt32(sqr["ID"]),
                                    Especializacao = sqr["ESPECIALIZACAO"].ToString()
                                },
                                IdClinicaNavigation = new Clinica()
                                {
                                    RazaoSocial= sqr["RAZAO_SOCIAL"].ToString()
                                }
                            };
                            medicos.Add(medico);
                        }
                    }
                }
            }
              
            return medicos;
        }
       
    }
}
