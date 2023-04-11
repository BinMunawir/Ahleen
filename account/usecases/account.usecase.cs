
using Account.Repositories;
using Account.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;
using MassTransit;
using events;

namespace Account.Usecases
{
    public class AccountUsecases: AccountFacad
    {

        private UserRepository repo;
        public AccountUsecases(UserRepository repo) {
            this.repo = repo;
        }

        public async Task<UserDTO> RegisterUser(UserDTO userDTO, IBus bus)
        {
            userDTO.Guid = Guid.NewGuid().ToString();
            userDTO.IsActive = true;
            userDTO.CreatedAt = DateTime.Now;
            userDTO.Status = "pending";

            await createWallet(userDTO, bus);

            userDTO = await this.repo.Create(userDTO);
            return userDTO;
        }

       
        public async Task<UserDTO> UpdateProfile(string guid, UserDTO userDTO) {
            
            UserDTO user = await this.repo.Update(guid, userDTO);
            return user;

        }
        public async Task<UserDTO> GetUser(string guid) {
            UserDTO user = await this.repo.Get(guid);
            return user;
        }
        public async Task<List<UserDTO>> GetUsers() {
            return (await this.repo.GetAll());
        }

        private static async Task createWallet(UserDTO userDTO, IBus bus)
            {
                await (await bus.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/RegisteredUsers"))).Send(new UserRegistered(){UserID=userDTO.Guid});
            }

    }
}