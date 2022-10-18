using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using TratamentoExcecoes;

namespace Projeto3
{
    public partial class FaleConosco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Enviar_Click(object sender, EventArgs e)
        {

            try
            {
                // TENTA ENVIAR O EMAIL
                // VALIDAR OS DADOS
                if (NomeCompleto.Text.Trim() == "")//trim verifica se esta vazio
                {
                    MensagemErro.Text = "Digite seu nome";
                }
                else if (SeuEmail.Text.Trim() == "")
                {
                    MensagemErro.Text = "Digite seu e-mail";
                }
                else if (Mensagem.Text.Trim() == "")
                {
                    MensagemErro.Text = "Digite a mensagem";
                }
                else
                {
                    // ENVIAR O E-MAIL

                    // 1. montar o pacote do email
                    MailMessage email = new MailMessage();
                    email.To.Add("contato@seudominio.com.br");
                    MailAddress from = new MailAddress("contato@seudominio.com.br");
                    email.From = from;
                    email.Subject = "Email enviado pelo form de contato";
                    email.Body = "Dados enviados\n";
                    email.Body += "Nome: " + NomeCompleto.Text + "\n";
                    email.Body += "Email: " + SeuEmail.Text + "\n";
                    email.Body += "Mensagem: " + Mensagem.Text + "\n";
                    email.IsBodyHtml = false;

                    // 2. Enviar o email
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.seudominio.com.br";
                    smtp.Credentials = new System.Net.NetworkCredential("contato@seudominio.com", "suasenha");
                    smtp.EnableSsl = true;
                    smtp.Send(email);
                }

            }
            catch (Exception ex)
            {
                // SE HOUVER FALHA O SISTEMA É DESVIADO PARA CÁ
                MensagemErro.Text = "Houve uma falha ao tentar enviar o e-mail ";

                LogExcecoes le = new LogExcecoes();
                le.SalvarExcecao(ex);
            }

        }
    }
}