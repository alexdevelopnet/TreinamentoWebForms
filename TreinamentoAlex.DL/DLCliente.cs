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
                cmd.Parameters.AddWithValue("@Cli_C_Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Cli_C_SobreNome", cliente.SobreNome);
                cmd.Parameters.AddWithValue("@Cli_D_DataNascimento", cliente.DataNascimento);
                cmd.Parameters.AddWithValue("@Cli_N_Pontuacao", cliente.Pontuacao);
                cmd.Parameters.AddWithValue("@Tip_Cli_N_Id", cliente.IdTipo);


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
                cmd.Parameters.AddWithValue("@Cli_N_Id", cliente.Id);
                cmd.Parameters.AddWithValue("@Cli_C_Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Cli_C_SobreNome", cliente.SobreNome);
                cmd.Parameters.AddWithValue("@Cli_D_DataNascimento", cliente.DataNascimento);
                cmd.Parameters.AddWithValue("@Cli_N_Pontuacao", cliente.Pontuacao);
                cmd.Parameters.AddWithValue("@Tip_Cli_N_Id", cliente.IdTipo);

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
        public void Deletar(int intIdCliente) {
            SqlConnection con = null;

            try {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_D_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cli_N_Id", intIdCliente);

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

                string strUsuarioAdministrador = ConfigurationManager.AppSettings["usuAdministrador"];

                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_L_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
               
                SqlDataReader radClientes = cmd.ExecuteReader();
                lstCliente = new List<ClienteListagem>();


                while (radClientes.Read()) {
                    ClienteListagem cliente = new ClienteListagem();

                    cliente.Id = Convert.ToInt32(radClientes["Cli_N_Id"]);
                    cliente.Nome = (string)radClientes["Cli_C_Nome"];
                    cliente.SobreNome = (string)radClientes["Cli_C_SobreNome"];
                    cliente.DataNascimento = Convert.ToDateTime(radClientes["Cli_D_DataNascimento"]);
                    cliente.Pontuacao = Convert.ToInt32(radClientes["Cli_N_Pontuacao"]);
                    cliente.IdTipo = Convert.ToInt32(radClientes["Tip_Cli_N_Id"]);
                    cliente.DescricaoTipo = (string)radClientes["Tip_C_Descricao"];

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
        public Cliente Obter(int IdCliente) {
            SqlConnection con = null;
            Cliente cliente = null;

            try {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_L_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Cli_N_Id", IdCliente);

                SqlDataReader radClientes = cmd.ExecuteReader();


                if (radClientes.Read()) {
                    cliente = new Cliente();

                    cliente.Id = Convert.ToInt32(radClientes["Cli_N_Id"]);
                    cliente.Nome = (string)radClientes["Cli_C_Nome"];
                    cliente.SobreNome = (string)radClientes["Cli_C_SobreNome"];
                    cliente.DataNascimento = Convert.ToDateTime(radClientes["Cli_D_DataNascimento"]);
                    cliente.Pontuacao = Convert.ToInt32(radClientes["Cli_N_Pontuacao"]);
                    cliente.IdTipo = Convert.ToInt32(radClientes["Tip_Cli_N_Id"]);


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
