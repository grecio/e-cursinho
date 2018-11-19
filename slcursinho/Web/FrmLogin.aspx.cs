using BLL;
using Framework.Concerns;
using Framework.Web;
using System;
using System.Linq;

namespace Web
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        private readonly BpUsuario bpUsuario;

        public FrmLogin()
        {

            this.bpUsuario = new BpUsuario();

        }

        private void Entrar()
        {
            var dt = bpUsuario.EfetuarLogin(txtLogin.Text, txtSenha.Text);

            Validador.Validar(dt.Count() > 0, "Nenhum usuário encontrado para o login e senha informados.");

            if (dt.Count() > 0)
            {
                Session["UsuarioLogado"] = dt.FirstOrDefault();
            }

            Response.Redirect("painel.htm");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request["logoff"]))
            {
                lblMensagem.Text = "Sessão expirou. por favor, efetue login novamente.";
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                Entrar();
            }
            catch (Exception ex)
            {
                JavaScript.ShowMsg(this.Page, ex.Message);
            }
        }        
        
    }
}