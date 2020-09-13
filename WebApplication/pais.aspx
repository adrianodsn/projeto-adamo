<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pais.aspx.cs" Inherits="WebApplication.PgPais" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous">
</head>
<body>

    <div class="container">

        <h1>Pais</h1>

        <div class="form-group">
            <a href="pai.aspx" class="btn btn-success btn-lg">Novo</a>
        </div>

        <form runat="server" id="form">
            <div class="panel panel-default">
                <div class="panel-heading">Filtro</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:TextBox ID="txtNomePai" runat="server" CssClass="form-control" placeholder="Nome Pai" TextMode="Search"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtNomeMae" runat="server" CssClass="form-control" placeholder="Nome Mãe" TextMode="Search"></asp:TextBox>
                        </div>

                        <br />
                        <br />

                        <div class="col-md-4">
                            <asp:LinkButton ID="btnFilter" runat="server" CssClass="btn btn-primary" OnClick="btnFilter_Click">Filtrar</asp:LinkButton>
                            
                            <asp:LinkButton ID="btnLimpar" runat="server" CssClass="btn btn-primary" OnClick="btnLimpar_Click">Limpar</asp:LinkButton>
                        </div>

                    </div>
                </div>

                <asp:GridView ID="grvPais" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table" DataKeyNames="Id" OnRowDeleting="grvPais_RowDeleting">
                    <Columns>

                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <%# Eval("Id") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nome Pai">
                            <ItemTemplate>
                                <%# Eval("NomePai") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                       <asp:TemplateField HeaderText="Nome Mãe">
                            <ItemTemplate>
                                <%# Eval("NomeMae") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="<%# Eval("Id", "pai.aspx?id={0}") %>" class="btn btn-primary">Itens</a>
                                <asp:LinkButton ID="btnDelete" runat="server" class="btn btn-danger" CommandName="Delete"  OnClientClick="return confirm('Excluir registro?');">Excluir</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle CssClass="text-right" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
        </form>

    </div>

</body>
</html>
