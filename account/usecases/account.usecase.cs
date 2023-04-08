
using Account.DTOs;
namespace Account.Usecases
{
    public class AccountUsecases: AccountFacad
    {
        public UserDTO RegisterUser(UserDTO userDTO) {
            System.Console.WriteLine("hi");
            return userDTO;
        }
        
    }
}