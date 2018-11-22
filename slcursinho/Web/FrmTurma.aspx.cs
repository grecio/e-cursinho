﻿using Dto;
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
    public partial class FrmTurma : FormBase
    {
        private enum painel
        {
            lista = 0,
            form = 1
        }

        private readonly BLL.BpCurso bpCurso;
        private readonly BLL.BpTurma bpTurma;
        private readonly BLL.BpTurmaStatus bpTurmaStatus;

        private long IdTurma
        {
            get
            {
                if (ViewState["IdTurma"] != null)
                {
                    long id = 0;
                    long.TryParse(ViewState["IdTurma"].ToString(), out id);
                    return id; 
                }

                return 0;
            }
            set { ViewState["IdTurma"] = value; }

        }

        public FrmTurma()
        {
            bpCurso = new BLL.BpCurso();
            bpTurma = new BLL.BpTurma();
            bpTurmaStatus = new BLL.BpTurmaStatus();
        }

        private void InicializarForm()
        {
            try
            {
                ExibirPainel(painel.lista);
                Listar();
                PreencherCursos();
                PreencherStatus();

            }
            catch (Exception ex)
            {
                JavaScript.ShowMsg(this.Page, ex.Message);
            }
        }

        private void PreencherStatus()
        {
            ddlStatus.DataSource = bpTurmaStatus.Listar();
            ddlStatus.DataTextField = "TurmaStatus";
            ddlStatus.DataValueField = "IdTurmaStatus";
            ddlStatus.DataBind();

        }

        private void PreencherCursos()
        {
            ddlCurso.DataSource = bpCurso.Listar();
            ddlCurso.DataTextField = "Curso";
            ddlCurso.DataValueField = "IdCurso";
            ddlCurso.DataBind();
        }

        private void ExibirPainel(painel painel)
        {
            MultiView1.ActiveViewIndex = (int)painel;
        }

        private void Listar()
        {

            grdList.DataSource = bpTurma.Listar();
            grdList.DataBind();

        }

        private void Ler()
        {

           
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
           
         
        }

        private void Excluir()
        {
          
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
                var dataini = DateTime.MinValue;
                var datafim = DateTime.MinValue;
                long idcurso = 0;
                int capacidade = 0;

                DateTime.TryParse(txtDataIni.Text, out dataini);
                DateTime.TryParse(txtDataFim.Text, out datafim);

                long.TryParse(ddlCurso.SelectedValue.ToString(), out idcurso);
                int.TryParse(txtCapacidade.Text, out capacidade);


                bpTurma.Salvar(new Domain.Turma()
                {
                    IdTurma = IdTurma,
                    IdCurso = idcurso,
                    IdTurmaStatus = Convert.ToInt32(ddlStatus.SelectedValue),
                    DataInicio = dataini,
                    DataFim = datafim,
                    Descricao = txtNome.Text,
                    Capacidade = capacidade,
                    IdUSuarioExc = UsuarioLogado.IdUsuario

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

                var dto = e.Row.DataItem as TurmaDto;

                var lkbSel = e.Row.FindControl("lkbSel") as LinkButton;
                var lkbRemover = e.Row.FindControl("lkbRemover") as LinkButton;

                if (lkbSel != null)
                {
                    lkbSel.CommandArgument = dto.IdTurma.ToString();
                }

                if (lkbRemover != null)
                {
                    lkbRemover.CommandArgument = dto.IdTurma.ToString();
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
                    IdTurma = Convert.ToInt64(e.CommandArgument.ToString());

                    Ler();
                    ExibirPainel(painel.form);
                }
                else if (e.CommandName.ToLowerInvariant() == "excluir")
                {
                    IdTurma = Convert.ToInt64(e.CommandArgument.ToString());

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