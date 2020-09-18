<%@ Page Title="" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="fornecedores.aspx.cs" Inherits="WebApplication.PgFornecedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h1>Fornecedores</h1>
        </div>
        <div class="col-md-6 text-right">
            <a href="fornecedor.aspx" class="btn btn-success">Novo</a>
        </div>
    </div>


    <div class="panel panel-default">
        <div class="panel-heading">Filtro</div>
        <div class="panel-body">

            <div class="row">
                <div class="col-md-8">
                    <div class="form-group">
                        <label>Nome Fornecedor</label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" TextMode="Search"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>CNPJ</label>
                        <asp:TextBox ID="txtCnpj" runat="server" CssClass="form-control  cnpj"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnFilter_" runat="server" CssClass="btn btn-primary" OnClick="btnFilter_Click" Text="Filtrar"></asp:Button>
            <asp:Button ID="btnLimpar" runat="server" CssClass="btn btn-default" OnClick="btnLimpar_Click" Text="Limpar"></asp:Button>
        </div>
    </div>

    <asp:GridView ID="grvFornecedores" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table" DataKeyNames="Id" OnRowDeleting="grvFornecedores_RowDeleting">
        <Columns>

            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <%# Eval("Id") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="CNPJ">
                <ItemTemplate>
                    <%# Eval("Cnpj") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nome">
                <ItemTemplate>
                    <%# Eval("Nome") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <a href="<%# Eval("Id", "fornecedor.aspx?id={0}") %>" class="btn btn-primary">Editar</a>
                    <asp:LinkButton ID="btnDelete" runat="server" class="btn btn-danger" CommandName="Delete">Excluir</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle CssClass="text-right" />
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <script src="assets/js/jquery.mask.min.js"></script>
    <script>
        $('.cnpj').mask('00.000.000/0000-00');
    </script>
</asp:Content>
