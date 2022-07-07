using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TreinamentoAlex.Web {
    public partial class Index : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnCadCliente_Click(object sender, EventArgs e) {
            Response.Redirect("CadCliente.aspx");
        }

        protected void btnCadFabricante_Click(object sender, EventArgs e) {
            Response.Redirect("CadFabricante.aspx");
        }

        protected void btnCadProduto_Click(object sender, EventArgs e) {
            Response.Redirect("CadProduto.aspx");
        }

        protected void btnCadCompra_Click(object sender, EventArgs e) {
            Response.Redirect("CadCompras.aspx");
        }

        protected void btnCadEstoque_Click(object sender, EventArgs e) {
            Response.Redirect("CadEstoque.aspx");
        }




    }
}