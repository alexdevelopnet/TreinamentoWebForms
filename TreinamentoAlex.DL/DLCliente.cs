using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TreinamentoAlex.Model;

namespace TreinamentoAlex.DL {
    public class DLCliente {

        #region Inserir
        //------------------------------------------------------------------------------------------
        public int Inserir(Cliente cliente) {
            int intId;
            SqlConnection con = null;


            try {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                
                SqlCommand cmd = new SqlCommand("USP_I_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@SobreNome", cliente.SobreNome);
                cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
                cmd.Parameters.AddWithValue("@Pontuacao", cliente.Pontuacao);
                cmd.Parameters.AddWithValue("@IdTipo", cliente.IdTipo);


                intId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally {
                if (con != null)
                    con.Close();
            }
            return intId;
        }
        #endregion
        //---------------------------------------------------------------------------------------
        #region Atualizar
        public void Atualizar(Cliente cliente) {
            SqlConnection con = null;

            try {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_U_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", cliente.Id);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@SobreNome", cliente.SobreNome);
                cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
                cmd.Parameters.AddWithValue("@Pontuacao", cliente.Pontuacao);
                cmd.Parameters.AddWithValue("@IdTipo", cliente.IdTipo);

                cmd.ExecuteNonQuery();
            }
            finally {
                if (con != null)
                    con.Close();
            }
        }
        #endregion
        //---------------------------------------------------------------------------------------
        #region Deletar
        public void Deletar(int id) {
            SqlConnection con = null;

            try {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_D_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
            finally {
                if (con != null)
                    con.Close();
            }
        }
        #endregion
        //---------------------------------------------------------------------------------------
        #region Listar
        public List<ClienteListagem> Listar() {
            SqlConnection con = null;
            List<ClienteListagem> lstCliente = null;

            try {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                 
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_L_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
               
                SqlDataReader radClientes = cmd.ExecuteReader();
                lstCliente = new List<ClienteListagem>();


                while (radClientes.Read()) {
                    ClienteListagem cliente = new ClienteListagem();

                    cliente.Id = Convert.ToInt32(radClientes["Id"]);
                    cliente.Nome = (string)radClientes["Nome"];
                    cliente.SobreNome = (string)radClientes["SobreNome"];
                    cliente.DataNascimento = Convert.ToDateTime(radClientes["DataNascimento"]);
                    cliente.Pontuacao = Convert.ToInt32(radClientes["Pontuacao"]);
                    //cliente.IdTipo = Convert.ToInt32(radClientes["IdTipo"]);
                    //cliente.DescricaoTipo = (string)radClientes["Descricao"];

                    lstCliente.Add(cliente);
                }

            }
            finally {
                if (con != null)
                    con.Close();
            }

            return lstCliente;
        }
        #endregion
        //---------------------------------------------------------------------------------------
        #region Obter
        public Cliente Obter(int Id) {
            SqlConnection con = null;
            Cliente cliente = null;

            try {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_O_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", Id);

                SqlDataReader radClientes = cmd.ExecuteReader();


                if (radClientes.Read()) {
                    cliente = new Cliente();

                    cliente.Id = Convert.ToInt32(radClientes["Id"]);
                    cliente.Nome = (string)radClientes["Nome"];
                    cliente.SobreNome = (string)radClientes["SobreNome"];
                    cliente.DataNascimento = Convert.ToDateTime(radClientes["DataNascimento"]);
                    cliente.Pontuacao = Convert.ToInt32(radClientes["Pontuacao"]);
                    cliente.IdTipo = Convert.ToInt32(radClientes["IdTipo"]);


                }

            }
            finally {
                if (con != null)
                    con.Close();
            }

            return cliente;
        }
        #endregion
        //---------------------------------------------------------------------------------------
    }
}
