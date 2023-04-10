
using Statement.DTOs;

namespace Statement.Repositories
{
    public interface StatementRepository
    {

       public StatementDTO Create(StatementDTO statement);
       public StatementDTO Get(string guid);
       public List<StatementDTO> GetAll();

    }
}