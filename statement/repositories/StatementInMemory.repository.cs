
using Statement.DTOs;
namespace Statement.Repositories
{
    public class StatementInMemoryRepository : StatementRepository
    {


        private List<StatementDTO> statements = new List<StatementDTO>{
            new StatementDTO() with {Guid="6a3f922e-304f-4215-9816-08a1f2947e68"}
        };
        public StatementDTO Create(StatementDTO statement) {
            this.statements.Add(statement);
            System.Console.WriteLine(statement);
            System.Console.WriteLine("Statements: " + this.statements.Count);
            return statement;
        }

        public StatementDTO Get(string guid) {
            return this.statements.Where(u => u.Guid == guid).SingleOrDefault();
        }

        public List<StatementDTO> GetAll()
        {
            return this.statements;
        }
    }
}

