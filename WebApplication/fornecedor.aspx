<%@ Page Title="" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="fornecedor.aspx.cs" Inherits="WebApplication.PgFornecedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>
        <asp:Literal ID="litAcao" runat="server"></asp:Literal>
    </h1>

    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label>
                    CNPJ
                    <asp:RequiredFieldValidator ID="rfvCnpj" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtCnpj" CssClass="label label-danger" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="txtCnpj" runat="server" CssClass="form-control cnpj"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-8">
            <div class="form-group">
                <label>
                    Nome Fornecedor
                    <asp:RequiredFieldValidator ID="rfvNome" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtNome" CssClass="label label-danger" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
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
        $('.cnpj').mask('00.000.000/0000-00');
    </script>
</asp:Content>
