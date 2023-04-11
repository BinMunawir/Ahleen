
using System.Text;
using Payment.DTOs;
using Payment.Repositories;
using Payment.Services;
using Payment.Usecases;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading;
using MassTransit;
using Newtonsoft.Json;
using events;

namespace events
{
    

public class UserRegistered
{
    public string UserID { get; set; }
}
}
class UserRegisteredConsumer : IConsumer<UserRegistered> {
        private WalletRepository repo;
        private PaymentGateway paymentGateway;
        private IBus bus;

        public UserRegisteredConsumer(WalletRepository repo, PaymentGateway paymentGateway, IBus bus) {
            this.repo = repo;
            this.paymentGateway = paymentGateway;
            this.bus = bus;
        }
    public async Task Consume(ConsumeContext<UserRegistered> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"UserRegistered message: {jsonMessage}");


        var walletDTO = JsonConvert.DeserializeObject<WalletDTO>(jsonMessage);
        await new PaymentUsecases(this.repo, this.paymentGateway).OpenWallet(walletDTO, bus);
    }
}