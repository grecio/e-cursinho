<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>

    <title>Menu</title>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <%
		
    Dim iMenus, iSubMenus
    Dim vetMenus(4, 1), vetSubMenus()
		
    vetMenus(0, 0) = "Acadêmico"
    Redim vetSubMenus(5, 2)
		
    vetSubMenus(0, 0) = "Alunos"
    vetSubMenus(0, 1) = "FrmAluno.aspx"

    vetSubMenus(1, 0) = "Instrutores"
    vetSubMenus(1, 1) = "FrmInstrutor.aspx"  

    vetSubMenus(2, 0) = "Cursos"
    vetSubMenus(2, 1) = "FrmCurso.aspx"
   
    vetSubMenus(3, 0) = "Turmas"
    vetSubMenus(3, 1) = "FrmTurma.aspx"
   
    vetSubMenus(4, 0) = "Matriculas"
    vetSubMenus(4, 1) = "FrmMatricula.aspx"

    vetMenus(0, 1) = vetSubMenus		

    vetMenus(1, 0) = "Administrativo"
		
    Redim vetSubMenus(2, 2)

    vetSubMenus(0, 0) = "Usuários"
    vetSubMenus(0, 1) = "FrmUsuario.aspx"

    vetSubMenus(1, 0) = "Grupos de Usuários"
    vetSubMenus(1, 1) = "FrmGrupoUsuario.aspx"

    vetSubMenus(2, 0) = "Permissões de Acesso"
    vetSubMenus(2, 1) = "FrmPermissao.aspx"
		                   				  
    vetMenus(1, 1) = vetSubMenus
		
    vetMenus(2, 0) = "Financeiro"
		
    Redim vetSubMenus(1, 2)		

    vetSubMenus(0, 0) = "Contas a pagar"
    vetSubMenus(0, 1) = "FrmContasPagar.aspx"
	
    vetSubMenus(1, 0) = "Contas a receber"
    vetSubMenus(1, 1) = "FrmContasReceber.aspx"
	
        
    vetMenus(2, 1) = vetSubMenus
	
    vetMenus(3, 0) = "Relat&oacute;rios"

    Redim vetSubMenus(2, 2)

    vetSubMenus(0, 0) = "Alunos"
    vetSubMenus(0, 1) = "FrmRptAluno.aspx"

    vetSubMenus(1, 0) = "Receita"
    vetSubMenus(1, 1) = "FrmRptReceita.aspx"

    vetSubMenus(2, 0) = "Despesa"
    vetSubMenus(2, 1) = "FrmRptDespesa.aspx"

    vetMenus(3, 1) = vetSubMenus

    vetMenus(4, 0) = "Sistema"

    Redim vetSubMenus(0, 2)

    vetSubMenus(0, 0) = "Sair"
    vetSubMenus(0, 1) = "logout.aspx"

    vetMenus(4, 1) = vetSubMenus


    %>

    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="stylesheet" href="Content/menu.css" type="text/css">
    <script type="text/javascript">

        function Ocultar() {
            document.getElementById('menu').style.display = "none";
            document.getElementById('seta').innerHTML = "<strong>&raquo;</strong>"

            document.getElementById('seta').onmousedown = Apresentar;

            window.parent.document.getElementById('estrutura2').cols = '20, *';

            return;
        }

        function Apresentar() {
            window.parent.document.getElementById('estrutura2').cols = '220, *';

            document.getElementById('menu').style.display = "block";
            document.getElementById('seta').innerHTML = "<strong>&laquo;</strong>"

            seta.onmousedown = Ocultar;

            return;
        }

        var intMenuSel = 0;

        function ClickMenu(oMenu, oSubMenu) {

            oSubMenu = document.getElementById(oSubMenu);

            if (oSubMenu.style.display != '') {
                oSubMenu.style.display = '';
            }
            else {
                oSubMenu.style.display = 'none';
            }

            return (false);
        }

    </script>
</head>
<body>
    <table style="background-color: #f1f1f1; height: 100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td valign="top" id="celula_menu">
                <ul id="menu">
                    <% For iMenus = 0 To UBound(vetMenus) %>
                    <li class="ItemMenu">
                        <a href="#" onclick="javascript:ClickMenu(this, 'SubMenu<%=iMenus%>')" style="font-weight: bold;">
                            <%=vetMenus(iMenus, 0)%>
                        </a>
                        <ul class="SubMenu" id="SubMenu<%=iMenus%>" style="display: none">
                            <% For iSubMenus = 0 To UBound(vetMenus(iMenus, 1)) %>
                            <% strTarget = CStr(vetMenus(iMenus, 1)(iSubMenus, 2)) %>
                            <%	If strTarget = "" Then %>
                            <%		strTarget = "principal" %>
                            <%	End If %>
                            <li>
                                <a href="<%=vetMenus(iMenus, 1)(iSubMenus, 1)%>" target="<%=strTarget%>">
                                    <%=vetMenus(iMenus, 1)(iSubMenus, 0)%>
                                </a>
                                <% Next %>
                            </li>
                        </ul>
                        <% Next %>
                    </li>
                </ul>
            </td>
            <td id="celula_seta">
                <a href="#" onclick="javascript:Ocultar()" id="seta"><strong>&laquo;</strong></a>
            </td>
        </tr>
    </table>
</body>
</html>
