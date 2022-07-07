using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TreinamentoAlex.BL;
using TreinamentoAlex.Model;

namespace TreinamentoAlex.Web {
    public partial class CadProduto : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                CarregarDdlFabricante();
                PopulargdvCadProduto();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e) {

            if (!(ddlFabricante == null || ddlFabricante.SelectedIndex > 0)) {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "alerta",
                    "alert('Escolha o Fabricante.');", true);

            }
            else {


                BLProdutos blProdutos = new BLProdutos();
                Produto produto = new Produto();
                produto.Descricao = txtDescricao.Text;
                produto.Valor = Convert.ToDouble(txtvalorUnitario.Text);
                produto.Id_Fabricante = (ddlFabricante.SelectedValue);
                
                blProdutos.Inserir(produto);


                if (Id == 0) {

                    produto.Id = Id;
                    new BLProdutos().Atualizar(produto);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "alerta",
                        "alert('Registro Inserido com sucesso.');", true);
                    PopulargdvCadProduto();


                }

                PopulargdvCadProduto();
            }
        }

        private void PopulargdvCadProduto() {
            BLProdutos blProdutos = new BLProdutos();


            gdvCadProduto.DataSource = blProdutos.Listar();
            gdvCadProduto.DataBind();

        }

        private void CarregarDdlFabricante() {

            BLFabricante blFabricante = new BLFabricante();
            List<Fabricante> lstFabricantes = blFabricante.Listar();

            ddlFabricante.DataSource = lstFabricantes;
            ddlFabricante.DataBind();
            ListItem ltiSelecione = new ListItem("<-- Selecione -->", "-1");
            ddlFabricante.Items.Insert(0, ltiSelecione);

        }

        public int Id {
            get {
                if (ViewState["Id"] != null)

                    return (int)ViewState["Id"];
                return 0;
            }
            set {
                ViewState["Id"] = value;
            }
        }

        protected void gdvCadProduto_RowCommand(object sender, GridViewCommandEventArgs e) {

            BLProdutos blProdutos = new BLProdutos();

            if (e.CommandName == "Excluir") {
                Id = Convert.ToInt32(e.CommandArgument);
                Produto produto = new Produto();
                produto.Id = Id;
                 blProdutos.Deletar(produto);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "alerta", "alert('Dados Excluidos com sucesso.');", true);
                Response.Redirect("CadProduto.aspx");

            }
            if (e.CommandName == "Editar") {
                Id = Convert.ToInt32(e.CommandArgument);
                Produto produto = new BLProdutos().Obter(Id);
                txtDescricao.Text = produto.Descricao;
                txtvalorUnitario.Text = produto.Valor.ToString();
                ddlFabricante.SelectedValue = produto.Id_Fabricante;
                btnCancelar.Visible = true;

            }

        }
    }
}