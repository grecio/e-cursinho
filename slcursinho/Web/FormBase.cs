using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    public class FormBase : System.Web.UI.Page
    {          
        public enum Modo
        {
            inc, 
            alt,
            pagar
        }

        public const string MSG_EXCLUIR = "Deseja realmente excluir?";
        public const string MSG_SUCESSO_UPD = "Dados alterados com sucesso.";
        public const string MSG_SUCESSO_INC = "Dados cadastrados com sucesso.";
        public const string MSG_PAGAR = "Confirma o pagamento da conta?";
        public const string MSG_RECEBER = "Confirma o recebimento da conta?";

        public UsuarioDto UsuarioLogado
        {
            get
            {

                if (Session["UsuarioLogado"] != null)
                {
                    return  (UsuarioDto)Session["UsuarioLogado"];
                }                

                return null;
            }

            set
            {
                Session["UsuarioLogado"] = value;
            }
        }
      
        protected override void OnPreRender(EventArgs e)
        {
            //if (UsuarioLogado == null)
            //{
            //    Response.Redirect("logout.aspx");
            //}
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            if (Session["UsuarioLogado"] == null)
            {
                Response.Redirect("logout.aspx");
            }

        }
    }
}