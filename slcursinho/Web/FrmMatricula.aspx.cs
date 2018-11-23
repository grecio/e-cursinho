using Dto;
using Framework.Util;
using Framework.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class FrmMatricula : FormBase
    {

        private readonly BLL.BpCurso bpCurso;
        private readonly BLL.BpTurma bpTurma;

        public FrmMatricula()
        {
            bpCurso = new BLL.BpCurso();
            bpTurma = new BLL.BpTurma();
        }

        private enum painel
        {
            lista = 0,
            form = 1
        }

        private enum painelAlunoResponsavel
        {
            sim = 0,
            nao = 1
        }

        private long IdMatricula
        {
            get { return Convert.ToInt64(ViewState["IdMatricula"].ToString()); }
            set { ViewState["IdMatricula"] = value; }

        }

        private void InicializarForm()
        {
            try
            {
                ExibirPainel(painel.lista);
                PreencherEstados();
                PreencherCurso();
                PreencherTurma();
            }
            catch (Exception ex)
            {
                JavaScript.ShowMsg(this.Page, ex.Message);
            }
        }

        private void PreencherCurso()
        {
            ddlCurso.DataSource = bpCurso.Listar().OrderBy(item => item.Curso);
            ddlCurso.DataTextField = "Curso";
            ddlCurso.DataValueField = "IdCurso";

            ddlCurso.DataBind();

            ddlCurso.Items.Insert(0, new ListItem() { Text = "Selecione", Value = "0" });


        }

        private void PreencherTurma()
        {

            long idcurso = 0;

            long.TryParse(ddlCurso.SelectedValue, out idcurso);

            ddlTurma.DataSource = bpTurma.Listar(idcurso);
            ddlTurma.DataTextField = "Descricao";
            ddlTurma.DataValueField = "IdTurma";
            ddlTurma.DataBind();

            ddlTurma.Items.Insert(0, new ListItem() { Text = "Selecione", Value = "0" });
        }

        private void PreencherEstados()
        {
            ddlEstadoAluno.DataSource = Util.ObterUF();
            ddlEstadoAluno.DataTextField = "estado";
            ddlEstadoAluno.DataValueField = "id";
            ddlEstadoAluno.DataBind();

            ddlEstadoAlunoResponsavel.DataSource = Util.ObterUF();
            ddlEstadoAlunoResponsavel.DataTextField = "estado";
            ddlEstadoAlunoResponsavel.DataValueField = "id";
            ddlEstadoAlunoResponsavel.DataBind();

            ddlEstadoResponsavel.DataSource = Util.ObterUF();
            ddlEstadoResponsavel.DataTextField = "estado";
            ddlEstadoResponsavel.DataValueField = "id";
            ddlEstadoResponsavel.DataBind();

        }

        private void Novo()
        {

        }


        private void ExibirPainel(painel painel)
        {
            MultiView1.ActiveViewIndex = (int)painel;
        }

        private void ExibirPainelResponsavel(painelAlunoResponsavel painel)
        {
            MultiView2.ActiveViewIndex = (int)painel;
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
            ExibirPainelResponsavel(painelAlunoResponsavel.sim);
        }


        protected void ddlResponsavel_SelectedIndexChanged(object sender, EventArgs e)
        {

            painelAlunoResponsavel painel = ddlResponsavel.SelectedValue.ToLowerInvariant() == "sim" ?
                                            painelAlunoResponsavel.sim : painelAlunoResponsavel.nao;

            ExibirPainelResponsavel(painel);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ExibirPainel(painel.lista);
        }
    }

}