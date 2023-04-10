
using Microsoft.AspNetCore.Mvc;
using Account.DTOs;
using Account.Repositories;
using Account.Usecases;

namespace Account.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class Accounts : ControllerBase
    {

        private UserRepository repo;
        public Accounts(UserRepository repo) {
            this.repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> RegisterUserAsync(UserDTO userDTO) {
            return await new AccountUsecases(this.repo).RegisterUserAsync(userDTO);
        }
        [HttpGet]
        public ActionResult<List<UserDTO>> GetWallets() {
            List<UserDTO> users = new AccountUsecases(this.repo).GetUsers();
            return users;
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