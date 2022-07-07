using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TreinamentoAlex.BL;
using TreinamentoAlex.Model;

namespace TreinamentoAlex.Web {
    public partial class CadEstoque : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                CarregarDropDownListsProdutos();

            }
        }

        #region DropDownList
        private void CarregarDropDownListsProdutos() {

            BLProdutos blProdutos = new BLProdutos();


            ddlProduto.DataSource = blProdutos.Listar(); ;
            ddlProduto.DataBind();
            ListItem ltiSelecione = new ListItem("<-- Selecione -->", "-1");
            ddlProduto.Items.Insert(0, ltiSelecione);

        }
        #endregion

        #region EventosDe Botões
        //-------------------------------------------------------------------
        protected void btnSalvar_Click(object sender, EventArgs e) {

            if (!(ddlProduto == null || ddlProduto.SelectedIndex > 0)) {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(),
                    "alerta", "alert('Escolha o Produto.');", true);
            }
            else {


                BLProdutos blProdutos = new BLProdutos();

                EstoqueListagem estoqueListagem = new EstoqueListagem();
                Id = Convert.ToInt32(ddlProduto.SelectedValue);
                estoqueListagem.Id = Id;

                BLEstoque blEstoque = new BLEstoque();
                blEstoque.EntradaDeProduto(Id, estoqueListagem.Quantidade = Convert.ToInt32(txtQuantidade.Text));
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(),
                    "alerta", "alert('Estoque Atualizado com Sucesso.');", true);


                LimparCampos();
            }
        }
        //-------------------------------------------------------------------
        protected void btnAlterar_Click(object sender, EventArgs e) {
            Estoque estoque = new Estoque();
            Id = Convert.ToInt32(ddlProduto.SelectedValue);

            estoque.Id = Id;
            estoque.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            BLEstoque blEstoque = new BLEstoque();
            blEstoque.Atualizar(estoque);

        }
        //-------------------------------------------------------------------
        #endregion

        #region ViewState
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
        #endregion

        #region Metodos
        //-----------------------------------------------------------------------------
        public void LimparCampos() {
            txtQuantidade.Text = "";
            ddlProduto.ClearSelection();
            lblQuantEstoque.Text = "";
        }
        //-----------------------------------------------------------------------------
        private void AtualizarTotalProdutos() {
            if (lblQuantEstoque.Text =="" ) {
            
                                EstoqueListagem estoqueListagem = new EstoqueListagem();
                                Id = Convert.ToInt32(ddlProduto.SelectedValue);
                                estoqueListagem.Id = Id;
                                BLEstoque blEstoque = new BLEstoque();
                                EstoqueListagem estProduto = blEstoque.ObterEstoque(Id);
                                lblQuantEstoque.Text = estProduto.Quantidade.ToString();
                    }
        }
        //-----------------------------------------------------------------------------
        #endregion

        #region GridView

        #endregion

        #region ddlProduto
        protected void ddlProduto_SelectedIndexChanged(object sender, EventArgs e) {
            AtualizarTotalProdutos();

        }
        #endregion
    }
}