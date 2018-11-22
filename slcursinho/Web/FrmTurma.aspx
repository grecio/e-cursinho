<%@ Page Title="" Language="C#" MasterPageFile="~/Painel.Master" AutoEventWireup="true" CodeBehind="FrmTurma.aspx.cs" Inherits="Web.FrmTurma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="1" style="width: 92%">
        <tr>
            <td class="linha">
                <asp:Label ID="Label1" runat="server" CssClass="tit" Text="Acadêmico&gt;Turmas"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:GridView ID="grdList" runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="Grid" DataKeyNames="IdCurso" EmptyDataText="Nenhum registro encontrado" OnPageIndexChanging="grdList_PageIndexChanging" OnRowCommand="grdList_RowCommand" OnRowDataBound="grdList_RowDataBound">
                                        <AlternatingRowStyle CssClass="GridAltItem" />
                                        <Columns>
                                            <asp:BoundField DataField="descricao" HeaderText="Turma" SortExpression="descricao">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="datainicio" HeaderText="Início" SortExpression="datainicio" DataFormatString="{0:dd/MM/yyyy}">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="datafim" HeaderText="Término" SortExpression="datafim" DataFormatString="{0:dd/MM/yyyy}">
                                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="turmastatus" HeaderText="Status" >
                                             <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                             <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkbInstrutures" runat="server" CausesValidation="False" CommandName="Instrutores" Text="Instrutores" ForeColor="#6600FF"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="7%" />
                                            </asp:TemplateField>

                                             <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkbhorarios" runat="server" CausesValidation="False" CommandName="Horarios" Text="Horários" ForeColor="#6600FF"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="7%" />
                                            </asp:TemplateField>

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
                                    <asp:Button ID="btnNovo" runat="server" CssClass="btn" Text="Novo" OnClick="btnNovo_Click" />
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
                                <td>
                                    <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Turma*:" Width="100px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNome" runat="server" CssClass="txt" Width="555px" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px">
                                    <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Curso*:" Width="100px"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlCurso" runat="server" Width="565px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px">
                                    <asp:Label ID="Label18" runat="server" CssClass="lbl" Text="Status*:" Width="100px"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Data Início*:"></asp:Label>
                                </td>
                                <td>
                                    <table cellspacing="1" style="width: 100%">
                                        <tr>
                                            <td style="width: 1%;">
                                                <asp:TextBox ID="txtDataIni" runat="server" CssClass="txt mask-data" Width="80px"></asp:TextBox>
                                            </td>
                                            <td style="width: 1%;">
                                                <asp:Label ID="Label19" runat="server" CssClass="lbl" Text="Data Término*:" Width="80px"></asp:Label>
                                            </td>
                                            <td style="width: 1%;">
                                                <asp:TextBox ID="txtDataFim" runat="server" CssClass="txt mask-data" Width="80px"></asp:TextBox>
                                            </td>
                                            <td style="width: 1%;">
                                                <asp:Label ID="Label20" runat="server" CssClass="lbl" Text="Max. Alunos*:" Width="80px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCapacidade" runat="server" CssClass="txt mask-numero" Width="80px"></asp:TextBox>
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
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnSalvar" runat="server" CssClass="btn" OnClick="btnSalvar_Click" Text="Salvar" />
                                    &nbsp;&nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn" OnClick="btnCancelar_Click" Text="Cancelar" />
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
</asp:Content>
