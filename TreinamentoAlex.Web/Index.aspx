<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TreinamentoAlex.Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    </head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <!-- Static navbar -->
            <div class="navbar navbar-default" role="navigation">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
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
                           
                                
                            </li>
                        </ul>

                    </div>
                    <!--/.nav-collapse -->
                </div>
                <!--/.container-fluid -->
            </div>

            <!-- Main component for a primary marketing message or call to action -->
            <div class="jumbotron">
                <h1>Treinamento Alex DTSys</h1>

                &nbsp;&nbsp;&nbsp;
                
                <asp:Button ID="btnCadCliente" CssClass="btn btn-primary" runat="server" Height="120px" Text="Clientes" Width="120px" OnClick="btnCadCliente_Click" />
                &nbsp;<asp:Button ID="btnCadFabricante" CssClass="btn btn-primary" runat="server" Height="120px" Text="Fabricante" Width="120px" OnClick="btnCadFabricante_Click" />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnCadProduto" CssClass="btn btn-primary" runat="server" Height="120px" Text="Produto" Width="120px" OnClick="btnCadProduto_Click" />
                &nbsp;<asp:Button ID="btnCadCompra" CssClass="btn btn-primary" runat="server" Text="Compra" Height="120px" ViewStateMode="Disabled" Width="120px" OnClick="btnCadCompra_Click" />
                &nbsp;<asp:Button ID="btnCadEstoque" CssClass="btn btn-primary" runat="server" Text="Estoque" Height="120px" Width="123px" OnClick="btnCadEstoque_Click" />

                &nbsp;
                <br />
                &nbsp;
                 
               
            </div>

        </div>
        <!-- /container -->
    </form>
</body>
</html>
