using Dal;
using Domain;
using Dto;
using Framework.Concerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BpUsuario
    {
        private readonly DbUsuario dbUsuario;


        public BpUsuario()
        {
            dbUsuario = new DbUsuario();
        }

        public IEnumerable<UsuarioDto> EfetuarLogin(string login, string senha)
        {
            Validador.Validar(!string.IsNullOrWhiteSpace(login), "Informe o login.");
            Validador.Validar(!string.IsNullOrWhiteSpace(senha), "Informe a senha.");

            return dbUsuario.EfetuarLogin(login, senha);
        }

        public IEnumerable<UsuarioDto> Listar()
        {
            return dbUsuario.Listar();
        }

        public UsuarioDto Selecionar(long id)
        {
            Validador.Validar(id > 0, "Informe o usuário.");

            return dbUsuario.Selecionar(id);
        }

        public bool Salvar(Usuario usuario)
        {
            Validador.Validar(!string.IsNullOrWhiteSpace(usuario.Nome), "Informe o nome.");
            Validador.Validar(!string.IsNullOrWhiteSpace(usuario.Login), "Informe o login.");
            Validador.Validar(!string.IsNullOrWhiteSpace(usuario.Senha), "Informe a senha.");

            return dbUsuario.Salvar(usuario);
        }

        public bool Excluir(long id)
        {
            Validador.Validar(id > 0, "Informe o usuário.");
            return dbUsuario.Excluir(id);
        }
    }
}
