
using Microsoft.AspNetCore.Mvc;
using Account.DTOs;
using Account.Repositories;

namespace Account.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Account : ControllerBase
    {

        private UserRepository repo;
        public Account(UserRepository repo) {
            this.repo = repo;
        }


        [HttpPost]
        public ActionResult<UserDTO> RegisterUser(UserDTO userDTO) {
            UserDTO user = repo.Create(userDTO);
            return user;
        }
    }
}