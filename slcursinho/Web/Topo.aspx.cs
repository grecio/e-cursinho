using Dto;
using System;

namespace Web
{
    public partial class Topo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogado"] != null)
            {
                lblUsu.Text = string.Format("Usuário Logado: {0}", (Session["UsuarioLogado"] as UsuarioDto).Nome);
            }            
        }
    }
}