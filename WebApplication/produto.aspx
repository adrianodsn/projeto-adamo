<%@ Page Title="" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="produto.aspx.cs" Inherits="WebApplication.PgProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>
        <asp:Literal ID="litAcao" runat="server"></asp:Literal>
    </h1>

    <div class="row">
        <div class="col-md-8">
            <div class="form-group">
                <label>
                    Descrição Produto
                            <asp:RequiredFieldValidator ID="rfvDescricao" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtDescricao" CssClass="label label-danger" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label>
                    Valor Unitário
                            <asp:RequiredFieldValidator ID="rfvVlrUnitario" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtValorUnit" CssClass="label label-danger" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="txtValorUnit" runat="server" CssClass="form-control money"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label>Qtd. Estoque</label>
                <asp:TextBox ID="txtQtdEstoque" runat="server" CssClass="form-control" Enabled="false" TextMode="Number"></asp:TextBox>
            </div>
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
    </script>
</asp:Content>
