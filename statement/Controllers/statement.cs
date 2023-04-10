
using Microsoft.AspNetCore.Mvc;
using Statement.DTOs;
using Statement.Repositories;
using Statement.Usecases;

namespace Statement.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class Statements : ControllerBase
    {

        private StatementRepository repo;
        public Statements(StatementRepository repo) {
            this.repo = repo;
        }

        [HttpPost]
        public ActionResult<StatementDTO> RegisterStatement(StatementDTO statement) {
            return new StatementUsecases(this.repo).RegisterStatement(statement);
        }

        [HttpGet("{guid}")]
        public ActionResult<StatementDTO> GetStatement(string guid) {
            StatementDTO user = new StatementUsecases(this.repo).GetStatement(guid);
            if (user is null) return NotFound();
            return user;
        }

        [HttpGet]
        public ActionResult<List<StatementDTO>> GetStatements() {
            List<StatementDTO> statements = new StatementUsecases(this.repo).GetStatements();
            return statements;
        }
    }
}