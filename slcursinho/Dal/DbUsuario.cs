using Dal.Properties;
using Dapper;
using Domain;
using Dto;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;

namespace Dal
{
    public class DbUsuario
    {
        public IEnumerable<UsuarioDto> EfetuarLogin(string _login, string _senha)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Query<UsuarioDto>("select * from usuario where login = @login and senha = @senha",
                    new { login = _login, senha = _senha });
            }
        }

        public IEnumerable<UsuarioDto> Listar()
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Query<UsuarioDto>("select * from usuario order by 1 desc");
            }
        }

        public UsuarioDto Selecionar(long id)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.QueryFirstOrDefault<UsuarioDto>("select * from usuario where idusuario = @idusuario",
                    new { idusuario = id });
            }
        }

        public bool Salvar(Usuario usuario)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                if (usuario.IdUsuario > 0)
                {
                    return cnn.Execute("update usuario set (nome, login, senha) values (@nome, @login, @senha) where idusuario = @idusuario") > 0;
                }

                return cnn.Execute("insert into usuario (nome, login, senha) values (@nome, @login, @senha)", usuario) > 0;
            }
        }

        public bool Excluir(long id)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                
                return cnn.Execute("delete from usuario where idusuario = @idusuario", new { idusuario = id }) > 0;
            }
        }

    }
}
