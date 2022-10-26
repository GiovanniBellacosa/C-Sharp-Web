using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using TratamentoExcecoes;

namespace Projeto3
{
    public partial class ExibirExcecoe : System.Web.UI.Page
    {
        string caminhoFisico = HttpContext.Current.Server.MapPath("~/Error.txt");

        LogExcecoes exc = new LogExcecoes();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Excecoes.Text = exc.LerExcecoes();
        }

        protected void Limpar_Click(object sender, EventArgs e)
        {
            exc.LimpaExcecoes();
            Excecoes.Text = "";
        }
    }
}