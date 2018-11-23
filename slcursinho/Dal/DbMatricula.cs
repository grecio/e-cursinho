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
    public class DbMatricula
    {

        public IEnumerable<MatriculaDto> Listar()
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Query<MatriculaDto>("select " +
                    "m.idmatricula, " +
                    "m.numero_matricula as numeromatricula,  " +
                    "m.idturma, " +
                    "t.turma, " +
                    "m.idaluno, " +
                    "a.nome as nomealuno" +
                    "from matricula m " +
                    "inner join aluno a on a.idaluno = m.idaluno " +
                    "inner join turma t on t.idturma = m.idturma " +
                    "order by a.nome");
            }
        }

        public bool Registrar()
        {

            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {

                cnn.Open();

                var afetadas = 0;

                using (var transaction = cnn.BeginTransaction())
                {

                    var idAluno = cnn.ExecuteScalar<long>("insert into aluno(nome, nascimento, idsexo, responsavel, " +
                        "responsavel_nascimento, responsavel_cpf, responsavel_rg) " +
                        "values(@nome, @nascimento, @idsexo, @nomeResponsavel, @responsavelNascimento, " +
                        "@responsavelCpf, @responsavelRg);  select LAST_INSERT_ID();");

                    var matricula_prefixo = cnn.ExecuteScalar<long>("select concat(c.ano, c.idcurso, '0', t.idturma) from turma t  " +
                        "inner join curso c on c.idcurso = t.idcurso " +
                        "where t.idturma = @idturma");


                    var matricula = string.Format("{0}{1}", matricula_prefixo.ToString(), idAluno.ToString());

                    var idMatricula = cnn.ExecuteScalar<long>("insert into matricula (numero_matricula, " +
                        "numero_contrato, idaluno, " +
                        "idturma, data, idusuarioinc, datainc) values (@numeroMatricula, @numeroContrato, " +
                        "@idturma, @data, @idusuarioExc, @dataExc); select LAST_INSERT_ID();");


                    cnn.Execute("insert into matricula_turma (idmatricula, idturma, " +
                        "idmatricula_turma_status, datainc, idusuarioinc)  values(@idmatricula, @idturma, 1, " +
                        "now(), @idusuarioExc)");
                
                    cnn.Execute("insert into aluno_endereco (idaluno_endereco_origem, " +
                        "cep, logradouro, bairro, " +
                        "cidade, iduf) values(@idaluno_endereco_origem, " +
                        "@cep, @logradouro," +
                        " @bairro, @cidade, @iduf)");

                    //cnn.Execute("delete from turma_horario where idturma = @id", new { id }, transaction);
                    //cnn.Execute("delete from turma_instrutor where idturma = @id", new { id }, transaction);
                    //afetadas = cnn.Execute("delete from turma where idturma = @id", new { id }, transaction);

                    transaction.Commit();
                }

                return afetadas > 0;
            }

        }

    }
}
