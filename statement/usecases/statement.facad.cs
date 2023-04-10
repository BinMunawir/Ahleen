
using Statement.DTOs;


namespace Statement.Usecases {
    interface StatementFacad
    {
        public StatementDTO RegisterStatement(StatementDTO statementDTO); 
        public StatementDTO GetStatement(string guid);
        public List<StatementDTO> GetStatements();
    }
}
