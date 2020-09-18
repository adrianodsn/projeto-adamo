<%@ Page Title="" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="compra.aspx.cs" Inherits="WebApplication.PgCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>
        <asp:Literal ID="litAcao" runat="server"></asp:Literal></h1>

    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label>
                    Data Compra
                    <asp:RequiredFieldValidator ID="rfvDataCompra" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtDataCompra" CssClass="label label-danger" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="txtDataCompra" runat="server" CssClass="form-control" MaxLength="10" TextMode="Date"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-9">
            <div class="form-group">
                <label>
                    Fornecedor
                    <asp:RequiredFieldValidator ID="rfvFornecedor" runat="server" ErrorMessage="obrigatório" ControlToValidate="ddlFornecedorId" CssClass="label label-danger" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </label>
                <asp:DropDownList ID="ddlFornecedorId" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

    </div>

    <div class="panel panel-primary">
        <div class="panel-heading">Itens</div>
        <div class="panel-body">

            <div class="form-inline form-group">
                <div class="form-group">
                    <label>Produto</label>
                    <asp:DropDownList ID="ddlProdutoIdParent" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Quantidade</label>
                    <asp:TextBox ID="txtQtd" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:LinkButton ID="btnAdicionarItem" runat="server" CssClass="btn btn-success" OnClick="btnAdicionarItem_Click" CausesValidation="false">Adicionar item</asp:LinkButton>
                </div>
            </div>

            <asp:UpdatePanel ID="uppItens" runat="server" UpdateMode="Conditional">

                <ContentTemplate>

                    <asp:GridView ID="grvItensCompra" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table" DataKeyNames="Id,Excluir" ShowHeader="false" OnRowDeleting="grvItensCompra_RowDeleting" OnRowDataBound="grvItensCompra_RowDataBound">
                        <Columns>

                            <asp:TemplateField HeaderText="Produto">
                                <ItemTemplate>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Produto
                                            <asp:RequiredFieldValidator ID="rfvProduto" runat="server" ErrorMessage="obrigatório" ControlToValidate="ddlProdutoId" CssClass="label label-danger" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:DropDownList ID="ddlProdutoId" runat="server" CssClass="form-control"></asp:DropDownList>
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
                                        <asp:TextBox ID="txtQuantidade" runat="server" CssClass="form-control" TextMode="Number" Text='<%# Eval("Qtd") %>' qtd></asp:TextBox>
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
                                        <asp:TextBox ID="txtValor" runat="server" CssClass="form-control money" Text='<%# Eval("ValorUnitario", "{0:N2}") %>' valorunit></asp:TextBox>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    Total: <span class="total"><%# Eval("Total", "{0:C}") %></span>
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

                </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdicionarItem" />
                </Triggers>

            </asp:UpdatePanel>
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

    <div class="form-group text-right">
        <asp:Button ID="btnSubmit" runat="server" Text="Gravar" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
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
</asp:Content>
