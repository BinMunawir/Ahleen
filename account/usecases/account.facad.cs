
using Account.DTOs;


namespace Account.Usecases {
    interface AccountFacad
    {
        public UserDTO RegisterUser(UserDTO userDTO); 
        public UserDTO UpdateProfile(string guid, UserDTO userDTO);
        public UserDTO GetUser(string guid);
    }
}
