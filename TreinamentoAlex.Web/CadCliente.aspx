<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadCliente.aspx.cs" Inherits="TreinamentoAlex.Web.CadCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Clientes</title>
    <link href="css/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <form id="frmCadClientes" runat="server">
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

                        </ul>

                    </div>
                    <!--/.nav-collapse -->
                </div>
                <!--/.container-fluid -->
            </div>

            <!-- Main component for a primary marketing message or call to action -->
            <div class="jumbotron">
                <h1>Cadastro de Cliente</h1>
                <section>
                    <article id="Cadastro">
                        <asp:Panel ID="PanelCadCliente" runat="server" CssClass="font-size: small">
                            <input type="hidden" name="_VIEWSTATE" id="_VIEWSTATE" value="" />
                            <p style="font-size: small">
                                Nome:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                                &nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Irforme O Nome" ControlToValidate="txtNome" ValidationGroup="Salvar" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </p>
                            <p style="font-size: small">
                                Sobre Nome:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                         <asp:TextBox ID="txtSobreNome" runat="server"></asp:TextBox>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Irforme O Sobre Nome" ControlToValidate="txtSobreNome" ValidationGroup="Salvar" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </p>
                            <p style="font-size: small">
                                   Data de Nascimento:&nbsp;
                                    <asp:TextBox ID="txtDataNasc" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDataNasc" ErrorMessage="Irforme A Data de Nascimento" SetFocusOnError="true" ValidationGroup="Salvar"></asp:RequiredFieldValidator>
                            </p>
                            <p style="font-size: small">
                                Pontuação:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            
                                <asp:TextBox ID="txtPontuacao" runat="server"></asp:TextBox>
                            </p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPontuacao" ErrorMessage="Irforme a pontuação" SetFocusOnError="true" ValidationGroup="Salvar" CssClass="font-size: small"></asp:RequiredFieldValidator>

                            <p>
                                <asp:DropDownList ID="ddlTipoCliente" runat="server" DataTextField="Descricao" DataValueField="IdTipo" Height="39px" Width="272px" CssClass="font-size: small" OnSelectedIndexChanged="ddlTipoCliente_SelectedIndexChanged">
                                </asp:DropDownList>
                            </p>
                            <asp:Button ID="btnSalvar" CssClass="btn btn-primary" runat="server" OnClick="btnSalvar_Click" Text="Salvar" ValidationGroup="Salvar" Width="174px" />
                            &nbsp;<asp:Button ID="btnCancelar" CssClass="btn btn-primary" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" Visible="False" />
                        </asp:Panel>
                    </article>

                    <article>
                        <asp:GridView ID="gdvClientes" runat="server" AutoGenerateColumns="False" Height="105px" Width="1136px" OnRowCommand="gdvClientes_RowCommand1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Font-Size="Small">
                            <Columns>
                                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                                <asp:BoundField DataField="SobreNome" HeaderText="Sobre Nome" />
                                <asp:BoundField DataField="DataNascimento" HeaderText="Data de Nascimento" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="Pontuacao" HeaderText="Pontuação" />
                                <asp:BoundField DataField="DescricaoTipo" HeaderText="Descrição" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Editar" CommandArgument='<% #Eval("Id")%>'>Editar</asp:LinkButton>
                                        &nbsp;
                                         <asp:LinkButton ID="lnkExcluir" runat="server" CommandName="Excluir" OnClientClick="return confirm('Deseja Realmente Escluir o Cliente')"
                                             CommandArgument='<% #Eval("Id")%>'>Excluír</asp:LinkButton>
                                        &nbsp;
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
