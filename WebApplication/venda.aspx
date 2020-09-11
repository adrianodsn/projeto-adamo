<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="venda.aspx.cs" Inherits="WebApplication.PgVenda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous">
</head>
<body>

    <div class="container">

        <h1>
            <asp:Literal ID="litAcao" runat="server"></asp:Literal></h1>

        <form runat="server" id="form">

            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label>
                            Data Venda
                            <asp:RequiredFieldValidator ID="rfvDataVenda" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtDataVenda" CssClass="label label-danger" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </label>
                        <asp:TextBox ID="txtDataVenda" runat="server" CssClass="form-control" MaxLength="10" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-8">
                    <div class="form-group">
                        <label>
                            Nome Cliente
                            <asp:RequiredFieldValidator ID="rfvNomeCliente" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtNomeCliente" CssClass="label label-danger" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </label>
                        <asp:TextBox ID="txtNomeCliente" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                </div>

            </div>

            <div class="panel panel-primary">
                <div class="panel-heading">Itens</div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:LinkButton ID="btnAdicionarItem" runat="server" CssClass="btn btn-success" OnClick="btnAdicionarItem_Click" CausesValidation="false">Adicionar item</asp:LinkButton>
                    </div>

                    <asp:GridView ID="grvItensVenda" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table" DataKeyNames="Id,Excluir" ShowHeader="false" OnRowDeleting="grvItensVenda_RowDeleting" OnRowDataBound="grvItensVenda_RowDataBound">
                        <Columns>

                            <asp:TemplateField HeaderText="Produto">
                                <ItemTemplate>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Produto
                                            <asp:RequiredFieldValidator ID="rfvProduto" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtProduto" CssClass="label label-danger" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:TextBox ID="txtProduto" runat="server" CssClass="form-control" Text='<%# Eval("Produto") %>'></asp:TextBox>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Quantidade">
                                <ItemTemplate>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Quantidade
                                            <asp:RequiredFieldValidator ID="rfvQuantidade" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtQuantidade" CssClass="label label-danger" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:TextBox ID="txtQuantidade" runat="server" CssClass="form-control" Text='<%# Eval("Qtd") %>' qtd></asp:TextBox>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Valor">
                                <ItemTemplate>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Valor
                                            <asp:RequiredFieldValidator ID="rfvValor" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtValor" CssClass="label label-danger" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:TextBox ID="txtValor" runat="server" CssClass="form-control money" Text='<%# Eval("ValorUnit", "{0:N2}") %>' valorunit></asp:TextBox>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    Total: <span class="total"><%# Eval("Total") %></span>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" class="btn btn-danger" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm('Excluir registro?');">Excluir</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle CssClass="text-right" />
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <asp:ListView runat="server" ID="ltvNotifications">
                <ItemTemplate>
                    <li>
                        <%# Eval("Message") %>
                    </li>
                </ItemTemplate>
                <LayoutTemplate>
                    <div class="alert alert-danger">
                        <ul>
                            <li runat="server" id="itemPlaceHolder" />
                        </ul>
                    </div>
                </LayoutTemplate>
            </asp:ListView>

            <asp:Button ID="btnSubmit" runat="server" Text="Gravar" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />

        </form>

    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <script src="assets/js/jquery.mask.min.js"></script>
    <script>
        $('.money').mask('000.000.000.000.000,00', { reverse: true });

        $('[qtd],[valorunit]').keyup(function () {
            var tr = $(this).closest('tr');
            var qtd = $('[qtd]', tr);
            var valorunit = $('[valorunit]', tr);
            var spanTotal = $('span.total', tr);

            if (qtd.val() != '' && valorunit.val() != '') {
                spanTotal.text((valorunit.val().replace('.', '').replace(',', '.') * qtd.val()).toFixed(2));
            } else {
                spanTotal.text('');
            }
        });
    </script>

</body>
</html>
