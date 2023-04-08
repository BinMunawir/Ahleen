
using Account.DTOs;

namespace Account.Repositories
{
    public interface UserRepository
    {
        // IEnumerable<Command> GetAllCommands();

       public UserDTO Create(UserDTO user);
    }
}