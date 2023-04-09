
using Account.DTOs;
namespace Account.Repositories
{
    public class UserInMemoryRepository : UserRepository
    {


        private List<UserDTO> Users = new List<UserDTO>{
            new UserDTO() with {Guid="6a3f922e-304f-4215-9816-08a1f2947e69"}
        };
        public UserDTO Create(UserDTO user) {
            this.Users.Add(user);
            System.Console.WriteLine(user);
            System.Console.WriteLine("users: " + this.Users.Count);
            return user;
        }

        public UserDTO Update(string guid, UserDTO user) {
            UserDTO oldUser = this.Get(guid);
            if (oldUser is null) throw new Exception("a user not exist");
            this.Users.Remove(oldUser);

            oldUser.FirstName = user.FirstName;
            oldUser.LastName = user.LastName;
            this.Users.Add(oldUser);
            return oldUser;
        }
        public UserDTO Get(string guid) {
            return this.Users.Where(u => u.Guid == guid).SingleOrDefault();
        }
    }
}

