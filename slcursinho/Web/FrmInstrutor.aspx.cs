using Dto;
using Framework.Concerns;
using Framework.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class FrmInstrutor : FormBase
    {
        private enum painel
        {
            lista = 0,
            form = 1
        }

        private readonly BLL.BpInstrutor bpInstrutor;

        private long IdInstrutor
        {
            get { return Convert.ToInt64(ViewState["IdInstrutor"].ToString()); }
            set { ViewState["IdInstrutor"] = value; }

        }

        public FrmInstrutor()
        {
            bpInstrutor = new BLL.BpInstrutor();
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

            grdList.DataSource = bpInstrutor.Listar();
            grdList.DataBind();

        }

        private void Ler()
        {

            var instrutorDto = bpInstrutor.Selecionar(IdInstrutor);

            Validador.Validar(instrutorDto != null, "Não foi possível obter os dados do instrutor.");

            if (instrutorDto != null)
            {
                IdInstrutor = instrutorDto.IdInstrutor;
                txtNome.Text = instrutorDto.Instrutor;
                txtTelefone.Text = instrutorDto.Telefone;
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
            IdInstrutor = 0;
            txtTelefone.Text = string.Empty;
            txtNome.Text = string.Empty;
        }

        private void Excluir()
        {
            bpInstrutor.Excluir(IdInstrutor);
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
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                bpInstrutor.Salvar(new Domain.Instrutor()
                {
                    IdUsuario = UsuarioLogado.IdUsuario,
                    IdInstrutor = IdInstrutor,
                    Nome = txtNome.Text,
                    Telefone = txtTelefone.Text
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

                var usuarioDto = e.Row.DataItem as InstrutorDto;

                var lkbSel = e.Row.FindControl("lkbSel") as LinkButton;
                var lkbRemover = e.Row.FindControl("lkbRemover") as LinkButton;

                if (lkbSel != null)
                {
                    lkbSel.CommandArgument = usuarioDto.IdInstrutor.ToString();
                }

                if (lkbRemover != null)
                {
                    lkbRemover.CommandArgument = usuarioDto.IdInstrutor.ToString();
                    JavaScript.AddConfirmSubmit(lkbRemover, MSG_EXCLUIR);

                }
            }
        }

        protected void grdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToLowerInvariant() == "selecionar")
                {
                    IdInstrutor = Convert.ToInt64(e.CommandArgument.ToString());

                    Ler();
                    ExibirPainel(painel.form);
                }
                else if (e.CommandName.ToLowerInvariant() == "excluir")
                {
                    IdInstrutor = Convert.ToInt64(e.CommandArgument.ToString());

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