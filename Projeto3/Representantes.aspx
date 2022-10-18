<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Representantes.aspx.cs" Inherits="Projeto3.Representantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row margin-top-60">
        <div class="col-6">
            <div class="box border margin-right-20">
                <h2>Cadastro de Representante</h2>
                <br />
                 <!--Esse label serve para exibir uma mensagem de erro ao usuario caso esqueça de digitar algo-->
                <asp:Label ID="Mensagem" Forecolor="red" Font-Size="16px" runat="server"></asp:Label>
                <br />
                <asp:Label ID="RepresentanteId" Font-Bold="true" Font-Size="20px" runat="server"></asp:Label>
                <label>Nome</label>
                <asp:TextBox ID="Nome" MazLenght="255" runat="server"></asp:TextBox>

                <label>E-mail</label>
                <asp:TextBox ID="Email" MazLenght="255" runat="server"></asp:TextBox>

                <label>Nome de Acesso</label>
                <asp:TextBox ID="NomeAcesso" MazLenght="255" runat="server"></asp:TextBox>

                <label>Senha</label>
                <asp:TextBox ID="Senha" MazLenght="255" runat="server"></asp:TextBox>

                <asp:Button ID="Salvar" OnClick="Salvar_Click" CssClass="botao-inserir" runat="server" Text="Inserir" />
                <asp:Button ID="Excluir" onClick="Excluir_Click" CssClass="botao-Excluir" Visible="false" runat="server" Text="Excluir" />

            </div>
        </div>

        <div class="col-6">
            <div class="box border">
                 <!--caixa pronta de exibição de dados-->
                <asp:GridView ID="ExibirRepresentantes" OnSelectedIndexChanged="ExibirRepresentantes_SelectedIndexChanged" AutoGenerateColumns="true" AutoGenerateSelectButton="true" CellPadding="8" Width="100%" BorderColor="#c0c0c0" runat="server"></asp:GridView>
         
            </div>
        </div>
    </div>
</asp:Content>
