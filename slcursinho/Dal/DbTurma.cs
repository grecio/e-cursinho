﻿using Dal.Properties;
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
    public class DbTurma
    {
        public IEnumerable<TurmaDto> Listar()
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Query<TurmaDto>("select turma.idturma, turma.idcurso, curso.curso, " +
                    "turmastatus.idturmastatus, turmastatus.turmastatus, turma.turma as descricao," +
                    "turma.datainicio, turma.datafim, " +
                    "turma.capacidade  from turma inner join curso on curso.idcurso = turma.idcurso " +
                    "inner join turmastatus on turmastatus.idturmastatus = turma.idturmastatus; ");
            }
        }

        public bool Salvar(Turma turma)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                if (turma.IdTurma > 0)
                {
                    return cnn.Execute("update turma set idcurso = @idcurso, " +
                        "idturmastatus = @idturmastatus, turma = @descricao, " +
                        "datainicio = @datainicio, datafim = @datafim, capacidade=@capacidade, " +
                        "dataupd=@dataExc, idusuarioupd=@idusuarioExc where idturma = @idturma", turma) > 0;
                }

                return cnn.Execute("insert into turma (idcurso, idturmastatus, turma, datainicio, datafim, " +
                                    "capacidade, datainc, idusuarioinc) " +
                                    "values (@idcurso, @idturmastatus, @descricao," +
                                    " @datainicio, @datafim, @capacidade, @dataexc, @idusuarioExc)", turma) > 0;
            }
        }

        public bool Excluir(long id)
        {
            using (var cnn = new MySqlConnection(Settings.Default.MySqlConnectionSetting))
            {
                return cnn.Execute("delete from turma where idturma = @idturma", new { idturma = id }) > 0;
            }
        }
    }
}
