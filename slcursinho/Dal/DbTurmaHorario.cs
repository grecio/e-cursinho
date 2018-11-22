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
    public class DbTurmaHorario
    {
        public IEnumerable<TurmaHorarioDto> Listar(long idturma)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Query<TurmaHorarioDto>("select th.idturma_horario as idturmahorario, " +
                    "th.idturma, " +
                    "dia, " +
                    "hora_entrada as horaentrada, " +
                    "hora_saida as horasaida " +
                    "from turma_horario  th " +
                    "inner join turma t on t.idturma = th.idturma " +
                    "where th.idturma = @idturma ", new { idturma });

            }


        }

        public bool Inserir(TurmaHorario model)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Execute("insert into turma_horario (idturma, dia, hora_entrada, hora_saida) values (@idturma, @dia, @horaentrada, @horasaida)", model) > 0;
            }
        }

        public bool Remover(long id)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Execute("delete from turma_horario where idturma_horario = @id", new { id = id }) > 0;
            }
        }
    }
}
