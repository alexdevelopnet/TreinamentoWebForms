using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TreinamentoAlex.BL;
using TreinamentoAlex.Model;

namespace TreinamentoAlex.Web {
    public partial class CadFabricante : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                PopularGdvFabricante();
            }
        }

        protected void gdvCadfabricante_RowCommand(object sender, GridViewCommandEventArgs e) {

        }

        public void PopularGdvFabricante() {
            BLFabricante blFabricante = new BLFabricante();


            gdvCadfabricante.DataSource = blFabricante.Listar();
            gdvCadfabricante.DataBind();
        }
        protected void btnSalvar_Click(object sender, EventArgs e) {
            BLFabricante blFabricante = new BLFabricante();
            Fabricante fabricante = new Fabricante();
            
            fabricante.Nome = txtNome.Text;
            fabricante.Cnpj = txtCNPJ.Text;

            blFabricante.Inserir(fabricante);
            PopularGdvFabricante();
        }
    }
}