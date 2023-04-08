
using Account.DTOs;
namespace Account.Repositories
{
    public class UserInMemoryRepository : UserRepository
    {


        private List<UserDTO> Users = new List<UserDTO>{};
        public UserDTO Create(UserDTO user) {
            this.Users.Add(user);
            System.Console.WriteLine("users: " + this.Users.Count);
            return user;
        }
    }
}

