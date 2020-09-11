<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pessoa.aspx.cs" Inherits="WebApplication.PgPessoa" %>

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
                <div class="col-md-8">
                    <div class="form-group">
                        <label>
                            Nome da pessoa
                            <asp:RequiredFieldValidator ID="rfvNomePessoa" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtNome" CssClass="label label-danger" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>
                            CPF
                            <asp:RequiredFieldValidator ID="rfvCpf" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtCpf" CssClass="label label-danger" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </label>
                        <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control cpf" MaxLength="14"></asp:TextBox>
                    </div>
                </div>
              <div class="col-md-4">
                    <div class="form-group">
                        <label>
                            Data Nascimento
                            <asp:RequiredFieldValidator ID="rfvDataNasc" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtDataNasc" CssClass="label label-danger" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </label>
                       <asp:TextBox ID="txtDataNasc" runat="server" CssClass="form-control" MaxLength="10" TextMode="Date"></asp:TextBox>
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
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <script src="assets/js/jquery.mask.min.js"></script>
    <script>
        $('.cpf').mask('000.000.000-00');
    </script>

</body>
</html>
