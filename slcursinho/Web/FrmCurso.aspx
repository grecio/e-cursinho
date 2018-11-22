<%@ Page Title="" Language="C#" MasterPageFile="~/Painel.Master" AutoEventWireup="true" CodeBehind="FrmCurso.aspx.cs" Inherits="Web.FrmCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="1" style="width: 92%">
        <tr>
            <td class="linha">
                <asp:Label ID="Label1" runat="server" CssClass="tit" Text="Cursos"></asp:Label>
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
                                            <asp:BoundField DataField="curso" HeaderText="Curso" SortExpression="curso">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="descricao" HeaderText="Descrição" SortExpression="descricao">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ano" HeaderText="Ano" SortExpression="ano">
                                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" />
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
                                    <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Curso:*" Width="100px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNome" runat="server" CssClass="txt" Width="555px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px">
                                    <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Descrição*:" Width="100px"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtDescricao" runat="server" CssClass="txt" Width="555px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Ano*:"></asp:Label>
                                </td>
                                <td>
                                    <table cellspacing="1" style="width: 100%">
                                        <tr>
                                            <td style="width: 1%;">
                                                <asp:DropDownList ID="ddlAno" runat="server" Width="70px">
                                                    <asp:ListItem>2018</asp:ListItem>
                                                    <asp:ListItem>2019</asp:ListItem>
                                                    <asp:ListItem>2020</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 1%;">
                                                <asp:Label ID="Label15" runat="server" CssClass="lbl" Text="Valor*:" Width="50px"></asp:Label>
                                            </td>
                                            <td style="width: 1%;">
                                                <asp:TextBox ID="txtValor" runat="server" CssClass="txt mask-val" Width="70px"></asp:TextBox>
                                            </td>
                                            <td style="width: 1%">
                                                <asp:Label ID="Label16" runat="server" CssClass="lbl" Text="Horas:" Width="50px"></asp:Label>
                                            </td>
                                            <td style="width: 1%;">
                                                <asp:TextBox ID="txtHora" runat="server" CssClass="txt mask-numero" Width="70px"></asp:TextBox>
                                            </td>
                                            <td style="width: 1%">
                                                <asp:Label ID="Label17" runat="server" CssClass="lbl" Text="Parcelas:" Width="50px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtQtdParcela" runat="server" CssClass="txt mask-numero" Width="70px"></asp:TextBox>
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
