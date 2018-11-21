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
    public partial class FrmCurso : FormBase
    {
        private enum painel
        {
            lista = 0,
            form = 1
        }

        private readonly BLL.BpCurso bpCurso;

        private long IdCurso
        {
            get { return Convert.ToInt64(ViewState["IdCurso"].ToString()); }
            set { ViewState["IdCurso"] = value; }

        }

        public FrmCurso()
        {
            bpCurso = new BLL.BpCurso();
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

            grdList.DataSource = bpCurso.Listar();
            grdList.DataBind();

        }

        private void Ler()
        {

            var cursoDto = bpCurso.Selecionar(IdCurso);

            Validador.Validar(cursoDto != null, "Não foi possível obter os dados do curso.");

            if (cursoDto != null)
            {
                IdCurso = cursoDto.IdCurso;

                txtNome.Text = cursoDto.Curso;
                txtDescricao.Text = cursoDto.Descricao;
                ddlAno.SelectedValue = cursoDto.Ano.ToString();
                txtValor.Text = cursoDto.Valor.ToString();
                txtHora.Text = cursoDto.Horas.ToString();
                txtQtdParcela.Text = cursoDto.Parcelas.ToString();
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
            IdCurso = 0;

            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            ddlAno.SelectedValue = DateTime.Now.Year.ToString();
            txtValor.Text = "0,00";
            txtHora.Text = string.Empty;
            txtQtdParcela.Text = string.Empty;
        }

        private void Excluir()
        {
            bpCurso.Excluir(IdCurso);
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
                int horas = 0;
                int parcelas = 0;

                int.TryParse(txtHora.Text, out horas);
                int.TryParse(txtQtdParcela.Text, out parcelas);

                bpCurso.Salvar(new Domain.Curso()
                {
                    IdCurso = IdCurso,
                    Nome = txtNome.Text,
                    Descricao = txtDescricao.Text,
                    Ano = Convert.ToInt32(ddlAno.SelectedValue),
                    Horas = horas,
                    Parcelas = parcelas,
                    IdUsuario = UsuarioLogado.IdUsuario,
                    Valor = Convert.ToDecimal(txtValor.Text.Replace(".","").Replace(",", "."))
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

                var dto = e.Row.DataItem as CursoDto;

                var lkbSel = e.Row.FindControl("lkbSel") as LinkButton;
                var lkbRemover = e.Row.FindControl("lkbRemover") as LinkButton;

                if (lkbSel != null)
                {
                    lkbSel.CommandArgument = dto.IdCurso.ToString();
                }

                if (lkbRemover != null)
                {
                    lkbRemover.CommandArgument = dto.IdCurso.ToString();
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
                    IdCurso = Convert.ToInt64(e.CommandArgument.ToString());

                    Ler();
                    ExibirPainel(painel.form);
                }
                else if (e.CommandName.ToLowerInvariant() == "excluir")
                {
                    IdCurso = Convert.ToInt64(e.CommandArgument.ToString());

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