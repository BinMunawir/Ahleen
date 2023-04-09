
using Microsoft.AspNetCore.Mvc;
using Account.DTOs;
using Account.Repositories;
using Account.Usecases;

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
            return new AccountUsecases(this.repo).RegisterUser(userDTO);
        }

        [HttpGet("{guid}")]
        public ActionResult<UserDTO> GetUser(string guid) {
            UserDTO user = new AccountUsecases(this.repo).GetUser(guid);
            if (user is null) return NotFound();
            return user;
        }
        [HttpPut("{guid}")]
        public ActionResult<UserDTO> UpdateProfile(string guid, UserDTO userDTO) {
            UserDTO user;
            try
            {
            user = new AccountUsecases(this.repo).UpdateProfile(guid, userDTO);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
            return user;
        }
    }
}