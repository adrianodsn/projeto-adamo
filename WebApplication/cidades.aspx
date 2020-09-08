<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cidades.aspx.cs" Inherits="WebApplication.PgCidades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous">
</head>
<body>

    <div class="container">

        <h1>Cidades</h1>

        <div class="form-group">
            <a href="cidade.aspx" class="btn btn-success btn-lg">Nova</a>
        </div>

        <form runat="server" id="form">
            <div class="panel panel-default">
                <div class="panel-heading">Filtro</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:TextBox ID="txtQ" runat="server" CssClass="form-control" placeholder="Palavra-chave" TextMode="Search"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlEstadoId" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <asp:LinkButton ID="btnFilter" runat="server" CssClass="btn btn-primary" OnClick="btnFilter_Click">Filtrar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>

            <asp:GridView ID="grvCidades" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table" DataKeyNames="Id" OnRowDeleting="grvCidades_RowDeleting">
                <Columns>

                    <asp:TemplateField HeaderText="#">
                        <ItemTemplate>
                            <%# Eval("Id") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cidade">
                        <ItemTemplate>
                            <%# string.Format("{0} - {1}", Eval("Nome"), Eval("Estado.Sigla")) %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="<%# Eval("Id", "cidade.aspx?id={0}") %>" class="btn btn-primary">Editar</a>
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
