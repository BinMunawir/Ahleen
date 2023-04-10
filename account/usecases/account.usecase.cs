
using Account.Repositories;
using Account.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Account.Usecases
{
    public class AccountUsecases: AccountFacad
    {

        private UserRepository repo;
        public AccountUsecases(UserRepository repo) {
            this.repo = repo;
        }

        public async Task<UserDTO> RegisterUserAsync(UserDTO userDTO)
        {
            userDTO.Guid = Guid.NewGuid().ToString();
            userDTO.IsActive = true;
            userDTO.CreatedAt = DateTime.Now;
            userDTO.Status = "pending";

            await createWallet(userDTO);

            userDTO.Status = "Active";
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
        public List<UserDTO> GetUsers() {
            return this.repo.GetAll();
        }

        private static async Task createWallet(UserDTO userDTO)
            {
                var client = new HttpClient();
                var body = new Dictionary<string, Object>();
                body.Add("UserID", userDTO.Guid);
                var request = await client.PostAsync(
                    new Uri("http://payment:18082/api/wallets"),
                    new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
                );
                string resultContent = await request.Content.ReadAsStringAsync();
                if ((int)request.StatusCode > 299) throw new Exception("couldn't make the wallet>>>\n " + resultContent);
            }

    }
}