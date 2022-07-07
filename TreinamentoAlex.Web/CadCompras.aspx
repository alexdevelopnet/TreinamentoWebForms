<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadCompras.aspx.cs" Inherits="TreinamentoAlex.Web.CadCompras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DTSys</title>

    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/Compras.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>

</head>
<body>
    <form id="frmCadCompras" runat="server">
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
                <h1>Cadastro de Compras</h1>


                <p style="font-size: small">
                    Cliente:
                        <asp:DropDownList ID="ddlCliente" runat="server" Height="26px" Width="231px" DataTextField="Nome" DataValueField="Id">
                        </asp:DropDownList>

                    &nbsp;<asp:Button ID="btProceder" CssClass="btn btn-primary" runat="server" Text="Proceder" Width="108px" OnClick="btProceder_Click" />

                </p>
                <section>
                        <article id="PainelCompra">
                            <asp:Panel ID="painelCliente" runat="server" BorderStyle="Solid"
                                GroupingText="Produto" Height="297px" ScrollBars="Auto" Width="839px" CssClass="font-size: small" Font-Size="Small"
                               Style="position: absolute; visibility: hidden; top: 132px; left: 0px;" BorderWidth="4px" HorizontalAlign="Left" >
                                <p>
                                    Produto:
                                    <asp:DropDownList ID="ddlProduto" runat="server" AutoPostBack="True" DataTextField="Descricao" DataValueField="Id" Height="18px" OnSelectedIndexChanged="ddlProduto_SelectedIndexChanged" Width="187px">
                                    </asp:DropDownList>
                                    &nbsp;Quantidade:&nbsp;
                                <asp:TextBox ID="txtQuantidade" CssClass="control-label" runat="server"></asp:TextBox>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQuantidade" ErrorMessage="Irforme a Quantidade" SetFocusOnError="true" ValidationGroup="Incluir"></asp:RequiredFieldValidator>
                                    &nbsp;

                                    <asp:Button ID="btnIncluirCompra" CssClass="btn btn-primary" runat="server" Text="Incluir Compra" OnClick="btnIncluirCompra_Click" ValidationGroup="Incluir" Height="38px" Width="166px" />

                                </p>

                                <p>
                                    Valor Unitário:
                                <asp:Label ID="lblValor" runat="server"></asp:Label>
                                    &nbsp;
                                </p>

                                <p>
                                    Data da Compra:&nbsp;
                                                   <asp:Label ID="lblData" runat="server"></asp:Label>
                                    &nbsp;
                                    <asp:Button ID="btCancelar" runat="server" Text="Cancelar" Width="106px" OnClick="btCancelar_Click" />

                                </p>
                            </asp:Panel>
                        </article>

                         <asp:Panel ID="painelCarrinhoDeCompra" runat="server">

                    <h2 class="auto-style1">
                        <asp:Image ID="imgCarrinho" runat="server" ImageUrl="~/img/carrinho_compras.jpg" Height="99px" Width="136px" />
                        <asp:Label ID="lblCliente" runat="server"></asp:Label></h2>


                    <asp:GridView ID="gdvIntensCompra" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvIntensCompra_RowCommand" ShowFooter="True" Font-Size="Small">
                        <Columns>
                            <asp:BoundField DataField="Descricao" HeaderText="Produto" />
                            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />
                            <asp:BoundField DataField="Valor" HeaderText="Valor Unitário" DataFormatString="{0:C2}" />
                            <asp:BoundField DataField="ValorTotalProduto" HeaderText="Pagar" DataFormatString="{0:C2}" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkExcluir" runat="server" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" CommandName="Excluir"
                                        Font-Bold="True" Height="25px" Width="90px" CssClass="btn btn-default"
                                        OnClientClick="return confirm('Deseja Realmente Excluir o Cliente')" CommandArgument='<% #Eval("Id")%>'>Excluir</asp:LinkButton>
                                    &nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />

                    Valor Total da Compra:
                        <asp:Label ID="lblTotal" runat="server" BorderStyle="Inset" Width="163px"></asp:Label>

                </asp:Panel>
                </section>
            </div>

        </div>
        <!-- /container -->





    </form>
</body>
</html>
