<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cidade.aspx.cs" Inherits="WebApplication.PgCidade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous">
</head>
<body>

    <div class="container">

        <h1>
            <asp:Literal ID="litAcao" runat="server"></asp:Literal>
        </h1>

        <form runat="server" id="form">


            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Nome do estado</label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Estado</label>
                        <asp:DropDownList ID="ddlEstadoId" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <asp:ListView runat="server" ID="ltvNotifications">
                <ItemTemplate>
                    <li>
                        <%# Eval("Message") %>
                    </li>
                </ItemTemplate>
                <LayoutTemplate>
                    <div class="alert alert-danger">
                        <ul>
                            <li runat="server" id="itemPlaceHolder" />
                        </ul>
                    </div>
                </LayoutTemplate>
            </asp:ListView>

            <asp:Button ID="btnSubmit" runat="server" Text="Gravar" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />

        </form>

    </div>

</body>
</html>
