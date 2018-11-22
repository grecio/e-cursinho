using Dal;
using Dto;
using System.Collections.Generic;

namespace BLL
{
    public class BpTurmaStatus
    {
        private readonly DbTurmaStatus dbTurmaStatus;

        public BpTurmaStatus()
        {
            dbTurmaStatus = new DbTurmaStatus();
        }
        public IEnumerable<TurmaStatusDto> Listar()
        {
            return dbTurmaStatus.Listar();
        }
    }
}
