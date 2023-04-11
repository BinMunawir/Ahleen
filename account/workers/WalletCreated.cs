
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading;
using MassTransit;
using Newtonsoft.Json;
using events;
using Account.Repositories;
using Account.Usecases;
using Account.DTOs;

namespace events
{
    

public class WalletCreated
{
    public string UserID { get; set; }
}
}
class WalletCreatedConsumer : IConsumer<WalletCreated> {
        private UserRepository repo;
        private IBus bus;

        public WalletCreatedConsumer(UserRepository repo, IBus bus) {
            this.repo = repo;
            this.bus = bus;
        }
    public async Task Consume(ConsumeContext<WalletCreated> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"UserRegistered message: {jsonMessage}");


        var walletCreated = JsonConvert.DeserializeObject<WalletCreated>(jsonMessage);
        var userDTO = new AccountUsecases(this.repo).GetUser(walletCreated.UserID);
        userDTO.Status = "Active";
        
        new AccountUsecases(this.repo).UpdateProfile(walletCreated.UserID, userDTO);

    }
}