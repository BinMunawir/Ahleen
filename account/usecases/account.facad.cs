
using Account.DTOs;
using MassTransit;

namespace Account.Usecases {
    interface AccountFacad
    {
        public Task<UserDTO> RegisterUser(UserDTO userDTO, IBus bus); 
        public Task<UserDTO> UpdateProfile(string guid, UserDTO userDTO);
        public Task<UserDTO> GetUser(string guid);
        public Task<List<UserDTO>> GetUsers();
    }
}
