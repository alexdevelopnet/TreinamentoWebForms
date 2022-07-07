<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadEstoque.aspx.cs" Inherits="TreinamentoAlex.Web.CadEstoque" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Controle de Estoque</title>
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
                <h1>Controle de Estoque</h1>

                <section>
                    <article id="CadEstoque" style="font-size: small">
                        Produto :&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlProduto" runat="server" Width="234px" DataTextField="Descricao" DataValueField="Id" Font-Size="Small" AutoPostBack="True" OnSelectedIndexChanged="ddlProduto_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;&nbsp; Quantidade Em Estoque:
                        <asp:Label ID="lblQuantEstoque" runat="server"></asp:Label>
                        <br />
                        Quantidade:
                        <asp:TextBox ID="txtQuantidade" runat="server" Font-Size="Small" ></asp:TextBox>

                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Irforme a Quantidade" ControlToValidate="txtQuantidade" ValidationGroup="Salvar" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>

                        <br />

                        <asp:Button ID="btnSalvar" runat="server" Height="41px" Text="Salvar" Width="174px" OnClick="btnSalvar_Click" ValidationGroup="Salvar" Font-Size="Small" />
                        &nbsp;
                        &nbsp;
                        
                        <br />
                    </article>

                    <article>
                    </article>
                </section>

            </div>

        </div>
        <!-- /container -->
    </form>
</body>
</html>
