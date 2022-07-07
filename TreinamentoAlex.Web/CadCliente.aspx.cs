using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;
using TreinamentoAlex.BL;
using TreinamentoAlex.Model;
using System.Web.UI;


namespace TreinamentoAlex.Web {
    public partial class CadCliente : System.Web.UI.Page {
        //===========================================================================================
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                CarregarDropDownLists();
                CarregarListagem();
            }
        }
        //------------------------------------------------------------------------------------------
        protected void btnSalvar_Click(object sender, EventArgs e) {

            CultureInfo ctiBr = new CultureInfo("pt-BR");

            Cliente cliente = new Cliente();

            cliente.Nome = txtNome.Text;
            cliente.SobreNome = txtSobreNome.Text;
            cliente.DataNascimento = DateTime.Parse(txtDataNasc.Text, ctiBr);
            cliente.Pontuacao = Convert.ToInt32(txtPontuacao.Text);
            cliente.IdTipo = Convert.ToInt32(ddlTipoCliente.SelectedValue);


            if (Id == 0) {
                new BLCliente().Iserir(cliente);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "alerta", "alert('Registro Inserido com sucesso.');", true);
            }
            else {
                cliente.Id = Id;
                new BLCliente().Atualizar(cliente);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "alerta", "alert('Registro Alterado com sucesso.');", true);
            }
            CarregarListagem();

        }
        //------------------------------------------------------------------------------------------
        protected void gdvClientes_RowCommand1(object sender, GridViewCommandEventArgs e) {

            CultureInfo ctiBr = new CultureInfo("pt-BR");


            BLCliente clienteBl = new BLCliente();


            if (e.CommandName == "Editar") {
                Id = Convert.ToInt32(e.CommandArgument);
                PanelCadastroVisivel(true);
                Cliente cliente = new BLCliente().Obter(Id);

                txtNome.Text = cliente.Nome;
                txtSobreNome.Text = cliente.SobreNome;
                txtDataNasc.Text = cliente.DataNascimento.ToString("d", ctiBr);
                txtPontuacao.Text = cliente.Pontuacao.ToString();
                ddlTipoCliente.SelectedValue = cliente.IdTipo.ToString();
                btnCancelar.Visible = true;
            }

            if (e.CommandName == "Excluir") {
                Id = Convert.ToInt32(e.CommandArgument);
                clienteBl.Deletar(Id);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "alerta", "alert('Dados Excluidos com sucesso.');", true);
                Response.Redirect("CadCliente.aspx");
            }

            if (e.CommandName == "Inserir") {
                PanelCadastroVisivel(true);

                CarregarListagem();
            }

        }
        //------------------------------------------------------------------------------------------
        private void CarregarListagem() {
            BLCliente blCLiente = new BLCliente();
            gdvClientes.DataSource = blCLiente.Listar();
            gdvClientes.DataBind();


        }
        //------------------------------------------------------------------------------------------
        private void CarregarDropDownLists() {
            BLTipoCliente blTipo = new BLTipoCliente();
            List<TipoCliente> lstTipos = blTipo.Listar();


            ddlTipoCliente.DataSource = lstTipos;
            ddlTipoCliente.DataBind();

            ListItem ltiSelecione = new ListItem("<-- Selecione -->", "-1");
            ddlTipoCliente.Items.Insert(0, ltiSelecione);
        }
        //------------------------------------------------------------------------------------------
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
        //------------------------------------------------------------------------------------------
        protected void btnCancelar_Click(object sender, EventArgs e) {
            txtNome.Text = "";
            txtSobreNome.Text = "";
            txtDataNasc.Text = "";
            txtPontuacao.Text = "";
            ddlTipoCliente.ClearSelection();

        }
        //------------------------------------------------------------------------------------------
        public void PanelCadastroVisivel(bool Enabled) {

            PanelCadCliente.Attributes.Clear();

            if (Enabled == true) {
                PanelCadCliente.Attributes.Add("position", "relative");
                PanelCadCliente.Attributes.Add("visibility", "visible");
            }
            else {
                PanelCadCliente.Attributes.Add("position", "absolute");
                PanelCadCliente.Attributes.Add("visibility", "hidden");
            }

        }

       
    }
    //===========================================================================================
}



