<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="produtos.aspx.cs" Inherits="WebApplication.PgProdutos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous">
</head>
<body>

    <div class="container">

        <h1>Produtos</h1>

        <div class="form-group">
            <a href="produto.aspx" class="btn btn-success btn-lg">Novo</a>
        </div>

        <form runat="server" id="form">
            <div class="panel panel-default">
                <div class="panel-heading">Filtro</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" placeholder="Descrição" TextMode="Search"></asp:TextBox>
                        </div>

                        <div class="col-md-4">
                            <asp:LinkButton ID="btnFilter" runat="server" CssClass="btn btn-primary" OnClick="btnFilter_Click">Filtrar</asp:LinkButton>
                        </div>

                    </div>
                </div>

                <asp:GridView ID="grvProdutos" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table" DataKeyNames="Id">
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
                            </ItemTemplate>
                            <ItemStyle CssClass="text-right" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
        </form>

    </div>

</body>
</html>
