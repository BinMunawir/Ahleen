
using Account.Repositories;
using Account.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Account.Usecases
{
    public class AccountUsecases: AccountFacad
    {

        private UserRepository repo;
        public AccountUsecases(UserRepository repo) {
            this.repo = repo;
        }

        public UserDTO RegisterUser(UserDTO userDTO) {
            userDTO.Guid = Guid.NewGuid().ToString();
            userDTO.IsActive = true;
            userDTO.CreatedAt = DateTime.Now;
            userDTO.Status = "pending";

            userDTO = this.repo.Create(userDTO);
            return userDTO;
        }

        public UserDTO UpdateProfile(string guid, UserDTO userDTO) {
            
            UserDTO user = this.repo.Update(guid, userDTO);
            return user;

        }
        public UserDTO GetUser(string guid) {
            UserDTO user = this.repo.Get(guid);
            return user;
        }

    }
}