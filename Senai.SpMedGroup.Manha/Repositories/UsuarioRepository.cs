﻿using Senai.SpMedGroup.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

        public List<Consultas> ListarConsultasDoUsuario(int id)
        {   
            string Select = 

                            "SELECT C.ID, M.CRM, C.DATA_CONSULTA, U.NOME, C.ID_PRONTUARIO, SC.SITUACAO, " +
                            "P.CPF, P.RG, C.RESULTADO FROM MEDICOS M JOIN CONSULTAS C ON M.CRM = C.CRM_MEDICO " +
                            "JOIN PRONTUARIOS P ON C.ID_PRONTUARIO = P.ID JOIN USUARIOS U ON U.ID = P.ID_USUARIO" +
                            " JOIN STATUS_CONSULTA SC ON SC.ID = C.STATUS_CONSULTA WHERE U.ID = @Id";


            List<Consultas> consultasUsuario = new List<Consultas>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Select, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
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
                                },
                               CrmMedicoNavigation = new Medicos()
                               {
                                    Crm = sqr["CRM"].ToString(),
                                    IdUsuarioNavigation = new Usuarios()
                                    {
                                           Nome = sqr["NOME"].ToString(),                     
                                    },
                               },
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

        public List<Usuarios> ListaUsuarios()
        {
            List<Usuarios> ListaUsuarios = new List<Usuarios>();
            using(SqlConnection con = new SqlConnection(StringConexao))
            {

                string Select = "SELECT U.ID, U.NOME, U.ID_TIPO_USUARIO, U.EMAIL, U.SENHA, T.TIPO, U.DATA_NASCIMENTO FROM USUARIOS U JOIN TIPO_USUARIO T ON U.ID_TIPO_USUARIO = T.ID  WHERE U.ID_TIPO_USUARIO = 2";

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

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {                
                string QuerySelect = "SELECT U.ID, U.NOME, U.EMAIL, U.SENHA, T.TIPO FROM USUARIOS U JOIN TIPO_USUARIO T ON U.ID_TIPO_USUARIO = T.ID WHERE U.EMAIL = @EMAIL AND U.SENHA = @SENHA";
                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@SENHA", senha);
                    con.Open();

                    SqlDataReader sqr = cmd.ExecuteReader();

                    if (sqr.HasRows)
                    {
                        Usuarios usuario = new Usuarios();
                        while (sqr.Read())
                        {
                            usuario.Id = Convert.ToInt32(sqr["ID"]);
                            usuario.Nome = (sqr["NOME"]).ToString();
                            usuario.Email = (sqr["EMAIL"]).ToString();
                            usuario.TipoUsuario = new TipoUsuario()
                            {                               
                                Tipo = (sqr["TIPO"]).ToString()
                            };
                        }
                        return usuario;
                    }
                }
                return null;
            }

        }
    }
}
