<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="FaleConosco.aspx.cs" Inherits="Projeto3.FaleConosco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin-top-60">
        <div class="row">
            <div class="col-6">
                <div class="box border margin-right-20">
                    <h2>Fale Conosco</h2>
                    <br />
                    <asp:Label ID="MensagemErro" ForeColor="red" Font-Size="16px" runat="server"></asp:Label>
                    <label>DIGITE SEU NOME</label>
                    <asp:TextBox ID="NomeCompleto" MaxLength="60" runat="server"></asp:TextBox>
                    <label>E-MAIL</label>
                    <asp:TextBox ID="SeuEmail" MaxLength="256" runat="server"></asp:TextBox>
                    <label>MENSAGEM </label>
                    <asp:TextBox ID="Mensagem" MaxLength="256" TextMode="MultiLine" Rows="6" runat="server"></asp:TextBox>

                    <asp:Button ID="Enviar" OnClick="Enviar_Click" CssClass="botao-inserir" runat="server" Text="Enviar" />
                </div>
            </div>
            <div class="col-6">
                <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d14718.562256641888!2d-47.3470564!3d-22.7415974!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94c89bea5cdb94f9%3A0xffb368bd91ea12ae!2sFatec%20Americana%20-%20Faculdade%20de%20Tecnologia%20de%20Americana%20Ministro%20Ralph%20Biasi!5e0!3m2!1spt-BR!2sbr!4v1664904978236!5m2!1spt-BR!2sbr" width="100%" height="495" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
            </div>
        </div>
    </div>
</asp:Content>
