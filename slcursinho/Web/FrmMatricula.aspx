<%@ Page Title="" Language="C#" MasterPageFile="~/Painel.Master" AutoEventWireup="true" CodeBehind="FrmMatricula.aspx.cs" Inherits="Web.FrmMatricula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="1" style="width: 92%">
        <tr>
            <td class="linha">
                <asp:Label ID="Label1" runat="server" CssClass="tit" Text="Matrículas"></asp:Label>
            </td>
        </tr>
       
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:GridView ID="grdList" runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="Grid" DataKeyNames="IdMatricula" EmptyDataText="Nenhum registro encontrado">
                                        <AlternatingRowStyle CssClass="GridAltItem" />
                                        <Columns>
                                            <asp:BoundField DataField="matricula" HeaderText="Matrícula" SortExpression="matricula">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="turma" HeaderText="Turma" SortExpression="turma">
                                                <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="aluno" HeaderText="Aluno" SortExpression="aluno">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkbSel" runat="server" CausesValidation="False" CommandName="Selecionar" Text="Editar"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="7%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkbRemover" runat="server" CausesValidation="False" CommandName="Excluir" Text="Remover"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="7%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#1E2F5E" CssClass="GridHeader" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" CssClass="GridItem" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Button ID="btnNovo" runat="server" CssClass="btn" Text="Nova Matrícula" OnClick="btnNovo_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">

                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label14" runat="server" CssClass="lbl_req" Text="Os campos em (*) são requeridos"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 15%;">
                                    <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Matrícula:" Width="100px"></asp:Label>
                                </td>
                                <td>
                                    <table cellspacing="1" style="width: 100%">
                                        <tr>
                                            <td style="width: 1%;">
                                                <asp:TextBox ID="txtMatricula" runat="server" CssClass="txt-dis" ReadOnly="True" Width="150px"></asp:TextBox>
                                            </td>
                                            <td style="width: 1%;">
                                                <asp:Label ID="Label18" runat="server" CssClass="lbl" Text="Contrato:" Width="70px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtContrato" runat="server" CssClass="txt-dis" ReadOnly="True" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label19" runat="server" CssClass="lbl" Text="Responsável:" Width="100px"></asp:Label>
                                </td>
                                <td>
                                    <table cellspacing="1" style="width: 100%">
                                        <tr>
                                            <td style="width: 1%;">
                                                <asp:DropDownList ID="ddlResponsavel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlResponsavel_SelectedIndexChanged" Width="70px">
                                                    <asp:ListItem Value="sim">Sim</asp:ListItem>
                                                    <asp:ListItem Value="nao">Não</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label53" runat="server" CssClass="lbl_req" ForeColor="Maroon" Text="Se o aluno for responsável pela matrícula, marque SIM nesta opção"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:MultiView ID="MultiView2" runat="server">
                                        <asp:View ID="View3" runat="server">
                                            <table cellspacing="1" style="width: 100%">
                                                <tr>
                                                    <td class="linha" colspan="2">
                                                        <asp:Label ID="Label32" runat="server" CssClass="lbl" Font-Bold="True" Text="Dados do Aluno e Responsável pela Matrícula"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="Label20" runat="server" CssClass="lbl" Text="Nome:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNomeAlunoResp" runat="server" CssClass="txt" Width="555px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="Label22" runat="server" CssClass="lbl" Text="CPF:" Width="70px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCpfAlunoResp" runat="server" CssClass="txt mask-numero" Width="100px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="Label26" runat="server" CssClass="lbl" Text="RG:" Width="70px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRgAlunoResp" runat="server" CssClass="txt mask-numero" Width="100px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="Label27" runat="server" CssClass="lbl" Text="Sexo:" Width="70px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSexoAlunoResp" runat="server" CssClass="ddl" Width="110px">
                                                            <asp:ListItem Value="1">Masculino</asp:ListItem>
                                                            <asp:ListItem Value="2">Feminino</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="Label21" runat="server" CssClass="lbl" Text="Data Nasc.:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <table cellspacing="1" style="width: 565px">
                                                            <tr>
                                                                <td style="width: 1%;">
                                                                    <asp:TextBox ID="txtDatanascAlunoResp" runat="server" CssClass="txt mask-data" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 1%;">
                                                                    <asp:Label ID="Label23" runat="server" CssClass="lbl" Text="Naturalidade:" Width="70px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNaturalidadeAlunoResp" runat="server" CssClass="txt mask-data" Width="100%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label24" runat="server" CssClass="lbl" Text="Estado Civil:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <table cellspacing="1" style="width: 565px">
                                                            <tr>
                                                                <td style="width: 1%;">
                                                                    <asp:DropDownList ID="ddlEstadocivilAlunoResp" runat="server" CssClass="ddl" Width="112px">
                                                                        <asp:ListItem Value="1">Solteiro(a)</asp:ListItem>
                                                                        <asp:ListItem Value="2">Casado(a)</asp:ListItem>
                                                                        <asp:ListItem Value="3">Outro</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 1%;">
                                                                    <asp:Label ID="Label60" runat="server" CssClass="lbl" Text="Profissão:" Width="70px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtProfissaoAlunoResp" runat="server" CssClass="txt mask-data" Width="100%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label61" runat="server" CssClass="lbl" Font-Bold="True" Text="Endereço:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label54" runat="server" CssClass="lbl" Text="CEP:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCepAlunoResponsavel" runat="server" CssClass="txt" Width="100px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label55" runat="server" CssClass="lbl" Text="Logradouro:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAlunoResponsavelEnderecoLogradouro" runat="server" CssClass="txt" Width="555px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label56" runat="server" CssClass="lbl" Text="Bairro:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBairroAlunoResponsavel" runat="server" CssClass="txt" Width="555px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label57" runat="server" CssClass="lbl" Text="Cidade:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <table cellspacing="0" style="width: 565px">
                                                            <tr>
                                                                <td style="width: 1%">
                                                                    <asp:TextBox ID="txtAlunoResponsavelCidade" runat="server" CssClass="txt" Width="400px"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 1%;">
                                                                    <asp:Label ID="Label58" runat="server" CssClass="lbl" Text="Estado:" Width="50px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlEstadoAlunoResponsavel" runat="server" Width="98%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="View4" runat="server">
                                            <table cellspacing="1" style="width: 100%">
                                                <tr>
                                                    <td class="linha" colspan="2">
                                                        <asp:Label ID="Label28" runat="server" CssClass="lbl" Font-Bold="True" Text="Dados do Aluno"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" style="width: 100%">
                                                            <tr>
                                                                <td style="width: 15%">
                                                                    <asp:Label ID="Label29" runat="server" CssClass="lbl" Text="Nome:" Width="100px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNomeAluno" runat="server" CssClass="txt" Width="555px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label30" runat="server" CssClass="lbl" Text="Data Nasc.:" Width="100px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <table cellspacing="1" style="width: 100%">
                                                                        <tr>
                                                                            <td style="width: 1%">
                                                                                <asp:TextBox ID="txtDataNascAluno" runat="server" CssClass="txt mask-data" Width="100px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 1%;">
                                                                                <asp:Label ID="Label31" runat="server" CssClass="lbl" Text="Sexo:" Width="70px"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlSexoAluno" runat="server" Width="200px">
                                                                                    <asp:ListItem Value="1">Masculino</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Feminino</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label34" runat="server" CssClass="lbl" Text="CEP:" Width="100px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCepAluno" runat="server" CssClass="txt" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label35" runat="server" CssClass="lbl" Text="Logradouro:" Width="100px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAlunoEnderecoLogradouro" runat="server" CssClass="txt" Width="555px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label36" runat="server" CssClass="lbl" Text="Bairro:" Width="100px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBairroAluno" runat="server" CssClass="txt" Width="555px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label37" runat="server" CssClass="lbl" Text="Cidade:" Width="100px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <table cellspacing="1" style="width: 100%">
                                                                        <tr>
                                                                            <td style="width: 1%">
                                                                                <asp:TextBox ID="txtBairroCidade" runat="server" CssClass="txt" Width="400px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 1%;">
                                                                                <asp:Label ID="Label38" runat="server" CssClass="lbl" Text="Estado:" Width="50px"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlEstadoAluno" runat="server" Width="98%">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="linha" colspan="2">
                                                                    <asp:Label ID="Label33" runat="server" CssClass="lbl" Font-Bold="True" Text="Dados do Responsável"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Nome:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNomeResponsavel" runat="server" CssClass="txt" Width="555px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="CPF:" Width="70px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <table cellspacing="1" style="width: 100%">
                                                            <tr>
                                                                <td style="width: 1%;">
                                                                    <asp:TextBox ID="txtCpfResponsavel" runat="server" CssClass="txt mask-numero" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 1%;">
                                                                    <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="RG:" Width="70px"></asp:Label>
                                                                </td>
                                                                <td style="width: 1%;">
                                                                    <asp:TextBox ID="txtRgResponsavel" runat="server" CssClass="txt mask-numero" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 1%;">
                                                                    <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Sexo:" Width="70px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSexoResponsavel" runat="server" Width="98%">
                                                                        <asp:ListItem Value="1">Masculino</asp:ListItem>
                                                                        <asp:ListItem Value="2">Feminino</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Data Nasc.:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <table cellspacing="1" style="width: 100%">
                                                            <tr>
                                                                <td style="width: 1%;">
                                                                    <asp:TextBox ID="txtDataNascimentoResponsavel" runat="server" CssClass="txt mask-data" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 1%;">
                                                                    <asp:Label ID="Label10" runat="server" CssClass="lbl" Text="Naturalidade:" Width="70px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNaturalidadeResponsavel" runat="server" CssClass="txt mask-data" Width="98%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Estado Civil:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <table cellspacing="1" style="width: 100%">
                                                            <tr>
                                                                <td style="width: 1%;">
                                                                    <asp:DropDownList ID="ddlEstadoCivilResponsavel" runat="server" Width="110px">
                                                                        <asp:ListItem Value="1">Solteiro(a)</asp:ListItem>
                                                                        <asp:ListItem Value="2">Casado(a)</asp:ListItem>
                                                                        <asp:ListItem Value="3">Outro</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 1%;">
                                                                    <asp:Label ID="Label12" runat="server" CssClass="lbl" Text="Profissão:" Width="70px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtProfissaoResponsavel" runat="server" CssClass="txt mask-data" Width="98%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label39" runat="server" CssClass="lbl" Text="CEP:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCepResponsavel" runat="server" CssClass="txt" Width="100px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label40" runat="server" CssClass="lbl" Text="Logradouro:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtLogradouroResponsavel" runat="server" CssClass="txt" Width="555px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label41" runat="server" CssClass="lbl" Text="Bairro:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBairroResponsavel" runat="server" CssClass="txt" Width="555px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label42" runat="server" CssClass="lbl" Text="Cidade:" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <table cellspacing="1" style="width: 100%">
                                                            <tr>
                                                                <td style="width: 1%">
                                                                    <asp:TextBox ID="txtCidadeResponsavel" runat="server" CssClass="txt" Width="400px"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 1%;">
                                                                    <asp:Label ID="Label43" runat="server" CssClass="lbl" Text="Estado:" Width="50px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlEstadoResponsavel" runat="server" Width="98%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px" class="linha" colspan="2">
                                    <asp:Label ID="Label44" runat="server" CssClass="lbl" Font-Bold="True" Text="Telefones"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px">
                                    <asp:Label ID="Label45" runat="server" CssClass="lbl" Text="DDD:" Width="100px"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <table cellspacing="1" style="width: 100%">
                                        <tr>
                                            <td style="width: 1%">
                                                <asp:TextBox ID="txtTelefone1Ddd" runat="server" CssClass="txt mask-numero" Width="50px">84</asp:TextBox>
                                            </td>
                                            <td style="width: 1%;">
                                                <asp:Label ID="Label46" runat="server" CssClass="lbl" Text="Número:" Width="70px"></asp:Label>
                                            </td>
                                            <td style="width: 1%;">
                                                <asp:TextBox ID="txtTelefone1Numero" runat="server" CssClass="txt mask-numero" Width="100px"></asp:TextBox>
                                            </td>
                                            <td style="width: 1%;">
                                                <asp:Label ID="Label49" runat="server" CssClass="lbl" Text="Obs:" Width="30px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTelefone1Obs" runat="server" CssClass="txt" Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px">
                                    <asp:Label ID="Label48" runat="server" CssClass="lbl" Text="DDD:" Width="100px"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <table cellspacing="1" style="width: 100%">
                                        <tr>
                                            <td style="width: 1%">
                                                <asp:TextBox ID="txtTelefone2Ddd" runat="server" CssClass="txt mask-numero" Width="50px">84</asp:TextBox>
                                            </td>
                                            <td style="width: 1%;">
                                                <asp:Label ID="Label47" runat="server" CssClass="lbl" Text="Número:" Width="70px"></asp:Label>
                                            </td>
                                            <td style="width: 1%">
                                                <asp:TextBox ID="txtTelefone2Numero" runat="server" CssClass="txt mask-numero" Width="100px"></asp:TextBox>
                                            </td>
                                            <td style="width: 1%;">
                                                <asp:Label ID="Label50" runat="server" CssClass="lbl" Text="Obs:" Width="30px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTelefone2Obs" runat="server" CssClass="txt" Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px">&nbsp;</td>
                                <td style="height: 19px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="linha" colspan="2" style="height: 19px">
                                    <asp:Label ID="Label51" runat="server" CssClass="lbl" Font-Bold="True" Text="Turma"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px">
                                    <asp:Label ID="Label59" runat="server" CssClass="lbl" Text="Curso:" Width="100px"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlCurso" runat="server" AutoPostBack="True" Width="98%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px">
                                    <asp:Label ID="Label52" runat="server" CssClass="lbl" Text="Turma:" Width="100px"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlTurma" runat="server" AutoPostBack="True" Width="98%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px">
                                    <asp:Label ID="Label15" runat="server" CssClass="lbl" Text="Inscritos:" Width="50px"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtTotalInscritos" runat="server" CssClass="txt-dis" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px">
                                    <asp:Label ID="Label16" runat="server" CssClass="lbl" Text="Vagas:" Width="80px"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtTotalVagas" runat="server" CssClass="txt-dis" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnSalvar" runat="server" CssClass="btn"  Text="Salvar" />
                                    &nbsp;&nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn" Text="Cancelar" />
                                </td>
                            </tr>
                        </table>

                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </table>
</asp:Content>
