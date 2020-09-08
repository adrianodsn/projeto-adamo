<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="estados.aspx.cs" Inherits="WebApplication.PgEstados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous">
</head>
<body>

    <div class="container">

        <h1>Estados</h1>

        <div class="form-group">
            <a href="estado.aspx" class="btn btn-success btn-lg">Novo</a>
        </div>

        <form runat="server" id="form">
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
        </form>

    </div>

</body>
</html>
