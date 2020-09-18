<%@ Page Title="" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="cidade.aspx.cs" Inherits="WebApplication.PgCidade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>
        <asp:Literal ID="litAcao" runat="server"></asp:Literal>
    </h1>

    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <label>Nome da cidade</label>
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label>Estado</label>
                <asp:DropDownList ID="ddlEstadoId" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label>Código Tom</label>
                <asp:TextBox ID="txtCodigoTom" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
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

    <div class="form-group text-right">
        <asp:Button ID="btnSubmit" runat="server" Text="Gravar" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
