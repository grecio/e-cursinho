﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Framework.Web
{
    public class JavaScript
    {

        #region Constantes Públicas

        public static string START_SCRIPT = "<script language='javascript'>";
        public static string END_SCRIPT = "</script>";
        public static string _BLANK = "_blank";
        public static string _PARENT = "_parent";
        public static string _SELF = "_self";
        public static string _TOP = "_top";

        #endregion

        #region Métodos

        public static void DocLocation(System.Web.UI.Page ObjectPage, string strURL)
        {
            var strScript = new StringBuilder();

            strScript.Append("<script language="+"javascript"+">");
            strScript.Append("document.location.href='" + strURL + "';");
            strScript.Append("</script>");

            ObjectPage.ClientScript.RegisterStartupScript(typeof(string), new Guid().ToString(), strScript.ToString());

        }

        public static void AddMaskText(System.Web.UI.WebControls.TextBox textObject , string maskText)
        {
            textObject.Attributes.Add("onKeyPress", String.Format("javascript:{0}", ScriptMaskText(maskText)));
            textObject.Attributes.Add("MaxLength", maskText.ToString().Length.ToString());

        }

        public static void AddNumDec(System.Web.UI.WebControls.TextBox sourceObject, Byte intCasas)
        {
            sourceObject.Attributes.Add("onKeyPress", String.Format("javascript:{0}", StringApenasNumDec(intCasas.ToString())));
        }

        public static void AddDefaultSubmit(System.Web.UI.WebControls.TextBox sourceObject, System.Web.UI.Control objectToSubmit, Boolean boolDropDownList = false)
        {
            sourceObject.Attributes.Add("onKeyPress", String.Format("javascript:{0}", ScriptDefaultSubmit(objectToSubmit, boolDropDownList )));
        }

        public static void AddConfirmSubmit(System.Web.UI.WebControls.WebControl objControl, String message, String eventName = "onClick")
        {                           
            objControl.Attributes.Add(eventName, String.Format("javascript:{0}", ScriptConfirmSubmit(message)));
        }

        public static void AddAtivarPesquisa(System.Web.UI.WebControls.TextBox sourceObject, String strTabela, String strDest = "", String strOrdExt = "", String strFiltroExt = "",String strReq = "", String eventName = "onClick", int idUsuarioValidaUnidade = 0)
        {
            sourceObject.Attributes.Add(eventName, String.Format("javascript:{0}; return false;", ScriptAtivaPesquisa(strTabela, strDest, strOrdExt, strFiltroExt, strReq)));
        }

        public static void AddOpenWindow(System.Web.UI.WebControls.TextBox sourceObject, String strPagina, String strTarget, int intWidth = 400,int intHeight = 300, String strScroll= "no", String eventName = "onClick")
        {
            sourceObject.Attributes.Add(eventName, String.Format("javascript:{0}", ScriptOpenWindow(strPagina, strTarget, intWidth, intHeight, strScroll)));
          
        }

        public static void SetFocus(System.Web.UI.Page objectPage, System.Web.UI.Control objectFocus)
        {
            SetFocus(objectPage, objectFocus.ClientID);
        }

        public static void SetFocus(System.Web.UI.Page objectPage, String objectId)
        {
            var strScript = new StringBuilder();

            strScript.Append("<script language=\"javascript\">");
            strScript.Append("$(\"#" + objectId + "\").focus();");
            strScript.Append("$(\"#" + objectId + "\").toggleClass('txt-focus');");
            strScript.Append("</script>");

            objectPage.ClientScript.RegisterStartupScript(typeof(String), new Guid().ToString(), strScript.ToString());

        }

        

        public static void ShowMsg(System.Web.UI.Page page, string Message)
        {
            page.ClientScript.RegisterStartupScript(typeof(string), new Guid().ToString(), ScriptMsg(Message));
        }

        public static void ShowMsgWithRedirect(System.Web.UI.Page page, string Message, string page_redirect)
        {           
            page.ClientScript.RegisterStartupScript(typeof(string), new Guid().ToString(), ScriptMsg(Message) + ScriptDocLocation(page_redirect));
        }

        public static void SetClick(System.Web.UI.Page objectPage, string objectId)
        {
            var strScript = new StringBuilder();
                    
            strScript.Append("<script language=\"javascript\">");
            strScript.Append("$(\"#" + objectId + "\").click();");
            strScript.Append("</script>");

            objectPage.ClientScript.RegisterStartupScript(typeof(String), new Guid().ToString(), strScript.ToString());

        }

        private static string ScriptDocLocation(string pagina)
        {
            var strScript = new System.Text.StringBuilder();

            strScript.Append("<script language=\"javascript\">");

            strScript.Append("document.location.href = '" + StringJava(pagina) + "'");

            strScript.Append("</script>");

            return strScript.ToString();
        }

        private static string ScriptMsg(string Message)
        {
            if (Message.ToUpper().Contains("DELETE statement conflicted".ToUpper()))
            {
                Message = "O registro não pode ser excluído. Existem informações relacionadas a ele.";
            }

            var strScript = new System.Text.StringBuilder();

            strScript.Append("<script language=\"javascript\">");

            strScript.Append("alert('" + StringJava(Message) + "');");

            strScript.Append("</script>");

            return strScript.ToString();

        }

        public static void ShowRPT(System.Web.UI.Page oPage, string strRpt, string strParam, bool popUp = false)
        {
            oPage.ClientScript.RegisterStartupScript(typeof(string), Guid.NewGuid().ToString(), string.Format("showRpt('{0}', '{1}', '{2}');", strRpt, strParam, popUp), true);
        } 
        
        #endregion

        #region Funções
        public static string StringJava(string Texto)
        {

            Texto = Texto.Replace("\\", "\\\\");
            Texto = Texto.Replace("\n", "\\n");
            Texto = Texto.Replace("'", "\\'");
            Texto = Texto.Replace("\"", "\\\"");

            return Texto;

        }
        
        public static string ScriptMaskText(string maskText)
        {

            return String.Format("return mascaraCampo(this, '{0}', event);", maskText);

        }

        public static string StringApenasNumDec(string casas)
        {

            return String.Format("apenasNumDec(this, {0}, 15, event);", casas);

        }

        public static string ScriptDefaultSubmit(System.Web.UI.Control objectToSubmit, Boolean boolDropDownList )
        {
            if (boolDropDownList)
            {
                return "if (event.keyCode == 13){document.getElementById('" + objectToSubmit.ClientID + "').click();return(false);};";
            }
            else
            {

                return "if (event.keyCode == 13 && Trim(this.value) != ''){document.getElementById('" + objectToSubmit.ClientID + "').click();return(false);};";
            }
        }

        public static string ScriptConfirmSubmit(string message)
        {

            return "if (!confirm('" + StringJava(message) + "')){return(false);};";

        }

        public static string ScriptAtivaPesquisa(String strTabela, String strDest, String strOrdExt, String strFiltroExt, String strReq)
        {

            return String.Format("AtivarPesquisa('{0}', '{1}', '{2}', '{3}','{4}');", strTabela, strDest, strFiltroExt, strOrdExt, strReq);

        }


        public static string ScriptOpenWindow(String strPagina, String strTarget, int intWidth, int intHeight, String strScroll)
        {

            return String.Format("abrirJanelaScroll('{0}','{1}','{2}','{3}', '{4}')", strPagina, strTarget, intWidth, intHeight, strScroll);

        }
        
        #endregion

    }
}
