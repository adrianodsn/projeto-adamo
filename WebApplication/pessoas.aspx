<%@ Page Title="" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="pessoas.aspx.cs" Inherits="WebApplication.PgPessoas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h1>Pessoas</h1>
        </div>
        <div class="col-md-6 text-right">
            <a id="botao" href="pessoa.aspx" class="btn btn-success">Novo</a>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">Filtro</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <label>Nome</label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control nome" TextMode="Search"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label>CPF</label>
                        <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control cpf" MaxLength="14"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label>Data Inicial</label>
                        <asp:TextBox ID="txtDataNascIni" runat="server" CssClass="form-control" MaxLength="10" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="form-group">
                        <label>Data Final</label>
                        <asp:TextBox ID="txtDataNascFim" runat="server" CssClass="form-control" MaxLength="10" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnFilter_" runat="server" CssClass="btn btn-primary" OnClick="btnFilter_Click" Text="Filtrar"></asp:Button>
            <asp:Button ID="btnLimpar" runat="server" CssClass="btn btn-default" OnClick="btnLimpar_Click" Text="Limpar"></asp:Button>
        </div>
    </div>

    <asp:GridView ID="grvPessoas" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table" DataKeyNames="Id" OnRowDeleting="grvPessoas_RowDeleting">
        <Columns>

            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <%# Eval("Id") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nome">
                <ItemTemplate>
                    <%# Eval("Nome") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="CPF">
                <ItemTemplate>
                    <%# Eval("cpf") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Data Nascimento">
                <ItemTemplate>
                    <%# Eval("DataNascimento", "{0:dd/MM/yyyy}") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <a href="<%# Eval("Id", "pessoa.aspx?id={0}") %>" class="btn btn-primary">Editar</a>
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
        $('.cpf').mask('000.000.000-00');

        $('.nome').keyup(function () {
            var q = $(this).val();
            $('#botao').html(q.length);
            console.log(q);
        });
    </script>
</asp:Content>
