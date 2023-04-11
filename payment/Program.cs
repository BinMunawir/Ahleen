
using MassTransit;
using Payment.Repositories;
using Payment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var walletInMemoryRepository = new WalletInMemoryRepository();
builder.Services.AddSingleton<WalletRepository>(walletInMemoryRepository);
var applePay = new ApplePay();
builder.Services.AddSingleton<PaymentGateway>(applePay);

builder.Services.AddMassTransit(x =>
{
                x.AddConsumer<UserRegisteredConsumer>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cur =>
                {
                    cur.Host(new Uri("rabbitmq://rabbitmq"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cur.ReceiveEndpoint("RegisteredUsers", oq =>
                    {
                        oq.PrefetchCount = 20;
                        oq.UseMessageRetry(r => r.Interval(2, 100));
                        oq.ConfigureConsumer<UserRegisteredConsumer>(provider);
                    });
                }));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
