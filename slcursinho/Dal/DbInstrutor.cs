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
    public class DbInstrutor
    {
        public IEnumerable<InstrutorDto> Listar()
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Query<InstrutorDto>("select * from instrutor order by 1 desc");
            }
        }

        public InstrutorDto Selecionar(long id)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.QueryFirstOrDefault<InstrutorDto>("select * from instrutor where idinstrutor = @idinstrutor",
                    new { idinstrutor = id });
            }
        }

        public bool Salvar(Instrutor instrutor)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                if (instrutor.IdInstrutor > 0)
                {
                    return cnn.Execute("update instrutor set instrutor = @nome, telefone = @telefone," +                      
                        "dataupd=@dataExc, idusuarioupd=@idusuario where idinstrutor = @idinstrutor", instrutor) > 0;
                }

                return cnn.Execute("insert into instrutor (instrutor, telefone, datainc, idusuarioinc) " +
                                    "values (@nome, @telefone, @dataexc, @idusuario)", instrutor) > 0;
            }
        }

        public bool Excluir(long id)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Execute("delete from instrutor where idinstrutor = @idinstrutor", new { idinstrutor = id }) > 0;
            }
        }
    }
}
