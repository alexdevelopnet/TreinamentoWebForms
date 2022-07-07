using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TreinamentoAlex.Model;

namespace TreinamentoAlex.DL {
    public class DLTipoCliente {

        //------------------------------------------------------------------------------------
        #region Inserir
        public int Inserir(TipoCliente tpcCliente) {
            int intIdTipoCliente;
            SqlConnection con = null;

            try {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_I_Tip_Tipo_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Tip_C_Descricacao", tpcCliente.Descricao);

                intIdTipoCliente = Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally {
                if (con != null)
                    con.Close();
            }
            return intIdTipoCliente;
        }
        #endregion
        //------------------------------------------------------------------------------------
        #region Atualizar
        public void Atualizar(TipoCliente tpcCliente) {
            SqlConnection con = null;

            try {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_U_Tip_Tipo_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tip_N_Id_TipoCliente", tpcCliente.IdTipo);
                cmd.Parameters.AddWithValue("@Tip_C_Descricacao", tpcCliente.Descricao);


                cmd.ExecuteNonQuery();
            }
            finally {
                if (con != null)
                    con.Close();
            }
        }
        #endregion
        //--------------------------------------------------------------------------------------
        #region Deletar
        public void Deletar(int intIdTipoCliente) {
            SqlConnection con = null;

            try {
                const string strConexao = "Data Source=DT-Server02;Initial Catalog=TreinamentoAlex; user=treinamento; pwd=treinamento;";
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_D_Tip_Tipo_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tip_N_Id", intIdTipoCliente);

                cmd.ExecuteNonQuery();
            }
            finally {
                if (con != null)
                    con.Close();
            }
        }
        #endregion
        //--------------------------------------------------------------------------------------
        #region Listar
        public List<TipoCliente> Listar() {
            SqlConnection con = null;
            List<TipoCliente> lstTipoCliente = null;

            try {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_L_Tip_Tipo_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlDataReader radClientes = cmd.ExecuteReader();
                lstTipoCliente = new List<TipoCliente>();

                while (radClientes.Read()) {
                    TipoCliente tipoCliente = new TipoCliente();
                    
                    tipoCliente.IdTipo = Convert.ToInt32(radClientes["Tip_N_Id"]);
                    tipoCliente.Descricao = (string)radClientes["Tip_C_Descricao"];


                    lstTipoCliente.Add(tipoCliente);
                }

            }
            finally {
                if (con != null)
                    con.Close();
            }

            return lstTipoCliente;
        }
        #endregion
        //--------------------------------------------------------------------------------------
        #region Obter
        public TipoCliente Obter(int IdTipoCliente) {
            SqlConnection con = null;
            TipoCliente tipoCliente = null;

            try {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_L_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlDataReader radClientes = cmd.ExecuteReader();


                if (radClientes.Read()) {
                    tipoCliente = new TipoCliente();

                    tipoCliente.IdTipo = Convert.ToInt32(radClientes["Tip_N_Id"]);
                    tipoCliente.Descricao = (string)radClientes["Tip_C_Descricacao"];

                }

            }
            finally {
                if (con != null)
                    con.Close();
            }

            return tipoCliente;
        }

    }
        #endregion
}
