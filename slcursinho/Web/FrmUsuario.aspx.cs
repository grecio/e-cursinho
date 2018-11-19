using Dto;
using Framework.Concerns;
using Framework.Web;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class FrmUsuario : FormBase
    {

        private enum painel
        {
            lista = 0,
            form = 1
        }

        private readonly BLL.BpUsuario bpUsuario;

        private long IdUsuario
        {
            get { return Convert.ToInt64(ViewState["IdUsuario"].ToString()); }
            set { ViewState["IdUsuario"] = value; }

        }

        public FrmUsuario()
        {
            bpUsuario = new BLL.BpUsuario();
        }

        private void InicializarForm()
        {
            try
            {
                ExibirPainel(painel.lista);
                Listar();

            }
            catch (Exception ex)
            {
                JavaScript.ShowMsg(this.Page, ex.Message);
            }
        }

        private void ExibirPainel(painel painel)
        {
            MultiView1.ActiveViewIndex = (int)painel;
        }

        private void Listar()
        {

            grdList.DataSource = bpUsuario.Listar();
            grdList.DataBind();

        }

        private void Ler()
        {

            var usuarioDto = bpUsuario.Selecionar(IdUsuario);

            Validador.Validar(usuarioDto != null, "Não foi possível obter os dados do usuário.");

            if (usuarioDto != null)
            {
                txtNome.Text = usuarioDto.Nome;
                txtLogin.Text = usuarioDto.Login;
                txtSenha.Text = usuarioDto.Senha;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                InicializarForm();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Novo();
            ExibirPainel(painel.form);
        }

        private void Novo()
        {
            IdUsuario = 0;
            txtLogin.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtSenha.Text = string.Empty;
        }

        private void Excluir()
        {
            bpUsuario.Excluir(IdUsuario);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Listar();
                ExibirPainel(painel.lista);
            }
            catch (Exception ex)
            {
                JavaScript.ShowMsg(Page, ex.Message);
                throw;
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                bpUsuario.Salvar(new Domain.Usuario()
                {
                    Login = txtLogin.Text,
                    Nome = txtNome.Text,
                    Senha = txtSenha.Text
                });

                Listar();
                ExibirPainel(painel.lista);
            }
            catch (Exception ex)
            {

                JavaScript.ShowMsg(Page, ex.Message);
            }
        }

        protected void grdList_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                grdList.PageIndex = e.NewPageIndex;
                Listar();
            }
            catch (Exception ex)
            {

                JavaScript.ShowMsg(Page, ex.Message);
            }
        }

        protected void grdList_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {

                var usuarioDto = e.Row.DataItem as UsuarioDto;

                var lkbSel = e.Row.FindControl("lkbSel") as LinkButton;
                var lkbRemover = e.Row.FindControl("lkbRemover") as LinkButton;

                if (lkbSel != null)
                {
                    lkbSel.CommandArgument = usuarioDto.IdUsuario.ToString();
                }

                if (lkbRemover != null)
                {
                    lkbRemover.CommandArgument = usuarioDto.IdUsuario.ToString();
                    JavaScript.AddConfirmSubmit(lkbRemover, FormBase.MSG_EXCLUIR);

                }
            }
        }

        protected void grdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToLowerInvariant() == "selecionar")
                {
                    IdUsuario = Convert.ToInt64(e.CommandArgument.ToString());

                    Ler();
                    ExibirPainel(painel.form);
                }
                else if (e.CommandName.ToLowerInvariant() == "excluir")
                {
                    IdUsuario = Convert.ToInt64(e.CommandArgument.ToString());

                    Excluir();
                    Listar();
                    ExibirPainel(painel.lista);
                }
            }
            catch (Exception ex)
            {

                JavaScript.ShowMsg(Page, ex.Message);
            }
        }

    }
}