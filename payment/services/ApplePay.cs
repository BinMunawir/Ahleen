
using Payment.DTOs;
using Payment.Services;
namespace Payment.Services
{
    public class ApplePay : PaymentGateway
    {
        public WalletDTO TopUpWallet(WalletDTO wallet, int amount)
        {
            wallet.Amount += amount; // اسهل من كدا مفيش
            return wallet;
        }
    }
}