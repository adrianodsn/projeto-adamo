<%@ Page Title="" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="produtos.aspx.cs" Inherits="WebApplication.PgProdutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h1>Produtos</h1>
        </div>
        <div class="col-md-6 text-right">
            <a href="produto.aspx" class="btn btn-success">Novo</a>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">Filtro</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                         <label>Descrição</label>
                        <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" TextMode="Search"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnFilter" runat="server" CssClass="btn btn-primary" OnClick="btnFilter_Click" Text="Filtrar"></asp:Button>
            <asp:Button ID="btnLimpar" runat="server" CssClass="btn btn-default" OnClick="btnLimpar_Click" Text="Limpar"></asp:Button>
        </div>
    </div>

    <asp:GridView ID="grvProdutos" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table" DataKeyNames="Id" OnRowDeleting="grvProdutos_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <%# Eval("Id") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Descrição">
                <ItemTemplate>
                    <%# Eval("Descricao") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Valor Unitário">
                <ItemTemplate>
                    <%# Eval("ValorUnitario") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qtd. Estoque">
                <ItemTemplate>
                    <%# Eval("QtdEstoque") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <a href="<%# Eval("Id", "produto.aspx?id={0}") %>" class="btn btn-primary">Editar</a>
                    <asp:LinkButton ID="btnDelete" runat="server" class="btn btn-danger" CommandName="Delete">Excluir</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle CssClass="text-right" />
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
