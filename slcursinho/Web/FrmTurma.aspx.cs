﻿using Domain;
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
    public partial class FrmTurma : FormBase
    {
        private enum painel
        {
            lista = 0,
            form = 1,
            instrutor = 2,
            horarios = 3
        }

        private readonly BLL.BpCurso bpCurso;
        private readonly BLL.BpTurma bpTurma;
        private readonly BLL.BpTurmaStatus bpTurmaStatus;
        private readonly BLL.BpTurmaInstrutor bpTurmaInstrutor;
        private readonly BLL.BpTurmaHorario bpTurmaHorario;
        private readonly BLL.BpInstrutor bpInstrutor;



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
            bpTurmaInstrutor = new BLL.BpTurmaInstrutor();
            bpTurmaHorario = new BLL.BpTurmaHorario();
            bpInstrutor = new BLL.BpInstrutor();
        }

        private void InicializarForm()
        {
            try
            {
                ExibirPainel(painel.lista);
                Listar();
                PreencherCursos();
                PreencherStatus();
                PreencherInstrutores();
                PreencherDias();
            }
            catch (Exception ex)
            {
                JavaScript.ShowMsg(this.Page, ex.Message);
            }
        }

        private void PreencherDias()
        {
            ddlDia.Items.AddRange(new ListItem[]
            {
                new ListItem() { Text = "Domingo", Value = "DOM" },
                new ListItem() { Text = "Segunda-feira", Value = "SEG" },
                new ListItem() { Text = "Terça-feira", Value = "TER" },
                new ListItem() { Text = "Quarta-feira", Value = "QUA" },
                new ListItem() { Text = "Quinta-feira", Value = "QUI" },
                new ListItem() { Text = "Sexta-feira", Value = "SEX" },
                new ListItem() { Text = "Sábado", Value = "SAB" }
            });

        }

        private void PreencherInstrutores()
        {
            ddlInstrutor.DataSource = bpInstrutor.Listar().OrderBy(item => item.Instrutor);
            ddlInstrutor.DataTextField = "Instrutor";
            ddlInstrutor.DataValueField = "IdInstrutor";
            ddlInstrutor.DataBind();
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
            bpTurma.Excluir(IdTurma);
        }

        private void AdicionarTurmaInstrutor()
        {
            bpTurmaInstrutor.Inserir(new TurmaInstrutor()
            {
                IdTurmaInstrutor = 0,
                IdTurma = IdTurma,
                IdInstrutor = Convert.ToInt64(ddlInstrutor.SelectedValue)

            });

        }

        private void ListarTurmaInstrutor()
        {
            grdTurmaInstrutorList.DataSource = bpTurmaInstrutor.Listar(IdTurma);
            grdTurmaInstrutorList.DataBind();
        }

        private void ListarTurmaHorario()
        {
            grdTurmaHorarioList.DataSource = bpTurmaHorario.Listar(IdTurma);
            grdTurmaHorarioList.DataBind();
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                var dto = e.Row.DataItem as TurmaDto;

                var lkbSel = e.Row.FindControl("lkbSel") as LinkButton;
                var lkbRemover = e.Row.FindControl("lkbRemover") as LinkButton;
                var lkbInstrutures = e.Row.FindControl("lkbInstrutures") as LinkButton;
                var lkbhorarios = e.Row.FindControl("lkbhorarios") as LinkButton;

                if (lkbhorarios != null)
                {
                    lkbhorarios.CommandArgument = dto.IdTurma.ToString();
                }

                if (lkbInstrutures != null)
                {
                    lkbInstrutures.CommandArgument = dto.IdTurma.ToString();
                }

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
                else if (e.CommandName.ToLowerInvariant() == "instrutores")
                {
                    IdTurma = Convert.ToInt64(e.CommandArgument.ToString());

                    var turmaDto = bpTurma.Ler(IdTurma);

                    if (turmaDto != null)
                    {
                        lblTurma.Text = turmaDto.Descricao.ToUpperInvariant();
                        lblCurso.Text = turmaDto.Curso.ToUpperInvariant();
                    }

                    ExibirPainel(painel.instrutor);
                    ListarTurmaInstrutor();

                }
                else if (e.CommandName.ToLowerInvariant() == "horarios")
                {
                    IdTurma = Convert.ToInt64(e.CommandArgument.ToString());

                    var turmaDto = bpTurma.Ler(IdTurma);

                    if (turmaDto != null)
                    {
                        lblTurmaHorario_Turma.Text = turmaDto.Descricao.ToUpperInvariant();
                        lblTurmaHorario_Curso.Text = turmaDto.Curso.ToUpperInvariant();
                    }

                    ExibirPainel(painel.horarios);
                    ListarTurmaHorario();
                }
            }
            catch (Exception ex)
            {

                JavaScript.ShowMsg(Page, ex.Message);
            }
        }

        protected void btnInstrutorInserir_Click(object sender, EventArgs e)
        {
            try
            {
                AdicionarTurmaInstrutor();
                ListarTurmaInstrutor();
            }
            catch (Exception ex)
            {

                JavaScript.ShowMsg(Page, ex.Message);
            }
        }

        protected void grdTurmaInstrutorList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var dto = e.Row.DataItem as TurmaInstrutorDto;

                var lkbTurmaInstrutorRemover = e.Row.FindControl("lkbTurmaInstrutorRemover") as LinkButton;

                if (lkbTurmaInstrutorRemover != null)
                {
                    lkbTurmaInstrutorRemover.CommandArgument = dto.IdTurmaInstrutor.ToString();
                    JavaScript.AddConfirmSubmit(lkbTurmaInstrutorRemover, MSG_EXCLUIR);
                }
            }
        }

        protected void grdTurmaInstrutorList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToLowerInvariant() == "excluir")
                {
                    long id = 0;

                    long.TryParse(e.CommandArgument.ToString(), out id);

                    bpTurmaInstrutor.Remover(id);
                    ListarTurmaInstrutor();
                }
            }
            catch (Exception ex)
            {
                JavaScript.ShowMsg(Page, ex.Message);
            }
        }

        protected void grdTurmaInstrutorList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdTurmaInstrutorList.PageIndex = e.NewPageIndex;
                ListarTurmaInstrutor();
            }
            catch (Exception ex)
            {

                JavaScript.ShowMsg(Page, ex.Message);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            ExibirPainel(painel.lista);
        }

        protected void grdTurmaHorarioList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                var dto = e.Row.DataItem as TurmaHorarioDto;

                var lkbTurmaHorarioRemover = e.Row.FindControl("lkbTurmaHorarioRemover") as LinkButton;

                if (lkbTurmaHorarioRemover != null)
                {
                    lkbTurmaHorarioRemover.CommandArgument = dto.IdTurmaHorario.ToString();
                    JavaScript.AddConfirmSubmit(lkbTurmaHorarioRemover, MSG_EXCLUIR);

                }
            }
        }

        protected void grdTurmaHorarioList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdTurmaHorarioList.PageIndex = e.NewPageIndex;
                ListarTurmaHorario();
            }
            catch (Exception ex)
            {

                JavaScript.ShowMsg(Page, ex.Message);
            }
        }

        protected void btnTurmaHorarioVoltar_Click(object sender, EventArgs e)
        {
            ExibirPainel(painel.lista);
        }

        protected void btnTurmaHorarioAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                bpTurmaHorario.Inserir(new TurmaHorario()
                {
                    IdTurmaHorario = 0,
                    IdTurma = IdTurma,
                    Dia = ddlDia.SelectedValue,
                    HoraEntrada = txtHoraInicial.Text,
                    HoraSaida = txtHoraFinal.Text

                });

                ListarTurmaHorario();
            }
            catch (Exception ex)
            {

                JavaScript.ShowMsg(Page, ex.Message);
            }
        }

        protected void grdTurmaHorarioList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName.ToLowerInvariant() == "excluir")
                {
                    long id = 0;

                    long.TryParse(e.CommandArgument.ToString(), out id);

                    bpTurmaHorario.Remover(id);
                    ListarTurmaHorario();

                }

            }
            catch (Exception ex)
            {

                JavaScript.ShowMsg(Page, ex.Message);
            }
        }
    }
}