<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadFabricante.aspx.cs" Inherits="TreinamentoAlex.Web.CadFabricante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Fabricante</title>
    <link href="css/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <form id="CadFabricante" runat="server">
        <div class="container">

            <!-- Static navbar -->
            <div class="navbar navbar-default" role="navigation">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#">Treinamento Alex</a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li class="active"><a href="Index.aspx">Home</a></li>
                            <li><a href="CadCompras.aspx">Cadastro de Compra</a></li>
                            <li><a href="CadProduto.aspx">Cadastro de Produto</a></li>
                            <li><a href="CadCliente.aspx">Cadostro de Cliente</a></li>

                        </ul>

                    </div>
                    <!--/.nav-collapse -->
                </div>
                <!--/.container-fluid -->
            </div>

            <!-- Main component for a primary marketing message or call to action -->
            <div class="jumbotron">
                <h1>Cadastro de Fabricante</h1>

                <section>
                    <article>
                        <p style="font-size: small">Nome Fabricante: <asp:TextBox ID="txtNome" runat="server" Width="349px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome" ErrorMessage="Preencha o Nome Do Fabricante" ValidationGroup="Salvar"></asp:RequiredFieldValidator>
                        </p>
                        <p style="font-size: small">CNPJ:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtCNPJ" runat="server" Width="300px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCNPJ" ErrorMessage="Preencha o CNPJ" ValidationGroup="Salvar"></asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Button ID="btnSalvar" CssClass="btn btn-primary" runat="server" Text="Salvar" OnClick="btnSalvar_Click" Width="223px" ValidationGroup="Salvar" /></p>
                    </article>

                    <article>
                        <asp:GridView ID="gdvCadfabricante" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowCommand="gdvCadfabricante_RowCommand" Width="761px" Font-Size="Small">
                            <Columns>
                                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                                <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkExcluir" runat="server">Excluir</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </article>
                </section>


            </div>

        </div>
        <!-- /container -->
    </form>
</body>
</html>
