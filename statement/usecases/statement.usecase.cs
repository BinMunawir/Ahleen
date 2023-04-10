
using Statement.Repositories;
using Statement.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Statement.Usecases
{
    public class StatementUsecases: StatementFacad
    {

        private StatementRepository repo;
        public StatementUsecases(StatementRepository repo) {
            this.repo = repo;
        }

        public StatementDTO RegisterStatement(StatementDTO statementDTO) {
            statementDTO.Guid = Guid.NewGuid().ToString();
            statementDTO.CreatedAt = DateTime.Now;

            statementDTO = this.repo.Create(statementDTO);
            return statementDTO;
        }

        public StatementDTO GetStatement(string guid) {
            StatementDTO statement = this.repo.Get(guid);
            return statement;
        }

        public List<StatementDTO> GetStatements() {
            List<StatementDTO> statements = this.repo.GetAll();
            return statements;
        }

    }
}