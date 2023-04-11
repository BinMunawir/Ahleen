
using Account.DTOs;

namespace Account.Repositories
{
    public interface UserRepository
    {

       public Task<UserDTO> Create(UserDTO user);
       public Task<UserDTO> Update(string guid, UserDTO user);
       public Task<UserDTO> Get(string guid);
       public Task<List<UserDTO>> GetAll();

    }
}