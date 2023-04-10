
using Account.DTOs;

namespace Account.Repositories
{
    public interface UserRepository
    {

       public UserDTO Create(UserDTO user);
       public UserDTO Update(string guid, UserDTO user);
       public UserDTO Get(string guid);
       public List<UserDTO> GetAll();

    }
}