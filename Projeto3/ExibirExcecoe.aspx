<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="ExibirExcecoe.aspx.cs" Inherits="Projeto3.ExibirExcecoe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin-top-60">
        <asp:Label ID="Excecoes" runat="server"></asp:Label>
        <hr />
        <div style="text-align: right">
            <asp:Button ID="Limpar" CssClass="botao-delete" OnClick="Limpar_Click" runat="server" Text="Limpar" />
        </div>
    </div>
</asp:Content>
