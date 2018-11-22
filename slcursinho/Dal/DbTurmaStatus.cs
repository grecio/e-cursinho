using Dal.Properties;
using Dapper;
using Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DbTurmaStatus
    {
        public IEnumerable<TurmaStatusDto> Listar()
        {

            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Query<TurmaStatusDto>("select * from turmastatus");
            }
        }
    }
}
