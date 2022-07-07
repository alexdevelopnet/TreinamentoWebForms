using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TreinamentoAlex.BL;
using TreinamentoAlex.Model;
namespace TreinamentoAlex.Web {
    public partial class CadCompras : System.Web.UI.Page {
        //=================================================================================
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                CarregarDropDownListsCliente();
            }
        }

        #region CarregarDropDownLists
        //---------------------------------------------------------------------------------
        private void CarregarDropDownListsCliente() {
            BLCliente blCliente = new BLCliente();
            List<ClienteListagem> lstClientes = blCliente.Listar();

            ddlCliente.DataSource = lstClientes;
            ddlCliente.DataBind();

            ListItem ltiSelecione = new ListItem("<-- Selecione -->", "-1");
            ddlCliente.Items.Insert(0, ltiSelecione);

        }
        //---------------------------------------------------------------------------------
        private void CarregarDropDownListsProdutos() {

            BLProdutos blProdutos = new BLProdutos();
            List<Produto> lstProdutos = blProdutos.Listar();

            ddlProduto.DataSource = lstProdutos;
            ddlProduto.DataBind();
            ListItem ltiSelecione = new ListItem("<-- Selecione -->", "-1");
            ddlProduto.Items.Insert(0, ltiSelecione);


            ItemCompraListagem itemCompraListagem = new ItemCompraListagem();

        }
        //--------------------------------------------------------------------------------
        protected void ddlProduto_SelectedIndexChanged(object sender, EventArgs e) {
            if (IsPostBack) {
                painelCliente.Attributes.Clear();
                painelCliente.Attributes.Add("position", "relative");
                painelCliente.Attributes.Add("visibility", "visible");
            }
            Compra compra = new Compra();

            BLProdutos blProdutos = new BLProdutos();
            blProdutos.Obter(compra.Id);

            lblValor.Text = blProdutos.Obter(Convert.ToInt32(ddlProduto.SelectedValue)).Valor.ToString();

        }
        //--------------------------------------------------------------------------------
        #endregion

        #region EventosDe Botões
        protected void btnIncluirCompra_Click(object sender, EventArgs e) {

            if (!(ddlProduto == null || ddlProduto.SelectedIndex > 0)) {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(),
                "alerta", "alert('Escolha o Produto.');", true);
                VizualizarPainelCliente();
            }


            else {
                VizualizarPainelCliente();

                InserirItensCompra();

                VizualizarPanelCarrinho();

                LimparCampos();
            }
        }
        //--------------------------------------------------------------------------------
        protected void btProceder_Click(object sender, EventArgs e) {


            if (ddlCliente.SelectedIndex <= 0) {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "alerta", "alert('Escolha o Cliente.');", true);
            }
            else {
                VizualizarPainelCliente();

                CarregarDropDownListsProdutos();

                InserirCompra();

                lblCliente.Text = Convert.ToString(ddlCliente.SelectedItem);
            }
            lblData.Text = DateTime.Now.ToString();



        }
        //--------------------------------------------------------------------------------
        protected void btCancelar_Click(object sender, EventArgs e) {

        }
        #endregion

        #region Inserir

        //--------------------------------------------------------------------------------
        private void InserirCompra() {
            BLCompra blCompra = new BLCompra();
            Compra compra = new Compra();
            compra.IdCliente = Convert.ToInt32(ddlCliente.SelectedValue);
            compra.DataCompra = DateTime.Now;

            Id = blCompra.Inserir(compra);
        }
        //---------------------------------------------------------------------------------

        private void InserirItensCompra() {
            int intIdProduto = Convert.ToInt32(ddlProduto.SelectedValue);

            ItemCompra itemCompra = new ItemCompra();
            itemCompra.IdCompra = Id;
            itemCompra.IdProduto = intIdProduto;
            int quantidade = itemCompra.Quantidade = Convert.ToInt32(txtQuantidade.Text);

            BLItemCompra blItemCompra = new BLItemCompra();

            bool resp = ValidarEstoque(intIdProduto, quantidade);
            if (resp == true) {
                blItemCompra.Inserir(itemCompra);
            }
            AtualizaEstoque(intIdProduto, quantidade);

        }
        //---------------------------------------------------------------------------------
        #endregion
       
        #region AlterandoEstoque
        private bool ValidarEstoque(int intId, int intQuantidade) {

            BLItemCompra blItemCompra = new BLItemCompra();

            bool resp = Convert.ToBoolean(blItemCompra.VerificarEstoque(intId, intQuantidade));
            if (resp==true) {
                return true;    
            }
            else {
               return false;
            }
            
        }
        //---------------------------------------------------------------------------------
        private void AtualizaEstoque(int intIdProduto, int intQuantidade) {
            BLEstoque blEstoque = new BLEstoque();

            if (ValidarEstoque(intIdProduto,intQuantidade)==true) {
                blEstoque.SaidaDeProduto(intIdProduto, intQuantidade);
                PopulargdvItensCompra();

            }
            else {
                EstoqueListagem estProduto = blEstoque.ObterEstoque(intIdProduto);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(),
                "alerta", "alert('Quantidade de Produto no Momento Indisponível." + estProduto.Quantidade + "');", true);
              
            }

        }
        //--------------------------------------------------------------------------------
        #endregion

        #region Grid View
        private void PopulargdvItensCompra() {

            BLProdutos blProdutos = new BLProdutos();

            List<ItemCompraListagem> lstItens = blProdutos.ListarItensCompra(Id);

            double dblValorTotalCompra = (
                from item in lstItens
                select item.ValorTotalProduto
            ).Sum();


            gdvIntensCompra.DataSource = lstItens;
            gdvIntensCompra.DataBind();

            lblTotal.Text = dblValorTotalCompra.ToString("C2");
        }
        //---------------------------------------------------------------------------------
        protected void gdvIntensCompra_RowCommand(object sender, GridViewCommandEventArgs e) {
            BLItemCompra blItemCompra = new BLItemCompra();

            if (e.CommandName == "Excluir") {
                IdItemCompra = Convert.ToInt32(e.CommandArgument);
                ItemCompra item = new ItemCompra();
                item.Id = IdItemCompra;
                blItemCompra.Deletar(item);

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "alerta", "alert('Dados Excluidos com sucesso.');", true);
                PopulargdvItensCompra();

            }
        }

        #endregion

        #region Painel
        private void VizualizarPainelCliente() {
            if (IsPostBack) {
                painelCliente.Attributes.Clear();
                painelCliente.Attributes.Add("position", "relative");
                painelCliente.Attributes.Add("visibility", "visible");
            }
        }

        private void VizualizarPanelCarrinho() {
            painelCarrinhoDeCompra.Attributes.Clear();
            painelCarrinhoDeCompra.Attributes.Add("position", "relative");
            painelCarrinhoDeCompra.Attributes.Add("visibility", "visible");
            PopulargdvItensCompra();
        }
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
        //---------------------------------------------------------------------------------
        public int IdItemCompra {
            get {
                if (ViewState["IdItemCompra"] != null)

                    return (int)ViewState["IdItemCompra"];
                return 0;
            }
            set {
                ViewState["IdItemCompra"] = value;
            }

        }
        //---------------------------------------------------------------------------------
        #endregion

        #region Metodos
        public void LimparCampos() {
            txtQuantidade.Text = string.Empty;
            ddlProduto.SelectedIndex = -1;
            ddlProduto.Focus();
            ddlCliente.SelectedIndex = -1;
            lblValor.Text = "";
        }
        #endregion
        //=================================================================================
    }
}

