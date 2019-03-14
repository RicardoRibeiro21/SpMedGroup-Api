using Senai.SpMedGroup.Manha.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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

        public List<Consultas> ListarConsultasDoMedico(string crmMedico)
        {
            string Select = "SELECT C.STATUS_CONSULTA, C.RESULTADO, C.DATA_CONSULTA, U.NOME, U.ID, U.DATA_NASCIMENTO, C.ID_PRONTUARIO, P.ID_USUARIO, P.ID, P.CPF, P.RG FROM MEDICOS M JOIN CONSULTAS C ON M.CRM = C.CRM_MEDICO JOIN PRONTUARIOS P ON C.ID_PRONTUARIO = P.ID JOIN USUARIOS U ON U.ID = P.ID_USUARIO WHERE M.CRM = @CRM";
            List<Consultas> consultasMedico = new List<Consultas>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Select, con))
                {
                    cmd.Parameters.AddWithValue("@CRM", crmMedico);
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
                                    }
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

        public List<Medicos> ListarMedicos() => new SpMedGroupContext().Medicos.ToList();
    }
}
