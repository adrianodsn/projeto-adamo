<%@ Page Title="" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="estado.aspx.cs" Inherits="WebApplication.PgEstado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>
        <asp:Literal ID="litAcao" runat="server"></asp:Literal>
    </h1>

    <div class="row">
        <div class="col-md-8">
            <div class="form-group">
                <label>Nome do estado</label>
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label>Sigla</label>
                <asp:TextBox ID="txtSigla" runat="server" CssClass="form-control" MaxLength="2"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="form-group">
        <asp:LinkButton ID="btnAdicionarCidade" runat="server" CssClass="btn btn-success" OnClick="btnAdicionarCidade_Click" CausesValidation="false">Adicionar Cidade</asp:LinkButton>
    </div>

    <asp:UpdatePanel ID="uppCidades" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           
            <asp:ListView ID="ltvCidades" runat="server" DataKeyNames="Id,Excluir" OnItemDataBound="ltvCidades_ItemDataBound" OnItemDeleting="ltvCidades_ItemDeleting">
                <ItemTemplate>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-6">
                                    Cidade
                                </div>
                                <div class="col-md-6 text-right">
                                    <asp:LinkButton ID="btnDelete" runat="server" class="btn btn-danger btn-xs" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm('Excluir registro?');">Excluir</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">

                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>
                                    Nome cidade
                                <asp:RequiredFieldValidator ID="rfvNomeCidade" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtNomeCidade" CssClass="label label-danger" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtNomeCidade" runat="server" CssClass="form-control" Text='<%# Eval("Nome") %>'></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>
                                    Código Tom
                                <asp:RequiredFieldValidator ID="rfvCodigoTom" runat="server" ErrorMessage="obrigatório" ControlToValidate="txtCodigoTom" CssClass="label label-danger" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtCodigoTom" runat="server" CssClass="form-control" Text='<%# Eval("CodigoTom") %>'></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdicionarCidade" />
        </Triggers>

    </asp:UpdatePanel>

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
