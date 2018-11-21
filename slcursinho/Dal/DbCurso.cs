using Dal.Properties;
using Dapper;
using Domain;
using Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DbCurso
    {
        public IEnumerable<CursoDto> Listar()
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Query<CursoDto>("select * from curso order by 1 desc");
            }
        }

        public CursoDto Selecionar(long id)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.QueryFirstOrDefault<CursoDto>("select * from curso where idcurso = @idcurso",
                    new { idcurso = id });
            }
        }

        public bool Salvar(Curso curso)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                if (curso.IdCurso > 0)
                {
                    return cnn.Execute("update curso set curso = @nome, descricao = @descricao, ano = @ano, " +
                        "valor = @valor, horas = @horas, parcelas=@parcelas, " +
                        "dataupd=@dataExc, idusuarioupd=@idusuario where idcurso = @idcurso", curso) > 0;
                }

                return cnn.Execute("insert into curso (curso, descricao, ano, valor, horas, parcelas, datainc, idusuarioinc) " +
                                    "values (@nome, @descricao, @ano, @valor, @horas, @parcelas, @dataexc, @idusuario)", curso) > 0;
            }
        }

        public bool Excluir(long id)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Execute("delete from curso where idcurso = @idcurso", new { idcurso = id }) > 0;
            }
        }
    }
}
