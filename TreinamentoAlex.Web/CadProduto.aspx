<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadProduto.aspx.cs" Inherits="TreinamentoAlex.Web.CadProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Produtos</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    
</head>
<body>
    <form id="frmCadProduto" runat="server">
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
                <h1>Cadastro de Produto</h1>
                
                 <br/>
                <section>
                    <article id="CadProdutos" style="font-size: small">

                        <input type="hidden" name="_VIEWSTATE" id="_VIEWSTATE" value="" />
                        <p>
                            Descrição:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Informe a Descrição do Produto" ControlToValidate="txtDescricao"
                                ValidationGroup="Salvar" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </p>
                        <p>
                            Valor Unitário: 
                        <asp:TextBox ID="txtvalorUnitario" runat="server"  TextMode="Number" CausesValidation="True" ValidationGroup=" "></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Informe o valor do Produto" ControlToValidate="txtvalorUnitario"
                                ValidationGroup="Salvar" SetFocusOnError="true"></asp:RequiredFieldValidator>
                       
                        </p>
                        <p>  Fabricante:
                        <asp:DropDownList ID="ddlFabricante" runat="server" Height="25px" Width="297px" DataTextField="Nome" DataValueField="Id">
                        </asp:DropDownList>

                        </p>
                        <asp:Button ID="btnSalvar" CssClass="btn btn-primary" runat="server" Text="Salvar" ValidationGroup="Salvar" OnClick="btnSalvar_Click" />
                        &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Visible="False" />
                    </article>

                    <article id="gdv">
                        <asp:GridView ID="gdvCadProduto" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowCommand="gdvCadProduto_RowCommand" Font-Size="Small" Width="436px">
                            <Columns>
                                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                                <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:C2}" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkExcluir" runat="server"
                                            OnClientClick="return confirm('Deseja Realmente Excluir o Cliente')" CommandArgument='<% #Eval("Id")%>' CommandName="Excluir">Excluir</asp:LinkButton>
                                        &nbsp; &nbsp;<asp:LinkButton ID="lnkEditar" runat="server"  CommandArgument='<% #Eval("Id") %>' CommandName="Editar" > Editar</asp:LinkButton>
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
