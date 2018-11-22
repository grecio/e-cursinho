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
    public class DbTurmaInstrutor
    {
        public IEnumerable<TurmaInstrutorDto> Listar(long idturma)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Query<TurmaInstrutorDto>("select " +
                    "ti.idturma_instrutor as idturmainstrutor," +
                    "ti.idturma,  " +
                    "ti.idinstrutor, " +
                    "i.instrutor as nomeinstrutor " +
                    "from turma_instrutor ti inner join instrutor i on i.idinstrutor = ti.idinstrutor  " +
                    "where ti.idturma = @idturma", new {idturma =  idturma });

            }


        }

        public bool Inserir(TurmaInstrutor model)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Execute("insert into turma_instrutor (idturma, idinstrutor) values (@idturma, @idinstrutor)", model) > 0;
            }
        }

        public bool Remover(long id)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Execute("delete from turma_instrutor where idturma_instrutor = @id", new {id =  id }) > 0;
            }
        }
    }
}
