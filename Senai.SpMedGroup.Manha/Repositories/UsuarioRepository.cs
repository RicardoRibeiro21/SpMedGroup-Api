using Senai.SpMedGroup.Manha.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.Manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string StringConexao = "Data Source=.\\SQLEXPRESS;Initial Catalog=SPMEDGROUP;User ID = sa; Password = 132;";

        public void Atualizar(Usuarios usuario)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> ListaUsuarios()
        {
            List<Usuarios> ListaUsuarios = new List<Usuarios>();
            using(SqlConnection con = new SqlConnection(StringConexao))
            {

                string Select = "SELECT U.ID, U.NOME, U.ID_TIPO_USUARIO, U.EMAIL, U.SENHA, T.TIPO, U.DATA_NASCIMENTO FROM USUARIOS U JOIN TIPO_USUARIO T ON U.ID_TIPO_USUARIO = T.ID ";

                con.Open();

            using (SqlCommand cmd = new SqlCommand(Select, con))
            {
                SqlDataReader sqr = cmd.ExecuteReader();
                    if (sqr.HasRows)
                    {
                        while (sqr.Read())
                        {
                            Usuarios usuario = new Usuarios()
                            {
                                Id = Convert.ToInt32(sqr["ID"]),
                                Nome = sqr["NOME"].ToString(),
                                Senha = sqr["SENHA"].ToString(),
                                Email = sqr["EMAIL"].ToString(),
                                TipoUsuario = new TipoUsuario()
                                {
                                    Tipo = sqr["TIPO"].ToString(),

                                },
                                DataNascimento = Convert.ToDateTime(sqr["DATA_NASCIMENTO"]),
                            };
                            ListaUsuarios.Add(usuario);
                        }
                    }
                    return ListaUsuarios;
            }
            }
      
        }
    }
}
