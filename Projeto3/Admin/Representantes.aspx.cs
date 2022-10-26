using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Projeto3
{
    public partial class Representantes : System.Web.UI.Page
    {
        //publica para todos os metodos desta classe

        Model.Representantes representante = new Model.Representantes();

        //Instancia da classe de acesso ao banco de dados
        // DAO = Data Access Object (acesso ao banco de dados)
        DataServices.DataBase.DAO db = new DataServices.DataBase.DAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//só executar se for a primeira chamada
            {
                LoadGrid();
            }
        }

        /// <summary>
        /// carrega o grid com os dados do banco de dados
        /// </summary>
        protected void LoadGrid()
        {
            string comando = "SELECT RepresentanteId, Nome, NomeAcesso FROM Representantes ORDER BY RepresentanteId;";
            db.ConnectionString = App_Code.AppSettings.conectionDB();
            db.DataProviderName = DataServices.DataBase.DAO.ProviderName.OleDb;
            DataTable tb = (DataTable)db.Query(comando);

            ExibirRepresentantes.DataSource = tb;
            ExibirRepresentantes.DataBind();
            tb.Dispose();
        }

        /// <summary>
        /// Limpar controles do formulário
        /// </summary>
        protected void LimparControles()
        {
            Mensagem.Text = "";
            RepresentanteId.Text = "";
            Nome.Text = "";
            NomeAcesso.Text = "";
            Email.Text = "";
            Senha.Text = "";
            Salvar.Text = "Inserir";
            Excluir.Visible = false;
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            //1.validar as entradas
            if (Nome.Text.Trim() == "")//Trim() retira espaço em branco da direita e esquerda
            {
                Mensagem.Text = "Digite seu Nome";
            }
            else if (Email.Text.Trim() == "")
            {
                Mensagem.Text = "Digite seu E-mail";
            }
            else if (NomeAcesso.Text.Trim() == "")
            {
                Mensagem.Text = "Digite o seu Nome de Acesso";
            }
            else if (Senha.Text.Trim() == "")
            {
                Mensagem.Text = "Digite sua Senha de Acesso";
            }
            else if (PossoGravar(NomeAcesso.Text, RepresentanteId.Text) == false)
            {
                Mensagem.Text = "Este Nome de Acesso ja existe para outro usuário";
            }

            else
            {

                if (RepresentanteId.Text == "")
                {
                    //inserir um novo registro
                    representante.Nome = Nome.Text;
                    representante.Email = Email.Text;
                    representante.NomeAcesso = NomeAcesso.Text;
                    representante.Senha = Senha.Text;

                    //1. Definir a conexão
                    db.ConnectionString = App_Code.AppSettings.conectionDB();

                    //2. Definir o banco de dados
                    db.DataProviderName = DataServices.DataBase.DAO.ProviderName.OleDb;

                    //3. Insere o registro na tabela do banco de dados
                    db.Insert(representante, "RepresentanteId");

                    //Exemplo do comando SQL para inserir este registro
                    //string comando = "INSERT INTO Representantes (Nome,Email,NomeAcesso,Senha) VALUES ('" + Nome.Text + "','" + Email.Text + "','" + NomeAcesso + "','" + Senha.Text + "');";
                    //db.Query(comando);
                }
                else
                {
                    //editar o registro  selecionado
                    representante.Nome = Nome.Text;
                    representante.Email = Email.Text;
                    representante.NomeAcesso = NomeAcesso.Text;
                    representante.Senha = Senha.Text;
                    // Edita o registro na tabela do banco de dados 
                    db.Update(representante, "RepresentanteId",RepresentanteId.Text);

                    //Exemplo do comando SQL para editar o registro selecionado
                    //string comando = "UPDATE Representantes SET (Nome,Email,NomeAcesso,Senha) VALUES ('" + Nome.Text + "','" + Email.Text + "','" + NomeAcesso + "','" + Senha.Text + "' WHERE RepresentanteId =" + RepresentanteId.Text;
                    //db.Query(comando);
                }
                LimparControles();
                LoadGrid();
            }
        }

        protected void Excluir_Click(object sender, EventArgs e)
        {
            string comando = "DELETE FROM Representantes WHERE RepresentanteId=" + RepresentanteId.Text;
            db.ConnectionString = App_Code.AppSettings.conectionDB();
            db.DataProviderName = DataServices.DataBase.DAO.ProviderName.OleDb;
            db.Query(comando);
            LimparControles();
            LoadGrid();
        }


        protected bool PossoGravar(String NomeAcesso, String id)
        {
            //codigo SQL
            string comando = "SELECT * FROM Representantes WHERE NomeAcesso= '" + NomeAcesso + "';";
            db.ConnectionString = App_Code.AppSettings.conectionDB();
            db.DataProviderName = DataServices.DataBase.DAO.ProviderName.OleDb;

            DataTable tb = (System.Data.DataTable)db.Query(comando);
            if (tb.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                if (tb.Rows[0]["RepresentanteId"].ToString() == RepresentanteId.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected void ExibirRepresentantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepresentanteId.Text = ExibirRepresentantes.SelectedRow.Cells[1].Text;
            string comando = "SELECT * FROM Representantes WHERE RepresentanteId=" + RepresentanteId.Text;
            db.ConnectionString = App_Code.AppSettings.conectionDB();
            db.DataProviderName = DataServices.DataBase.DAO.ProviderName.OleDb;
            DataTable tb = (DataTable)db.Query(comando);

            Nome.Text = tb.Rows[0]["Nome"].ToString();
            Email.Text = tb.Rows[0]["Email"].ToString();
            NomeAcesso.Text = tb.Rows[0]["NomeAcesso"].ToString();
            Senha.Text = tb.Rows[0]["Senha"].ToString();

            Salvar.Text = "Editar";
            Excluir.Visible = true;
        }
    }
}