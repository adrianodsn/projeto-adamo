<%@ Page Title="" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="estados.aspx.cs" Inherits="WebApplication.PgEstados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h1>Estados</h1>
        </div>
        <div class="col-md-6 text-right">
            <a href="estado.aspx" class="btn btn-success">Novo</a>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">Filtro</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label>Nome Estado</label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" TextMode="Search"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnFilter_" runat="server" CssClass="btn btn-primary" OnClick="btnFilter_Click" Text="Filtrar"></asp:Button>
            <asp:Button ID="btnLimpar" runat="server" CssClass="btn btn-default" OnClick="btnLimpar_Click" Text="Limpar"></asp:Button>
        </div>
    </div>

    <asp:GridView ID="grvEstados" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table" DataKeyNames="Id" OnRowDeleting="grvEstados_RowDeleting">
        <Columns>

            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <%# Eval("Id") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <%# string.Format("{0} ({1})", Eval("Nome"), Eval("Sigla")) %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <a href="<%# Eval("Id", "estado.aspx?id={0}") %>" class="btn btn-primary">Editar</a>
                    <asp:LinkButton ID="btnDelete" runat="server" class="btn btn-danger" CommandName="Delete">Excluir</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle CssClass="text-right" />
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
