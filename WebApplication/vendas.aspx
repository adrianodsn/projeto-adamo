<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vendas.aspx.cs" Inherits="WebApplication.PgVendas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous">
</head>
<body>

    <div class="container">

        <h1>Vendas</h1>

        <div class="form-group">
            <a href="venda.aspx" class="btn btn-success btn-lg">Novo</a>
        </div>

        <form runat="server" id="form">
            <div class="panel panel-default">
                <div class="panel-heading">Filtro</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control" placeholder="Cliente" TextMode="Search"></asp:TextBox>
                        </div>

                        <div class="col-md-4">
                            <asp:TextBox ID="txtDataIni" runat="server" CssClass="form-control"  placeholder="Data Inicial" MaxLength="10" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="col-md-4">
                            <asp:TextBox ID="txtDataFim" runat="server" CssClass="form-control"  placeholder="Data Final" MaxLength="10" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="col-md-4">
                            <asp:LinkButton ID="btnFilter" runat="server" CssClass="btn btn-primary" OnClick="btnFilter_Click">Filtrar</asp:LinkButton>
                        </div>

                    </div>
                </div>

                <asp:GridView ID="grvVendas" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table" DataKeyNames="Id" OnRowDeleting="grvVendas_RowDeleting">
                    <Columns>

                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <%# Eval("Id") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cliente">
                            <ItemTemplate>
                                <%# Eval("Cliente") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Data Venda">
                            <ItemTemplate>
                                <%# Eval("Data", "{0:dd/MM/yyyy}") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="<%# Eval("Id", "venda.aspx?id={0}") %>" class="btn btn-primary">Itens</a>
                                <asp:LinkButton ID="btnDelete" runat="server" class="btn btn-danger" CommandName="Delete">Excluir</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle CssClass="text-right" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
        </form>

    </div>

</body>
</html>
