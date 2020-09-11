<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pessoas.aspx.cs" Inherits="WebApplication.PgPessoas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous">
</head>
<body>

    <div class="container">

        <h1>Pessoas</h1>

        <div class="form-group">
            <a href="pessoa.aspx" class="btn btn-success btn-lg">Novo</a>
        </div>

        <form runat="server" id="form">
            <div class="panel panel-default">
                <div class="panel-heading">Filtro</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" placeholder="Palavra-chave" TextMode="Search"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control  cpf" placeholder="CPF" MaxLength="14"></asp:TextBox>
                        </div>

                        <div class="col-md-4">
                            <asp:TextBox ID="txtDataNascIni" runat="server" CssClass="form-control"  placeholder="Data Inicial" MaxLength="10" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="col-md-4">
                            <asp:TextBox ID="txtDataNascFim" runat="server" CssClass="form-control"  placeholder="Data Final" MaxLength="10" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="col-md-4">
                            <asp:LinkButton ID="btnFilter" runat="server" CssClass="btn btn-primary" OnClick="btnFilter_Click">Filtrar</asp:LinkButton>
                        </div>

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
        </form>

    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <script src="assets/js/jquery.mask.min.js"></script>
    <script>
        $('.cpf').mask('000.000.000-00');
    </script>

</body>
</html>
