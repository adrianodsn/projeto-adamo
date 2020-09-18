<%@ Page Title="" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="compras.aspx.cs" Inherits="WebApplication.PgCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">

    <div class="row">
        <div class="col-md-6">
            <h1>Compras</h1>
        </div>
        <div class="col-md-6 text-right">
            <a href="compra.aspx" class="btn btn-success">Novo</a>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">Filtro</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Fornecedor</label>
                        <asp:DropDownList ID="ddlFornecedorId" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="form-group">
                        <label>Data Inicial</label>
                        <asp:TextBox ID="txtDataIni" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="form-group">
                        <label>Data Final</label>
                        <asp:TextBox ID="txtDataFim" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnFilter_" runat="server" CssClass="btn btn-primary" OnClick="btnFilter_Click" Text="Filtrar"></asp:Button>
            <asp:Button ID="btnLimpar_" runat="server" CssClass="btn btn-default" OnClick="btnLimpar_Click" Text="Limpar"></asp:Button>
        </div>
    </div>

    <asp:GridView ID="grvCompras" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table" DataKeyNames="Id" OnRowDeleting="grvCompras_RowDeleting">
        <Columns>

            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <%# Eval("Id") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Fornecedor">
                <ItemTemplate>
                    <%# Eval("Fornecedor.Nome") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Data Venda">
                <ItemTemplate>
                    <%# Eval("Data", "{0:dd/MM/yyyy}") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <a href="<%# Eval("Id", "compra.aspx?id={0}") %>" class="btn btn-primary">Itens</a>
                    <asp:LinkButton ID="btnDelete" runat="server" class="btn btn-danger" CommandName="Delete" OnClientClick="return confirm('Excluir registro?');">Excluir</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle CssClass="text-right" />
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
